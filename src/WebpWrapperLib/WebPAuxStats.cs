using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapper;

/// <summary>Structure for storing auxiliary statistics (mostly for lossy encoding)</summary>
public struct WebPAuxStats
{
    /// <summary>Final size</summary>
    public int coded_size;

    /// <summary>Peak-signal-to-noise ratio for Y/U/V/All/Alpha</summary>
    [NativeTypeName("float[5]")]
    public _PSNR_e__FixedBuffer PSNR;

    /// <summary>
    /// number of intra4/intra16/skipped macroblocks
    /// </summary>
    [NativeTypeName("int[3]")]
    public _block_count_e__FixedBuffer block_count;

    /// <summary>
    /// approximate number of bytes spent for header and mode-partition #0
    /// </summary>
    [NativeTypeName("int[2]")]
    public _header_bytes_e__FixedBuffer header_bytes;

    /// <summary>
    /// approximate number of bytes spent for DC/AC/uv coefficients for each (0..3) segments
    /// </summary>
    [NativeTypeName("int[3][4]")]
    public _residual_bytes_e__FixedBuffer residual_bytes;

    /// <summary>
    /// number of macroblocks in each segments
    /// </summary>
    [NativeTypeName("int[4]")]
    public _segment_size_e__FixedBuffer segment_size;

    /// <summary>
    /// quantizer values for each segments
    /// </summary>
    [NativeTypeName("int[4]")]
    public _segment_quant_e__FixedBuffer segment_quant;

    /// <summary>
    /// filtering strength for each segments [0..63]
    /// </summary>
    [NativeTypeName("int[4]")]
    public _segment_level_e__FixedBuffer segment_level;

    /// <summary>
    /// size of the transparency data
    /// </summary>
    public int alpha_data_size;

    /// <summary>
    /// size of the enhancement layer data
    /// </summary>
    public int layer_data_size;

    // lossless encoder statistics


    /// <summary>
    /// bit0:predictor bit1:cross-color transform
    /// bit2:subtract-green bit3:color indexing
    /// </summary>
    [NativeTypeName("uint32_t")]
    public uint lossless_features;

    /// <summary>
    /// number of precision bits of histogram
    /// </summary>
    public int histogram_bits;

    /// <summary>
    /// precision bits for predictor transform
    /// </summary>
    public int transform_bits;

    /// <summary>
    /// number of bits for color cache lookup
    /// </summary>
    public int cache_bits;

    /// <summary>
    /// number of color in palette, if used
    /// </summary>
    public int palette_size;

    /// <summary>
    /// final lossless size
    /// </summary>
    public int lossless_size;

    /// <summary>
    /// lossless header (transform, huffman etc) size
    /// </summary>
    public int lossless_hdr_size;

    /// <summary>
    /// lossless image data size
    /// </summary>
    public int lossless_data_size;

    /// <summary>
    /// precision bits for cross-color transform
    /// </summary>
    public int cross_color_transform_bits;

    /// <summary>
    /// padding for later use
    /// </summary>
    [NativeTypeName("uint32_t[1]")]
    public _pad_e__FixedBuffer pad;

    [InlineArray(5)]
    public struct _PSNR_e__FixedBuffer
    {
        public float e0;
    }

    [InlineArray(3)]
    public struct _block_count_e__FixedBuffer
    {
        public int e0;
    }

    [InlineArray(2)]
    public struct _header_bytes_e__FixedBuffer
    {
        public int e0;
    }

    [InlineArray(3 * 4)]
    public struct _residual_bytes_e__FixedBuffer
    {
        public int e0_0;
    }

    [InlineArray(4)]
    public struct _segment_size_e__FixedBuffer
    {
        public int e0;
    }

    [InlineArray(4)]
    public struct _segment_quant_e__FixedBuffer
    {
        public int e0;
    }

    [InlineArray(4)]
    public struct _segment_level_e__FixedBuffer
    {
        public int e0;
    }

    public struct _pad_e__FixedBuffer
    {
        public uint e0;

        [UnscopedRef]
        public ref uint this[int index]
        {
            get
            {
                return ref Unsafe.Add(ref e0, index);
            }
        }

        [UnscopedRef]
        public Span<uint> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
    }
}