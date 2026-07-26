using System.Runtime.CompilerServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal unsafe struct WebPIterator
{
    public int frame_num;

    public int num_frames;

    public int x_offset;

    public int y_offset;

    public int width;

    public int height;

    public int duration;

    public WebPMuxAnimDispose dispose_method;

    public int complete;

    public WebPData fragment;

    public int has_alpha;

    public WebPMuxAnimBlend blend_method;

    [NativeTypeName("uint32_t[2]")]
    public _pad_e__FixedBuffer pad;

    public void* private_;

    [InlineArray(2)]
    public struct _pad_e__FixedBuffer
    {
        public uint e0;
    }
}