// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Runtime.InteropServices;

namespace WebpWrapper;

/// <summary>Features gathered from the bit stream</summary>
[StructLayout(LayoutKind.Sequential)]
internal struct WebPBitstreamFeatures
{
    /// <summary>Width in pixels, as read from the bit stream</summary>
    public int Width;

    /// <summary>Height in pixels, as read from the bit stream</summary>
    public int Height;

    /// <summary>True if the bit stream contains an alpha channel</summary>
    public int Has_alpha;

    /// <summary>True if the bit stream is an animation</summary>
    public int Has_animation;

    /// <summary>0 = undefined (/mixed), 1 = lossy, 2 = lossless</summary>
    public int Format;

    /// <summary>Padding for later use</summary>
    public unsafe fixed uint pad[5];
}