using System.Diagnostics.CodeAnalysis;

namespace WebpWrapperLib.WebPInterop;

public struct WebPConfig
{
    /// <summary>Lossless encoding (0=lossy(default), 1=lossless).</summary>
    internal int lossless;

    /// <summary>Between 0 and 100. For lossy, 0 gives the smallest
    /// size and 100 the largest. For lossless, this
    /// parameter is the amount of effort put into the
    /// compression: 0 is the fastest but gives larger
    /// files compared to the slowest, but best, 100.</summary>
    internal float quality;

    /// <summary>Quality/speed trade-off (0=fast, 6=slower-better)</summary>
    internal int method;

    /// <summary>Hint for image type (lossless only for now).</summary>
    internal WebPImageHint image_hint;

    /// <summary>If non-zero, set the desired target size in bytes.
    ///  Takes precedence over the 'compression' parameter.</summary>
    internal int target_size;

    /// <summary>If non-zero, specifies the minimal distortion to
    /// try to achieve. Takes precedence over target_size.</summary>
    internal float target_PSNR;

    /// <summary>Maximum number of segments to use, in [1..4]</summary>
    internal int segments;

    /// <summary>The amplitude of the spatial noise shaping.
    /// Spatial noise shaping (SNS) refers to a general collection of built-in algorithms used to
    /// decide which area of the picture should use relatively less bits, and where else to better transfer these bits.
    /// The possible range goes from 0 (algorithm is off) to 100 (the maximal effect). The default value is 80.</summary>
    internal int sns_strength;

    /// <summary>The strength of the deblocking filter, between 0 (no filtering) and 100 (maximum filtering).
    /// A value of 0 turns off any filtering. Higher values increase the strength of the filtering process applied after decoding the image.
    /// The higher the value, the smoother the image appears. Typical values are usually in the range of 20 to 50.</summary>
    internal int filter_strength;

    /// <summary>Filter sharpness. Range: [0 = off .. 7 = least sharp]</summary>
    internal int filter_sharpness;

    /// <summary>Filtering type: 0 = simple, 1 = strong (only used
    /// if filter_strength > 0 or autofilter > 0)</summary>
    internal int filter_type;

    /// <summary>Auto adjust filter's strength [0 = off, 1 = on]</summary>
    internal int autofilter;

    /// <summary>Algorithm for encoding the alpha plane (0 = none,
    /// 1 = compressed with WebP lossless). Default is 1.</summary>
    internal int alpha_compression;

    /// <summary>Predictive filtering method for alpha plane.
    /// 0: none, 1: fast, 2: best. Default if 1.</summary>
    internal int alpha_filtering;

    /// <summary>The compression value for alpha compression between 0 (smallest size) and 100 (lossless).
    /// Lossless compression of alpha is achieved using a value of 100,
    /// while the lower values result in a lossy compression. The default is 100.</summary>
    internal int alpha_quality;

    /// <summary>Number of entropy-analysis passes (in [1..10]).</summary>
    internal int pass;

    /// <summary>If true, export the compressed picture back.
    /// In-loop filtering is not applied.</summary>
    internal int show_compressed;

    /// <summary>Preprocessing filter:
    /// 0=none, 1=segment-smooth, 2=pseudo-random dithering</summary>
    internal int preprocessing;

    /// <summary>log2(number of token partitions) in [0..3]. Default
    /// is set to 0 for easier progressive decoding.</summary>
    internal int partitions;

    /// <summary>Quality degradation allowed to fit the 512k limit
    /// on prediction modes coding (0: no degradation,
    /// 100: maximum possible degradation).</summary>
    internal int partition_limit;

    /// <summary>If true, compression parameters will be remapped
    /// to better match the expected output size from
    /// JPEG compression. Generally, the output size will
    /// be similar but the degradation will be lower.</summary>
    internal int emulate_jpeg_size;

    /// <summary>If non-zero, try and use multi-threaded encoding.</summary>
    internal int thread_level;

    /// <summary>If set, reduce memory usage (but increase CPU use).</summary>
    internal int low_memory;

