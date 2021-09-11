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
            this.helpButton = new System.Windows.Forms.PictureBox();
            this.statsButton = new System.Windows.Forms.PictureBox();
            this.optionsButton = new System.Windows.Forms.PictureBox();
            this.newgameButton = new System.Windows.Forms.PictureBox();
            this.minesCounter1 = new System.Windows.Forms.PictureBox();
            this.minesCounter10 = new System.Windows.Forms.PictureBox();
            this.minesCounter100 = new System.Windows.Forms.PictureBox();
            this.statsWorker = new System.ComponentModel.BackgroundWorker();
            this.timeKeeper = new System.ComponentModel.BackgroundWorker();
            this.timerDisplay10m = new System.Windows.Forms.PictureBox();
            this.timerDisplayC = new System.Windows.Forms.PictureBox();
            this.timerDisplay1s = new System.Windows.Forms.PictureBox();
            this.timerDisplay1m = new System.Windows.Forms.PictureBox();
            this.timerDisplay10s = new System.Windows.Forms.PictureBox();
            this.winAnimator = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newgameButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesCounter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesCounter10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesCounter100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay10m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplayC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay1s)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay1m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay10s)).BeginInit();
            this.SuspendLayout();
            // 
            // helpButton
            // 
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.Location = new System.Drawing.Point(12, 412);
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
            this.statsButton.Location = new System.Drawing.Point(12, 312);
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
            this.optionsButton.Location = new System.Drawing.Point(12, 212);
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
            this.newgameButton.Location = new System.Drawing.Point(12, 112);
            this.newgameButton.Name = "newgameButton";
            this.newgameButton.Size = new System.Drawing.Size(250, 75);
            this.newgameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.newgameButton.TabIndex = 0;
            this.newgameButton.TabStop = false;
            this.newgameButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.newgameButton_Down);
            this.newgameButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.newgameButton_Click);
            // 
            // minesCounter1
            // 
            this.minesCounter1.Image = ((System.Drawing.Image)(resources.GetObject("minesCounter1.Image")));
            this.minesCounter1.Location = new System.Drawing.Point(136, 12);
            this.minesCounter1.Name = "minesCounter1";
            this.minesCounter1.Size = new System.Drawing.Size(62, 86);
            this.minesCounter1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minesCounter1.TabIndex = 4;
            this.minesCounter1.TabStop = false;
            // 
            // minesCounter10
            // 
            this.minesCounter10.Image = ((System.Drawing.Image)(resources.GetObject("minesCounter10.Image")));
            this.minesCounter10.Location = new System.Drawing.Point(74, 12);
            this.minesCounter10.Name = "minesCounter10";
            this.minesCounter10.Size = new System.Drawing.Size(62, 86);
            this.minesCounter10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minesCounter10.TabIndex = 5;
            this.minesCounter10.TabStop = false;
            // 
            // minesCounter100
            // 
            this.minesCounter100.Image = ((System.Drawing.Image)(resources.GetObject("minesCounter100.Image")));
            this.minesCounter100.Location = new System.Drawing.Point(12, 12);
            this.minesCounter100.Name = "minesCounter100";
            this.minesCounter100.Size = new System.Drawing.Size(62, 86);
            this.minesCounter100.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minesCounter100.TabIndex = 6;
            this.minesCounter100.TabStop = false;
            this.minesCounter100.Visible = false;
            //
            // statsWorker
            //
            this.statsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.saveStats);
            // 
            // timeKeeper
            // 
            this.timeKeeper.DoWork += new System.ComponentModel.DoWorkEventHandler(this.timeKeeperWork);
            // 
            // timerDisplay10m
            // 
            this.timerDisplay10m.Image = ((System.Drawing.Image)(resources.GetObject("timerDisplay10m.Image")));
            this.timerDisplay10m.Location = new System.Drawing.Point(278, 12);
            this.timerDisplay10m.Name = "timerDisplay10m";
            this.timerDisplay10m.Size = new System.Drawing.Size(62, 86);
            this.timerDisplay10m.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.timerDisplay10m.TabIndex = 8;
            this.timerDisplay10m.TabStop = false;
            // 
            // timerDisplayC
            // 
            this.timerDisplayC.Image = ((System.Drawing.Image)(resources.GetObject("timerDisplayC.Image")));
            this.timerDisplayC.Location = new System.Drawing.Point(414, 12);
            this.timerDisplayC.Name = "timerDisplayC";
            this.timerDisplayC.Size = new System.Drawing.Size(30, 86);
            this.timerDisplayC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.timerDisplayC.TabIndex = 9;
            this.timerDisplayC.TabStop = false;
            // 
            // timerDisplay1s
            // 
            this.timerDisplay1s.Image = ((System.Drawing.Image)(resources.GetObject("timerDisplay1s.Image")));
            this.timerDisplay1s.Location = new System.Drawing.Point(518, 12);
            this.timerDisplay1s.Name = "timerDisplay1s";
            this.timerDisplay1s.Size = new System.Drawing.Size(62, 86);
            this.timerDisplay1s.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.timerDisplay1s.TabIndex = 10;
            this.timerDisplay1s.TabStop = false;
            // 
            // timerDisplay1m
            // 
            this.timerDisplay1m.Image = ((System.Drawing.Image)(resources.GetObject("timerDisplay1m.Image")));
            this.timerDisplay1m.Location = new System.Drawing.Point(346, 12);
            this.timerDisplay1m.Name = "timerDisplay1m";
            this.timerDisplay1m.Size = new System.Drawing.Size(62, 86);
            this.timerDisplay1m.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.timerDisplay1m.TabIndex = 11;
            this.timerDisplay1m.TabStop = false;
            // 
            // timerDisplay10s
            // 
            this.timerDisplay10s.Image = ((System.Drawing.Image)(resources.GetObject("timerDisplay10s.Image")));
            this.timerDisplay10s.Location = new System.Drawing.Point(450, 12);
            this.timerDisplay10s.Name = "timerDisplay10s";
            this.timerDisplay10s.Size = new System.Drawing.Size(62, 86);
            this.timerDisplay10s.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.timerDisplay10s.TabIndex = 12;
            this.timerDisplay10s.TabStop = false;
            //
            // winAnimator
            //
            this.winAnimator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.winAnimatorWork);
            this.winAnimator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.endWinAnimation);
            // 
            // MinesweeperGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(128)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(592, 503);
            this.Controls.Add(this.timerDisplay10s);
            this.Controls.Add(this.timerDisplay1m);
            this.Controls.Add(this.timerDisplay1s);
            this.Controls.Add(this.timerDisplayC);
            this.Controls.Add(this.timerDisplay10m);
            this.Controls.Add(this.minesCounter100);
            this.Controls.Add(this.minesCounter10);
            this.Controls.Add(this.minesCounter1);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.newgameButton);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(610, 550);
            this.Name = "MinesweeperGUI";
            this.Text = "Minesweeper but with Cats";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.drawBoard);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tilesMouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tilesMouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newgameButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesCounter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesCounter10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesCounter100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay10m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplayC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay1s)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay1m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay10s)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox helpButton;
        private System.Windows.Forms.PictureBox statsButton;
        private System.Windows.Forms.PictureBox optionsButton;
        private System.Windows.Forms.PictureBox newgameButton;
        private PictureBox minesCounter1;
        private PictureBox minesCounter10;
        private PictureBox minesCounter100;
        private BackgroundWorker statsWorker;
        private BackgroundWorker timeKeeper;
        private PictureBox timerDisplay10m;
        private PictureBox timerDisplayC;
        private PictureBox timerDisplay1s;
        private PictureBox timerDisplay1m;
        private PictureBox timerDisplay10s;
        private BackgroundWorker winAnimator;
    }
}

