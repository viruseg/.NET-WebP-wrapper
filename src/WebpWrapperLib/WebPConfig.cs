// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Runtime.InteropServices;

namespace WebpWrapper;

/// <summary>Compression parameters</summary>
[StructLayout(LayoutKind.Sequential)]
public struct WebPConfig
{
    /// <summary>Lossless encoding (0=lossy(default), 1=lossless).</summary>
    public int lossless;

    /// <summary>between 0 and 100. For lossy, 0 gives the smallest
    /// size and 100 the largest. For lossless, this
    /// parameter is the amount of effort put into the
    /// compression: 0 is the fastest but gives larger
    /// files compared to the slowest, but best, 100.</summary>
    public float quality;

    /// <summary>quality/speed trade-off (0=fast, 6=slower-better)</summary>
    public int method;

    /// <summary>Hint for image type (lossless only for now).</summary>
    public WebPImageHint image_hint;

    /// <summary>if non-zero, set the desired target size in bytes.
    ///  Takes precedence over the 'compression' parameter.</summary>
    public int target_size;

    /// <summary>if non-zero, specifies the minimal distortion to
    /// try to achieve. Takes precedence over target_size.</summary>
    public float target_PSNR;

    /// <summary>maximum number of segments to use, in [1..4]</summary>
    public int segments;

    /// <summary>Spatial Noise Shaping. 0=off, 100=maximum.</summary>
    public int sns_strength;

    /// <summary>range: [0 = off .. 100 = strongest]</summary>
    public int filter_strength;

    /// <summary>range: [0 = off .. 7 = least sharp]</summary>
    public int filter_sharpness;

    /// <summary>filtering type: 0 = simple, 1 = strong (only used
    /// if filter_strength > 0 or autofilter > 0)</summary>
    public int filter_type;

    /// <summary>Auto adjust filter's strength [0 = off, 1 = on]</summary>
    public int autofilter;

    /// <summary>Algorithm for encoding the alpha plane (0 = none,
    /// 1 = compressed with WebP lossless). Default is 1.</summary>
    public int alpha_compression;

    /// <summary>Predictive filtering method for alpha plane.
    /// 0: none, 1: fast, 2: best. Default if 1.</summary>
    public int alpha_filtering;

    /// <summary>Between 0 (smallest size) and 100 (lossless).
    /// Default is 100.</summary>
    public int alpha_quality;

    /// <summary>number of entropy-analysis passes (in [1..10]).</summary>
    public int pass;

    /// <summary>if true, export the compressed picture back.
    /// In-loop filtering is not applied.</summary>
    public int show_compressed;

    /// <summary>preprocessing filter:
    /// 0=none, 1=segment-smooth, 2=pseudo-random dithering</summary>
    public int preprocessing;

    /// <summary>log2(number of token partitions) in [0..3]. Default
    /// is set to 0 for easier progressive decoding.</summary>
    public int partitions;

    /// <summary>quality degradation allowed to fit the 512k limit
    /// on prediction modes coding (0: no degradation,
    /// 100: maximum possible degradation).</summary>
    public int partition_limit;

    /// <summary>If true, compression parameters will be remapped
    /// to better match the expected output size from
    /// JPEG compression. Generally, the output size will
    /// be similar but the degradation will be lower.</summary>
    public int emulate_jpeg_size;

    /// <summary>If non-zero, try and use multi-threaded encoding.</summary>
    public int thread_level;

    /// <summary>If set, reduce memory usage (but increase CPU use).</summary>
    public int low_memory;

    /// <summary>Near lossless encoding [0 = max loss .. 100 = off (default)].</summary>
    public int near_lossless;

    /// <summary>if non-zero, preserve the exact RGB values under
    /// transparent area. Otherwise, discard this invisible
    /// RGB information for better compression. The default
    /// value is 0.</summary>
    public int exact;

    /// <summary>reserved for future lossless feature</summary>
    public int use_delta_palette;

    /// <summary>if needed, use sharp (and slow) RGB->YUV conversion</summary>
    public int use_sharp_yuv;

    /// <summary>minimum permissible quality factor</summary>
    public int qmin;

    /// <summary>maximum permissible quality factor</summary>
    public int qmax;
}