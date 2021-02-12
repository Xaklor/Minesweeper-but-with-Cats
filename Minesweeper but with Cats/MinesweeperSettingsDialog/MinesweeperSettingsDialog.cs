using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class MinesweeperSettingsDialog : Form
    {
        public int mapWidth;
        public int mapHeight;
        public int numMines;

        public MinesweeperSettingsDialog()
        {
            mapWidth = 30;
            mapHeight = 16;
            numMines = 99;
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            mapWidth = 9;
            mapHeight = 9;
            numMines = 10;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mapWidth = 16;
            mapHeight = 16;
            numMines = 40;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mapWidth = 30;
            mapHeight = 16;
            numMines = 99;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}