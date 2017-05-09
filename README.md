# MozJpeg-wrapper
The most complete MozJpeg wrapper in pure managed C#.

Exposes decoding API, encoding API and information API via turbojpeg-compatible API info for any JPEG file). In the future I'll update to expose more advanced Decoding API.

The wrapper is in safe managed code in one class. No need for external dll except turbojpeg_x32.dll and turbojpeg_x64.dll (included v3.2). The wrapper work in 32, 64 bit or ANY system (automatic select the apropiate library.

The code is fully commented and includes a simple example for using the wrapper.

## Use
Load JPEG image for JPEG file
```C#
using (MozJpeg mozJpeg = new MozJpeg())
	this.pictureBox.Image = mozJpeg.Load(pathFileName);
```

Save bitmap to JPEG file with quality 85
```C#
using (MozJpeg mozJpeg = new MozJpeg())
	mozJpeg.Save(bmp, fileName, 85);
```

Decode JPEG date in byte array to bitmap and load in PictureBox container
```C#
byte[] rawJpeg = File.ReadAllBytes("test.jpg");
using (clsWebP mozJpeg = new rawJpeg())
	  this.pictureBox.Image = mozJpeg.Decode(rawJpeg);
```

Encode bitmap to byte array with quality 75, without JFIF, with accurate DCT, optimized scan and tuned for MS-SSIM (maximum compression and minimum size)
```C#
byte[] rawJpeg;
using (MozJpeg mozJpeg = new MozJpeg())
		rawJpeg = mozJpeg.Encode(bmp, 75, false, TJFlags.ACCURATEDCT |
		                         TJFlags.DC_SCAN_OPT2 | TJFlags.TUNE_MS_SSIM);
File.WriteAllBytes("test.webp", rawJpeg);
```

Get info from JPEG file
```C#
byte[] rawJpeg = File.ReadAllBytes("test.jpg");
using (clsWebP mozJpeg = new rawJpeg())
		mozJpeg.GetInfo(rawJpeg, out width, out height, out horizontalResolution,
		                out verticalResolution, out subsampl, out colorspace);
```

## Thanks to pornel for his amazing code.
Without his work this wrapper would not have been possible.
