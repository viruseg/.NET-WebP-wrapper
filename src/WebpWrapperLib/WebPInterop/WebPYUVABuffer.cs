using WebpWrapperLib.InteropAttribute;

namespace WebpWrapperLib.WebPInterop;

internal unsafe struct WebPYUVABuffer
{
    /// <summary>Pointer to luma samples</summary>
    [NativeTypeName("uint8_t *")]
    public byte* y;

    /// <summary>Pointer to chroma U samples</summary>
    [NativeTypeName("uint8_t *")]
    public byte* u;

    /// <summary>Pointer to chroma V samples</summary>
    [NativeTypeName("uint8_t *")]
    public byte* v;

    /// <summary>Pointer to alpha samples</summary>
    [NativeTypeName("uint8_t *")]
    public byte* a;

    /// <summary>Luma stride</summary>
    public int y_stride;

    /// <summary>Chroma U stride</summary>
    public int u_stride;

    /// <summary>Chroma V stride</summary>
    public int v_stride;

    /// <summary>Alpha stride</summary>
    public int a_stride;

    /// <summary>Luma plane size</summary>
    [NativeTypeName("size_t")]
    public nuint y_size;

    /// <summary>Chroma plane U size</summary>
    [NativeTypeName("size_t")]
    public nuint u_size;

    /// <summary>Chroma plane V size</summary>
    [NativeTypeName("size_t")]
    public nuint v_size;

    /// <summary>Alpha plane size</summary>
    [NativeTypeName("size_t")]
    public nuint a_size;
}