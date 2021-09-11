
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
            this.widthLabel = new System.Windows.Forms.PictureBox();
            this.minesLabel = new System.Windows.Forms.PictureBox();
            this.heightLabel = new System.Windows.Forms.PictureBox();
            this.themesLabel = new System.Windows.Forms.PictureBox();
            this.largeTilesCheckBox = new System.Windows.Forms.CheckBox();
            this.largeTilesLabel = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.widthLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.themesLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeTilesLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // customWidthBox
            // 
            this.customWidthBox.Location = new System.Drawing.Point(470, 37);
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
            this.customWidthBox.Size = new System.Drawing.Size(63, 27);
            this.customWidthBox.TabIndex = 5;
            this.customWidthBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.customWidthBox.ValueChanged += new System.EventHandler(this.customWidthBox_ValueChanged);
            // 
            // customHeightBox
            // 
            this.customHeightBox.Location = new System.Drawing.Point(470, 85);
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
            this.customHeightBox.Size = new System.Drawing.Size(63, 27);
            this.customHeightBox.TabIndex = 6;
            this.customHeightBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.customHeightBox.ValueChanged += new System.EventHandler(this.customHeightBox_ValueChanged);
            // 
            // customMinesBox
            // 
            this.customMinesBox.Location = new System.Drawing.Point(470, 135);
            this.customMinesBox.Maximum = new decimal(new int[] {
            899,
            0,
            0,
            0});
            this.customMinesBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customMinesBox.Name = "customMinesBox";
            this.customMinesBox.Size = new System.Drawing.Size(63, 27);
            this.customMinesBox.TabIndex = 7;
            this.customMinesBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customMinesBox.ValueChanged += new System.EventHandler(this.customMinesBox_ValueChanged);
            // 
            // catsThemeButton
            // 
            this.catsThemeButton.Image = ((System.Drawing.Image)(resources.GetObject("catsThemeButton.Image")));
            this.catsThemeButton.Location = new System.Drawing.Point(470, 173);
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
            this.bubbleThemeButton.Location = new System.Drawing.Point(470, 204);
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
            this.darkThemeButton.Location = new System.Drawing.Point(501, 204);
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
            this.classicThemeButton.Location = new System.Drawing.Point(501, 173);
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
            this.easyDifficultyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.easyButton_Down);
            this.easyDifficultyButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.easyButton_Up);
            // 
            // normalDifficultyButton
            // 
            this.normalDifficultyButton.Image = ((System.Drawing.Image)(resources.GetObject("normalDifficultyButton.Image")));
            this.normalDifficultyButton.Location = new System.Drawing.Point(13, 135);
            this.normalDifficultyButton.Name = "normalDifficultyButton";
            this.normalDifficultyButton.Size = new System.Drawing.Size(250, 75);
            this.normalDifficultyButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.normalDifficultyButton.TabIndex = 13;
            this.normalDifficultyButton.TabStop = false;
            this.normalDifficultyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.normalButton_Down);
            this.normalDifficultyButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.normalButton_Up);
            // 
            // hardDifficultyButton
            // 
            this.hardDifficultyButton.Image = ((System.Drawing.Image)(resources.GetObject("hardDifficultyButton.Image")));
            this.hardDifficultyButton.Location = new System.Drawing.Point(12, 253);
            this.hardDifficultyButton.Name = "hardDifficultyButton";
            this.hardDifficultyButton.Size = new System.Drawing.Size(250, 75);
            this.hardDifficultyButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.hardDifficultyButton.TabIndex = 14;
            this.hardDifficultyButton.TabStop = false;
            this.hardDifficultyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hardButton_Down);
            this.hardDifficultyButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hardButton_Up);
            // 
            // confirmButton
            // 
            this.confirmButton.Image = ((System.Drawing.Image)(resources.GetObject("confirmButton.Image")));
            this.confirmButton.Location = new System.Drawing.Point(65, 366);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(198, 75);
            this.confirmButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.confirmButton.TabIndex = 15;
            this.confirmButton.TabStop = false;
            this.confirmButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.confirmButton_Down);
            this.confirmButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.confirmButton_Up);
            // 
            // cancelButton
            // 
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.Location = new System.Drawing.Point(283, 366);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(198, 75);
            this.cancelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cancelButton.TabIndex = 16;
            this.cancelButton.TabStop = false;
            this.cancelButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cancelButton_Down);
            this.cancelButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cancelButton_Up);
            // 
            // widthLabel
            // 
            this.widthLabel.Image = ((System.Drawing.Image)(resources.GetObject("widthLabel.Image")));
            this.widthLabel.Location = new System.Drawing.Point(304, 35);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(160, 29);
            this.widthLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.widthLabel.TabIndex = 17;
            this.widthLabel.TabStop = false;
            // 
            // minesLabel
            // 
            this.minesLabel.Image = ((System.Drawing.Image)(resources.GetObject("minesLabel.Image")));
            this.minesLabel.Location = new System.Drawing.Point(304, 135);
            this.minesLabel.Name = "minesLabel";
            this.minesLabel.Size = new System.Drawing.Size(160, 29);
            this.minesLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minesLabel.TabIndex = 18;
            this.minesLabel.TabStop = false;
            // 
            // heightLabel
            // 
            this.heightLabel.Image = ((System.Drawing.Image)(resources.GetObject("heightLabel.Image")));
            this.heightLabel.Location = new System.Drawing.Point(304, 85);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(160, 37);
            this.heightLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.heightLabel.TabIndex = 19;
            this.heightLabel.TabStop = false;
            // 
            // themesLabel
            // 
            this.themesLabel.Image = ((System.Drawing.Image)(resources.GetObject("themesLabel.Image")));
            this.themesLabel.Location = new System.Drawing.Point(304, 185);
            this.themesLabel.Name = "themesLabel";
            this.themesLabel.Size = new System.Drawing.Size(160, 29);
            this.themesLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.themesLabel.TabIndex = 20;
            this.themesLabel.TabStop = false;
            // 
            // largeTilesCheckBox
            // 
            this.largeTilesCheckBox.AutoSize = true;
            this.largeTilesCheckBox.Location = new System.Drawing.Point(470, 274);
            this.largeTilesCheckBox.Name = "largeTilesCheckBox";
            this.largeTilesCheckBox.Size = new System.Drawing.Size(18, 17);
            this.largeTilesCheckBox.TabIndex = 23;
            this.largeTilesCheckBox.UseVisualStyleBackColor = true;
            this.largeTilesCheckBox.CheckedChanged += new System.EventHandler(this.largeTilesCheckBox_CheckedChanged);
            // 
            // largeTilesLabel
            // 
            this.largeTilesLabel.Image = ((System.Drawing.Image)(resources.GetObject("largeTilesLabel.Image")));
            this.largeTilesLabel.Location = new System.Drawing.Point(304, 253);
            this.largeTilesLabel.Name = "largeTilesLabel";
            this.largeTilesLabel.Size = new System.Drawing.Size(133, 59);
            this.largeTilesLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.largeTilesLabel.TabIndex = 24;
            this.largeTilesLabel.TabStop = false;
            // 
            // MinesweeperSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(128)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(545, 453);
            this.Controls.Add(this.largeTilesLabel);
            this.Controls.Add(this.largeTilesCheckBox);
            this.Controls.Add(this.themesLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.minesLabel);
            this.Controls.Add(this.widthLabel);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MinesweeperSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
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
            ((System.ComponentModel.ISupportInitialize)(this.widthLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.themesLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeTilesLabel)).EndInit();
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
        private PictureBox widthLabel;
        private PictureBox minesLabel;
        private PictureBox heightLabel;
        private PictureBox themesLabel;
        private CheckBox largeTilesCheckBox;
        private PictureBox largeTilesLabel;
    }
}

