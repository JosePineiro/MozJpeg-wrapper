// clsWebP, by Jose M. Piñeiro
// Website: https://github.com/JosePineiro/MozJpeg-wapper
// Version: 1.0.0.0 (May 8, 2017)
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MozJpegWrapper;


namespace MozJpegTest
{
    public partial class MozJpegExample : Form
    {
        #region | Constructors |
        public MozJpegExample()
        {
            InitializeComponent();
        }

        private void MozJpegExample_Load(object sender, EventArgs e)
        {
            try
            {
                //Inform of execution mode
                if (IntPtr.Size == 8)
                    this.Text = Application.ProductName + " x64 " + Application.ProductVersion;
                else
                    this.Text = Application.ProductName + " x32 " + Application.ProductVersion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nIn WebPExample.WebPExample_Load", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region << Events >>

        //Load JPEG example
        private void buttonLoad_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
                {
                    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                    openFileDialog.FileName = "";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.buttonSave.Enabled = true;
                        this.buttonSave.Enabled = true;
                        string pathFileName = openFileDialog.FileName;

                        if (Path.GetExtension(pathFileName) == ".jpeg" || Path.GetExtension(pathFileName) == ".jpg")
                        {
                            using (MozJpeg mozJpeg = new MozJpeg())
                                this.pictureBox.Image = mozJpeg.Load(pathFileName);
                        }
                        else
                            this.pictureBox.Image = Image.FromFile(pathFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nIn MozJpegExample.buttonLoad_Click", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Load JPEG examples
        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            string fileName;
            byte[] rawJpeg;

            try
            {
                //get the picturebox image
                Bitmap bmp = (Bitmap)pictureBox.Image;

                //Test simple save function with quality 75
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SimpleSave.jpg");
                using (MozJpeg mozJpeg = new MozJpeg())
                    mozJpeg.Save(bmp, fileName, 75);
                MessageBox.Show("Made " + fileName);

                //Test encode in memory with quality 75 in Baseline format
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Baseline.jpg");
                using (MozJpeg mozJpeg = new MozJpeg())
                    rawJpeg = mozJpeg.Encode(bmp, 75, true, TJFlags.BASELINE);
                File.WriteAllBytes(fileName, rawJpeg);
                MessageBox.Show("Made " + fileName);

                //Test encode lossly mode in memory with quality 75, with JFIF in grayscale
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Grayscale.jpg");
                using (MozJpeg mozJpeg = new MozJpeg())
                    rawJpeg = mozJpeg.Encode(bmp, 75, true, TJFlags.NONE, TJSubsamplingOptions.TJSAMP_GRAY);
                File.WriteAllBytes(fileName, rawJpeg);
                MessageBox.Show("Made " + fileName);

                //Test encode lossly mode in memory with quality 75, with JFIF and optimize scan
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Optimize1.jpg");
                using (MozJpeg mozJpeg = new MozJpeg())
                    rawJpeg = mozJpeg.Encode(bmp, 75, true, TJFlags.DC_SCAN_OPT2);
                File.WriteAllBytes(fileName, rawJpeg);
                MessageBox.Show("Made " + fileName);

                //Test encode lossly mode in memory with quality 75, without JFIF and optimize scan
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Optimize2.jpg");
                using (MozJpeg mozJpeg = new MozJpeg())
                    rawJpeg = mozJpeg.Encode(bmp, 75, true, TJFlags.ACCURATEDCT | TJFlags.DC_SCAN_OPT2);
                File.WriteAllBytes(fileName, rawJpeg);
                MessageBox.Show("Made " + fileName);

                //Test encode lossly mode in memory with quality 75, without JFIF and optimize scan
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Optimize3.jpg");
                using (MozJpeg mozJpeg = new MozJpeg())
                    rawJpeg = mozJpeg.Encode(bmp, 75, false, TJFlags.ACCURATEDCT | TJFlags.DC_SCAN_OPT2);
                File.WriteAllBytes(fileName, rawJpeg);
                MessageBox.Show("Made " + fileName);

                //Test encode lossly mode in memory with quality 75, without JFIF and optimize scan
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Arithmetic.jpg");
                using (MozJpeg mozJpeg = new MozJpeg())
                    rawJpeg = mozJpeg.Encode(bmp, 75, false, TJFlags.ACCURATEDCT | TJFlags.DC_SCAN_OPT2 | TJFlags.ARITHMETIC);
                File.WriteAllBytes(fileName, rawJpeg);
                MessageBox.Show("Made " + fileName);

                //Test encode lossly mode in memory with quality 75, without JFIF and optimize scan
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tune_MS_SSIM.jpg");
                using (MozJpeg mozJpeg = new MozJpeg())
                    rawJpeg = mozJpeg.Encode(bmp, 75, false, TJFlags.ACCURATEDCT | TJFlags.DC_SCAN_OPT2 | TJFlags.TUNE_MS_SSIM);
                File.WriteAllBytes(fileName, rawJpeg);
                MessageBox.Show("Made " + fileName);

                MessageBox.Show("End of Test");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nIn MozJpegExample.buttonSave_Click", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Information of JPEG example
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            float horizontalResolution;
            float verticalResolution;
            TJSubsamplingOptions subsampl;
            TJColorSpaces colorspace;
            string subsamplLong;
            string colorspaceLong;

            try
            {
                using (OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
                {
                    openFileDialog.Filter = "Jpeg files (*.jpg, *.jpeg)|*.jpg;*.jpeg";
                    openFileDialog.FileName = "";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.buttonSave.Enabled = true;
                        this.buttonSave.Enabled = true;
                        string pathFileName = openFileDialog.FileName;
                        byte[] rawJpeg = File.ReadAllBytes(pathFileName);

                        using (MozJpeg mozJpeg = new MozJpeg())
                            mozJpeg.GetInfo(rawJpeg, out width, out height, out horizontalResolution, out verticalResolution, out subsampl, out colorspace);

                        switch(subsampl)
                        {
                            case TJSubsamplingOptions.TJSAMP_444:
                                subsamplLong = "4:4:4 (no chrominance subsampling)";
                                break;
                            case TJSubsamplingOptions.TJSAMP_422:
                                subsamplLong = "4:2:2";
                                break;
                            case TJSubsamplingOptions.TJSAMP_420:
                                subsamplLong = "4:2:0";
                                break;
                            case TJSubsamplingOptions.TJSAMP_GRAY:
                                subsamplLong = "Grayscale. The JPEG not contain chrominance components.";
                                break;
                            case TJSubsamplingOptions.TJSAMP_440:
                                subsamplLong = "4:4:0";
                                break;
                            case TJSubsamplingOptions.TJSAMP_411:
                                subsamplLong = "4:1:1";
                                break;
                            default:
                                subsamplLong = "Unknown.";
                                break;
                        }

                        switch(colorspace)
                        {
                            case TJColorSpaces.TJCS_RGB:
                                colorspaceLong = "RGB.";
                                break;
                            case TJColorSpaces.TJCS_YCbCr:
                                colorspaceLong = "YCbCr.";
                                break;
                            case TJColorSpaces.TJCS_GRAY:
                                colorspaceLong = "Grayscale.";
                                break;
                            case TJColorSpaces.TJCS_CMYK:
                                colorspaceLong = "YCCK.";
                                break;
                            case TJColorSpaces.TJCS_YCCK:
                                colorspaceLong = "YCCK (AKA 'YCbCrK').";
                                break;
                            default:
                                colorspaceLong = "Unknown.";
                                break;
                        }

                        MessageBox.Show("Width: " + width + "\n" +
                                        "Height: " + height + "\n" +
                                        "Chroma subsample: " + subsamplLong + "\n" +
                                        "Color space: " + colorspaceLong + "\n" +
                                        "Horizontal resolution: " + horizontalResolution + "\n" +
                                        "Vertical resolution: " + verticalResolution + "\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nIn MozJpegExample.buttonInfo_Click", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion
    }
}

