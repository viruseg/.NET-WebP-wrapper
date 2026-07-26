using System.Runtime.CompilerServices;
using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal unsafe struct WebPChunkIterator
{
    public int chunk_num;

    public int num_chunks;

    public WebPData chunk;

    [NativeTypeName("uint32_t[6]")]
    public _pad_e__FixedBuffer pad;

    public void* private_;

    [InlineArray(6)]
    public struct _pad_e__FixedBuffer
    {
        public uint e0;
    }
}