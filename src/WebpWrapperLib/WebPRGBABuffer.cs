// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Runtime.InteropServices;

namespace WebpWrapper;

/// <summary>Generic structure for describing the output sample buffer</summary>
[StructLayout(LayoutKind.Sequential)]
internal struct WebPRGBABuffer
{
    /// <summary>Pointer to RGBA samples</summary>
    public IntPtr rgba;

    /// <summary>Stride in bytes from one scanline to the next</summary>
    public int stride;

    /// <summary>Total size of the RGBA buffer</summary>
    public UIntPtr size;
}