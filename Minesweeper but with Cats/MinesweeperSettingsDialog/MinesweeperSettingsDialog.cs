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
        public int mapWidth = 9;
        public int mapHeight = 9;
        public int numMines = 10;
        public bool confirmed;

        public MinesweeperSettingsDialog()
        {
            confirmed = false;
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            customWidthBox.Value = 9;
            customHeightBox.Value = 9;
            customMinesBox.Value = 10;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            customWidthBox.Value = 16;
            customHeightBox.Value = 16;
            customMinesBox.Value = 40;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            customWidthBox.Value = 30;
            customHeightBox.Value = 16;
            customMinesBox.Value = 99;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            confirmed = true;
            mapWidth = (int)customWidthBox.Value;
            mapHeight = (int)customHeightBox.Value;
            numMines = (int)customMinesBox.Value;
            this.Close();
        }
    }
}