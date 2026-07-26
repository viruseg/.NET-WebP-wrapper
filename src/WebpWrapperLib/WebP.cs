// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebpWrapperLib.WebPInterop;

namespace WebpWrapper;

/// <summary>
/// Wrapper for WebP format.
/// </summary>
[SuppressMessage("Interoperability", "CA1416")]
public static class WebP
{
    /// <summary>This function will initialize the configuration according to a predefined set of parameters (referred to by 'preset') and a given quality factor</summary>
    /// <param name="preset">Type of image</param>
    /// <param name="quality">Quality of compression</param>
    /// <param name="config">The WebPConfig structure</param>
    /// <returns>0 if error</returns>
    public static unsafe int WebPConfigInit(WebPPreset preset, float quality, out WebPConfig config)
    {
        Unsafe.SkipInit(out WebPConfig tempConfig);

        var result = Methods.WebPConfigPreset(&tempConfig, preset, quality);

        config = tempConfig;
        return result;
    }

    /// <summary>Decode a WebP image</summary>
    /// <param name="rawWebP">The data to uncompress</param>
    /// <returns>Bitmap with the WebP image</returns>
    public static unsafe Bitmap Decode(byte[] rawWebP)
    {
        fixed (byte* pinnedWebP = rawWebP)
        {
            Bitmap? bmp = null;
            BitmapData? bmpData = null;

            try
            {
                //Get image width and height
                Unsafe.SkipInit(out WebPBitstreamFeatures features);
                var result = Methods.WebPGetFeatures(pinnedWebP, (nuint) rawWebP.Length, &features);
                if (result != 0) ThrowHelper.ThrowException(result.ToString());

                //Create a BitmapData and Lock all pixels to be written
                bmp = features.HasAlpha
                    ? new Bitmap(features.Width, features.Height, PixelFormat.Format32bppArgb)
                    : new Bitmap(features.Width, features.Height, PixelFormat.Format24bppRgb);
                bmpData = bmp.LockBits(new Rectangle(0, 0, features.Width, features.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

                //Uncompress the image
                var outputSize = bmpData.Stride * features.Height;
                if (bmp.PixelFormat == PixelFormat.Format24bppRgb)
                    Methods.WebPDecodeBGRInto(pinnedWebP, (nuint) rawWebP.Length, (byte*) bmpData.Scan0, (nuint) outputSize, bmpData.Stride);
                else
                    Methods.WebPDecodeBGRAInto(pinnedWebP, (nuint) rawWebP.Length, (byte*) bmpData.Scan0, (nuint) outputSize, bmpData.Stride);

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
    public static unsafe Bitmap Decode(byte[] rawWebP, WebPDecoderOptions options)
    {
        var pinnedWebP = GCHandle.Alloc(rawWebP, GCHandleType.Pinned);
        Bitmap? bmp = null;
        BitmapData? bmpData = null;
        try
        {
            Unsafe.SkipInit(out WebPDecoderConfig config);
            if (Methods.WebPInitDecoderConfig(&config) == 0)
            {
                ThrowHelper.ThrowInitDecoderConfigException();
            }

            // Read the .webp input file information
            var ptrRawWebP = pinnedWebP.AddrOfPinnedObject();
            VP8StatusCode result;
            if (options.UseScaling)
            {
                result = Methods.WebPGetFeatures((byte*) ptrRawWebP, (nuint) rawWebP.Length, &config.input);
                if (result != VP8StatusCode.VP8_STATUS_OK) ThrowHelper.ThrowGetFeaturesException(result);

                //Test cropping values
                if (options.UseCropping)
                {
                    if (options.crop_left + options.crop_width > config.input.Width || options.crop_top + options.crop_height > config.input.Height)
                        ThrowHelper.ThrowCropException();
                }
            }

            config.options = options;

            //Create a BitmapData and Lock all pixels to be written
            if (config.input.HasAlpha)
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
            config.output.u.RGBA.rgba = (byte*) bmpData.Scan0;
            config.output.u.RGBA.stride = bmpData.Stride;
            config.output.u.RGBA.size = (nuint) (bmp.Height * bmpData.Stride);
            config.output.height = bmp.Height;
            config.output.width = bmp.Width;
            config.output.is_external_memory = 1;

            // Decode
            result = Methods.WebPDecode((byte*) ptrRawWebP, (nuint) rawWebP.Length, &config);
            if (result != VP8StatusCode.VP8_STATUS_OK) ThrowHelper.ThrowGetFeaturesException(result);

            Methods.WebPFreeDecBuffer(&config.output);

            return bmp;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowDecodeException(ex);
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

    /// <summary>Lossy encoding bitmap to WebP (Simple encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="quality">Between 0 (lower quality, lowest file size) and 100 (highest quality, higher file size)</param>
    /// <returns>Compressed data</returns>
    public static unsafe byte[] EncodeLossy(Bitmap bmp, int quality = 75)
    {
        //test bmp
        if (bmp.Width == 0 || bmp.Height == 0) ThrowHelper.ThrowBitmapNoDataException(nameof(bmp));
        if (bmp.Width > Methods.WEBP_MAX_DIMENSION || bmp.Height > Methods.WEBP_MAX_DIMENSION) ThrowHelper.ThrowBitmapDimensionException(Methods.WEBP_MAX_DIMENSION);
        if (bmp.PixelFormat != PixelFormat.Format24bppRgb && bmp.PixelFormat != PixelFormat.Format32bppArgb) ThrowHelper.ThrowBitmapPixelFormatException();

        BitmapData? bmpData = null;
        byte* unmanagedData = null;

        try
        {
            //Get bmp data
            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);

            //Compress the bmp data
            var size = bmp.PixelFormat == PixelFormat.Format24bppRgb
                ? (int) Methods.WebPEncodeBGR((byte*) bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, quality, &unmanagedData)
                : (int) Methods.WebPEncodeBGRA((byte*) bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, quality, &unmanagedData);

            if (size == 0)
                ThrowHelper.ThrowEncodeException();

            //Copy image compress data to output array
            var rawWebP = GC.AllocateUninitializedArray<byte>(size);
            Marshal.Copy((IntPtr) unmanagedData, rawWebP, 0, size);

            return rawWebP;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowEncodeLosslyException(ex);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (bmpData != null) bmp.UnlockBits(bmpData);

            //Free memory
            if (unmanagedData != null) Methods.WebPFree(unmanagedData);
        }
    }

    /// <summary>Encoding bitmap to WebP (Advanced encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="config">Configuration for encode</param>
    /// <returns>Compressed data</returns>
    public static byte[] Encode(Bitmap bmp, WebPConfig config)
    {
        return AdvancedEncode(bmp, config, false, out _);
    }

    /// <summary>Encoding bitmap to WebP (Advanced encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="config">Configuration for encode</param>
    /// <param name="info">True if need encode info.</param>
    /// <param name="stats">Output statistics</param>
    /// <returns>Compressed data</returns>
    public static byte[] Encode(Bitmap bmp, WebPConfig config, bool info, out WebPAuxStats stats)
    {
        return AdvancedEncode(bmp, config, info, out stats);
    }

    /// <summary>Lossless encoding bitmap to WebP (Simple encoding API)</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <returns>Compressed data</returns>
    public static unsafe byte[] EncodeLossless(Bitmap bmp)
    {
        //test bmp
        if (bmp.Width == 0 || bmp.Height == 0) ThrowHelper.ThrowBitmapNoDataException(nameof(bmp));
        if (bmp.Width > Methods.WEBP_MAX_DIMENSION || bmp.Height > Methods.WEBP_MAX_DIMENSION) ThrowHelper.ThrowBitmapDimensionException(Methods.WEBP_MAX_DIMENSION);
        if (bmp.PixelFormat != PixelFormat.Format24bppRgb && bmp.PixelFormat != PixelFormat.Format32bppArgb) ThrowHelper.ThrowBitmapPixelFormatException();

        BitmapData? bmpData = null;
        byte* unmanagedData = null;
        try
        {
            //Get bmp data
            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);

            //Compress the bmp data
            var size = bmp.PixelFormat == PixelFormat.Format24bppRgb
                ? (int) Methods.WebPEncodeLosslessBGR((byte*) bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, &unmanagedData)
                : (int) Methods.WebPEncodeLosslessBGRA((byte*) bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, &unmanagedData);

            //Copy image compress data to output array
            var rawWebP = GC.AllocateUninitializedArray<byte>(size);
            Marshal.Copy((IntPtr) unmanagedData, rawWebP, 0, size);

            return rawWebP;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowEncodeLosslessException(ex);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (bmpData != null) bmp.UnlockBits(bmpData);

            //Free memory
            if (unmanagedData != null) Methods.WebPFree(unmanagedData);
        }
    }

    /// <summary>Get the libwebp version</summary>
    /// <returns>Version of library</returns>
    public static string GetVersion()
    {
        try
        {
            var v = (uint) Methods.WebPGetDecoderVersion();
            var revision = v % 256;
            var minor = (v >> 8) % 256;
            var major = (v >> 16) % 256;
            return major + "." + minor + "." + revision;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowGetVersionException(ex);
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
    public static unsafe WebPBitstreamFeatures GetInfo(byte[] rawWebP)
    {
        fixed (byte* ptrRawWebP = rawWebP)
        {
            try
            {
                Unsafe.SkipInit(out WebPBitstreamFeatures features);
                var result = Methods.WebPGetFeatures(ptrRawWebP, (nuint) rawWebP.Length, &features);

                if (result != 0) ThrowHelper.ThrowException(result.ToString());

                return features;
            }
            catch (Exception ex)
            {
                ThrowHelper.ThrowGetInfoException(ex);
                return default;
            }
        }
    }

    /// <summary>Compute PSNR, SSIM or LSIM distortion metric between two pictures. Warning: this function is rather CPU-intensive</summary>
    /// <param name="source">Picture to measure</param>
    /// <param name="reference">Reference picture</param>
    /// <param name="metric_type">0 = PSNR, 1 = SSIM, 2 = LSIM</param>
    /// <returns>dB in the Y/U/V/Alpha/All order</returns>
    public static unsafe float[] GetPictureDistortion(Bitmap source, Bitmap reference, int metric_type)
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
            if (Methods.WebPPictureInit(&wpicSource) != 1) ThrowHelper.ThrowWebPPictureInitException();
            wpicSource.width = source.Width;
            wpicSource.height = source.Height;

            //Put the source bitmap componets in wpic
            if (sourceBmpData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                wpicSource.use_argb = 1;
                if (Methods.WebPPictureImportBGRA(&wpicSource, (byte*) sourceBmpData.Scan0, sourceBmpData.Stride) != 1)
                    ThrowHelper.ThrowWebPPictureImportBGRException();
            }
            else
            {
                wpicSource.use_argb = 0;
                if (Methods.WebPPictureImportBGR(&wpicSource, (byte*) sourceBmpData.Scan0, sourceBmpData.Stride) != 1)
                    ThrowHelper.ThrowWebPPictureImportBGRException();
            }

            // Setup the reference picture data, allocating the bitmap, width and height
            referenceBmpData = reference.LockBits(new Rectangle(0, 0, reference.Width, reference.Height), ImageLockMode.ReadOnly, reference.PixelFormat);
            if (Methods.WebPPictureInit(&wpicReference) != 1) ThrowHelper.ThrowWebPPictureInitException();
            wpicReference.width = reference.Width;
            wpicReference.height = reference.Height;
            wpicReference.use_argb = 1;

            //Put the source bitmap contents in WebPPicture instance
            if (sourceBmpData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                wpicSource.use_argb = 1;
                if (Methods.WebPPictureImportBGRA(&wpicReference, (byte*) referenceBmpData.Scan0, referenceBmpData.Stride) != 1)
                    ThrowHelper.ThrowWebPPictureImportBGRException();
            }
            else
            {
                wpicSource.use_argb = 0;
                if (Methods.WebPPictureImportBGR(&wpicReference, (byte*) referenceBmpData.Scan0, referenceBmpData.Stride) != 1)
                    ThrowHelper.ThrowWebPPictureImportBGRException();
            }

            //Measure
            var ptrResult = pinnedResult.AddrOfPinnedObject();
            if (Methods.WebPPictureDistortion(&wpicSource, &wpicReference, metric_type, (float*) ptrResult) != 1)
                ThrowHelper.ThrowException("Can´t measure.");
            return result;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowGetPictureDistortionException(ex);
            return null;
        }
        finally
        {
            //Unlock the pixels
            if (sourceBmpData != null) source.UnlockBits(sourceBmpData);
            if (referenceBmpData != null) reference.UnlockBits(referenceBmpData);

            //Free memory
            if (wpicSource.argb != null) Methods.WebPPictureFree(&wpicSource);
            if (wpicReference.argb != null) Methods.WebPPictureFree(&wpicReference);
            //Free memory
            if (pinnedResult.IsAllocated) pinnedResult.Free();
        }
    }

    /// <summary>Encoding image  using Advanced encoding API</summary>
    /// <param name="bmp">Bitmap with the image</param>
    /// <param name="config">Configuration for encode</param>
    /// <param name="info">True if need encode info.</param>
    /// <param name="stats">Output statistics</param>
    /// <returns>Compressed data</returns>
    private static unsafe byte[] AdvancedEncode(Bitmap bmp, WebPConfig config, bool info, out WebPAuxStats stats)
    {
        var wpic = (WebPPicture) default;
        BitmapData? bmpData = null;
        WebPAuxStats* ptrStats = null;
        try
        {
            //Validate the configuration
            if (Methods.WebPValidateConfig(&config) != 1) ThrowHelper.ThrowConfigurationParametersException();

            //test bmp
            if (bmp.Width == 0 || bmp.Height == 0) ThrowHelper.ThrowBitmapNoDataException(nameof(bmp));
            if (bmp.Width > Methods.WEBP_MAX_DIMENSION || bmp.Height > Methods.WEBP_MAX_DIMENSION) ThrowHelper.ThrowBitmapDimensionException(Methods.WEBP_MAX_DIMENSION);
            if (bmp.PixelFormat != PixelFormat.Format24bppRgb && bmp.PixelFormat != PixelFormat.Format32bppArgb) ThrowHelper.ThrowBitmapPixelFormatException();

            // Setup the input data, allocating a the bitmap, width and height
            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            if (Methods.WebPPictureInit(&wpic) != 1) ThrowHelper.ThrowWebPPictureInitException();
            wpic.width = bmp.Width;
            wpic.height = bmp.Height;

            long dataWebpSize;
            if (bmp.PixelFormat == PixelFormat.Format32bppArgb)
            {
                //Put the bitmap componets in wpic
                var result = Methods.WebPPictureImportBGRA(&wpic, (byte*) bmpData.Scan0, bmpData.Stride);
                if (result != 1) ThrowHelper.ThrowWebPPictureImportBGRAException();
                dataWebpSize = (long) bmp.Width * bmp.Height * 32L;
            }
            else
            {
                //Put the bitmap contents in WebPPicture instance
                var result = Methods.WebPPictureImportBGR(&wpic, (byte*) bmpData.Scan0, bmpData.Stride);
                if (result != 1) ThrowHelper.ThrowWebPPictureImportBGRException();
                dataWebpSize = (long) bmp.Width * bmp.Height * 24L;
            }

            //Set up statistics of compression
            if (info)
            {
                ptrStats = (WebPAuxStats*) Marshal.AllocHGlobal(sizeof(WebPAuxStats));
                *ptrStats = default;
                wpic.stats = ptrStats;
            }

            byte[] rawWebP;
            var dataWebpPtr = Marshal.AllocHGlobal((nint) dataWebpSize);

            try
            {
                wpic.custom_ptr = (void*) dataWebpPtr;

                //Set up a byte-writing method (write-to-memory, in this case)
                wpic.writer = &MyWriter;

                //compress the input samples
                if (Methods.WebPEncode(&config, &wpic) != 1)
                    ThrowHelper.ThrowEncodingErrorException((uint) wpic.error_code);

                //Unlock the pixels
                bmp.UnlockBits(bmpData);
                bmpData = null!;

                //Copy webpData to rawWebP
                var size = (int) ((nint) wpic.custom_ptr - (long) dataWebpPtr);
                var dataWebp = new Span<byte>((void*) dataWebpPtr, size);

                rawWebP = GC.AllocateUninitializedArray<byte>(size);
                dataWebp.CopyTo(rawWebP);

            }
            finally
            {
                Marshal.FreeHGlobal(dataWebpPtr);
            }

            stats = info && ptrStats != null ? *ptrStats : default;

            return rawWebP;
        }
        catch (Exception ex)
        {
            ThrowHelper.ThrowAdvancedEncodeException(ex);
            stats = default;
            return null;
        }
        finally
        {
            //Free statistics memory
            if (ptrStats != null) Marshal.FreeHGlobal((IntPtr) ptrStats);

            //Unlock the pixels
            if (bmpData != null) bmp.UnlockBits(bmpData);

            //Free memory
            if (wpic.argb != null) Methods.WebPPictureFree(&wpic);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe int MyWriter(byte* data, nuint data_size, WebPPicture* picture)
    {
        Buffer.MemoryCopy(source: data, picture->custom_ptr, data_size, data_size);
        picture->custom_ptr = (byte*)picture->custom_ptr + data_size;
        return 1;
    }
}