    /// <summary>Near lossless encoding [0 = max loss .. 100 = off (default)].</summary>
    internal int near_lossless;

    /// <summary>if non-zero, preserve the exact RGB values under
    /// transparent area. Otherwise, discard this invisible
    /// RGB information for better compression. The default
    /// value is 0.</summary>
    internal int exact;

    /// <summary>reserved for future lossless feature</summary>
    internal int use_delta_palette;

    /// <summary>If needed, use sharp (and slow) RGB->YUV conversion</summary>
    internal int use_sharp_yuv;

    /// <summary>Minimum permissible quality factor</summary>
    internal int qmin;

    /// <summary>Maximum permissible quality factor</summary>
    internal int qmax;



    /// <summary>Lossless encoding (0=lossy(default), 1=lossless).</summary>
    public WebpFormatForConfig Lossless
    {
        get => (WebpFormatForConfig) lossless;
        set => lossless = (int) value;
    }

    /// <summary>Between 0 and 100. For lossy, 0 gives the smallest
    /// size and 100 the largest. For lossless, this
    /// parameter is the amount of effort put into the
    /// compression: 0 is the fastest but gives larger
    /// files compared to the slowest, but best, 100.</summary>
    public float Quality
    {
        get => quality;
        set => quality = Math.Clamp(value, 0, 100);
    }

    /// <summary>Quality/speed trade-off (0=fast, 6=slower-better)</summary>
    public int Method
    {
        get => method;
        set => method = Math.Clamp(value, 0, 6);
    }

    /// <summary>Hint for image type (lossless only for now).</summary>
    public WebPImageHint ImageHint
    {
        get => image_hint;
        set => image_hint = value;
    }

    /// <summary>If non-zero, set the desired target size in bytes.
    ///  Takes precedence over the 'compression' parameter.</summary>
    public int TargetSize
    {
        get => target_size;
        set => target_size = Math.Max(value, 0);
    }

    /// <summary>If non-zero, specifies the minimal distortion to
    /// try to achieve. Takes precedence over target_size.</summary>
    public float TargetPsnr
    {
        get => target_PSNR;
        set => target_PSNR = Math.Max(value, 0);
    }

    /// <summary>Maximum number of segments to use, in [1..4]</summary>
    public int Segments
    {
        get => segments;
        set => segments = Math.Clamp(value, 1, 4);
    }

    /// <summary>The amplitude of the spatial noise shaping.
    /// Spatial noise shaping (SNS) refers to a general collection of built-in algorithms used to
    /// decide which area of the picture should use relatively less bits, and where else to better transfer these bits.
    /// The possible range goes from 0 (algorithm is off) to 100 (the maximal effect). The default value is 80.</summary>
    public int SnsStrength
    {
        get => sns_strength;
        set => sns_strength = Math.Clamp(value, 0, 100);
    }

    /// <summary>The strength of the deblocking filter, between 0 (no filtering) and 100 (maximum filtering).
    /// A value of 0 turns off any filtering. Higher values increase the strength of the filtering process applied after decoding the image.
    /// The higher the value, the smoother the image appears. Typical values are usually in the range of 20 to 50.</summary>
    public int FilterStrength
    {
        get => filter_strength;
        set => filter_strength = Math.Clamp(value, 0, 100);
    }

    /// <summary>Filter sharpness. Range: [0 = off .. 7 = least sharp]</summary>
    public int FilterSharpness
    {
        get => filter_sharpness;
        set => filter_sharpness = Math.Clamp(value, 0, 7);
    }

    /// <summary>Filtering type: 0 = simple, 1 = strong (only used
    /// if filter_strength > 0 or autofilter > 0)</summary>
    public int FilterType
    {
        get => filter_type;
        set => filter_type = Math.Clamp(value, 0, 1);
    }

    /// <summary>Auto adjust filter's strength [0 = off, 1 = on]</summary>
    public bool Autofilter
    {
        get => autofilter == 1;
        set => autofilter = value ? 1 : 0;
    }

    /// <summary>Algorithm for encoding the alpha plane (0 = none,
    /// 1 = compressed with WebP lossless). Default is 1.</summary>
    public bool AlphaCompression
    {
        get => alpha_compression == 1;
        set => alpha_compression = value ? 1 : 0;
    }

