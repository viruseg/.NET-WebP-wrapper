using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal unsafe struct WebPData
{
    [NativeTypeName("const uint8_t *")]
    public byte* bytes;

    [NativeTypeName("size_t")]
    public nuint size;
}