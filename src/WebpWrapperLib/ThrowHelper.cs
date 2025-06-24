using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace WebpWrapper;

internal static class ThrowHelper
{
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowException(string message)
    {
        throw new Exception(message);
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowEncodeLosslessException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.EncodeLossless (Simple)");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowLoadException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.Load");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowGetPictureDistortionException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.GetPictureDistortion");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowGetVersionException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.GetVersion");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowGetInfoException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.GetInfo");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowDecodeException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.Decode");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowSaveException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.Save");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowThumbnailException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.Thumbnail");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowAdvancedEncodeException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.AdvancedEncode");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowEncodeLosslyException(string message)
    {
        throw new Exception($"{message}\r\nIn WebP.EncodeLossly");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowGetFeaturesException(VP8StatusCode result)
    {
        throw new Exception($"Failed WebPGetFeatures with error {result}");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowBitmapNoDataException(string paramName)
    {
        throw new ArgumentException("Bitmap contains no data.", paramName);
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowBitmapDimensionException(int maxDimension)
    {
        throw new NotSupportedException($"Bitmap's dimension is too large. Max is {maxDimension}x{maxDimension} pixels.");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowEncodingErrorException(uint errorCode)
    {
        throw new Exception($"Encoding error: {(WebPEncodingError) errorCode}");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowBitmapPixelFormatException()
    {
        throw new NotSupportedException("Only support Format24bppRgb and Format32bppArgb pixelFormat.");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInitDecoderConfigException()
    {
        throw new Exception("WebPInitDecoderConfig failed. Wrong version?");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowCropException()
    {
        throw new Exception("Crop options exceeded WebP image dimensions");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowWebPPictureInitException()
    {
        throw new Exception("Can´t initialize WebPPictureInit");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowWebPPictureImportBGRException()
    {
        throw new Exception("Can´t allocate memory in WebPPictureImportBGR");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowWebPPictureImportBGRAException()
    {
        throw new Exception("Can´t allocate memory in WebPPictureImportBGRA");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowEncodeException()
    {
        throw new Exception("Can´t encode WebP");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowConfigurePresetException()
    {
        throw new Exception("Can´t configure preset");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowConfigPresetException()
    {
        throw new Exception("Can´t config preset");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowConfigurationParametersException()
    {
        throw new Exception("Bad configuration parameters");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowConfigureLosslessPresetException()
    {
        throw new Exception("Can´t configure lossless preset");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowDllVersionException()
    {
        throw new Exception("This DLL version not support EncodeNearLossless");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int ThrowInvalidPlatformException()
    {
        throw new InvalidOperationException("Invalid platform. Can not find proper function");
    }
}