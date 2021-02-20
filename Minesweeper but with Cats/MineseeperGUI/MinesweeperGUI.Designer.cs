using MinesweeperModel;
using System;
using System.ComponentModel;

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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.newgameButton = new System.Windows.Forms.PictureBox();
            this.optionsButton = new System.Windows.Forms.PictureBox();
            this.statsButton = new System.Windows.Forms.PictureBox();
            this.helpButton = new System.Windows.Forms.PictureBox();
            this.GUICellsLoader = new System.ComponentModel.BackgroundWorker();
            this.loadingImage = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newgameButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.newgameButton);
            this.flowLayoutPanel1.Controls.Add(this.optionsButton);
            this.flowLayoutPanel1.Controls.Add(this.statsButton);
            this.flowLayoutPanel1.Controls.Add(this.helpButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(145, 517);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // newgameButton
            // 
            this.newgameButton.Image = ((System.Drawing.Image)(resources.GetObject("newgameButton.Image")));
            this.newgameButton.Location = new System.Drawing.Point(3, 3);
            this.newgameButton.Name = "newgameButton";
            this.newgameButton.Size = new System.Drawing.Size(128, 128);
            this.newgameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.newgameButton.TabIndex = 0;
            this.newgameButton.TabStop = false;
            this.newgameButton.Click += new System.EventHandler(this.newgameButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Image = ((System.Drawing.Image)(resources.GetObject("optionsButton.Image")));
            this.optionsButton.Location = new System.Drawing.Point(3, 137);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(112, 105);
            this.optionsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.optionsButton.TabIndex = 1;
            this.optionsButton.TabStop = false;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // statsButton
            // 
            this.statsButton.Image = ((System.Drawing.Image)(resources.GetObject("statsButton.Image")));
            this.statsButton.Location = new System.Drawing.Point(3, 248);
            this.statsButton.Name = "statsButton";
            this.statsButton.Size = new System.Drawing.Size(128, 128);
            this.statsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.statsButton.TabIndex = 2;
            this.statsButton.TabStop = false;
            this.statsButton.Click += new System.EventHandler(this.statsButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.Location = new System.Drawing.Point(3, 382);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(128, 128);
            this.helpButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpButton.TabIndex = 3;
            this.helpButton.TabStop = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // GUICellsLoader
            // 
            this.GUICellsLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadGUICells);
            this.GUICellsLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.endLoadingAnimation);
            // 
            // loadingImage
            // 
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(200, 10);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(225, 225);
            this.loadingImage.TabIndex = 1;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // MinesweeperGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(482, 553);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "MinesweeperGUI";
            this.Text = "Minesweeper but with Cats";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newgameButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox newgameButton;
        private System.Windows.Forms.PictureBox optionsButton;
        private System.Windows.Forms.PictureBox statsButton;
        private System.Windows.Forms.PictureBox helpButton;
        private System.ComponentModel.BackgroundWorker GUICellsLoader;
        private System.Windows.Forms.PictureBox loadingImage;
    }
}

