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

    /// <summary>Between 0 and 100. For lossy, 0 gives the smallest
    /// size and 100 the largest. For lossless, this
    /// parameter is the amount of effort put into the
    /// compression: 0 is the fastest but gives larger
    /// files compared to the slowest, but best, 100.</summary>
    public float quality;

    /// <summary>Quality/speed trade-off (0=fast, 6=slower-better)</summary>
    public int method;

    /// <summary>Hint for image type (lossless only for now).</summary>
    public WebPImageHint image_hint;

    /// <summary>If non-zero, set the desired target size in bytes.
    ///  Takes precedence over the 'compression' parameter.</summary>
    public int target_size;

    /// <summary>If non-zero, specifies the minimal distortion to
    /// try to achieve. Takes precedence over target_size.</summary>
    public float target_PSNR;

    /// <summary>Maximum number of segments to use, in [1..4]</summary>
    public int segments;

    /// <summary>The amplitude of the spatial noise shaping.
    /// Spatial noise shaping (SNS) refers to a general collection of built-in algorithms used to
    /// decide which area of the picture should use relatively less bits, and where else to better transfer these bits.
    /// The possible range goes from 0 (algorithm is off) to 100 (the maximal effect). The default value is 80.</summary>
    public int sns_strength;

    /// <summary>The strength of the deblocking filter, between 0 (no filtering) and 100 (maximum filtering).
    /// A value of 0 turns off any filtering. Higher values increase the strength of the filtering process applied after decoding the image.
    /// The higher the value, the smoother the image appears. Typical values are usually in the range of 20 to 50.</summary>
    public int filter_strength;

    /// <summary>Filter sharpness. Range: [0 = off .. 7 = least sharp]</summary>
    public int filter_sharpness;

    /// <summary>Filtering type: 0 = simple, 1 = strong (only used
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

    /// <summary>The compression value for alpha compression between 0 (smallest size) and 100 (lossless).
    /// Lossless compression of alpha is achieved using a value of 100,
    /// while the lower values result in a lossy compression. The default is 100.</summary>
    public int alpha_quality;

    /// <summary>Number of entropy-analysis passes (in [1..10]).</summary>
    public int pass;

    /// <summary>If true, export the compressed picture back.
    /// In-loop filtering is not applied.</summary>
    public int show_compressed;

    /// <summary>Preprocessing filter:
    /// 0=none, 1=segment-smooth, 2=pseudo-random dithering</summary>
    public int preprocessing;

    /// <summary>log2(number of token partitions) in [0..3]. Default
    /// is set to 0 for easier progressive decoding.</summary>
    public int partitions;

    /// <summary>Quality degradation allowed to fit the 512k limit
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

    /// <summary>If needed, use sharp (and slow) RGB->YUV conversion</summary>
    public int use_sharp_yuv;

    /// <summary>Minimum permissible quality factor</summary>
    public int qmin;

    /// <summary>Maximum permissible quality factor</summary>
    public int qmax;
}