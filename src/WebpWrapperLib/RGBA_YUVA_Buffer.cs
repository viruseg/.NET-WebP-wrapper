// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Runtime.InteropServices;

namespace WebpWrapper;

/// <summary>Union of buffer parameters</summary>
[StructLayout(LayoutKind.Explicit)]
internal struct RGBA_YUVA_Buffer
{
    [FieldOffset(0)] public WebPRGBABuffer RGBA;

    [FieldOffset(0)] public WebPYUVABuffer YUVA;
}