    /// <summary>Predictive filtering method for alpha plane.
    /// 0: none, 1: fast, 2: best. Default if 1.</summary>
    public int AlphaFiltering
    {
        get => alpha_filtering;
        set => alpha_filtering = Math.Clamp(value, 0, 2);
    }

    /// <summary>The compression value for alpha compression between 0 (smallest size) and 100 (lossless).
    /// Lossless compression of alpha is achieved using a value of 100,
    /// while the lower values result in a lossy compression. The default is 100.</summary>
    public int AlphaQuality
    {
        get => alpha_quality;
        set => alpha_quality = Math.Clamp(value, 0, 100);
    }

    /// <summary>Number of entropy-analysis passes (in [1..10]).</summary>
    public int Pass
    {
        get => pass;
        set => pass = Math.Clamp(value, 1, 10);
    }

    /// <summary>If true, export the compressed picture back.
    /// In-loop filtering is not applied.</summary>
    public bool ShowCompressed
    {
        get => show_compressed == 1;
        set => show_compressed = value ? 1 : 0;
    }

    /// <summary>Preprocessing filter:
    /// 0=none, 1=segment-smooth, 2=pseudo-random dithering</summary>
    public int Preprocessing
    {
        get => preprocessing;
        set => preprocessing = Math.Clamp(value, 0, 2);
    }

    /// <summary>log2(number of token partitions) in [0..3]. Default
    /// is set to 0 for easier progressive decoding.</summary>
    public int Partitions
    {
        get => partitions;
        set => partitions = Math.Clamp(value, 0, 3);
    }

    /// <summary>Quality degradation allowed to fit the 512k limit
    /// on prediction modes coding (0: no degradation,
    /// 100: maximum possible degradation).</summary>
    public int PartitionLimit
    {
        get => partition_limit;
        set => partition_limit = Math.Clamp(value, 0, 100);
    }

    /// <summary>If true, compression parameters will be remapped
    /// to better match the expected output size from
    /// JPEG compression. Generally, the output size will
    /// be similar but the degradation will be lower.</summary>
    public bool EmulateJpegSize
    {
        get => emulate_jpeg_size == 1;
        set => emulate_jpeg_size = value ? 1 : 0;
    }

    /// <summary>If non-zero, try and use multi-threaded encoding.</summary>
    public bool ThreadLevel
    {
        get => thread_level == 1;
        set => thread_level = value ? 1 : 0;
    }

    /// <summary>If set, reduce memory usage (but increase CPU use).</summary>
    public bool LowMemory
    {
        get => low_memory == 1;
        set => low_memory = value ? 1 : 0;
    }

    /// <summary>Near lossless encoding [0 = max loss .. 100 = off (default)].</summary>
    public int NearLossless
    {
        get => near_lossless;
        set => near_lossless = Math.Clamp(value, 0, 100);
    }

    /// <summary>if non-zero, preserve the exact RGB values under
    /// transparent area. Otherwise, discard this invisible
    /// RGB information for better compression. The default
    /// value is 0.</summary>
    public int Exact
    {
        get => exact;
        set => exact = value;
    }

    /// <summary>
    /// reserved
    /// </summary>
    public int UseDeltaPalette
    {
        get => use_delta_palette;
        set => use_delta_palette = value;
    }

    /// <summary>If needed, use sharp (and slow) RGB->YUV conversion</summary>
    public bool UseSharpYuv
    {
        get => use_sharp_yuv == 1;
        set => use_sharp_yuv = value ? 1 : 0;
    }

    /// <summary>Minimum permissible quality factor</summary>
    public int Qmin
    {
        get => qmin;
        set => qmin = value;
    }

    /// <summary>Maximum permissible quality factor</summary>
    public int Qmax
    {
        get => qmax;
        set => qmax = value;
    }

    /// <summary>Get a pointer to the configuration structure</summary>
    [UnscopedRef]
    public ref WebPConfig GetPinnableReference()
    {
        return ref this;
    }
}