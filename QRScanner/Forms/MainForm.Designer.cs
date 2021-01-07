namespace QRScanner.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tbQr = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.lblCopied = new MaterialSkin.Controls.MaterialLabel();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(20, 312);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(193, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "== QR Code information ==";
            // 
            // tbQr
            // 
            this.tbQr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbQr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbQr.Depth = 0;
            this.tbQr.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbQr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbQr.Hint = "";
            this.tbQr.Location = new System.Drawing.Point(12, 341);
            this.tbQr.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbQr.Name = "tbQr";
            this.tbQr.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbQr.Size = new System.Drawing.Size(476, 108);
            this.tbQr.TabIndex = 6;
            this.tbQr.Text = "";
            // 
            // pnlBack
            // 
            this.pnlBack.Controls.Add(this.pbQRCode);
            this.pnlBack.Location = new System.Drawing.Point(-1, 64);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(509, 240);
            this.pnlBack.TabIndex = 7;
            // 
            // lblCopied
            // 
            this.lblCopied.AlternativeForeColor = System.Drawing.Color.Green;
            this.lblCopied.AutoSize = true;
            this.lblCopied.BackColor = System.Drawing.SystemColors.Control;
            this.lblCopied.Depth = 0;
            this.lblCopied.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCopied.ForeColor = System.Drawing.Color.Red;
            this.lblCopied.Location = new System.Drawing.Point(92, 465);
            this.lblCopied.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCopied.Name = "lblCopied";
            this.lblCopied.Size = new System.Drawing.Size(280, 19);
            this.lblCopied.TabIndex = 8;
            this.lblCopied.Text = "Authenication code copied to clipboard!";
            this.lblCopied.Visible = false;
            // 
            // pbQRCode
            // 
            this.pbQRCode.BackColor = System.Drawing.Color.DodgerBlue;
            this.pbQRCode.BackgroundImage = global::QRScanner.Properties.Resources.screenshot;
            this.pbQRCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbQRCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbQRCode.Location = new System.Drawing.Point(19, 7);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(465, 218);
            this.pbQRCode.TabIndex = 0;
            this.pbQRCode.TabStop = false;
            this.pbQRCode.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Overline;
            this.materialLabel2.Location = new System.Drawing.Point(395, 307);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(100, 13);
            this.materialLabel2.TabIndex = 9;
            this.materialLabel2.Text = "Press above to capture";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.lblCopied);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.tbQr);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "QR Capture";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbQRCode;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Panel pnlBack;
        private MaterialSkin.Controls.MaterialLabel lblCopied;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        public MaterialSkin.Controls.MaterialMultiLineTextBox tbQr;
    }
}

