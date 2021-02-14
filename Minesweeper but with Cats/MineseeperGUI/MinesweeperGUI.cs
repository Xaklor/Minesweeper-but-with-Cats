using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private List<PictureBox> GUICells;
        private int mapWidth;
        private int mapHeight;
        private int numMines;

        // used for attaching GUICells to the GUI from the background worker
        private delegate void addGUICellDelegate(Form form, Control GUICell);
        addGUICellDelegate addGUICell = (Form form, Control GUICell) => form.Controls.Add(GUICell);

        // used for deleting old GUICells from the GUI from the background worker
        private delegate void wipeGUICellDelegate(MinesweeperGUI GUI);
        wipeGUICellDelegate wipeGUICell = wipeGUICells;

        public MinesweeperGUI()
        {
            GUICells = new List<PictureBox>();
            mapWidth = 9;
            mapHeight = 9;
            numMines = 10;
            InitializeComponent();
        }

        /// <summary>
        /// entry point for the process of starting a new game. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newgameButton_Click(object sender, EventArgs e)
        {
            // this starts the loading animation playing and adjusts it to match our current map size
            loadingImage.Size = new Size(mapWidth * 25, mapHeight * 25);
            loadingImage.Visible = true;
            
            // in order for the GUI to paint changes, the main thread needs to be idle
            // this starts up the intensive work on a background worker thread, it will run loadGUICells()
            GUICellsLoader.RunWorkerAsync();            
        }

        /// <summary>
        /// work done by the background worker, GUICellsLoader.
        /// this clears away the old GUICells, and then generates the new ones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadGUICells(object sender, DoWorkEventArgs e)
        {
            // this timer tracks how long it takes to perform the task
            Stopwatch workTimer = new Stopwatch();
            workTimer.Start();

            // clearing the old GUICells requires access to the main thread, so Invoke is necessary here.
            Invoke(wipeGUICell, new object[] { this });

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    PictureBox GUICell = new PictureBox();
                    GUICell.Image = Properties.Resources.cat_blank;
                    // anchor the GUICells based on loadingImage's location for consistency in case something moves.
                    GUICell.Location = new Point((x * 25) + loadingImage.Location.X, (y * 25) + loadingImage.Location.Y);
                    GUICell.Size = new Size(25, 25);
                    GUICell.MouseUp += new MouseEventHandler(GUICell_Click);

                    // adding to the GUI's controls requires access to the main thread, so Invoke is necessary here.
                    Invoke(addGUICell, new Object[] { this, GUICell });
                    GUICells.Add(GUICell);
                }
            }

            // wait until the loading animation has finished playing, once this method finishes the animation will be 
            // removed and we don't want that to happen in the middle of the animation.
            while (workTimer.ElapsedMilliseconds < 1500) { }
        }

        /// <summary>
        /// static method for clearing away old GUICells, used by the background worker's Invoke.
        /// </summary>
        /// <param name="GUI"></param>
        private static void wipeGUICells(MinesweeperGUI GUI)
        {
            foreach (PictureBox GUICell in GUI.GUICells)
            {
                GUICell.Dispose();
            }

            GUI.GUICells.Clear();
        }

        /// <summary>
        /// ending point for the process of starting a new game. removes the loading animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endLoadingAnimation(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingImage.Visible = false;
        }

        /// <summary>
        /// click up event handler for the game.
        /// left clicking a cell reveals it.
        /// right clicking a cell flags it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUICell_Click(object sender, MouseEventArgs e)
        {
            // GUICells are in an array just like MinesweeperCells
            // index = x + y * rowlength
            // rowlength is mapWidth
            // anchor point is the loadingImage's location in case things move
            // x = mouse.x - anchor_x / 25
            // y = mouse.y - anchor_y / 25
            // MousePosition is relative to the screen, to get it relative to the form we convert 
            Point relativeMousePosition = PointToClient(MousePosition);
            int cellx = (relativeMousePosition.X - loadingImage.Location.X) / 25;
            int celly = (relativeMousePosition.Y - loadingImage.Location.Y) / 25;

            // left clicking a cell reveals it
            if (e.Button == MouseButtons.Left)
            {
                GUICells[cellx + (celly * mapWidth)].Image = Properties.Resources._0;
            }
            // right clicking a cell flags it
            else if (e.Button == MouseButtons.Right)
            {
                GUICells[cellx + (celly * mapWidth)].Image = Properties.Resources.cat_flagged;
            }
        }

        /// <summary>
        /// opens the settings dialog and copies the results into the main program.
        /// currently the settings dialog only sends information for easy, normal, and hard mode maps.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsButton_Click(object sender, EventArgs e)
        {
            MinesweeperSettingsDialog settingsDialog = new MinesweeperSettingsDialog();
            settingsDialog.ShowDialog();

            // only make changes if the confirm button was clicked in the dialog. 
            if (settingsDialog.confirmed)
            {
                mapWidth = settingsDialog.mapWidth;
                mapHeight = settingsDialog.mapHeight;
                numMines = settingsDialog.numMines;

                newgameButton_Click(null, null);
            }
        }

        /// <summary>
        /// not implemented yet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I have not added stats yet.", "oops");
        }

        /// <summary>
        /// not implemented yet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This box explains how to play minesweeper.", "help");
        }

        
    }
}
