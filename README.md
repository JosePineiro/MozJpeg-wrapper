# MozJpeg-wapper
Wapper for mozjpeg in C#. The most complete wapper in pure managed C#.

Exposes decoding API, encoding API and information API via turbojpeg compatible API. info of any JPEG file). In the future I´ll update for expose more advanced Decoding API.

The wapper are in safe managed code in one class. No need external dll except turbojpeg_x32.dll and turbojpeg_x64.dll (included v3.2). The wapper work in 32, 64 bit or ANY system (automatic select the apropiate library.

The code are full comented and include simple example for using the wapper.

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

Encode bitmap to byte array with quality 75, without JFIF, whith accurate DCT, optimize scan and tuned for MS-SSIM (maximum compression and minimum size)
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

## Thanks to pornel by his amazing code.
Without his work this wapper would not have been possible.
