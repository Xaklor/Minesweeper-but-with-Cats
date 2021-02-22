
namespace MinesweeperGUI
{
    partial class MinesweeperSettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinesweeperSettingsDialog));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.customWidthBox = new System.Windows.Forms.NumericUpDown();
            this.customHeightBox = new System.Windows.Forms.NumericUpDown();
            this.customMinesBox = new System.Windows.Forms.NumericUpDown();
            this.catsThemeButton = new System.Windows.Forms.PictureBox();
            this.bubbleThemeButton = new System.Windows.Forms.PictureBox();
            this.darkThemeButton = new System.Windows.Forms.PictureBox();
            this.classicThemeButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMinesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicThemeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(302, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(153, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(125, 106);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(153, 179);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 140);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // customWidthBox
            // 
            this.customWidthBox.Location = new System.Drawing.Point(354, 168);
            this.customWidthBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.customWidthBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.customWidthBox.Name = "customWidthBox";
            this.customWidthBox.Size = new System.Drawing.Size(150, 27);
            this.customWidthBox.TabIndex = 5;
            this.customWidthBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // customHeightBox
            // 
            this.customHeightBox.Location = new System.Drawing.Point(354, 201);
            this.customHeightBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.customHeightBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.customHeightBox.Name = "customHeightBox";
            this.customHeightBox.Size = new System.Drawing.Size(150, 27);
            this.customHeightBox.TabIndex = 6;
            this.customHeightBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // customMinesBox
            // 
            this.customMinesBox.Location = new System.Drawing.Point(354, 234);
            this.customMinesBox.Maximum = new decimal(new int[] {
            1599,
            0,
            0,
            0});
            this.customMinesBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customMinesBox.Name = "customMinesBox";
            this.customMinesBox.Size = new System.Drawing.Size(150, 27);
            this.customMinesBox.TabIndex = 7;
            this.customMinesBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // catsThemeButton
            // 
            this.catsThemeButton.Image = ((System.Drawing.Image)(resources.GetObject("catsThemeButton.Image")));
            this.catsThemeButton.Location = new System.Drawing.Point(47, 201);
            this.catsThemeButton.Name = "catsThemeButton";
            this.catsThemeButton.Size = new System.Drawing.Size(25, 25);
            this.catsThemeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.catsThemeButton.TabIndex = 8;
            this.catsThemeButton.TabStop = false;
            this.catsThemeButton.Click += new System.EventHandler(this.setCatTheme);
            // 
            // bubbleThemeButton
            // 
            this.bubbleThemeButton.Image = ((System.Drawing.Image)(resources.GetObject("bubbleThemeButton.Image")));
            this.bubbleThemeButton.Location = new System.Drawing.Point(47, 234);
            this.bubbleThemeButton.Name = "bubbleThemeButton";
            this.bubbleThemeButton.Size = new System.Drawing.Size(25, 25);
            this.bubbleThemeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bubbleThemeButton.TabIndex = 9;
            this.bubbleThemeButton.TabStop = false;
            this.bubbleThemeButton.Click += new System.EventHandler(this.setBubbleTheme);
            // 
            // darkThemeButton
            // 
            this.darkThemeButton.Image = ((System.Drawing.Image)(resources.GetObject("darkThemeButton.Image")));
            this.darkThemeButton.Location = new System.Drawing.Point(78, 234);
            this.darkThemeButton.Name = "darkThemeButton";
            this.darkThemeButton.Size = new System.Drawing.Size(25, 25);
            this.darkThemeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.darkThemeButton.TabIndex = 10;
            this.darkThemeButton.TabStop = false;
            this.darkThemeButton.Click += new System.EventHandler(this.setDarkTheme);
            // 
            // classicThemeButton
            // 
            this.classicThemeButton.Image = ((System.Drawing.Image)(resources.GetObject("classicThemeButton.Image")));
            this.classicThemeButton.Location = new System.Drawing.Point(78, 201);
            this.classicThemeButton.Name = "classicThemeButton";
            this.classicThemeButton.Size = new System.Drawing.Size(25, 25);
            this.classicThemeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.classicThemeButton.TabIndex = 11;
            this.classicThemeButton.TabStop = false;
            this.classicThemeButton.Click += new System.EventHandler(this.setClassicTheme);
            // 
            // MinesweeperSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(545, 403);
            this.Controls.Add(this.classicThemeButton);
            this.Controls.Add(this.darkThemeButton);
            this.Controls.Add(this.bubbleThemeButton);
            this.Controls.Add(this.catsThemeButton);
            this.Controls.Add(this.customMinesBox);
            this.Controls.Add(this.customHeightBox);
            this.Controls.Add(this.customWidthBox);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MinesweeperSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMinesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsThemeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleThemeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkThemeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicThemeButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.NumericUpDown customWidthBox;
        private System.Windows.Forms.NumericUpDown customHeightBox;
        private System.Windows.Forms.NumericUpDown customMinesBox;
        private System.Windows.Forms.PictureBox catsThemeButton;
        private System.Windows.Forms.PictureBox bubbleThemeButton;
        private System.Windows.Forms.PictureBox darkThemeButton;
        private System.Windows.Forms.PictureBox classicThemeButton;
    }
}

