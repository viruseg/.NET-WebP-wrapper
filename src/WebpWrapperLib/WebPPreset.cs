// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

namespace WebpWrapper;

/// <summary>Enumerate some predefined settings for WebPConfig, depending on the type of source picture. These presets are used when calling WebPConfigPreset()</summary>
public enum WebPPreset
{
    /// <summary>Default preset</summary>
    WEBP_PRESET_DEFAULT = 0,

    /// <summary>Digital picture, like portrait, inner shot</summary>
    WEBP_PRESET_PICTURE,

    /// <summary>Outdoor photograph, with natural lighting</summary>
    WEBP_PRESET_PHOTO,

    /// <summary>Hand or line drawing, with high-contrast details</summary>
    WEBP_PRESET_DRAWING,

    /// <summary>Small-sized colorful images</summary>
    WEBP_PRESET_ICON,

    /// <summary>Text-like</summary>
    WEBP_PRESET_TEXT
}