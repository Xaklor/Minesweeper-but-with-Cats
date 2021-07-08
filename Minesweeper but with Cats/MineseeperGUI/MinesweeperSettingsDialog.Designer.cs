﻿
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
            this.customWidthBox = new System.Windows.Forms.NumericUpDown();
            this.customHeightBox = new System.Windows.Forms.NumericUpDown();
            this.customMinesBox = new System.Windows.Forms.NumericUpDown();
            this.catsThemeButton = new System.Windows.Forms.PictureBox();
            this.bubbleThemeButton = new System.Windows.Forms.PictureBox();
            this.darkThemeButton = new System.Windows.Forms.PictureBox();
            this.classicThemeButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.customWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMinesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
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
            this.catsThemeButton.Location = new System.Drawing.Point(354, 63);
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
            this.bubbleThemeButton.Location = new System.Drawing.Point(416, 63);
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
            this.darkThemeButton.Location = new System.Drawing.Point(447, 63);
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
            this.classicThemeButton.Location = new System.Drawing.Point(385, 63);
            this.classicThemeButton.Name = "classicThemeButton";
            this.classicThemeButton.Size = new System.Drawing.Size(25, 25);
            this.classicThemeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.classicThemeButton.TabIndex = 11;
            this.classicThemeButton.TabStop = false;
            this.classicThemeButton.Click += new System.EventHandler(this.setClassicTheme);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(13, 113);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(13, 213);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(250, 75);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(65, 307);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(198, 75);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(283, 307);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(198, 75);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // MinesweeperSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(545, 403);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.classicThemeButton);
            this.Controls.Add(this.darkThemeButton);
            this.Controls.Add(this.bubbleThemeButton);
            this.Controls.Add(this.catsThemeButton);
            this.Controls.Add(this.customMinesBox);
            this.Controls.Add(this.customHeightBox);
            this.Controls.Add(this.customWidthBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MinesweeperSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.customWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMinesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsThemeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleThemeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkThemeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicThemeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown customWidthBox;
        private System.Windows.Forms.NumericUpDown customHeightBox;
        private System.Windows.Forms.NumericUpDown customMinesBox;
        private System.Windows.Forms.PictureBox catsThemeButton;
        private System.Windows.Forms.PictureBox bubbleThemeButton;
        private System.Windows.Forms.PictureBox darkThemeButton;
        private System.Windows.Forms.PictureBox classicThemeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}
