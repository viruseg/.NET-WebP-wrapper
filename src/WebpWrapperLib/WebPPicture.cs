// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Runtime.InteropServices;

namespace WebpWrapper;

/// <summary>Main exchange structure (input samples, output bytes, statistics)</summary>
[StructLayout(LayoutKind.Sequential)]
internal struct WebPPicture
{
    /// <summary>Main flag for encoder selecting between ARGB or YUV input. Recommended to use ARGB input (*argb, argb_stride) for lossless, and YUV input (*y, *u, *v, etc.) for lossy</summary>
    public int use_argb;

    /// <summary>Color-space: should be YUV420 for now (=Y'CbCr). Value = 0</summary>
    public UInt32 colorspace;

    /// <summary>Width of picture (less or equal to WEBP_MAX_DIMENSION)</summary>
    public int width;

    /// <summary>Height of picture (less or equal to WEBP_MAX_DIMENSION)</summary>
    public int height;

    /// <summary>Pointer to luma plane</summary>
    public IntPtr y;

    /// <summary>Pointer to chroma U plane</summary>
    public IntPtr u;

    /// <summary>Pointer to chroma V plane</summary>
    public IntPtr v;

    /// <summary>Luma stride</summary>
    public int y_stride;

    /// <summary>Chroma stride</summary>
    public int uv_stride;

    /// <summary>Pointer to the alpha plane</summary>
    public IntPtr a;

    /// <summary>stride of the alpha plane</summary>
    public int a_stride;

    /// <summary>Padding for later use</summary>
    private readonly UInt32 pad1_0, pad1_1;

    /// <summary>Pointer to ARGB (32 bit) plane</summary>
    public IntPtr argb;

    /// <summary>This is stride in pixels units, not bytes</summary>
    public int argb_stride;

    /// <summary>Padding for later use</summary>
    private readonly UInt32 pad2_0, pad2_1, pad2_2;

    /// <summary>Byte-emission hook, to store compressed bytes as they are ready</summary>
    public IntPtr writer;

    /// <summary>Can be used by the writer</summary>
    public IntPtr custom_ptr;

    // map for extra information (only for lossy compression mode)
    /// <summary>1: intra type, 2: segment, 3: quant, 4: intra-16 prediction mode, 5: chroma prediction mode, 6: bit cost, 7: distortion</summary>
    public int extra_info_type;

    /// <summary>If not NULL, points to an array of size ((width + 15) / 16) * ((height + 15) / 16) that will be filled with a macroblock map, depending on extra_info_type</summary>
    public IntPtr extra_info;

    /// <summary>Pointer to side statistics (updated only if not NULL)</summary>
    public IntPtr stats;

    /// <summary>Error code for the latest error encountered during encoding</summary>
    public UInt32 error_code;

    /// <summary>If not NULL, report progress during encoding</summary>
    public IntPtr progress_hook;

    /// <summary>This field is free to be set to any value and used during callbacks (like progress-report e.g.)</summary>
    public IntPtr user_data;

    /// <summary>Padding for later use</summary>
    private readonly UInt32 pad3_0, pad3_1, pad3_2;

    /// <summary>Unused for now</summary>
    public IntPtr pad4;

    /// <summary>Unused for now</summary>
    public IntPtr pad5;

    /// <summary>Padding for later use</summary>
    private readonly UInt32 pad6_0, pad6_1, pad6_2, pad6_3, pad6_4, pad6_5, pad6_6, pad6_7;

    // PRIVATE FIELDS
    /// <summary>row chunk of memory for yuva planes</summary>
    public IntPtr memory_;

    /// <summary>and for argb too.</summary>
    public IntPtr memory_argb_;

    /// <summary>Padding for later use</summary>
    private readonly UInt32 pad7_0, pad7_1;
}