using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinesweeperModel;

namespace MinesweeperGUI
{
    public partial class MinesweeperGUI : Form
    {

        private readonly int ANCHOR_POINT_X = 200;
        private readonly int ANCHOR_POINT_Y = 0;
        private List<PictureBox> GUICells;

        public MinesweeperGUI()
        {
            GUICells = new List<PictureBox>();
            InitializeComponent();
        }

        private void newgameButton_Click(object sender, EventArgs e)
        {

            wipe_GUICells();

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    PictureBox GUICell = new PictureBox();
                    GUICell.Image = Properties.Resources.cat_blank;
                    GUICell.Location = new Point((x * 25) + ANCHOR_POINT_X, (y * 25) + ANCHOR_POINT_Y);
                    GUICell.Size = new Size(25, 25);
                    GUICell.MouseUp += new MouseEventHandler(GUICell_Click);

                    this.Controls.Add(GUICell);
                    GUICells.Add(GUICell);
                }
            }
        }

        private void wipe_GUICells()
        {
            
            foreach (PictureBox GUICell in GUICells)
            {
                this.Controls.Remove(GUICell);
            }
            
            GUICells.Clear();
        }

        private void GUICell_Click(object sender, MouseEventArgs e)
        {
            // GUICells are in an array just like MinesweeperCells
            // index = x + y * rowlength
            // rowlength is 5
            // x = mouse.x - anchor_x / 25
            // y = mouse.y - anchor_y / 25
            // MousePosition is relative to the screen, to get it relative to the form we convert 
            Point relativeMousePosition = PointToClient(MousePosition);
            int cellx = (relativeMousePosition.X - ANCHOR_POINT_X) / 25;
            int celly = (relativeMousePosition.Y - ANCHOR_POINT_Y) / 25;

            if (e.Button == MouseButtons.Left)
            {
                GUICells[cellx + (celly * 5)].Image = Properties.Resources._0;
            }
            else if (e.Button == MouseButtons.Right)
            {
                GUICells[cellx + (celly * 5)].Image = Properties.Resources.cat_flagged;
            }


        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this needs to open up a new dialog that lets you change settings.", "options");
        }

        private void statsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I have not added stats yet.", "oops");
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This box explains how to play minesweeper.", "help");
        }
    }
}
