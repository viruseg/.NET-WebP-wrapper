using System.Runtime.CompilerServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal struct WebPAnimDecoderOptions
{
    public WEBP_CSP_MODE color_mode;

    public int use_threads;

    [NativeTypeName("uint32_t[7]")]
    public _padding_e__FixedBuffer padding;

    [InlineArray(7)]
    public struct _padding_e__FixedBuffer
    {
        public uint e0;
    }
}