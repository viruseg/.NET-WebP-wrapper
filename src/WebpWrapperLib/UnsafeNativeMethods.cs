// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Runtime.InteropServices;
using System.Security;

#pragma warning disable CA1416

namespace WebpWrapper;

[SuppressUnmanagedCodeSecurity]
internal static partial class UnsafeNativeMethods
{
    [LibraryImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
    public static partial void CopyMemory(IntPtr dest, IntPtr src, IntPtr count);

    private const int WEBP_DECODER_ABI_VERSION = 0x0210;

    /// <summary>This function will initialize the configuration according to a predefined set of parameters (referred to by 'preset') and a given quality factor</summary>
    /// <param name="config">The WebPConfig structure</param>
    /// <param name="preset">Type of image</param>
    /// <param name="quality">Quality of compression</param>
    /// <returns>0 if error</returns>
    internal static int WebPConfigInit(ref WebPConfig config, WebPPreset preset, float quality)
    {
        return IntPtr.Size switch
        {
            8 => WebPConfigInitInternal_x64(ref config, preset, quality, WEBP_DECODER_ABI_VERSION),
            _ => ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPConfigInitInternal")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPConfigInitInternal_x64(ref WebPConfig config, WebPPreset preset, float quality, int WEBP_DECODER_ABI_VERSION);

    /// <summary>Get info of WepP image</summary>
    /// <param name="rawWebP">Bytes[] of WebP image</param>
    /// <param name="data_size">Size of rawWebP</param>
    /// <param name="features">Features of WebP image</param>
    /// <returns>VP8StatusCode</returns>
    internal static VP8StatusCode WebPGetFeatures(IntPtr rawWebP, int data_size, ref WebPBitstreamFeatures features)
    {
        return IntPtr.Size switch
        {
            8 => WebPGetFeaturesInternal_x64(rawWebP, (UIntPtr) data_size, ref features, WEBP_DECODER_ABI_VERSION),
            _ => (VP8StatusCode) ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPGetFeaturesInternal")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial VP8StatusCode WebPGetFeaturesInternal_x64(IntPtr rawWebP, UIntPtr data_size, ref WebPBitstreamFeatures features, int WEBP_DECODER_ABI_VERSION);

    /// <summary>Activate the lossless compression mode with the desired efficiency</summary>
    /// <param name="config">The WebPConfig struct</param>
    /// <param name="level">between 0 (fastest, lowest compression) and 9 (slower, best compression)</param>
    /// <returns>0 in case of parameter error</returns>
    internal static int WebPConfigLosslessPreset(ref WebPConfig config, int level)
    {
        return IntPtr.Size switch
        {
            8 => WebPConfigLosslessPreset_x64(ref config, level),
            _ => ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPConfigLosslessPreset")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPConfigLosslessPreset_x64(ref WebPConfig config, int level);

    /// <summary>Check that configuration is non-NULL and all configuration parameters are within their valid ranges</summary>
    /// <param name="config">The WebPConfig structure</param>
    /// <returns>1 if configuration is OK</returns>
    internal static int WebPValidateConfig(ref WebPConfig config)
    {
        return IntPtr.Size switch
        {
            8 => WebPValidateConfig_x64(ref config),
            _ => ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPValidateConfig")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPValidateConfig_x64(ref WebPConfig config);

    /// <summary>Initialize the WebPPicture structure checking the DLL version</summary>
    /// <param name="wpic">The WebPPicture structure</param>
    /// <returns>1 if not error</returns>
    internal static int WebPPictureInitInternal(ref WebPPicture wpic)
    {
        return IntPtr.Size switch
        {
            8 => WebPPictureInitInternal_x64(ref wpic, WEBP_DECODER_ABI_VERSION),
            _ => ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPPictureInitInternal")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPPictureInitInternal_x64(ref WebPPicture wpic, int WEBP_DECODER_ABI_VERSION);

    /// <summary>Colorspace conversion function to import RGB samples</summary>
    /// <param name="wpic">The WebPPicture structure</param>
    /// <param name="bgr">Point to BGR data</param>
    /// <param name="stride">stride of BGR data</param>
    /// <returns>Returns 0 in case of memory error.</returns>
    internal static int WebPPictureImportBGR(ref WebPPicture wpic, IntPtr bgr, int stride)
    {
        return IntPtr.Size switch
        {
            8 => WebPPictureImportBGR_x64(ref wpic, bgr, stride),
            _ => ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPPictureImportBGR")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPPictureImportBGR_x64(ref WebPPicture wpic, IntPtr bgr, int stride);

    /// <summary>Color-space conversion function to import RGB samples</summary>
    /// <param name="wpic">The WebPPicture structure</param>
    /// <param name="bgra">Point to BGRA data</param>
    /// <param name="stride">stride of BGRA data</param>
    /// <returns>Returns 0 in case of memory error.</returns>
    internal static int WebPPictureImportBGRA(ref WebPPicture wpic, IntPtr bgra, int stride)
    {
        return IntPtr.Size switch
        {
            8 => WebPPictureImportBGRA_x64(ref wpic, bgra, stride),
            _ => ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPPictureImportBGRA")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPPictureImportBGRA_x64(ref WebPPicture wpic, IntPtr bgra, int stride);

    /// <summary>Color-space conversion function to import RGB samples</summary>
    /// <param name="wpic">The WebPPicture structure</param>
    /// <param name="bgr">Point to BGR data</param>
    /// <param name="stride">stride of BGR data</param>
    /// <returns>Returns 0 in case of memory error.</returns>
    internal static int WebPPictureImportBGRX(ref WebPPicture wpic, IntPtr bgr, int stride)
    {
        return IntPtr.Size switch
        {
            8 => WebPPictureImportBGRX_x64(ref wpic, bgr, stride),
            _ => ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPPictureImportBGRX")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPPictureImportBGRX_x64(ref WebPPicture wpic, IntPtr bgr, int stride);

    /// <summary>The writer type for output compress data</summary>
    /// <param name="data">Data returned</param>
    /// <param name="data_size">Size of data returned</param>
    /// <param name="wpic">Picture structure</param>
    /// <returns></returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int WebPMemoryWrite([In] IntPtr data, UIntPtr data_size, ref WebPPicture wpic);

    /// <summary>Compress to WebP format</summary>
    /// <param name="config">The configuration structure for compression parameters</param>
    /// <param name="picture">'picture' hold the source samples in both YUV(A) or ARGB input</param>
    /// <returns>Returns 0 in case of error, 1 otherwise. In case of error, picture->error_code is updated accordingly.</returns>
    internal static int WebPEncode(ref WebPConfig config, ref WebPPicture picture)
    {
        return IntPtr.Size switch
        {
            8 => WebPEncode_x64(ref config, ref picture),
            _ => ThrowHelper.ThrowInvalidPlatformException()
        };
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPEncode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPEncode_x64(ref WebPConfig config, ref WebPPicture picture);

    /// <summary>Release the memory allocated by WebPPictureAlloc() or WebPPictureImport*()
    /// Note that this function does _not_ free the memory used by the 'picture' object itself.
    /// Besides memory (which is reclaimed) all other fields of 'picture' are preserved</summary>
    /// <param name="picture">Picture structure</param>
    internal static void WebPPictureFree(ref WebPPicture picture)
    {
        switch (IntPtr.Size)
        {
            case 8: WebPPictureFree_x64(ref picture); break;
            default: ThrowHelper.ThrowInvalidPlatformException(); break;
        }
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPPictureFree")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial void WebPPictureFree_x64(ref WebPPicture wpic);

    /// <summary>Validate the WebP image header and retrieve the image height and width. Pointers *width and *height can be passed NULL if deemed irrelevant</summary>
    /// <param name="data">Pointer to WebP image data</param>
    /// <param name="data_size">This is the size of the memory block pointed to by data containing the image data</param>
    /// <param name="width">The range is limited currently from 1 to 16383</param>
    /// <param name="height">The range is limited currently from 1 to 16383</param>
    /// <returns>1 if success, otherwise error code returned in the case of (a) formatting error(s).</returns>
    internal static int WebPGetInfo(IntPtr data, int data_size, out int width, out int height)
    {
        switch (IntPtr.Size)
        {
            case 8:
                return WebPGetInfo_x64(data, (UIntPtr) data_size, out width, out height);
            default:
                ThrowHelper.ThrowInvalidPlatformException();
                width = 0;
                height = 0;
                return 0;
        }
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPGetInfo")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPGetInfo_x64(IntPtr data, UIntPtr data_size, out int width, out int height);

    /// <summary>Decode WEBP image pointed to by *data and returns BGR samples into a preallocated buffer</summary>
    /// <param name="data">Pointer to WebP image data</param>
    /// <param name="data_size">This is the size of the memory block pointed to by data containing the image data</param>
    /// <param name="output_buffer">Pointer to decoded WebP image</param>
    /// <param name="output_buffer_size">Size of allocated buffer</param>
    /// <param name="output_stride">Specifies the distance between scan lines</param>
    internal static void WebPDecodeBGRInto(IntPtr data, int data_size, IntPtr output_buffer, int output_buffer_size, int output_stride)
    {
        WebPDecodeBGRInto_x64(data, (UIntPtr) data_size, output_buffer, output_buffer_size, output_stride);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPDecodeBGRInto")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial IntPtr WebPDecodeBGRInto_x64(IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);

    /// <summary>Decode WEBP image pointed to by *data and returns BGRA samples into a preallocated buffer</summary>
    /// <param name="data">Pointer to WebP image data</param>
    /// <param name="data_size">This is the size of the memory block pointed to by data containing the image data</param>
    /// <param name="output_buffer">Pointer to decoded WebP image</param>
    /// <param name="output_buffer_size">Size of allocated buffer</param>
    /// <param name="output_stride">Specifies the distance between scan lines</param>
    internal static void WebPDecodeBGRAInto(IntPtr data, int data_size, IntPtr output_buffer, int output_buffer_size, int output_stride)
    {
        WebPDecodeBGRAInto_x64(data, (UIntPtr) data_size, output_buffer, output_buffer_size, output_stride);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPDecodeBGRAInto")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial IntPtr WebPDecodeBGRAInto_x64(IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);

    /// <summary>Decode WEBP image pointed to by *data and returns ARGB samples into a preallocated buffer</summary>
    /// <param name="data">Pointer to WebP image data</param>
    /// <param name="data_size">This is the size of the memory block pointed to by data containing the image data</param>
    /// <param name="output_buffer">Pointer to decoded WebP image</param>
    /// <param name="output_buffer_size">Size of allocated buffer</param>
    /// <param name="output_stride">Specifies the distance between scan lines</param>
    internal static void WebPDecodeARGBInto(IntPtr data, int data_size, IntPtr output_buffer, int output_buffer_size, int output_stride)
    {
        WebPDecodeARGBInto_x64(data, (UIntPtr) data_size, output_buffer, output_buffer_size, output_stride);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPDecodeARGBInto")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial IntPtr WebPDecodeARGBInto_x64(IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);

    /// <summary>Initialize the configuration as empty. This function must always be called first, unless WebPGetFeatures() is to be called</summary>
    /// <param name="webPDecoderConfig">Configuration structure</param>
    /// <returns>False in case of mismatched version.</returns>
    internal static int WebPInitDecoderConfig(ref WebPDecoderConfig webPDecoderConfig)
    {
        return WebPInitDecoderConfigInternal_x64(ref webPDecoderConfig, WEBP_DECODER_ABI_VERSION);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPInitDecoderConfigInternal")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPInitDecoderConfigInternal_x64(ref WebPDecoderConfig webPDecoderConfig, int WEBP_DECODER_ABI_VERSION);

    /// <summary>Decodes the full data at once, taking configuration into account</summary>
    /// <param name="data">WebP raw data to decode</param>
    /// <param name="data_size">Size of WebP data </param>
    /// <param name="webPDecoderConfig">Configuration structure</param>
    /// <returns>VP8_STATUS_OK if the decoding was successful</returns>
    internal static VP8StatusCode WebPDecode(IntPtr data, int data_size, ref WebPDecoderConfig webPDecoderConfig)
    {
        return WebPDecode_x64(data, (UIntPtr) data_size, ref webPDecoderConfig);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPDecode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial VP8StatusCode WebPDecode_x64(IntPtr data, UIntPtr data_size, ref WebPDecoderConfig config);

    /// <summary>Free any memory associated with the buffer. Must always be called last. Doesn't free the 'buffer' structure itself</summary>
    /// <param name="buffer">WebPDecBuffer</param>
    internal static void WebPFreeDecBuffer(ref WebPDecBuffer buffer)
    {
        WebPFreeDecBuffer_x64(ref buffer);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPFreeDecBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial void WebPFreeDecBuffer_x64(ref WebPDecBuffer buffer);

    /// <summary>Lossy encoding images</summary>
    /// <param name="bgr">Pointer to BGR image data</param>
    /// <param name="width">The range is limited currently from 1 to 16383</param>
    /// <param name="height">The range is limited currently from 1 to 16383</param>
    /// <param name="stride">Specifies the distance between scanlines</param>
    /// <param name="quality_factor">Ranges from 0 (lower quality) to 100 (highest quality). Controls the loss and quality during compression</param>
    /// <param name="output">output_buffer with WebP image</param>
    /// <returns>Size of WebP Image or 0 if an error occurred</returns>
    internal static int WebPEncodeBGR(IntPtr bgr, int width, int height, int stride, float quality_factor, out IntPtr output)
    {
        return WebPEncodeBGR_x64(bgr, width, height, stride, quality_factor, out output);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPEncodeBGR")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPEncodeBGR_x64(IntPtr bgr, int width, int height, int stride, float quality_factor, out IntPtr output);

    /// <summary>Lossy encoding images</summary>
    /// <param name="bgra">Pointer to BGRA image data</param>
    /// <param name="width">The range is limited currently from 1 to 16383</param>
    /// <param name="height">The range is limited currently from 1 to 16383</param>
    /// <param name="stride">Specifies the distance between scan lines</param>
    /// <param name="quality_factor">Ranges from 0 (lower quality) to 100 (highest quality). Controls the loss and quality during compression</param>
    /// <param name="output">output_buffer with WebP image</param>
    /// <returns>Size of WebP Image or 0 if an error occurred</returns>
    internal static int WebPEncodeBGRA(IntPtr bgra, int width, int height, int stride, float quality_factor, out IntPtr output)
    {
        return WebPEncodeBGRA_x64(bgra, width, height, stride, quality_factor, out output);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPEncodeBGRA")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPEncodeBGRA_x64(IntPtr bgra, int width, int height, int stride, float quality_factor, out IntPtr output);

    /// <summary>Lossless encoding images pointed to by *data in WebP format</summary>
    /// <param name="bgr">Pointer to BGR image data</param>
    /// <param name="width">The range is limited currently from 1 to 16383</param>
    /// <param name="height">The range is limited currently from 1 to 16383</param>
    /// <param name="stride">Specifies the distance between scan lines</param>
    /// <param name="output">output_buffer with WebP image</param>
    /// <returns>Size of WebP Image or 0 if an error occurred</returns>
    internal static int WebPEncodeLosslessBGR(IntPtr bgr, int width, int height, int stride, out IntPtr output)
    {
        return WebPEncodeLosslessBGR_x64(bgr, width, height, stride, out output);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPEncodeLosslessBGR")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPEncodeLosslessBGR_x64(IntPtr bgr, int width, int height, int stride, out IntPtr output);

    /// <summary>Lossless encoding images pointed to by *data in WebP format</summary>
    /// <param name="bgra">Pointer to BGRA image data</param>
    /// <param name="width">The range is limited currently from 1 to 16383</param>
    /// <param name="height">The range is limited currently from 1 to 16383</param>
    /// <param name="stride">Specifies the distance between scan lines</param>
    /// <param name="output">output_buffer with WebP image</param>
    /// <returns>Size of WebP Image or 0 if an error occurred</returns>
    internal static int WebPEncodeLosslessBGRA(IntPtr bgra, int width, int height, int stride, out IntPtr output)
    {
        return WebPEncodeLosslessBGRA_x64(bgra, width, height, stride, out output);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPEncodeLosslessBGRA")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPEncodeLosslessBGRA_x64(IntPtr bgra, int width, int height, int stride, out IntPtr output);

    /// <summary>Releases memory returned by the WebPEncode</summary>
    /// <param name="p">Pointer to memory</param>
    internal static void WebPFree(IntPtr p)
    {
        WebPFree_x64(p);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPFree")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial void WebPFree_x64(IntPtr p);

    /// <summary>Get the WebP version library</summary>
    /// <returns>8bits for each of major/minor/revision packet in integer. E.g: v2.5.7 is 0x020507</returns>
    internal static int WebPGetDecoderVersion()
    {
        return WebPGetDecoderVersion_x64();
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPGetDecoderVersion")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPGetDecoderVersion_x64();

    /// <summary>Compute PSNR, SSIM or LSIM distortion metric between two pictures</summary>
    /// <param name="srcPicture">Picture to measure</param>
    /// <param name="refPicture">Reference picture</param>
    /// <param name="metric_type">0 = PSNR, 1 = SSIM, 2 = LSIM</param>
    /// <param name="pResult">dB in the Y/U/V/Alpha/All order</param>
    /// <returns>False in case of error (the two pictures don't have same dimension, ...)</returns>
    internal static int WebPPictureDistortion(ref WebPPicture srcPicture, ref WebPPicture refPicture, int metric_type, IntPtr pResult)
    {
        return WebPPictureDistortion_x64(ref srcPicture, ref refPicture, metric_type, pResult);
    }

    [LibraryImport(@"runtimes\win-x64\native\libwebp.dll", EntryPoint = "WebPPictureDistortion")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static partial int WebPPictureDistortion_x64(ref WebPPicture srcPicture, ref WebPPicture refPicture, int metric_type, IntPtr pResult);
}