// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

namespace WebpWrapper;

/// <summary>Image characteristics hint for the underlying encoder</summary>
public enum WebPImageHint
{
    /// <summary>Default preset</summary>
    WEBP_HINT_DEFAULT = 0,

    /// <summary>Digital picture, like portrait, inner shot</summary>
    WEBP_HINT_PICTURE,

    /// <summary>Outdoor photograph, with natural lighting</summary>
    WEBP_HINT_PHOTO,

    /// <summary>Discrete tone image (graph, map-tile etc)</summary>
    WEBP_HINT_GRAPH,

    /// <summary>List terminator. Always last</summary>
    WEBP_HINT_LAST
}