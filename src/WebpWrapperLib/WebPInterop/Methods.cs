using System.Runtime.InteropServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal static unsafe partial class Methods
{
    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void* WebPMalloc([NativeTypeName("size_t")] nuint size);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPFree(void* ptr);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPGetDecoderVersion();

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPGetInfo([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, int* width, int* height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeRGBA([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, int* width, int* height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeARGB([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, int* width, int* height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeBGRA([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, int* width, int* height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeRGB([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, int* width, int* height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeBGR([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, int* width, int* height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeYUV([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, int* width, int* height, [NativeTypeName("uint8_t **")] byte** u, [NativeTypeName("uint8_t **")] byte** v, int* stride, int* uv_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeRGBAInto([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("uint8_t *")] byte* output_buffer, [NativeTypeName("size_t")] nuint output_buffer_size, int output_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeARGBInto([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("uint8_t *")] byte* output_buffer, [NativeTypeName("size_t")] nuint output_buffer_size, int output_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeBGRAInto([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("uint8_t *")] byte* output_buffer, [NativeTypeName("size_t")] nuint output_buffer_size, int output_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeRGBInto([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("uint8_t *")] byte* output_buffer, [NativeTypeName("size_t")] nuint output_buffer_size, int output_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeBGRInto([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("uint8_t *")] byte* output_buffer, [NativeTypeName("size_t")] nuint output_buffer_size, int output_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPDecodeYUVInto([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("uint8_t *")] byte* luma, [NativeTypeName("size_t")] nuint luma_size, int luma_stride, [NativeTypeName("uint8_t *")] byte* u, [NativeTypeName("size_t")] nuint u_size, int u_stride, [NativeTypeName("uint8_t *")] byte* v, [NativeTypeName("size_t")] nuint v_size, int v_stride);

    public static int WebPIsPremultipliedMode(WEBP_CSP_MODE mode)
    {
        return (mode == WEBP_CSP_MODE.MODE_rgbA || mode == WEBP_CSP_MODE.MODE_bgrA || mode == WEBP_CSP_MODE.MODE_Argb || mode == WEBP_CSP_MODE.MODE_rgbA_4444) ? 1 : 0;
    }

    public static int WebPIsAlphaMode(WEBP_CSP_MODE mode)
    {
        return (mode == WEBP_CSP_MODE.MODE_RGBA || mode == WEBP_CSP_MODE.MODE_BGRA || mode == WEBP_CSP_MODE.MODE_ARGB || mode == WEBP_CSP_MODE.MODE_RGBA_4444 || mode == WEBP_CSP_MODE.MODE_YUVA || (WebPIsPremultipliedMode(mode)) != 0) ? 1 : 0;
    }

    public static int WebPIsRGBMode(WEBP_CSP_MODE mode)
    {
        return mode < WEBP_CSP_MODE.MODE_YUV ? 1 : 0;
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPInitDecBufferInternal(WebPDecBuffer* param0, int param1);

    public static int WebPInitDecBuffer(WebPDecBuffer* buffer)
    {
        return WebPInitDecBufferInternal(buffer, 0x0210);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPFreeDecBuffer(WebPDecBuffer* buffer);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPIDecoder* WebPINewDecoder(WebPDecBuffer* output_buffer);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPIDecoder* WebPINewRGB(WEBP_CSP_MODE csp, [NativeTypeName("uint8_t *")] byte* output_buffer, [NativeTypeName("size_t")] nuint output_buffer_size, int output_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPIDecoder* WebPINewYUVA([NativeTypeName("uint8_t *")] byte* luma, [NativeTypeName("size_t")] nuint luma_size, int luma_stride, [NativeTypeName("uint8_t *")] byte* u, [NativeTypeName("size_t")] nuint u_size, int u_stride, [NativeTypeName("uint8_t *")] byte* v, [NativeTypeName("size_t")] nuint v_size, int v_stride, [NativeTypeName("uint8_t *")] byte* a, [NativeTypeName("size_t")] nuint a_size, int a_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPIDecoder* WebPINewYUV([NativeTypeName("uint8_t *")] byte* luma, [NativeTypeName("size_t")] nuint luma_size, int luma_stride, [NativeTypeName("uint8_t *")] byte* u, [NativeTypeName("size_t")] nuint u_size, int u_stride, [NativeTypeName("uint8_t *")] byte* v, [NativeTypeName("size_t")] nuint v_size, int v_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPIDelete(WebPIDecoder* idec);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial VP8StatusCode WebPIAppend(WebPIDecoder* idec, [NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial VP8StatusCode WebPIUpdate(WebPIDecoder* idec, [NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPIDecGetRGB([NativeTypeName("const WebPIDecoder *")] WebPIDecoder* idec, int* last_y, int* width, int* height, int* stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint8_t *")]
    public static partial byte* WebPIDecGetYUVA([NativeTypeName("const WebPIDecoder *")] WebPIDecoder* idec, int* last_y, [NativeTypeName("uint8_t **")] byte** u, [NativeTypeName("uint8_t **")] byte** v, [NativeTypeName("uint8_t **")] byte** a, int* width, int* height, int* stride, int* uv_stride, int* a_stride);

    [return: NativeTypeName("uint8_t *")]
    public static byte* WebPIDecGetYUV([NativeTypeName("const WebPIDecoder *")] WebPIDecoder* idec, int* last_y, [NativeTypeName("uint8_t **")] byte** u, [NativeTypeName("uint8_t **")] byte** v, int* width, int* height, int* stride, int* uv_stride)
    {
        return WebPIDecGetYUVA(idec, last_y, u, v, null, width, height, stride, uv_stride, null);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const WebPDecBuffer *")]
    public static partial WebPDecBuffer* WebPIDecodedArea([NativeTypeName("const WebPIDecoder *")] WebPIDecoder* idec, int* left, int* top, int* width, int* height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial VP8StatusCode WebPGetFeaturesInternal([NativeTypeName("const uint8_t *")] byte* param0, [NativeTypeName("size_t")] nuint param1, WebPBitstreamFeatures* param2, int param3);

    public static VP8StatusCode WebPGetFeatures([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, WebPBitstreamFeatures* features)
    {
        return WebPGetFeaturesInternal(data, data_size, features, 0x0210);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPInitDecoderConfigInternal(WebPDecoderConfig* param0, int param1);

    public static int WebPInitDecoderConfig(WebPDecoderConfig* config)
    {
        return WebPInitDecoderConfigInternal(config, 0x0210);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPValidateDecoderConfig([NativeTypeName("const WebPDecoderConfig *")] WebPDecoderConfig* config);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPIDecoder* WebPIDecode([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, WebPDecoderConfig* config);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial VP8StatusCode WebPDecode([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, WebPDecoderConfig* config);

    [NativeTypeName("#define WEBP_DECODER_ABI_VERSION WEBP_DECODER_ABI_VERSION")]
    public const int WEBP_DECODER_ABI_VERSION = 0x0210;

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPGetEncoderVersion();

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WebPEncodeRGB([NativeTypeName("const uint8_t *")] byte* rgb, int width, int height, int stride, float quality_factor, [NativeTypeName("uint8_t **")] byte** output);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WebPEncodeBGR([NativeTypeName("const uint8_t *")] byte* bgr, int width, int height, int stride, float quality_factor, [NativeTypeName("uint8_t **")] byte** output);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WebPEncodeRGBA([NativeTypeName("const uint8_t *")] byte* rgba, int width, int height, int stride, float quality_factor, [NativeTypeName("uint8_t **")] byte** output);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WebPEncodeBGRA([NativeTypeName("const uint8_t *")] byte* bgra, int width, int height, int stride, float quality_factor, [NativeTypeName("uint8_t **")] byte** output);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WebPEncodeLosslessRGB([NativeTypeName("const uint8_t *")] byte* rgb, int width, int height, int stride, [NativeTypeName("uint8_t **")] byte** output);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WebPEncodeLosslessBGR([NativeTypeName("const uint8_t *")] byte* bgr, int width, int height, int stride, [NativeTypeName("uint8_t **")] byte** output);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WebPEncodeLosslessRGBA([NativeTypeName("const uint8_t *")] byte* rgba, int width, int height, int stride, [NativeTypeName("uint8_t **")] byte** output);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WebPEncodeLosslessBGRA([NativeTypeName("const uint8_t *")] byte* bgra, int width, int height, int stride, [NativeTypeName("uint8_t **")] byte** output);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPConfigInitInternal(WebPConfig* param0, WebPPreset param1, float param2, int param3);

    public static int WebPConfigInit(WebPConfig* config)
    {
        return WebPConfigInitInternal(config, WebPPreset.WEBP_PRESET_DEFAULT, 75.0f, 0x0210);
    }

    public static int WebPConfigPreset(WebPConfig* config, WebPPreset preset, float quality)
    {
        return WebPConfigInitInternal(config, preset, quality, 0x0210);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPConfigLosslessPreset(WebPConfig* config, int level);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPValidateConfig([NativeTypeName("const WebPConfig *")] WebPConfig* config);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPMemoryWriterInit(WebPMemoryWriter* writer);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPMemoryWriterClear(WebPMemoryWriter* writer);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPMemoryWrite([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("const WebPPicture *")] WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureInitInternal(WebPPicture* param0, int param1);

    public static int WebPPictureInit(WebPPicture* picture)
    {
        return WebPPictureInitInternal(picture, 0x0210);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureAlloc(WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPPictureFree(WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureCopy([NativeTypeName("const WebPPicture *")] WebPPicture* src, WebPPicture* dst);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPlaneDistortion([NativeTypeName("const uint8_t *")] byte* src, [NativeTypeName("size_t")] nuint src_stride, [NativeTypeName("const uint8_t *")] byte* @ref, [NativeTypeName("size_t")] nuint ref_stride, int width, int height, [NativeTypeName("size_t")] nuint x_step, int type, float* distortion, float* result);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureDistortion([NativeTypeName("const WebPPicture *")] WebPPicture* src, [NativeTypeName("const WebPPicture *")] WebPPicture* @ref, int metric_type, [NativeTypeName("float[5]")] float* result);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureCrop(WebPPicture* picture, int left, int top, int width, int height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureView([NativeTypeName("const WebPPicture *")] WebPPicture* src, int left, int top, int width, int height, WebPPicture* dst);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureIsView([NativeTypeName("const WebPPicture *")] WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureRescale(WebPPicture* picture, int width, int height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureImportRGB(WebPPicture* picture, [NativeTypeName("const uint8_t *")] byte* rgb, int rgb_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureImportRGBA(WebPPicture* picture, [NativeTypeName("const uint8_t *")] byte* rgba, int rgba_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureImportRGBX(WebPPicture* picture, [NativeTypeName("const uint8_t *")] byte* rgbx, int rgbx_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureImportBGR(WebPPicture* picture, [NativeTypeName("const uint8_t *")] byte* bgr, int bgr_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureImportBGRA(WebPPicture* picture, [NativeTypeName("const uint8_t *")] byte* bgra, int bgra_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureImportBGRX(WebPPicture* picture, [NativeTypeName("const uint8_t *")] byte* bgrx, int bgrx_stride);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureARGBToYUVA(WebPPicture* picture, WebPEncCSP param1);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureARGBToYUVADithered(WebPPicture* picture, WebPEncCSP colorspace, float dithering);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureSharpARGBToYUVA(WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureSmartARGBToYUVA(WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureYUVAToARGB(WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPCleanupTransparentArea(WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPPictureHasTransparency([NativeTypeName("const WebPPicture *")] WebPPicture* picture);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPBlendAlpha(WebPPicture* picture, [NativeTypeName("uint32_t")] uint background_rgb);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPEncode([NativeTypeName("const WebPConfig *")] WebPConfig* config, WebPPicture* picture);

    [NativeTypeName("#define WEBP_ENCODER_ABI_VERSION 0x0210")]
    public const int WEBP_ENCODER_ABI_VERSION = 0x0210;

    [NativeTypeName("#define WEBP_MAX_DIMENSION 16383")]
    public const int WEBP_MAX_DIMENSION = 16383;

    [NativeTypeName("#define VP8_SIGNATURE 0x9d012a")]
    public const int VP8_SIGNATURE = 0x9d012a;

    [NativeTypeName("#define VP8_MAX_PARTITION0_SIZE (1 << 19)")]
    public const int VP8_MAX_PARTITION0_SIZE = (1 << 19);

    [NativeTypeName("#define VP8_MAX_PARTITION_SIZE (1 << 24)")]
    public const int VP8_MAX_PARTITION_SIZE = (1 << 24);

    [NativeTypeName("#define VP8_FRAME_HEADER_SIZE 10")]
    public const int VP8_FRAME_HEADER_SIZE = 10;

    [NativeTypeName("#define VP8L_SIGNATURE_SIZE 1")]
    public const int VP8L_SIGNATURE_SIZE = 1;

    [NativeTypeName("#define VP8L_MAGIC_BYTE 0x2f")]
    public const int VP8L_MAGIC_BYTE = 0x2f;

    [NativeTypeName("#define VP8L_IMAGE_SIZE_BITS 14")]
    public const int VP8L_IMAGE_SIZE_BITS = 14;

    [NativeTypeName("#define VP8L_VERSION_BITS 3")]
    public const int VP8L_VERSION_BITS = 3;

    [NativeTypeName("#define VP8L_VERSION 0")]
    public const int VP8L_VERSION = 0;

    [NativeTypeName("#define VP8L_FRAME_HEADER_SIZE 5")]
    public const int VP8L_FRAME_HEADER_SIZE = 5;

    [NativeTypeName("#define MAX_PALETTE_SIZE 256")]
    public const int MAX_PALETTE_SIZE = 256;

    [NativeTypeName("#define MAX_CACHE_BITS 11")]
    public const int MAX_CACHE_BITS = 11;

    [NativeTypeName("#define HUFFMAN_CODES_PER_META_CODE 5")]
    public const int HUFFMAN_CODES_PER_META_CODE = 5;

    [NativeTypeName("#define ARGB_BLACK 0xff000000")]
    public const uint ARGB_BLACK = 0xff000000;

    [NativeTypeName("#define DEFAULT_CODE_LENGTH 8")]
    public const int DEFAULT_CODE_LENGTH = 8;

    [NativeTypeName("#define MAX_ALLOWED_CODE_LENGTH 15")]
    public const int MAX_ALLOWED_CODE_LENGTH = 15;

    [NativeTypeName("#define NUM_LITERAL_CODES 256")]
    public const int NUM_LITERAL_CODES = 256;

    [NativeTypeName("#define NUM_LENGTH_CODES 24")]
    public const int NUM_LENGTH_CODES = 24;

    [NativeTypeName("#define NUM_DISTANCE_CODES 40")]
    public const int NUM_DISTANCE_CODES = 40;

    [NativeTypeName("#define CODE_LENGTH_CODES 19")]
    public const int CODE_LENGTH_CODES = 19;

    [NativeTypeName("#define MIN_HUFFMAN_BITS 2")]
    public const int MIN_HUFFMAN_BITS = 2;

    [NativeTypeName("#define NUM_HUFFMAN_BITS 3")]
    public const int NUM_HUFFMAN_BITS = 3;

    [NativeTypeName("#define MIN_TRANSFORM_BITS 2")]
    public const int MIN_TRANSFORM_BITS = 2;

    [NativeTypeName("#define NUM_TRANSFORM_BITS 3")]
    public const int NUM_TRANSFORM_BITS = 3;

    [NativeTypeName("#define TRANSFORM_PRESENT 1")]
    public const int TRANSFORM_PRESENT = 1;

    [NativeTypeName("#define NUM_TRANSFORMS 4")]
    public const int NUM_TRANSFORMS = 4;

    [NativeTypeName("#define ALPHA_HEADER_LEN 1")]
    public const int ALPHA_HEADER_LEN = 1;

    [NativeTypeName("#define ALPHA_NO_COMPRESSION 0")]
    public const int ALPHA_NO_COMPRESSION = 0;

    [NativeTypeName("#define ALPHA_LOSSLESS_COMPRESSION 1")]
    public const int ALPHA_LOSSLESS_COMPRESSION = 1;

    [NativeTypeName("#define ALPHA_PREPROCESSED_LEVELS 1")]
    public const int ALPHA_PREPROCESSED_LEVELS = 1;

    [NativeTypeName("#define TAG_SIZE 4")]
    public const int TAG_SIZE = 4;

    [NativeTypeName("#define CHUNK_SIZE_BYTES 4")]
    public const int CHUNK_SIZE_BYTES = 4;

    [NativeTypeName("#define CHUNK_HEADER_SIZE 8")]
    public const int CHUNK_HEADER_SIZE = 8;

    [NativeTypeName("#define RIFF_HEADER_SIZE 12")]
    public const int RIFF_HEADER_SIZE = 12;

    [NativeTypeName("#define ANMF_CHUNK_SIZE 16")]
    public const int ANMF_CHUNK_SIZE = 16;

    [NativeTypeName("#define ANIM_CHUNK_SIZE 6")]
    public const int ANIM_CHUNK_SIZE = 6;

    [NativeTypeName("#define VP8X_CHUNK_SIZE 10")]
    public const int VP8X_CHUNK_SIZE = 10;

    [NativeTypeName("#define MAX_CANVAS_SIZE (1 << 24)")]
    public const int MAX_CANVAS_SIZE = (1 << 24);

    [NativeTypeName("#define MAX_IMAGE_AREA (1ULL << 32)")]
    public const ulong MAX_IMAGE_AREA = (1UL << 32);

    [NativeTypeName("#define MAX_LOOP_COUNT (1 << 16)")]
    public const int MAX_LOOP_COUNT = (1 << 16);

    [NativeTypeName("#define MAX_DURATION (1 << 24)")]
    public const int MAX_DURATION = (1 << 24);

    [NativeTypeName("#define MAX_POSITION_OFFSET (1 << 24)")]
    public const int MAX_POSITION_OFFSET = (1 << 24);

    [NativeTypeName("#define MAX_CHUNK_PAYLOAD (~0U - CHUNK_HEADER_SIZE - 1)")]
    public const uint MAX_CHUNK_PAYLOAD = (~0U - 8 - 1);

    public static void WebPDataInit(WebPData* webp_data)
    {
        if (webp_data != null)
        {
            NativeMemory.Fill(webp_data, (uint)(sizeof(WebPData)), 0);
        }
    }

    public static void WebPDataClear(WebPData* webp_data)
    {
        if (webp_data != null)
        {
            WebPFree(unchecked((void*)(webp_data->bytes)));
            WebPDataInit(webp_data);
        }
    }

    public static int WebPDataCopy([NativeTypeName("const WebPData *")] WebPData* src, WebPData* dst)
    {
        if (src == null || dst == null)
        {
            return 0;
        }

        WebPDataInit(dst);
        if (src->bytes != null && src->size != 0)
        {
            dst->bytes = (byte*)(WebPMalloc(src->size));
            if (dst->bytes == null)
            {
                return 0;
            }

            NativeMemory.Copy(src->bytes, (void*)(dst->bytes), src->size);
            dst->size = src->size;
        }

        return 1;
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPGetMuxVersion();

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMux* WebPNewInternal(int param0);

    public static WebPMux* WebPMuxNew()
    {
        return WebPNewInternal(0x0109);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPMuxDelete(WebPMux* mux);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMux* WebPMuxCreateInternal([NativeTypeName("const WebPData *")] WebPData* param0, int param1, int param2);

    public static WebPMux* WebPMuxCreate([NativeTypeName("const WebPData *")] WebPData* bitstream, int copy_data)
    {
        return WebPMuxCreateInternal(bitstream, copy_data, 0x0109);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxSetChunk(WebPMux* mux, [NativeTypeName("const char[4]")] sbyte* fourcc, [NativeTypeName("const WebPData *")] WebPData* chunk_data, int copy_data);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxGetChunk([NativeTypeName("const WebPMux *")] WebPMux* mux, [NativeTypeName("const char[4]")] sbyte* fourcc, WebPData* chunk_data);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxDeleteChunk(WebPMux* mux, [NativeTypeName("const char[4]")] sbyte* fourcc);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxSetImage(WebPMux* mux, [NativeTypeName("const WebPData *")] WebPData* bitstream, int copy_data);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxPushFrame(WebPMux* mux, [NativeTypeName("const WebPMuxFrameInfo *")] WebPMuxFrameInfo* frame, int copy_data);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxGetFrame([NativeTypeName("const WebPMux *")] WebPMux* mux, [NativeTypeName("uint32_t")] uint nth, WebPMuxFrameInfo* frame);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxDeleteFrame(WebPMux* mux, [NativeTypeName("uint32_t")] uint nth);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxSetAnimationParams(WebPMux* mux, [NativeTypeName("const WebPMuxAnimParams *")] WebPMuxAnimParams* @params);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxGetAnimationParams([NativeTypeName("const WebPMux *")] WebPMux* mux, WebPMuxAnimParams* @params);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxSetCanvasSize(WebPMux* mux, int width, int height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxGetCanvasSize([NativeTypeName("const WebPMux *")] WebPMux* mux, int* width, int* height);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxGetFeatures([NativeTypeName("const WebPMux *")] WebPMux* mux, [NativeTypeName("uint32_t *")] uint* flags);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxNumChunks([NativeTypeName("const WebPMux *")] WebPMux* mux, WebPChunkId id, int* num_elements);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPMuxAssemble(WebPMux* mux, WebPData* assembled_data);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPAnimEncoderOptionsInitInternal(WebPAnimEncoderOptions* param0, int param1);

    public static int WebPAnimEncoderOptionsInit(WebPAnimEncoderOptions* enc_options)
    {
        return WebPAnimEncoderOptionsInitInternal(enc_options, 0x0109);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPAnimEncoder* WebPAnimEncoderNewInternal(int param0, int param1, [NativeTypeName("const WebPAnimEncoderOptions *")] WebPAnimEncoderOptions* param2, int param3);

    public static WebPAnimEncoder* WebPAnimEncoderNew(int width, int height, [NativeTypeName("const WebPAnimEncoderOptions *")] WebPAnimEncoderOptions* enc_options)
    {
        return WebPAnimEncoderNewInternal(width, height, enc_options, 0x0109);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPAnimEncoderAdd(WebPAnimEncoder* enc, [NativeTypeName("struct WebPPicture *")] WebPPicture* frame, int timestamp_ms, [NativeTypeName("const struct WebPConfig *")] WebPConfig* config);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPAnimEncoderAssemble(WebPAnimEncoder* enc, WebPData* webp_data);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial sbyte* WebPAnimEncoderGetError(WebPAnimEncoder* enc);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPAnimEncoderDelete(WebPAnimEncoder* enc);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPAnimEncoderSetChunk(WebPAnimEncoder* enc, [NativeTypeName("const char[4]")] sbyte* fourcc, [NativeTypeName("const WebPData *")] WebPData* chunk_data, int copy_data);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPAnimEncoderGetChunk([NativeTypeName("const WebPAnimEncoder *")] WebPAnimEncoder* enc, [NativeTypeName("const char[4]")] sbyte* fourcc, WebPData* chunk_data);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPMuxError WebPAnimEncoderDeleteChunk(WebPAnimEncoder* enc, [NativeTypeName("const char[4]")] sbyte* fourcc);

    [NativeTypeName("#define WEBP_MUX_ABI_VERSION 0x0109")]
    public const int WEBP_MUX_ABI_VERSION = 0x0109;

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPGetDemuxVersion();

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPDemuxer* WebPDemuxInternal([NativeTypeName("const WebPData *")] WebPData* param0, int param1, WebPDemuxState* param2, int param3);

    public static WebPDemuxer* WebPDemux([NativeTypeName("const WebPData *")] WebPData* data)
    {
        return WebPDemuxInternal(data, 0, null, 0x0107);
    }

    public static WebPDemuxer* WebPDemuxPartial([NativeTypeName("const WebPData *")] WebPData* data, WebPDemuxState* state)
    {
        return WebPDemuxInternal(data, 1, state, 0x0107);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPDemuxDelete(WebPDemuxer* dmux);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("uint32_t")]
    public static partial uint WebPDemuxGetI([NativeTypeName("const WebPDemuxer *")] WebPDemuxer* dmux, WebPFormatFeature feature);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPDemuxGetFrame([NativeTypeName("const WebPDemuxer *")] WebPDemuxer* dmux, int frame_number, WebPIterator* iter);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPDemuxNextFrame(WebPIterator* iter);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPDemuxPrevFrame(WebPIterator* iter);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPDemuxReleaseIterator(WebPIterator* iter);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPDemuxGetChunk([NativeTypeName("const WebPDemuxer *")] WebPDemuxer* dmux, [NativeTypeName("const char[4]")] sbyte* fourcc, int chunk_number, WebPChunkIterator* iter);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPDemuxNextChunk(WebPChunkIterator* iter);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPDemuxPrevChunk(WebPChunkIterator* iter);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPDemuxReleaseChunkIterator(WebPChunkIterator* iter);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPAnimDecoderOptionsInitInternal(WebPAnimDecoderOptions* param0, int param1);

    public static int WebPAnimDecoderOptionsInit(WebPAnimDecoderOptions* dec_options)
    {
        return WebPAnimDecoderOptionsInitInternal(dec_options, 0x0107);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial WebPAnimDecoder* WebPAnimDecoderNewInternal([NativeTypeName("const WebPData *")] WebPData* param0, [NativeTypeName("const WebPAnimDecoderOptions *")] WebPAnimDecoderOptions* param1, int param2);

    public static WebPAnimDecoder* WebPAnimDecoderNew([NativeTypeName("const WebPData *")] WebPData* webp_data, [NativeTypeName("const WebPAnimDecoderOptions *")] WebPAnimDecoderOptions* dec_options)
    {
        return WebPAnimDecoderNewInternal(webp_data, dec_options, 0x0107);
    }

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPAnimDecoderGetInfo([NativeTypeName("const WebPAnimDecoder *")] WebPAnimDecoder* dec, WebPAnimInfo* info);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPAnimDecoderGetNext(WebPAnimDecoder* dec, [NativeTypeName("uint8_t **")] byte** buf, int* timestamp);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WebPAnimDecoderHasMoreFrames([NativeTypeName("const WebPAnimDecoder *")] WebPAnimDecoder* dec);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPAnimDecoderReset(WebPAnimDecoder* dec);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const WebPDemuxer *")]
    public static partial WebPDemuxer* WebPAnimDecoderGetDemuxer([NativeTypeName("const WebPAnimDecoder *")] WebPAnimDecoder* dec);

    [LibraryImport("runtimes/win-x64/native/libwebp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WebPAnimDecoderDelete(WebPAnimDecoder* dec);

    [NativeTypeName("#define WEBP_DEMUX_ABI_VERSION 0x0107")]
    public const int WEBP_DEMUX_ABI_VERSION = 0x0107;
}