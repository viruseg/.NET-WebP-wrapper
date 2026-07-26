using System.Runtime.CompilerServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal struct WebPAnimInfo
{
    [NativeTypeName("uint32_t")]
    public uint canvas_width;

    [NativeTypeName("uint32_t")]
    public uint canvas_height;

    [NativeTypeName("uint32_t")]
    public uint loop_count;

    [NativeTypeName("uint32_t")]
    public uint bgcolor;

    [NativeTypeName("uint32_t")]
    public uint frame_count;

    [NativeTypeName("uint32_t[4]")]
    public _pad_e__FixedBuffer pad;

    [InlineArray(4)]
    public struct _pad_e__FixedBuffer
    {
        public uint e0;
    }
}