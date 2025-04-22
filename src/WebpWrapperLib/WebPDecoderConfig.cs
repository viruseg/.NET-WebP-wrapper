// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

using System.Runtime.InteropServices;

namespace WebpWrapper;

[StructLayout(LayoutKind.Sequential)]
internal struct WebPDecoderConfig
{
    /// <summary>Immutable bit stream features (optional)</summary>
    public WebPBitstreamFeatures input;

    /// <summary>Output buffer (can point to external memory)</summary>
    public WebPDecBuffer output;

    /// <summary>Decoding options</summary>
    public WebPDecoderOptions options;
}