// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WebpWrapper;

/// <summary>
/// Wrapper for WebP format.
/// </summary>
[SuppressMessage("Interoperability", "CA1416")]
public sealed class WebP : IDisposable
{
    private const int WEBP_MAX_DIMENSION = 16383;

    private UnsafeNativeMethods.WebPMemoryWrite? OnCallback;

    /// <summary>This function will initialize the configuration according to a predefined set of parameters (referred to by 'preset') and a given quality factor</summary>
    /// <param name="config">The WebPConfig structure</param>
    /// <param name="preset">Type of image</param>
    /// <param name="quality">Quality of compression</param>
    /// <returns>0 if error</returns>
    public int WebPConfigInit(ref WebPConfig config, WebPPreset preset, float quality)
    {
        return UnsafeNativeMethods.WebPConfigInit(ref config, preset, quality);
    }

    /// <summary>Read a WebP file</summary>
    /// <param name="pathFileName">WebP file to load</param>
    /// <returns>Bitmap with the WebP image</returns>
    public Bitmap Load(string pathFileName)
    {
        try
        {
            var rawWebP = File.ReadAllBytes(pathFileName);

            return Decode(rawWebP);
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowLoadException(ex.Message);
            return null;
        }
    }

    /// <summary>Decode a WebP image</summary>
    /// <param name="rawWebP">The data to uncompress</param>
    /// <returns>Bitmap with the WebP image</returns>
    public unsafe Bitmap Decode(byte[] rawWebP)
    {
        fixed (byte* pinnedWebP = rawWebP)
        {
            Bitmap? bmp = null;
            BitmapData? bmpData = null;

            try
            {
                //Get image width and height
                GetInfo(rawWebP, out var imgWidth, out var imgHeight, out var hasAlpha, out _, out _);

                //Create a BitmapData and Lock all pixels to be written
                bmp = hasAlpha
                    ? new Bitmap(imgWidth, imgHeight, PixelFormat.Format32bppArgb)
                    : new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb);
                bmpData = bmp.LockBits(new Rectangle(0, 0, imgWidth, imgHeight), ImageLockMode.WriteOnly, bmp.PixelFormat);

                //Uncompress the image
                var outputSize = bmpData.Stride * imgHeight;
                if (bmp.PixelFormat == PixelFormat.Format24bppRgb)
                    UnsafeNativeMethods.WebPDecodeBGRInto((IntPtr) pinnedWebP, rawWebP.Length, bmpData.Scan0, outputSize, bmpData.Stride);
                else
                    UnsafeNativeMethods.WebPDecodeBGRAInto((IntPtr) pinnedWebP, rawWebP.Length, bmpData.Scan0, outputSize, bmpData.Stride);

                return bmp;
            }
            finally
            {
                //Unlock the pixels
                if (bmpData != null) bmp?.UnlockBits(bmpData);
            }
        }
    }

    /// <summary>Decode a WebP image</summary>
    /// <param name="rawWebP">the data to uncompress</param>
    /// <param name="options">Options for advanced decode</param>
    /// <returns>Bitmap with the WebP image</returns>
    public Bitmap Decode(byte[] rawWebP, WebPDecoderOptions options)
    {
        var pinnedWebP = GCHandle.Alloc(rawWebP, GCHandleType.Pinned);
        Bitmap? bmp = null;
        BitmapData? bmpData = null;
        try
        {
            WebPDecoderConfig config = default;
            if (UnsafeNativeMethods.WebPInitDecoderConfig(ref config) == 0)
            {
                ThrowHelper.ThrowInitDecoderConfigException();
            }

            // Read the .webp input file information
            var ptrRawWebP = pinnedWebP.AddrOfPinnedObject();
            int height;
            int width;
            VP8StatusCode result;
            if (options.use_scaling == 0)
            {
                result = UnsafeNativeMethods.WebPGetFeatures(ptrRawWebP, rawWebP.Length, ref config.input);
                if (result != VP8StatusCode.VP8_STATUS_OK) ThrowHelper.ThrowGetFeaturesException(result);

                //Test cropping values
                if (options.use_cropping == 1)
                {
                    if (options.crop_left + options.crop_width > config.input.Width || options.crop_top + options.crop_height > config.input.Height)
                        ThrowHelper.ThrowCropException();
                    width = options.crop_width;
                    height = options.crop_height;
                }
            }
            else
            {
                width = options.scaled_width;
                height = options.scaled_height;
            }

            config.options.bypass_filtering = options.bypass_filtering;
            config.options.no_fancy_upsampling = options.no_fancy_upsampling;
            config.options.use_cropping = options.use_cropping;
            config.options.crop_left = options.crop_left;
            config.options.crop_top = options.crop_top;
            config.options.crop_width = options.crop_width;
            config.options.crop_height = options.crop_height;
            config.options.use_scaling = options.use_scaling;
            config.options.scaled_width = options.scaled_width;
            config.options.scaled_height = options.scaled_height;
            config.options.use_threads = options.use_threads;
            config.options.dithering_strength = options.dithering_strength;
            config.options.flip = options.flip;
            config.options.alpha_dithering_strength = options.alpha_dithering_strength;

            //Create a BitmapData and Lock all pixels to be written
            if (config.input.Has_alpha == 1)
            {
                config.output.colorspace = WEBP_CSP_MODE.MODE_bgrA;
                bmp = new Bitmap(config.input.Width, config.input.Height, PixelFormat.Format32bppArgb);
            }
            else
            {
                config.output.colorspace = WEBP_CSP_MODE.MODE_BGR;
                bmp = new Bitmap(config.input.Width, config.input.Height, PixelFormat.Format24bppRgb);
            }

            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // Specify the output format
            config.output.u.RGBA.rgba = bmpData.Scan0;
            config.output.u.RGBA.stride = bmpData.Stride;
            config.output.u.RGBA.size = (UIntPtr) (bmp.Height * bmpData.Stride);
            config.output.height = bmp.Height;
            config.output.width = bmp.Width;
            config.output.is_external_memory = 1;

            // Decode
            result = UnsafeNativeMethods.WebPDecode(ptrRawWebP, rawWebP.Length, ref config);
            if (result != VP8StatusCode.VP8_STATUS_OK) ThrowHelper.ThrowGetFeaturesException(result);

            UnsafeNativeMethods.WebPFreeDecBuffer(ref config.output);

            return bmp;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowDecodeException(ex.Message);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (bmpData != null) bmp?.UnlockBits(bmpData);

            //Free memory
            if (pinnedWebP.IsAllocated) pinnedWebP.Free();
        }
    }

    /// <summary>Get Thumbnail from webP in mode faster/low quality</summary>
    /// <param name="rawWebP">The data to uncompress</param>
    /// <param name="width">Wanted width of thumbnail</param>
    /// <param name="height">Wanted height of thumbnail</param>
    /// <returns>Bitmap with the WebP thumbnail in 24bpp</returns>
    public Bitmap GetThumbnailFast(byte[] rawWebP, int width, int height)
    {
        var pinnedWebP = GCHandle.Alloc(rawWebP, GCHandleType.Pinned);
        Bitmap? bmp = null;
        BitmapData? bmpData = null;

        try
        {
            WebPDecoderConfig config = default;
            if (UnsafeNativeMethods.WebPInitDecoderConfig(ref config) == 0)
                ThrowHelper.ThrowInitDecoderConfigException();

            // Set up decode options
            config.options.bypass_filtering = 1;
            config.options.no_fancy_upsampling = 1;
            config.options.use_threads = 1;
            config.options.use_scaling = 1;
            config.options.scaled_width = width;
            config.options.scaled_height = height;

            // Create a BitmapData and Lock all pixels to be written
            bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // Specify the output format
            config.output.colorspace = WEBP_CSP_MODE.MODE_BGR;
            config.output.u.RGBA.rgba = bmpData.Scan0;
            config.output.u.RGBA.stride = bmpData.Stride;
            config.output.u.RGBA.size = (UIntPtr) (height * bmpData.Stride);
            config.output.height = height;
            config.output.width = width;
            config.output.is_external_memory = 1;

            // Decode
            var ptrRawWebP = pinnedWebP.AddrOfPinnedObject();
            var result = UnsafeNativeMethods.WebPDecode(ptrRawWebP, rawWebP.Length, ref config);
            if (result != VP8StatusCode.VP8_STATUS_OK) ThrowHelper.ThrowGetFeaturesException(result);

            UnsafeNativeMethods.WebPFreeDecBuffer(ref config.output);

            return bmp;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowThumbnailException(ex.Message);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (bmpData != null) bmp?.UnlockBits(bmpData);

            //Free memory
            if (pinnedWebP.IsAllocated) pinnedWebP.Free();
        }
    }

    /// <summary>Thumbnail from webP in mode slow/high quality</summary>
    /// <param name="rawWebP">The data to uncompress</param>
    /// <param name="width">Wanted width of thumbnail</param>
    /// <param name="height">Wanted height of thumbnail</param>
    /// <returns>Bitmap with the WebP thumbnail</returns>
    public Bitmap GetThumbnailQuality(byte[] rawWebP, int width, int height)
    {
        var pinnedWebP = GCHandle.Alloc(rawWebP, GCHandleType.Pinned);
        Bitmap? bmp = null;
        BitmapData? bmpData = null;

        try
        {
            WebPDecoderConfig config = default;
            if (UnsafeNativeMethods.WebPInitDecoderConfig(ref config) == 0)
                ThrowHelper.ThrowInitDecoderConfigException();

            var ptrRawWebP = pinnedWebP.AddrOfPinnedObject();
            var result = UnsafeNativeMethods.WebPGetFeatures(ptrRawWebP, rawWebP.Length, ref config.input);
            if (result != VP8StatusCode.VP8_STATUS_OK) ThrowHelper.ThrowGetFeaturesException(result);

            // Set up decode options
            config.options.bypass_filtering = 0;
            config.options.no_fancy_upsampling = 0;
            config.options.use_threads = 1;
            config.options.use_scaling = 1;
            config.options.scaled_width = width;
            config.options.scaled_height = height;

            //Create a BitmapData and Lock all pixels to be written
            if (config.input.Has_alpha == 1)
            {
                config.output.colorspace = WEBP_CSP_MODE.MODE_bgrA;
                bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            }
            else
            {
                config.output.colorspace = WEBP_CSP_MODE.MODE_BGR;
                bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            }

            bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // Specify the output format
            config.output.u.RGBA.rgba = bmpData.Scan0;
            config.output.u.RGBA.stride = bmpData.Stride;
            config.output.u.RGBA.size = (UIntPtr) (height * bmpData.Stride);
            config.output.height = height;
            config.output.width = width;
            config.output.is_external_memory = 1;

            // Decode
            result = UnsafeNativeMethods.WebPDecode(ptrRawWebP, rawWebP.Length, ref config);
            if (result != VP8StatusCode.VP8_STATUS_OK) ThrowHelper.ThrowGetFeaturesException(result);

            UnsafeNativeMethods.WebPFreeDecBuffer(ref config.output);

            return bmp;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowThumbnailException(ex.Message);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (bmpData != null) bmp?.UnlockBits(bmpData);

            //Free memory
            if (pinnedWebP.IsAllocated) pinnedWebP.Free();
        }
    }

    /// <summary>Save bitmap to file in WebP format</summary>
    /// <param name="bmp">Bitmap with the WebP image</param>
    /// <param name="pathFileName">The file to write</param>
    /// <param name="quality">Between 0 (lower quality, lowest file size) and 100 (highest quality, higher file size)</param>
    public void Save(Bitmap bmp, string pathFileName, int quality = 75)
    {
        try
        {
            //Encode in webP format
            var rawWebP = EncodeLossy(bmp, quality);

            //Write webP file
            File.WriteAllBytes(pathFileName, rawWebP);
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowSaveException(ex.Message);
        }
    }

    /// <summary>Lossy encoding bitmap to WebP (Simple encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="quality">Between 0 (lower quality, lowest file size) and 100 (highest quality, higher file size)</param>
    /// <returns>Compressed data</returns>
    public byte[] EncodeLossy(Bitmap bmp, int quality = 75)
    {
        //test bmp
        if (bmp.Width == 0 || bmp.Height == 0) ThrowHelper.ThrowBitmapNoDataException(nameof(bmp));
        if (bmp.Width > WEBP_MAX_DIMENSION || bmp.Height > WEBP_MAX_DIMENSION) ThrowHelper.ThrowBitmapDimensionException(WEBP_MAX_DIMENSION);
        if (bmp.PixelFormat != PixelFormat.Format24bppRgb && bmp.PixelFormat != PixelFormat.Format32bppArgb) ThrowHelper.ThrowBitmapPixelFormatException();

        BitmapData? bmpData = null;
        var unmanagedData = IntPtr.Zero;

        try
        {
            //Get bmp data
            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);

            //Compress the bmp data
            var size = bmp.PixelFormat == PixelFormat.Format24bppRgb
                ? UnsafeNativeMethods.WebPEncodeBGR(bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, quality, out unmanagedData)
                : UnsafeNativeMethods.WebPEncodeBGRA(bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, quality, out unmanagedData);

            if (size == 0)
                ThrowHelper.ThrowEncodeException();

            //Copy image compress data to output array
            var rawWebP = GC.AllocateUninitializedArray<byte>(size);
            Marshal.Copy(unmanagedData, rawWebP, 0, size);

            return rawWebP;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowEncodeLosslyException(ex.Message);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (bmpData != null) bmp.UnlockBits(bmpData);

            //Free memory
            if (unmanagedData != IntPtr.Zero) UnsafeNativeMethods.WebPFree(unmanagedData);
        }
    }

    /// <summary>Lossy encoding bitmap to WebP (Advanced encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="quality">Between 0 (lower quality, lowest file size) and 100 (highest quality, higher file size)</param>
    /// <param name="speed">Between 0 (fastest, lowest compression) and 9 (slower, best compression)</param>
    /// <param name="info">True if need encode info.</param>
    /// <returns>Compressed data</returns>
    public byte[] EncodeLossy(Bitmap bmp, int quality, int speed, bool info = false)
    {
        //Initialize configuration structure
        var config = new WebPConfig();

        //Set compression parameters
        if (UnsafeNativeMethods.WebPConfigInit(ref config, WebPPreset.WEBP_PRESET_DEFAULT, 75) == 0) ThrowHelper.ThrowConfigurePresetException();

        // Add additional tuning:
        config.method = speed;
        if (config.method > 6)
            config.method = 6;
        config.quality = quality;
        config.autofilter = 1;
        config.pass = speed + 1;
        config.segments = 4;
        config.partitions = 3;
        config.thread_level = 1;
        config.alpha_quality = quality;
        config.alpha_filtering = 2;
        config.use_sharp_yuv = 1;

        if (UnsafeNativeMethods.WebPGetDecoderVersion() > 1082) //Old version does not support preprocessing 4
        {
            config.preprocessing = 4;
            config.use_sharp_yuv = 1;
        }
        else
            config.preprocessing = 3;

        return AdvancedEncode(bmp, config, info);
    }

    /// <summary>Lossy encoding bitmap to WebP (Advanced encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="config">Configuration for encode</param>
    /// <param name="info">True if need encode info.</param>
    /// <returns>Compressed data</returns>
    public byte[] EncodeLossy(Bitmap bmp, WebPConfig config, bool info = false)
    {
        return AdvancedEncode(bmp, config, info);
    }

    /// <summary>Lossless encoding bitmap to WebP (Simple encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <returns>Compressed data</returns>
    public byte[] EncodeLossless(Bitmap bmp)
    {
        //test bmp
        if (bmp.Width == 0 || bmp.Height == 0) ThrowHelper.ThrowBitmapNoDataException(nameof(bmp));
        if (bmp.Width > WEBP_MAX_DIMENSION || bmp.Height > WEBP_MAX_DIMENSION) ThrowHelper.ThrowBitmapDimensionException(WEBP_MAX_DIMENSION);
        if (bmp.PixelFormat != PixelFormat.Format24bppRgb && bmp.PixelFormat != PixelFormat.Format32bppArgb) ThrowHelper.ThrowBitmapPixelFormatException();

        BitmapData? bmpData = null;
        var unmanagedData = IntPtr.Zero;
        try
        {
            //Get bmp data
            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);

            //Compress the bmp data
            var size = bmp.PixelFormat == PixelFormat.Format24bppRgb
                ? UnsafeNativeMethods.WebPEncodeLosslessBGR(bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, out unmanagedData)
                : UnsafeNativeMethods.WebPEncodeLosslessBGRA(bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, out unmanagedData);

            //Copy image compress data to output array
            var rawWebP = GC.AllocateUninitializedArray<byte>(size);
            Marshal.Copy(unmanagedData, rawWebP, 0, size);

            return rawWebP;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowEncodeLosslessException(ex.Message);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (bmpData != null) bmp.UnlockBits(bmpData);

            //Free memory
            if (unmanagedData != IntPtr.Zero) UnsafeNativeMethods.WebPFree(unmanagedData);
        }
    }

    /// <summary>Lossless encoding image in bitmap (Advanced encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="speed">Between 0 (fastest, lowest compression) and 9 (slower, best compression)</param>
    /// <returns>Compressed data</returns>
    public byte[] EncodeLossless(Bitmap bmp, int speed)
    {
        //Initialize configuration structure
        var config = new WebPConfig();

        //Set compression parameters
        if (UnsafeNativeMethods.WebPConfigInit(ref config, WebPPreset.WEBP_PRESET_DEFAULT, (speed + 1) * 10) == 0)
            ThrowHelper.ThrowConfigPresetException();

        //Old version of DLL does not support info and WebPConfigLosslessPreset
        if (UnsafeNativeMethods.WebPGetDecoderVersion() > 1082)
        {
            if (UnsafeNativeMethods.WebPConfigLosslessPreset(ref config, speed) == 0)
                ThrowHelper.ThrowConfigureLosslessPresetException();
        }
        else
        {
            config.lossless = 1;
            config.method = speed;
            if (config.method > 6)
                config.method = 6;
            config.quality = (speed + 1) * 10;
        }

        config.pass = speed + 1;
        config.thread_level = 1;
        config.alpha_filtering = 2;
        config.use_sharp_yuv = 1;
        config.exact = 0;

        return AdvancedEncode(bmp, config, false);
    }

    /// <summary>Near lossless encoding image in bitmap</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="quality">Between 0 (lower quality, lowest file size) and 100 (highest quality, higher file size)</param>
    /// <param name="speed">Between 0 (fastest, lowest compression) and 9 (slower, best compression)</param>
    /// <returns>Compress data</returns>
    public byte[] EncodeNearLossless(Bitmap bmp, int quality, int speed = 9)
    {
        //test DLL version
        if (UnsafeNativeMethods.WebPGetDecoderVersion() <= 1082) ThrowHelper.ThrowDllVersionException();

        //Inicialize config struct
        var config = new WebPConfig();

        //Set compression parameters
        if (UnsafeNativeMethods.WebPConfigInit(ref config, WebPPreset.WEBP_PRESET_DEFAULT, (speed + 1) * 10) == 0)
            ThrowHelper.ThrowConfigurePresetException();
        if (UnsafeNativeMethods.WebPConfigLosslessPreset(ref config, speed) == 0)
            ThrowHelper.ThrowConfigureLosslessPresetException();

        config.pass = speed + 1;
        config.near_lossless = quality;
        config.thread_level = 1;
        config.alpha_filtering = 2;
        config.use_sharp_yuv = 1;
        config.exact = 0;

        return AdvancedEncode(bmp, config, false);
    }

    /// <summary>Get the libwebp version</summary>
    /// <returns>Version of library</returns>
    public string GetVersion()
    {
        try
        {
            var v = (uint) UnsafeNativeMethods.WebPGetDecoderVersion();
            var revision = v % 256;
            var minor = (v >> 8) % 256;
            var major = (v >> 16) % 256;
            return major + "." + minor + "." + revision;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowGetVersionException(ex.Message);
            return null;
        }
    }

    /// <summary>Get info of WEBP data</summary>
    /// <param name="rawWebP">The data of WebP</param>
    /// <param name="width">width of image</param>
    /// <param name="height">height of image</param>
    /// <param name="has_alpha">Image has alpha channel</param>
    /// <param name="has_animation">Image is a animation</param>
    /// <param name="format">Format of image</param>
    public static unsafe void GetInfo(byte[] rawWebP, out int width, out int height, out bool has_alpha, out bool has_animation, out WebpFormat format)
    {
        fixed (byte* ptrRawWebP = rawWebP)
        {
            try
            {
                var features = new WebPBitstreamFeatures();
                var result = UnsafeNativeMethods.WebPGetFeatures((IntPtr) ptrRawWebP, rawWebP.Length, ref features);

                if (result != 0) ThrowHelper.ThrowException(result.ToString());

                width = features.Width;
                height = features.Height;
                has_alpha = features.Has_alpha == 1;
                has_animation = features.Has_animation == 1;
                format = features.Format switch
                {
                    1 => WebpFormat.Lossy,
                    2 => WebpFormat.Lossless,
                    _ => WebpFormat.Undefined
                };
            }
            catch (Exception ex)
            {
                ThrowHelper.ThrowGetInfoException(ex.Message);
                width = 0;
                height = 0;
                has_alpha = false;
                has_animation = false;
                format = default;
            }
        }
    }

    /// <summary>Compute PSNR, SSIM or LSIM distortion metric between two pictures. Warning: this function is rather CPU-intensive</summary>
    /// <param name="source">Picture to measure</param>
    /// <param name="reference">Reference picture</param>
    /// <param name="metric_type">0 = PSNR, 1 = SSIM, 2 = LSIM</param>
    /// <returns>dB in the Y/U/V/Alpha/All order</returns>
    public float[] GetPictureDistortion(Bitmap source, Bitmap reference, int metric_type)
    {
        var wpicSource = (WebPPicture) default;
        var wpicReference = (WebPPicture) default;
        BitmapData? sourceBmpData = null;
        BitmapData? referenceBmpData = null;
        var result = new float[5];
        var pinnedResult = GCHandle.Alloc(result, GCHandleType.Pinned);

        try
        {
            if (source == null) ThrowHelper.ThrowException("Source picture is void");
            if (reference == null) ThrowHelper.ThrowException("Reference picture is void");
            if (metric_type > 2) ThrowHelper.ThrowException("Bad metric_type. Use 0 = PSNR, 1 = SSIM, 2 = LSIM");
            if (source.Width != reference.Width || source.Height != reference.Height) ThrowHelper.ThrowException("Source and Reference pictures have different dimensions");

            // Setup the source picture data, allocating the bitmap, width and height
            sourceBmpData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, source.PixelFormat);
            wpicSource = default;
            if (UnsafeNativeMethods.WebPPictureInitInternal(ref wpicSource) != 1) ThrowHelper.ThrowWebPPictureInitException();
            wpicSource.width = source.Width;
            wpicSource.height = source.Height;

            //Put the source bitmap componets in wpic
            if (sourceBmpData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                wpicSource.use_argb = 1;
                if (UnsafeNativeMethods.WebPPictureImportBGRA(ref wpicSource, sourceBmpData.Scan0, sourceBmpData.Stride) != 1)
                    ThrowHelper.ThrowWebPPictureImportBGRException();
            }
            else
            {
                wpicSource.use_argb = 0;
                if (UnsafeNativeMethods.WebPPictureImportBGR(ref wpicSource, sourceBmpData.Scan0, sourceBmpData.Stride) != 1)
                    ThrowHelper.ThrowWebPPictureImportBGRException();
            }

            // Setup the reference picture data, allocating the bitmap, width and height
            referenceBmpData = reference.LockBits(new Rectangle(0, 0, reference.Width, reference.Height), ImageLockMode.ReadOnly, reference.PixelFormat);
            wpicReference = default;
            if (UnsafeNativeMethods.WebPPictureInitInternal(ref wpicReference) != 1) ThrowHelper.ThrowWebPPictureInitException();
            wpicReference.width = reference.Width;
            wpicReference.height = reference.Height;
            wpicReference.use_argb = 1;

            //Put the source bitmap contents in WebPPicture instance
            if (sourceBmpData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                wpicSource.use_argb = 1;
                if (UnsafeNativeMethods.WebPPictureImportBGRA(ref wpicReference, referenceBmpData.Scan0, referenceBmpData.Stride) != 1)
                    ThrowHelper.ThrowWebPPictureImportBGRException();
            }
            else
            {
                wpicSource.use_argb = 0;
                if (UnsafeNativeMethods.WebPPictureImportBGR(ref wpicReference, referenceBmpData.Scan0, referenceBmpData.Stride) != 1)
                    ThrowHelper.ThrowWebPPictureImportBGRException();
            }

            //Measure
            var ptrResult = pinnedResult.AddrOfPinnedObject();
            if (UnsafeNativeMethods.WebPPictureDistortion(ref wpicSource, ref wpicReference, metric_type, ptrResult) != 1)
                ThrowHelper.ThrowException("Can´t measure.");
            return result;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowGetPictureDistortionException(ex.Message);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (sourceBmpData != null) source.UnlockBits(sourceBmpData);
            if (referenceBmpData != null) reference.UnlockBits(referenceBmpData);

            //Free memory
            if (wpicSource.argb != IntPtr.Zero) UnsafeNativeMethods.WebPPictureFree(ref wpicSource);
            if (wpicReference.argb != IntPtr.Zero) UnsafeNativeMethods.WebPPictureFree(ref wpicReference);
            //Free memory
            if (pinnedResult.IsAllocated) pinnedResult.Free();
        }
    }

    /// <summary>Encoding image  using Advanced encoding API</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="config">Configuration for encode</param>
    /// <param name="info">True if need encode info.</param>
    /// <returns>Compressed data</returns>
    [RequiresDynamicCode("Calls System.Runtime.InteropServices.Marshal.PtrToStructure(nint, Type)")]
    private unsafe byte[] AdvancedEncode(Bitmap bmp, WebPConfig config, bool info)
    {
        var wpic = (WebPPicture) default;
        BitmapData? bmpData = null;
        var ptrStats = IntPtr.Zero;
        try
        {
            //Validate the configuration
            if (UnsafeNativeMethods.WebPValidateConfig(ref config) != 1) ThrowHelper.ThrowConfigurationParametersException();

            //test bmp
            if (bmp.Width == 0 || bmp.Height == 0) ThrowHelper.ThrowBitmapNoDataException(nameof(bmp));
            if (bmp.Width > WEBP_MAX_DIMENSION || bmp.Height > WEBP_MAX_DIMENSION) ThrowHelper.ThrowBitmapDimensionException(WEBP_MAX_DIMENSION);
            if (bmp.PixelFormat != PixelFormat.Format24bppRgb && bmp.PixelFormat != PixelFormat.Format32bppArgb) ThrowHelper.ThrowBitmapPixelFormatException();

            // Setup the input data, allocating a the bitmap, width and height
            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            if (UnsafeNativeMethods.WebPPictureInitInternal(ref wpic) != 1) ThrowHelper.ThrowWebPPictureInitException();
            wpic.width = bmp.Width;
            wpic.height = bmp.Height;
            wpic.use_argb = 1;

            long dataWebpSize;
            if (bmp.PixelFormat == PixelFormat.Format32bppArgb)
            {
                //Put the bitmap componets in wpic
                var result = UnsafeNativeMethods.WebPPictureImportBGRA(ref wpic, bmpData.Scan0, bmpData.Stride);
                if (result != 1) ThrowHelper.ThrowWebPPictureImportBGRAException();
                wpic.colorspace = (uint) WEBP_CSP_MODE.MODE_bgrA;
                dataWebpSize = (long) bmp.Width * bmp.Height * 32L;
            }
            else
            {
                //Put the bitmap contents in WebPPicture instance
                var result = UnsafeNativeMethods.WebPPictureImportBGR(ref wpic, bmpData.Scan0, bmpData.Stride);
                if (result != 1) ThrowHelper.ThrowWebPPictureImportBGRException();
                dataWebpSize = (long) bmp.Width * bmp.Height * 24L;
            }

            //Set up statistics of compression
            WebPAuxStats stats;
            if (info)
            {
                stats = default;
                ptrStats = Marshal.AllocHGlobal(Marshal.SizeOf(stats));
                Marshal.StructureToPtr(stats, ptrStats, false);
                wpic.stats = ptrStats;
            }

            byte[] rawWebP;
            var dataWebpPtr = Marshal.AllocHGlobal((System.IntPtr) dataWebpSize);

            try
            {
                wpic.custom_ptr = dataWebpPtr;

                //Set up a byte-writing method (write-to-memory, in this case)
                OnCallback = MyWriter;
                wpic.writer = Marshal.GetFunctionPointerForDelegate(OnCallback);

                //compress the input samples
                if (UnsafeNativeMethods.WebPEncode(ref config, ref wpic) != 1)
                    ThrowHelper.ThrowEncodingErrorException(wpic.error_code);

                //Unlock the pixels
                bmp.UnlockBits(bmpData);
                bmpData = null!;

                //Copy webpData to rawWebP
                var size = (int) (wpic.custom_ptr - (long) dataWebpPtr);
                var dataWebp = new Span<byte>((void*) dataWebpPtr, size);

                rawWebP = GC.AllocateUninitializedArray<byte>(size);
                dataWebp.CopyTo(rawWebP);

            }
            finally
            {
                Marshal.FreeHGlobal(dataWebpPtr);

                //Remove OnCallback
                OnCallback = null!;
            }

            //Show statistics
            if (info)
            {
                stats = Marshal.PtrToStructure<WebPAuxStats>(ptrStats)!;
                Debug.Print("Dimension: " + wpic.width + " x " + wpic.height + " pixels\n" +
                            "Output:    " + stats.coded_size + " bytes\n" +
                            "PSNR Y:    " + stats.PSNRY + " db\n" +
                            "PSNR u:    " + stats.PSNRU + " db\n" +
                            "PSNR v:    " + stats.PSNRV + " db\n" +
                            "PSNR ALL:  " + stats.PSNRALL + " db\n" +
                            "Block intra4:  " + stats.block_count_intra4 + "\n" +
                            "Block intra16: " + stats.block_count_intra16 + "\n" +
                            "Block skipped: " + stats.block_count_skipped + "\n" +
                            "Header size:    " + stats.header_bytes + " bytes\n" +
                            "Mode-partition: " + stats.mode_partition_0 + " bytes\n" +
                            "Macro-blocks 0: " + stats.segment_size_segments0 + " residuals bytes\n" +
                            "Macro-blocks 1: " + stats.segment_size_segments1 + " residuals bytes\n" +
                            "Macro-blocks 2: " + stats.segment_size_segments2 + " residuals bytes\n" +
                            "Macro-blocks 3: " + stats.segment_size_segments3 + " residuals bytes\n" +
                            "Quantizer    0: " + stats.segment_quant_segments0 + " residuals bytes\n" +
                            "Quantizer    1: " + stats.segment_quant_segments1 + " residuals bytes\n" +
                            "Quantizer    2: " + stats.segment_quant_segments2 + " residuals bytes\n" +
                            "Quantizer    3: " + stats.segment_quant_segments3 + " residuals bytes\n" +
                            "Filter level 0: " + stats.segment_level_segments0 + " residuals bytes\n" +
                            "Filter level 1: " + stats.segment_level_segments1 + " residuals bytes\n" +
                            "Filter level 2: " + stats.segment_level_segments2 + " residuals bytes\n" +
                            "Filter level 3: " + stats.segment_level_segments3 + " residuals bytes\n", "Compression statistics");
            }

            return rawWebP;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowAdvancedEncodeException(ex.Message);
            return null;
        }
        finally
        {
            //Free statistics memory
            if (ptrStats != nint.Zero) Marshal.FreeHGlobal(ptrStats);

            //Unlock the pixels
            if (bmpData != null) bmp.UnlockBits(bmpData);

            //Free memory
            if (wpic.argb != IntPtr.Zero) UnsafeNativeMethods.WebPPictureFree(ref wpic);
        }
    }

    private static int MyWriter([In] nint data, nuint data_size, ref WebPPicture picture)
    {
        UnsafeNativeMethods.CopyMemory(picture.custom_ptr, data, (nint) data_size);
        picture.custom_ptr = nint.Add(picture.custom_ptr, (int) data_size);
        return 1;
    }

    private delegate int MyWriterDelegate([In] IntPtr data, UIntPtr data_size, ref WebPPicture picture);

    /// <summary>Free memory</summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}