// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

namespace WebpWrapper;

/// <summary>
/// Format of image.
/// </summary>
public enum WebpFormat
{
    /// <summary>Undefined format.</summary>
    Undefined = 0,

    /// <summary>Lossy format.</summary>
    Lossy = 1,

    /// <summary>Lossless format.</summary>
    Lossless = 2
}