using MaterialSkin.Controls;
using QRCodeDecoderLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRScanner.Forms
{
    public partial class MainForm : MaterialForm
    {
        private string imgPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\qr.png";
        public MainForm()
        {
            InitializeComponent();
            pbQRCode.BackColor = Color.Transparent;
            pnlBack.BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap bit = null;

            AreaSelectForm selection = new AreaSelectForm();
            bit = selection.CaptureImage();

            if (bit != null)
            {
                tbQr.ResetText();

                pbQRCode.BackgroundImage = (Image)bit;

                //Save the image locally                
                bit.Save(imgPath, ImageFormat.Png);

                QRCodeTrace.Open(imgPath);

                DecodeQR(bit);

                //Delete the image
                if (File.Exists(imgPath))
                    File.Delete(imgPath);
            }

            if (!this.Visible)
                this.Show();
        }

        private void DecodeQR(Bitmap QRCodeInputImage)
        {            
            // create QR Code decoder object
            QRDecoder decoder = new QRDecoder();
            
            // call image decoder methos with <code>Bitmap</code> image of QRCode barcode
            byte[][] DataByteArray = decoder.ImageDecoder(QRCodeInputImage);

            if(DataByteArray == null)
            {
                tbQr.Text = "Could not detect/successfully decode QR Code.";
                return;
            }

            if (DataByteArray.Length > 1)
            {
                for (int i = 0; i < DataByteArray.Length; i++)
                {
                    tbQr.AppendText("QR " + (i+1) + ":  " + ByteArrayToStr(DataByteArray[i]) + "\r\n");                    
                }
            }
            else if(DataByteArray.Length == 1)
            {
                string code = ByteArrayToStr(DataByteArray[0]);                
                tbQr.Text = code + "\r\n";
                if (code.StartsWith("otpauth://"))
                {
                    int secretIndex = code.IndexOf("secret=") + 7;
                    int issuerIndex = code.IndexOf("&issuer=");
                    if(issuerIndex != -1)
                    {
                        Clipboard.SetText(code.Substring(secretIndex, (issuerIndex - secretIndex)));
                        lblCopied.Visible = true;
                    }
                    else
                    {
                        // auth code without issuer
                        string check = code.Substring(secretIndex);
                        if (!HasSpecialChars(check))
                        {
                            Clipboard.SetText(code.Substring(secretIndex));
                            lblCopied.Visible = true;
                        }
                        else
                        {
                            tbQr.Text += "\r\n\r\nCould not extract 'secret' from the auth code.";
                        }
                    }
                }                    
            }

        }
        
        bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }

        // The QRDecoder converts byte array to text string the class using this conversion
        public static string ByteArrayToStr(byte[] DataArray)
        {
            Decoder decoder = Encoding.UTF8.GetDecoder();
            int CharCount = decoder.GetCharCount(DataArray, 0, DataArray.Length);
            char[] CharArray = new char[CharCount];
            decoder.GetChars(DataArray, 0, DataArray.Length, CharArray, 0);
            return new string(CharArray);
        }
   
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            pictureBox1_Click(sender, e);
        }
    }
}
