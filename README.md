This fork is intended for current versions of .NET. Includes the latest version of the library libwebp.dll v1.6.0. The structures have been updated to match the current version of the library.

The wrapper work only 64-bit Windows system.

|Package|Download|
|-|-|
|Webp-Wrapper-for-NET-Win-x64|[![NuGet](https://img.shields.io/nuget/v/Webp-Wrapper-for-NET-Win-x64.svg)](https://www.nuget.org/packages/Webp-Wrapper-for-NET-Win-x64) [![NuGet](https://img.shields.io/nuget/dt/Webp-Wrapper-for-NET-Win-x64.svg)](https://www.nuget.org/packages/Webp-Wrapper-for-NET-Win-x64)

```bash
dotnet add package Webp-Wrapper-for-NET-Win-x64
```

# WebP-wrapper
Wrapper for libwebp in C#. The most complete wrapper in pure managed C#.

Exposes Simple Decoding and Encoding API, Advanced Decoding and Encoding API (with statistics of compression), Get version library and WebPGetFeatures (info of any WebP file). Exposed get PSNR, SSIM or LSIM distortion metrics.

The wrapper is in safe managed code in one class. No need for external dll except libwebp_x64.dll (included). The wrapper work only 64-bit Windows system.

## Decompress Functions:ap bmp = webp.Load("test.webp");
Decode WebP to bitmap
```C#
byte[] rawWebp = File.ReadAllBytes("test.webp");
using Bitmap bmp = WebP.Decode(rawWebp);
```

Advanced decode WebP to bitmap
```C#
byte[] rawWebp = File.ReadAllBytes("test.webp");
using Bitmap bmp = WebP.Decode(rawWebp, new WebPDecoderOptions { UseThreads = true, Flip = true });
```


## Compress Functions:
Encode to memory buffer in lossy mode with quality 75 and save to file
```C#
byte[] rawJpg = File.ReadAllBytes("test.jpg");
using MemoryStream memoryStream = new MemoryStream(rawJpg);
using Bitmap bmp = new Bitmap(memoryStream);
byte[] rawWebp = WebP.EncodeLossy(bmp, 75);
File.WriteAllBytes("test.webp", rawWebp);
```

Encode to memory buffer in lossless mode and save to file
```C#
byte[] rawJpg = File.ReadAllBytes("test.jpg");
using MemoryStream memoryStream = new MemoryStream(rawJpg);
using Bitmap bmp = new Bitmap(memoryStream);
byte[] rawWebp = WebP.EncodeLossless(bmp);
File.WriteAllBytes("test.webp", rawWebp);
```iteAllBytes("test.webp", rawWebP); 
```

Encode to memory buffer in lossy with custom config and save to file
```C#
WebP.WebPConfigInit(WebPPreset.WEBP_PRESET_PHOTO, 85, out WebPConfig config);
config.Method = 6;
config.Pass = 2;
config.ThreadLevel = true;

byte[] rawJpg = File.ReadAllBytes("test.jpg");
using MemoryStream memoryStream = new MemoryStream(rawJpg);
using Bitmap bmp = new Bitmap(memoryStream);
byte[] rawWebp = WebP.Encode(bmp, config);
File.WriteAllBytes("test.webp", rawWebp);
```

## Another Functions:	
Get version of libwebp.dll
```C#
string version = "libwebp.dll v" + WebP.GetVersion();
```

Get info from WebP file
```C#
byte[] rawWebp = File.ReadAllBytes("test.webp");
WebPBitstreamFeatures info = WebP.GetInfo(rawWebp);
Console.WriteLine("Width: " + info.Width + "\n" +
                  "Height: " + info.Height + "\n" +
                  "Has alpha: " + info.HasAlpha + "\n" +
                  "Is animation: " + info.HasAnimation + "\n" +
                  "Format: " + info.Format);
```

Get PSNR, SSIM or LSIM distortion metric between two pictures
```C#
int metric = 0;  //0 = PSNR, 1= SSIM, 2=LSIM
using Bitmap source = (Bitmap) Image.FromFile("image1.png");
using Bitmap reference = (Bitmap) Image.FromFile("image2.png");
float[] result = WebP.GetPictureDistortion(source, reference, metric);

Console.WriteLine("Red: " + result[0] + "dB\n" +
                  "Green: " + result[1] + "dB\n" +
                  "Blue: " + result[2] + "dB\n" +
                  "Alpha: " + result[3] + "dB\n" +
                  "All: " + result[4] + "dB\n");
```
