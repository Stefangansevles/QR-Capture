using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRScanner.Forms
{
    /// <summary>
    /// This form becomes full-screen so that you can draw a selection on it
    /// </summary>
    public partial class AreaSelectForm : Form
    {
        //These variables control the mouse position
        private int selectX;
        private int selectY;
        private int selectWidth;
        private int selectHeight;

        //This variable control when you start the right click
        private bool start = false;

        private Bitmap selectedImage;

        public AreaSelectForm()
        {
            InitializeComponent();            
        }

        private void AreaSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        public Bitmap CaptureImage()
        {
            this.ShowDialog();
            return selectedImage;
        }

        private void AreaSelectForm_Load(object sender, EventArgs e)
        {
            //Hide the Form
            this.Hide();

            Rectangle r = new Rectangle();
            foreach (Screen s in Screen.AllScreens)
            {
                if (s != Screen.FromControl(this)) // Blackout only the secondary screens
                    r = Rectangle.Union(r, s.Bounds);
            }

            this.Top = r.Top;
            this.Left = r.Left;
            this.Size = new Size(r.Width, r.Height);
            var t = this.Location;
            
            //Create the Bitmap
            Bitmap printscreen = new Bitmap(r.Width, r.Height);
            //Create the Graphic Variable with screen Dimensions
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            //Copy Image from the screen
            //graphics.CopyFromScreen()
            graphics.CopyFromScreen(this.Left, this.Top, 0, 0, printscreen.Size);
            //Create a temporal memory stream for the image
            using (MemoryStream s = new MemoryStream())
            {
                //save graphic variable into memory
                printscreen.Save(s, ImageFormat.Bmp);
                pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);
                //set the picture box with temporary stream
                pictureBox1.Image = Image.FromStream(s);
            }
            //Show Form
            this.Show();
            //Cross Cursor
            Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //validate if there is an image
            if (pictureBox1.Image == null)
                return;
            //validate if right-click was trigger
            if (start)
            {
                //refresh picture box
                pictureBox1.Refresh();
                //set corner square to mouse coordinates
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                //draw dotted rectangle
                Graphics gr = pictureBox1.CreateGraphics();

                using (Pen pen1 = new Pen(Color.Black, 2))
                {
                    gr.DrawRectangle(pen1, new Rectangle(selectX, selectY, selectWidth, selectHeight));
                }
                using (Pen pen2 = new Pen(Color.White, 2))
                {
                    pen2.DashPattern = new float[] { 5, 5 };
                    gr.DrawRectangle(pen2, new Rectangle(selectX, selectY, selectWidth, selectHeight));
                }

                gr.Dispose();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //validate when user right-click
            if (!start)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //starts coordinates for rectangle
                    selectX = e.X;
                    selectY = e.Y;
                }
                //refresh picture box
                pictureBox1.Refresh();
                //start control variable for draw rectangle
                start = true;
            }
            else
            {
                
            }
        }
        private void SaveToClipboard()
        {
            //validate if something selected
            if (selectWidth > 0)
            {

                Rectangle rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
                //create bitmap with original dimensions
                Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                //create bitmap with selected dimensions
                Bitmap _img = new Bitmap(selectWidth, selectHeight);
                //create graphic variable
                Graphics g = Graphics.FromImage(_img);
                //set graphic attributes
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
                //insert image stream into clipboard
                Clipboard.SetImage(_img);
            }
            this.Close();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //validate if there is image
            if (pictureBox1.Image == null)
                return;
            //same functionality when mouse is over
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Refresh();
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;

                Graphics gr = pictureBox1.CreateGraphics();


                using (Pen pen1 = new Pen(Color.Black, 2))
                {
                    gr.DrawRectangle(pen1, new Rectangle(selectX, selectY, selectWidth, selectHeight));
                }
                using (Pen pen2 = new Pen(Color.White, 2))
                {
                    pen2.DashPattern = new float[] { 5, 5 };
                    gr.DrawRectangle(pen2, new Rectangle(selectX, selectY, selectWidth, selectHeight));
                }

                gr.Dispose();
            }
            start = false;

            if (selectWidth > 0)
            {
                Rectangle rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
                //create bitmap with original dimensions
                Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                //create bitmap with selected dimensions
                Bitmap _img = new Bitmap(selectWidth, selectHeight);
                //create graphic variable
                Graphics g = Graphics.FromImage(_img);
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
                selectedImage = _img;
            }
            this.Close();
        }
    }
}
