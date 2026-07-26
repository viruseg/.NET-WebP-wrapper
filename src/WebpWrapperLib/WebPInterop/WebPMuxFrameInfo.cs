using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal struct WebPMuxFrameInfo
{
    public WebPData bitstream;

    public int x_offset;

    public int y_offset;

    public int duration;

    public WebPChunkId id;

    public WebPMuxAnimDispose dispose_method;

    public WebPMuxAnimBlend blend_method;

    [NativeTypeName("uint32_t[1]")]
    public _pad_e__FixedBuffer pad;

    public struct _pad_e__FixedBuffer
    {
        public uint e0;

        [UnscopedRef]
        public ref uint this[int index]
        {
            get
            {
                return ref Unsafe.Add(ref e0, index);
            }
        }

        [UnscopedRef]
        public Span<uint> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
    }
}