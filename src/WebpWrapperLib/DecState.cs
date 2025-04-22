// Wrapper for WebP format in C#. (MIT)
// Copyright (c) 2020 Jose M. Piñeiro
// Copyright (c) 2025 Denis Tulupov

namespace WebpWrapper;

/// <summary>
/// Decoding states. State normally flows as:
/// WEBP_HEADER->VP8_HEADER->VP8_PARTS0->VP8_DATA->DONE for a lossy image, and
/// WEBP_HEADER->VP8L_HEADER->VP8L_DATA->DONE for a lossless image.
/// If there is any error the decoder goes into state ERROR.
/// </summary>
internal enum DecState
{
    STATE_WEBP_HEADER, // All the data before that of the VP8/VP8L chunk.
    STATE_VP8_HEADER, // The VP8 Frame header (within the VP8 chunk).
    STATE_VP8_PARTS0,
    STATE_VP8_DATA,
    STATE_VP8L_HEADER,
    STATE_VP8L_DATA,
    STATE_DONE,
    STATE_ERROR
}