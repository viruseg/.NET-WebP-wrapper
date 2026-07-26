using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

/// <summary>Generic structure for describing the output sample buffer</summary>
internal unsafe struct WebPRGBABuffer
{
    /// <summary>Pointer to RGBA samples</summary>
    [NativeTypeName("uint8_t *")]
    public byte* rgba;

    /// <summary>Stride in bytes from one scanline to the next</summary>
    public int stride;

    /// <summary>Total size of the RGBA buffer</summary>
    [NativeTypeName("size_t")]
    public nuint size;
}