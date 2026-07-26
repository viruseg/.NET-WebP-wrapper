using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

/// <summary>Output buffer</summary>
internal unsafe struct WebPDecBuffer
{
    /// <summary>Color space</summary>
    public WEBP_CSP_MODE colorspace;

    /// <summary>Width of image</summary>
    public int width;

    /// <summary>Height of image</summary>
    public int height;

    /// <summary>If non-zero, 'internal_memory' pointer is not used. If value is '2' or more, the external memory is considered 'slow' and multiple read/write will be avoided</summary>
    public int is_external_memory;

    /// <summary>Output buffer parameters</summary>
    [NativeTypeName("__AnonymousRecord_decode_L223_C3")]
    public _u_e__Union u;

    /// <summary>Padding for later use</summary>
    [NativeTypeName("uint32_t[4]")]
    public _pad_e__FixedBuffer pad;
    /// <summary>Internally allocated memory (only when is_external_memory is 0). Should not be used externally, but accessed via WebPRGBABuffer</summary>

    [NativeTypeName("uint8_t *")]
    public byte* private_memory;

    /// <summary>Union of buffer parameters</summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct _u_e__Union
    {
        [FieldOffset(0)]
        public WebPRGBABuffer RGBA;

        [FieldOffset(0)]
        public WebPYUVABuffer YUVA;
    }

    [InlineArray(4)]
    public struct _pad_e__FixedBuffer
    {
        public uint e0;
    }
}