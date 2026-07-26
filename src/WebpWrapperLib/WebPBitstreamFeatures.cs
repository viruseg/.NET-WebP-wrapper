using System.Runtime.CompilerServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapper;

/// <summary>Features gathered from the bit stream</summary>
public readonly struct WebPBitstreamFeatures
{
    /// <summary>Width in pixels, as read from the bit stream</summary>
    private readonly int width;

    /// <summary>Height in pixels, as read from the bit stream</summary>
    private readonly int height;

    /// <summary>True if the bit stream contains an alpha channel</summary>
    private readonly int has_alpha;

    /// <summary>True if the bit stream is an animation</summary>
    private readonly int has_animation;

    /// <summary>0 = undefined (/mixed), 1 = lossy, 2 = lossless</summary>
    private readonly int format;

    [NativeTypeName("uint32_t[5]")]
    private readonly _pad_e__FixedBuffer pad;

    /// <summary>Padding for later use</summary>
    [InlineArray(5)]
    private struct _pad_e__FixedBuffer
    {
        public uint e0;
    }

    /// <summary>Width in pixels, as read from the bit stream</summary>
    public int Width => width;

    /// <summary>Height in pixels, as read from the bit stream</summary>
    public int Height => height;

    /// <summary>True if the bit stream contains an alpha channel</summary>
    public bool HasAlpha => has_alpha == 1;

    /// <summary>True if the bit stream is an animation</summary>
    public bool HasAnimation => has_animation == 1;

    /// <summary>0 = undefined (/mixed), 1 = lossy, 2 = lossless</summary>
    public WebpFormat Format => (WebpFormat) format;
}