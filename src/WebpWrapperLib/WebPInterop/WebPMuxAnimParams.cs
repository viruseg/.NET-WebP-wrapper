using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal struct WebPMuxAnimParams
{
    [NativeTypeName("uint32_t")]
    public uint bgcolor;

    public int loop_count;
}