using MinesweeperModel;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    partial class MinesweeperGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinesweeperGUI));
            this.GUICellsLoader = new System.ComponentModel.BackgroundWorker();
            this.loadingImage = new System.Windows.Forms.PictureBox();
            this.helpButton = new System.Windows.Forms.PictureBox();
            this.statsButton = new System.Windows.Forms.PictureBox();
            this.optionsButton = new System.Windows.Forms.PictureBox();
            this.newgameButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newgameButton)).BeginInit();
            this.SuspendLayout();
            // 
            // GUICellsLoader
            // 
            this.GUICellsLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadGUICells);
            this.GUICellsLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.endLoadingAnimation);
            // 
            // loadingImage
            // 
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(278, 12);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(225, 225);
            this.loadingImage.TabIndex = 1;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // helpButton
            // 
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.Location = new System.Drawing.Point(12, 312);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(250, 75);
            this.helpButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpButton.TabIndex = 3;
            this.helpButton.TabStop = false;
            this.helpButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.helpButton_Down);
            this.helpButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.helpButton_Click);
            // 
            // statsButton
            // 
            this.statsButton.Image = ((System.Drawing.Image)(resources.GetObject("statsButton.Image")));
            this.statsButton.Location = new System.Drawing.Point(12, 212);
            this.statsButton.Name = "statsButton";
            this.statsButton.Size = new System.Drawing.Size(250, 75);
            this.statsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.statsButton.TabIndex = 2;
            this.statsButton.TabStop = false;
            this.statsButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.statsButton_Down);
            this.statsButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.statsButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Image = ((System.Drawing.Image)(resources.GetObject("optionsButton.Image")));
            this.optionsButton.Location = new System.Drawing.Point(12, 112);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(250, 75);
            this.optionsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.optionsButton.TabIndex = 1;
            this.optionsButton.TabStop = false;
            this.optionsButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.optionsButton_Down);
            this.optionsButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.optionsButton_Click);
            // 
            // newgameButton
            // 
            this.newgameButton.Image = ((System.Drawing.Image)(resources.GetObject("newgameButton.Image")));
            this.newgameButton.Location = new System.Drawing.Point(12, 12);
            this.newgameButton.Name = "newgameButton";
            this.newgameButton.Size = new System.Drawing.Size(250, 75);
            this.newgameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.newgameButton.TabIndex = 0;
            this.newgameButton.TabStop = false;
            this.newgameButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.newgameButton_Down);
            this.newgameButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.newgameButton_Click);
            // 
            // MinesweeperGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(128)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(512, 453);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.newgameButton);
            this.Controls.Add(this.loadingImage);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(530, 500);
            this.Name = "MinesweeperGUI";
            this.Text = "Minesweeper but with Cats";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onExit);
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newgameButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker GUICellsLoader;
        private System.Windows.Forms.PictureBox loadingImage;
        private System.Windows.Forms.PictureBox helpButton;
        private System.Windows.Forms.PictureBox statsButton;
        private System.Windows.Forms.PictureBox optionsButton;
        private System.Windows.Forms.PictureBox newgameButton;
    }
}

