namespace VoskProjesi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBaslat = new Button();
            btnDurdur = new Button();
            txtGunluk = new TextBox();
            lblAnlik = new Label();
            SuspendLayout();
            // 
            // btnBaslat
            // 
            btnBaslat.Location = new Point(70, 31);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(119, 46);
            btnBaslat.TabIndex = 0;
            btnBaslat.Text = "Başlat";
            btnBaslat.UseVisualStyleBackColor = true;
            btnBaslat.Click += btnBaslat_Click;
            // 
            // btnDurdur
            // 
            btnDurdur.Location = new Point(271, 31);
            btnDurdur.Name = "btnDurdur";
            btnDurdur.Size = new Size(119, 46);
            btnDurdur.TabIndex = 1;
            btnDurdur.Text = "Durdur";
            btnDurdur.UseVisualStyleBackColor = true;
            btnDurdur.Click += btnDurdur_Click;
            // 
            // txtGunluk
            // 
            txtGunluk.Location = new Point(70, 146);
            txtGunluk.Multiline = true;
            txtGunluk.Name = "txtGunluk";
            txtGunluk.ScrollBars = ScrollBars.Vertical;
            txtGunluk.Size = new Size(320, 229);
            txtGunluk.TabIndex = 2;
            // 
            // lblAnlik
            // 
            lblAnlik.AutoSize = true;
            lblAnlik.Location = new Point(70, 109);
            lblAnlik.Name = "lblAnlik";
            lblAnlik.Size = new Size(157, 20);
            lblAnlik.TabIndex = 3;
            lblAnlik.Text = "(Dinleme bekleniyor...)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 450);
            Controls.Add(lblAnlik);
            Controls.Add(txtGunluk);
            Controls.Add(btnDurdur);
            Controls.Add(btnBaslat);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBaslat;
        private Button btnDurdur;
        private TextBox txtGunluk;
        private Label lblAnlik;
    }
}
