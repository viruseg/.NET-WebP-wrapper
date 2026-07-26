using System.Runtime.CompilerServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

/// <summary>Decoding options</summary>
public struct WebPDecoderOptions
{
    /// <summary>If true, skip the in-loop filtering</summary>
    internal int bypass_filtering;

    /// <summary>If true, use faster point-wise up-sampler</summary>
    internal int no_fancy_upsampling;

    /// <summary>If true, cropping is applied _first_</summary>
    internal int use_cropping;

    /// <summary>Left position for cropping. Will be snapped to even values</summary>
    internal int crop_left;

    /// <summary>Top position for cropping. Will be snapped to even values</summary>
    internal int crop_top;

    /// <summary>Width of the cropping area</summary>
    internal int crop_width;

    /// <summary>Height of the cropping area</summary>
    internal int crop_height;

    /// <summary>If true, scaling is applied _afterward_</summary>
    internal int use_scaling;

    /// <summary>Final width</summary>
    internal int scaled_width;

    /// <summary>Final height</summary>
    internal int scaled_height;

    /// <summary>If true, use multi-threaded decoding</summary>
    internal int use_threads;

    /// <summary>Dithering strength (0=Off, 100=full)</summary>
    internal int dithering_strength;

    /// <summary>Flip output vertically</summary>
    internal int flip;

    /// <summary>Alpha dithering strength in [0..100]</summary>
    internal int alpha_dithering_strength;

    /// <summary>Padding for later use</summary>
    [NativeTypeName("uint32_t[5]")]
    private _pad_e__FixedBuffer pad;

    [InlineArray(5)]
    private struct _pad_e__FixedBuffer
    {
        public uint e0;
    }



    /// <summary>If true, skip the in-loop filtering</summary>
    public bool BypassFiltering
    {
        get => bypass_filtering == 1;
        set => bypass_filtering = value ? 1 : 0;
    }

    /// <summary>If true, use faster point-wise up-sampler</summary>
    public bool NoFancyUpsampling
    {
        get => no_fancy_upsampling == 1;
        set => no_fancy_upsampling = value ? 1 : 0;
    }

    /// <summary>If true, cropping is applied _first_</summary>
    public bool UseCropping
    {
        get => use_cropping == 1;
        set => use_cropping = value ? 1 : 0;
    }

    /// <summary>Left position for cropping. Will be snapped to even values</summary>
    public int CropLeft
    {
        get => crop_left;
        set => crop_left = Math.Max(value, 0);
    }

    /// <summary>Top position for cropping. Will be snapped to even values</summary>
    public int CropTop
    {
        get => crop_top;
        set => crop_top = Math.Max(value, 0);
    }

    /// <summary>Width of the cropping area</summary>
    public int CropWidth
    {
        get => crop_width;
        set => crop_width = Math.Max(value, 0);
    }

    /// <summary>Height of the cropping area</summary>
    public int CropHeight
    {
        get => crop_height;
        set => crop_height = Math.Max(value, 0);
    }

    /// <summary>If true, scaling is applied _afterward_</summary>
    public bool UseScaling
    {
        get => use_scaling == 1;
        set => use_scaling = value ? 1 : 0;
    }

    /// <summary>Final width</summary>
    public int ScaledWidth
    {
        get => scaled_width;
        set => scaled_width = Math.Max(value, 0);
    }

    /// <summary>Final height</summary>
    public int ScaledHeight
    {
        get => scaled_height;
        set => scaled_height = Math.Max(value, 0);
    }

    /// <summary>If true, use multi-threaded decoding</summary>
    public bool UseThreads
    {
        get => use_threads == 1;
        set => use_threads = value ? 1 : 0;
    }

    /// <summary>Dithering strength (0=Off, 100=full)</summary>
    public int DitheringStrength
    {
        get => dithering_strength;
        set => dithering_strength = Math.Clamp(value, 0, 100);
    }

    /// <summary>Flip output vertically</summary>
    public bool Flip
    {
        get => flip == 1;
        set => flip = value ? 1 : 0;
    }

    /// <summary>Alpha dithering strength in [0..100]</summary>
    public int AlphaDitheringStrength
    {
        get => alpha_dithering_strength;
        set => alpha_dithering_strength = Math.Clamp(value, 0, 100);
    }
}