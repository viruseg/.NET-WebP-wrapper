using System.Runtime.CompilerServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

/// <summary>Features gathered from the bit stream</summary>
internal struct WebPBitstreamFeatures
{
    /// <summary>Width in pixels, as read from the bit stream</summary>
    public int width;

    /// <summary>Height in pixels, as read from the bit stream</summary>
    public int height;

    /// <summary>True if the bit stream contains an alpha channel</summary>
    public int has_alpha;

    /// <summary>True if the bit stream is an animation</summary>
    public int has_animation;

    /// <summary>0 = undefined (/mixed), 1 = lossy, 2 = lossless</summary>
    public int format;

    [NativeTypeName("uint32_t[5]")]
    public _pad_e__FixedBuffer pad;

    /// <summary>Padding for later use</summary>
    [InlineArray(5)]
    public struct _pad_e__FixedBuffer
    {
        public uint e0;
    }
}