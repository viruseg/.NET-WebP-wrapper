using System.Runtime.CompilerServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal struct WebPAnimEncoderOptions
{
    public WebPMuxAnimParams anim_params;

    public int minimize_size;

    public int kmin;

    public int kmax;

    public int allow_mixed;

    public int verbose;

    [NativeTypeName("uint32_t[4]")]
    public _padding_e__FixedBuffer padding;

    [InlineArray(4)]
    public struct _padding_e__FixedBuffer
    {
        public uint e0;
    }
}