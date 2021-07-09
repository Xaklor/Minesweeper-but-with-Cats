
using System;
using System.Windows.Forms;

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
            this.easyDifficultyButton = new System.Windows.Forms.PictureBox();
            this.normalDifficultyButton = new System.Windows.Forms.PictureBox();
            this.hardDifficultyButton = new System.Windows.Forms.PictureBox();
            this.confirmButton = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.customWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMinesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicThemeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyDifficultyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalDifficultyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardDifficultyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
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
            // easyDifficultyButton
            // 
            this.easyDifficultyButton.Image = ((System.Drawing.Image)(resources.GetObject("easyDifficultyButton.Image")));
            this.easyDifficultyButton.Location = new System.Drawing.Point(13, 13);
            this.easyDifficultyButton.Name = "easyDifficultyButton";
            this.easyDifficultyButton.Size = new System.Drawing.Size(250, 75);
            this.easyDifficultyButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.easyDifficultyButton.TabIndex = 12;
            this.easyDifficultyButton.TabStop = false;
            this.easyDifficultyButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.easyButton_Up);
            this.easyDifficultyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.easyButton_Down);
            // 
            // normalDifficultyButton
            // 
            this.normalDifficultyButton.Image = ((System.Drawing.Image)(resources.GetObject("normalDifficultyButton.Image")));
            this.normalDifficultyButton.Location = new System.Drawing.Point(13, 113);
            this.normalDifficultyButton.Name = "normalDifficultyButton";
            this.normalDifficultyButton.Size = new System.Drawing.Size(250, 75);
            this.normalDifficultyButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.normalDifficultyButton.TabIndex = 13;
            this.normalDifficultyButton.TabStop = false;
            this.normalDifficultyButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.normalButton_Up);
            this.normalDifficultyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.normalButton_Down);
            // 
            // hardDifficultyButton
            // 
            this.hardDifficultyButton.Image = ((System.Drawing.Image)(resources.GetObject("hardDifficultyButton.Image")));
            this.hardDifficultyButton.Location = new System.Drawing.Point(13, 213);
            this.hardDifficultyButton.Name = "hardDifficultyButton";
            this.hardDifficultyButton.Size = new System.Drawing.Size(250, 75);
            this.hardDifficultyButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.hardDifficultyButton.TabIndex = 14;
            this.hardDifficultyButton.TabStop = false;
            this.hardDifficultyButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hardButton_Up);
            this.hardDifficultyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hardButton_Down);
            // 
            // confirmButton
            // 
            this.confirmButton.Image = ((System.Drawing.Image)(resources.GetObject("confirmButton.Image")));
            this.confirmButton.Location = new System.Drawing.Point(65, 307);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(198, 75);
            this.confirmButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.confirmButton.TabIndex = 15;
            this.confirmButton.TabStop = false;
            this.confirmButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.confirmButton_Up);
            this.confirmButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.confirmButton_Down);
            // 
            // cancelButton
            // 
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.Location = new System.Drawing.Point(283, 307);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(198, 75);
            this.cancelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cancelButton.TabIndex = 16;
            this.cancelButton.TabStop = false;
            this.cancelButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cancelButton_Up);
            this.cancelButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cancelButton_Down);
            // 
            // MinesweeperSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(34, 128, 58);
            this.ClientSize = new System.Drawing.Size(545, 403);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.hardDifficultyButton);
            this.Controls.Add(this.normalDifficultyButton);
            this.Controls.Add(this.easyDifficultyButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.easyDifficultyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalDifficultyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardDifficultyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
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
        private System.Windows.Forms.PictureBox easyDifficultyButton;
        private System.Windows.Forms.PictureBox normalDifficultyButton;
        private System.Windows.Forms.PictureBox hardDifficultyButton;
        private System.Windows.Forms.PictureBox confirmButton;
        private System.Windows.Forms.PictureBox cancelButton;
    }
}

