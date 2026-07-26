using System.Runtime.CompilerServices;
using WebpWrapper;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

/// <summary>Main exchange structure (input samples, output bytes, statistics)</summary>
internal unsafe struct WebPPicture
{
    /// <summary>Main flag for encoder selecting between ARGB or YUV input. Recommended to use ARGB input (*argb, argb_stride) for lossless, and YUV input (*y, *u, *v, etc.) for lossy</summary>
    public int use_argb;

    /// <summary>Color-space: should be YUV420 for now (=Y'CbCr). Value = 0</summary>
    public WebPEncCSP colorspace;

    /// <summary>Width of picture (less or equal to WEBP_MAX_DIMENSION)</summary>
    public int width;

    /// <summary>Height of picture (less or equal to WEBP_MAX_DIMENSION)</summary>
    public int height;

    /// <summary>Pointer to luma plane</summary>
    [NativeTypeName("uint8_t *")]
    public byte* y;

    /// <summary>Pointer to chroma U plane</summary>
    [NativeTypeName("uint8_t *")]
    public byte* u;

    /// <summary>Pointer to chroma V plane</summary>
    [NativeTypeName("uint8_t *")]
    public byte* v;

    /// <summary>Luma stride</summary>
    public int y_stride;

    /// <summary>Chroma stride</summary>
    public int uv_stride;

    /// <summary>Pointer to the alpha plane</summary>
    [NativeTypeName("uint8_t *")]
    public byte* a;

    /// <summary>stride of the alpha plane</summary>
    public int a_stride;

    /// <summary>Padding for later use</summary>
    [NativeTypeName("uint32_t[2]")]
    public _pad1_e__FixedBuffer pad1;

    /// <summary>Pointer to ARGB (32 bit) plane</summary>
    [NativeTypeName("uint32_t *")]
    public uint* argb;

    /// <summary>This is stride in pixels units, not bytes</summary>
    public int argb_stride;

    /// <summary>Padding for later use</summary>
    [NativeTypeName("uint32_t[3]")]
    public _pad2_e__FixedBuffer pad2;

    /// <summary>Byte-emission hook, to store compressed bytes as they are ready</summary>
    [NativeTypeName("WebPWriterFunction")]
    public delegate* unmanaged[Cdecl]<byte*, nuint, WebPPicture*, int> writer;

    /// <summary>Can be used by the writer</summary>
    public void* custom_ptr;
    /// <summary>
    /// Map for extra information (only for lossy compression mode).
    /// 1: intra type, 2: segment, 3: quant, 4: intra-16 prediction mode, 5: chroma prediction mode, 6: bit cost, 7: distortion
    /// </summary>
    public int extra_info_type;

    /// <summary>If not NULL, points to an array of size ((width + 15) / 16) * ((height + 15) / 16) that will be filled with a macroblock map, depending on extra_info_type</summary>
    [NativeTypeName("uint8_t *")]
    public byte* extra_info;

    /// <summary>Pointer to side statistics (updated only if not NULL)</summary>
    public WebPAuxStats* stats;

    /// <summary>Error code for the latest error encountered during encoding</summary>
    public WebPEncodingError error_code;

    /// <summary>If not NULL, report progress during encoding</summary>
    [NativeTypeName("WebPProgressHook")]
    public delegate* unmanaged[Cdecl]<int, WebPPicture*, int> progress_hook;

    /// <summary>This field is free to be set to any value and used during callbacks (like progress-report e.g.)</summary>
    public void* user_data;

    /// <summary>Padding for later use</summary>
    [NativeTypeName("uint32_t[3]")]
    public _pad3_e__FixedBuffer pad3;

    /// <summary>Unused for now</summary>
    [NativeTypeName("uint8_t *")]
    public byte* pad4;

    /// <summary>Unused for now</summary>
    [NativeTypeName("uint8_t *")]
    public byte* pad5;

    /// <summary>Padding for later use</summary>
    [NativeTypeName("uint32_t[8]")]
    public _pad6_e__FixedBuffer pad6;

    // PRIVATE FIELDS
    /// <summary>row chunk of memory for yuva planes</summary>
    public void* memory_;

    /// <summary>and for argb too.</summary>
    public void* memory_argb_;

    /// <summary>Padding for later use</summary>
    [NativeTypeName("void *[2]")]
    public _pad7_e__FixedBuffer pad7;

    [InlineArray(2)]
    public struct _pad1_e__FixedBuffer
    {
        public uint e0;
    }

    [InlineArray(3)]
    public struct _pad2_e__FixedBuffer
    {
        public uint e0;
    }

    [InlineArray(3)]
    public struct _pad3_e__FixedBuffer
    {
        public uint e0;
    }

    [InlineArray(8)]
    public struct _pad6_e__FixedBuffer
    {
        public uint e0;
    }

    public unsafe struct _pad7_e__FixedBuffer
    {
        public void* e0;
        public void* e1;

        public ref void* this[int index]
        {
            get
            {
                fixed (void** pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}