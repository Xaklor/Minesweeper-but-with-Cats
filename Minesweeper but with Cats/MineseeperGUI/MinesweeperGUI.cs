using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MinesweeperModel;

namespace MinesweeperGUI
{
    public enum state
    {
        blank,
        flagged,
        mine,
        zero,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight
    }
    public enum theme
    {
        cats,
        classic,
        bubble,
        dark
    }

    public partial class MinesweeperGUI : Form
    {
        private List<GUICell> GUICells;
        private int mapWidth;
        private int mapHeight;
        private int numMines;
        private int numMinesInit;
        private theme currentTheme;

        // used for attaching GUICells to the GUI from the background worker
        private delegate void addGUICellDelegate(Form form, Control GUICell);
        addGUICellDelegate addGUICell = (Form form, Control GUICell) => form.Controls.Add(GUICell);

        // used for deleting old GUICells from the GUI from the background worker
        private delegate void wipeGUICellDelegate(MinesweeperGUI GUI);
        wipeGUICellDelegate wipeGUICell = wipeGUICells;

        // this thing is called a Pinvoke, I don't understand what that means but what happens here is that
        // the default windows system timer isn't accurate enough to handle animated gifs in the picturebox,
        // so this overrides that and sets the timer to match the frequency of the animated gif loading animation.
        // the speed of the timer can be adjusted by changing timerAccuracy, but 10ms is enough for my animations.
        // taken from here: https://stackoverflow.com/questions/25382400/gif-animated-files-in-c-sharp-have-lower-framerates-than-they-should
        private const int timerAccuracy = 10;
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        public static extern int timeEndPeriod(int msec);

        public MinesweeperGUI()
        {
            GUICells = new List<GUICell>();
            mapWidth = 9;
            mapHeight = 9;
            numMines = 10;
            numMinesInit = 10;
            currentTheme = theme.cats;
            InitializeComponent();
            // this sets the internal timer to the new speed.
            timeBeginPeriod(timerAccuracy);
        }

        /*
         * ----------------
         * NEW GAME METHODS
         * ----------------
         */

        /// <summary>
        /// causes the newgame button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newgameButton_Down(object sender, MouseEventArgs e)
        {
            switch (currentTheme)
            {
                case theme.cats:
                    newgameButton.Image = Properties.Resources.cat_newgame_button_pressed;
                    break;

                case theme.classic:
                    newgameButton.Image = Properties.Resources.classic_newgame_button_pressed;
                    break;

                case theme.dark:
                    newgameButton.Image = Properties.Resources.dark_newgame_button_pressed;
                    break;

                case theme.bubble:
                    newgameButton.Image = Properties.Resources.bubble_newgame_button_pressed;
                    break;
            }
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

            numMines = numMinesInit;
            setMinesDisplay(true);

            // in order for the GUI to paint changes, the main thread needs to be idle
            // this starts up the intensive work on a background worker thread, it will run loadGUICells()
            GUICellsLoader.RunWorkerAsync();

            // this causes the button to pop back up.
            switch (currentTheme)
            {
                case theme.cats:
                    newgameButton.Image = Properties.Resources.cat_newgame_button;
                    break;

                case theme.classic:
                    newgameButton.Image = Properties.Resources.classic_newgame_button;
                    break;

                case theme.dark:
                    newgameButton.Image = Properties.Resources.dark_newgame_button;
                    break;

                case theme.bubble:
                    newgameButton.Image = Properties.Resources.bubble_newgame_button;
                    break;
            }
        }

        /// <summary>
        /// sets the mines displays to match the current number of shown mines. if this is called on game startup, 
        /// then it will also hide the hundreds or thousands place if they are unneeded.
        /// </summary>
        /// <param name="startup"></param>
        private void setMinesDisplay(bool startup=false)
        {
            // don't count negatives, just set everything to 0 and end instead.
            if (numMines < 0)
            {
                this.minesCounter1.Image    = Properties.Resources.display_0;
                this.minesCounter10.Image   = Properties.Resources.display_0;
                this.minesCounter100.Image  = Properties.Resources.display_0;
                this.minesCounter1000.Image = Properties.Resources.display_0;
                return;
            }

            // ones
            switch (numMines % 10)
            {
                case 0:
                    this.minesCounter1.Image = Properties.Resources.display_0;
                    break;
                case 1:
                    this.minesCounter1.Image = Properties.Resources.display_1;
                    break;
                case 2:
                    this.minesCounter1.Image = Properties.Resources.display_2;
                    break;
                case 3:
                    this.minesCounter1.Image = Properties.Resources.display_3;
                    break;
                case 4:
                    this.minesCounter1.Image = Properties.Resources.display_4;
                    break;
                case 5:
                    this.minesCounter1.Image = Properties.Resources.display_5;
                    break;
                case 6:
                    this.minesCounter1.Image = Properties.Resources.display_6;
                    break;
                case 7:
                    this.minesCounter1.Image = Properties.Resources.display_7;
                    break;
                case 8:
                    this.minesCounter1.Image = Properties.Resources.display_8;
                    break;
                case 9:
                    this.minesCounter1.Image = Properties.Resources.display_9;
                    break;
            }

            // tens
            switch (numMines % 100 / 10)
            {
                case 0:
                    this.minesCounter10.Image = Properties.Resources.display_0;
                    break;
                case 1:
                    this.minesCounter10.Image = Properties.Resources.display_1;
                    break;
                case 2:
                    this.minesCounter10.Image = Properties.Resources.display_2;
                    break;
                case 3:
                    this.minesCounter10.Image = Properties.Resources.display_3;
                    break;
                case 4:
                    this.minesCounter10.Image = Properties.Resources.display_4;
                    break;
                case 5:
                    this.minesCounter10.Image = Properties.Resources.display_5;
                    break;
                case 6:
                    this.minesCounter10.Image = Properties.Resources.display_6;
                    break;
                case 7:
                    this.minesCounter10.Image = Properties.Resources.display_7;
                    break;
                case 8:
                    this.minesCounter10.Image = Properties.Resources.display_8;
                    break;
                case 9:
                    this.minesCounter10.Image = Properties.Resources.display_9;
                    break;
            }

            // hundreds
            if(startup)
                this.minesCounter100.Visible = true;

            switch (numMines % 1000 / 100)
            {
                case 0:
                    this.minesCounter100.Image = Properties.Resources.display_0;
                    if(startup)
                        this.minesCounter100.Visible = false;

                    break;
                case 1:
                    this.minesCounter100.Image = Properties.Resources.display_1;
                    break;
                case 2:
                    this.minesCounter100.Image = Properties.Resources.display_2;
                    break;
                case 3:
                    this.minesCounter100.Image = Properties.Resources.display_3;
                    break;
                case 4:
                    this.minesCounter100.Image = Properties.Resources.display_4;
                    break;
                case 5:
                    this.minesCounter100.Image = Properties.Resources.display_5;
                    break;
                case 6:
                    this.minesCounter100.Image = Properties.Resources.display_6;
                    break;
                case 7:
                    this.minesCounter100.Image = Properties.Resources.display_7;
                    break;
                case 8:
                    this.minesCounter100.Image = Properties.Resources.display_8;
                    break;
                case 9:
                    this.minesCounter100.Image = Properties.Resources.display_9;
                    break;
            }

            // thousands
            if(startup)
                this.minesCounter1000.Visible = true;

            switch (numMines % 10000 / 1000)
            {
                case 0:
                    this.minesCounter1000.Image = Properties.Resources.display_0;
                    if(startup)
                        this.minesCounter1000.Visible = false;

                    break;
                case 1:
                    this.minesCounter1000.Image = Properties.Resources.display_1;
                    break;
                case 2:
                    this.minesCounter1000.Image = Properties.Resources.display_2;
                    break;
                case 3:
                    this.minesCounter1000.Image = Properties.Resources.display_3;
                    break;
                case 4:
                    this.minesCounter1000.Image = Properties.Resources.display_4;
                    break;
                case 5:
                    this.minesCounter1000.Image = Properties.Resources.display_5;
                    break;
                case 6:
                    this.minesCounter1000.Image = Properties.Resources.display_6;
                    break;
                case 7:
                    this.minesCounter1000.Image = Properties.Resources.display_7;
                    break;
                case 8:
                    this.minesCounter1000.Image = Properties.Resources.display_8;
                    break;
                case 9:
                    this.minesCounter1000.Image = Properties.Resources.display_9;
                    break;
            }
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
                    GUICell cell = new GUICell();
                    cell.currentTheme = this.currentTheme;
                    cell.currentState = state.blank;
                    updateGUICellState(cell, state.blank);
                    // anchor the GUICells based on loadingImage's location for consistency in case something moves.
                    cell.Location = new Point((x * 25) + loadingImage.Location.X, (y * 25) + loadingImage.Location.Y);
                    cell.Size = new Size(25, 25);
                    cell.MouseUp += new MouseEventHandler(GUICell_Click);

                    // adding to the GUI's controls requires access to the main thread, so Invoke is necessary here.
                    Invoke(addGUICell, new Object[] { this, cell });
                    GUICells.Add(cell);
                }
            }

            // wait until the loading animation has finished playing, once this method finishes the animation will be 
            // removed and we don't want that to happen in the middle of the animation.
            while (workTimer.ElapsedMilliseconds < 1820) { }
        }

        /// <summary>
        /// static method for clearing away old GUICells, used by the background worker's Invoke.
        /// </summary>
        /// <param name="GUI"></param>
        private static void wipeGUICells(MinesweeperGUI GUI)
        {
            foreach (GUICell cell in GUI.GUICells)
            {
                cell.Dispose();
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

        /*
         * ----------------------
         * OPTIONS BUTTON METHODS
         * ----------------------
         */

        /// <summary>
        /// causes the options button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsButton_Down(object sender, MouseEventArgs e)
        {
            switch (currentTheme)
            {
                case theme.cats:
                    optionsButton.Image = Properties.Resources.cat_options_button_pressed;
                    break;

                case theme.classic:
                    optionsButton.Image = Properties.Resources.classic_options_button_pressed;
                    break;

                case theme.dark:
                    optionsButton.Image = Properties.Resources.dark_options_button_pressed;
                    break;

                case theme.bubble:
                    optionsButton.Image = Properties.Resources.bubble_options_button_pressed;
                    break;
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
            MinesweeperSettingsDialog settingsDialog = new MinesweeperSettingsDialog(this.currentTheme, mapWidth, mapHeight, numMines);
            settingsDialog.ShowDialog();

            // this causes the button to pop back up.
            switch (currentTheme)
            {
                case theme.cats:
                    optionsButton.Image = Properties.Resources.cat_options_button;
                    break;

                case theme.classic:
                    optionsButton.Image = Properties.Resources.classic_options_button;
                    break;

                case theme.dark:
                    optionsButton.Image = Properties.Resources.dark_options_button;
                    break;

                case theme.bubble:
                    optionsButton.Image = Properties.Resources.bubble_options_button;
                    break;
            }

            // update the theme if a new one was chosen inside the dialog.
            if (settingsDialog.selectedTheme != this.currentTheme)
            {
                changeTheme(settingsDialog.selectedTheme);
            }

            // only make game changes if the confirm button was clicked in the dialog. 
            if (settingsDialog.confirmed)
            {

                mapWidth = settingsDialog.mapWidth;
                mapHeight = settingsDialog.mapHeight;
                numMinesInit = settingsDialog.numMines;

                // change our own dimensions accordingly
                // we need to ensure the map has enough space to contain everything, so we pick whichever is 
                // the larger of our starting dimensions and the new dimensions based on the new map.
                // the +1 and +2 on mapWidth and mapHeight are necessary and I have no idea why.
                int w = Math.Max(530, loadingImage.Location.X + (mapWidth + 1) * 25);
                int h = Math.Max(550, loadingImage.Location.Y + (mapHeight + 2) * 25);
                this.MinimumSize = new Size(w, h);
                this.Size = MinimumSize;

                // this starts a new game with the new settings.
                newgameButton_Click(null, null);

            }
        }

        /// <summary>
        /// changes all GUI elements to fit a new theme.
        /// </summary>
        /// <param name="newTheme"></param>
        private void changeTheme(theme newTheme)
        {
            // update our current theme
            this.currentTheme = newTheme;

            // update buttons
            updateSidebarButtons(newTheme);

            // update cells
            foreach (GUICell cell in GUICells)
            {
                updateGUICellTheme(cell, newTheme);
            }

            // update background color
            updateBGColor(newTheme);

            // update loading animation
            updateLoadingAnimation(newTheme);
        }

        /// <summary>
        /// changes the sidebar buttons to match the given theme.
        /// </summary>
        /// <param name="newTheme"></param>
        private void updateSidebarButtons(theme newTheme)
        {
            // new game button
            switch (newTheme)
            {
                case theme.cats:
                    this.newgameButton.Image = Properties.Resources.cat_newgame_button;
                    break;

                case theme.classic:
                    this.newgameButton.Image = Properties.Resources.classic_newgame_button; 
                    break;

                case theme.bubble:
                    this.newgameButton.Image = Properties.Resources.bubble_newgame_button; 
                    break;

                case theme.dark:
                    this.newgameButton.Image = Properties.Resources.dark_newgame_button; 
                    break;

            }

            // options button
            switch (newTheme)
            {
                case theme.cats:
                    this.optionsButton.Image = Properties.Resources.cat_options_button;
                    break;

                case theme.classic:
                    this.optionsButton.Image = Properties.Resources.classic_options_button;
                    break;

                case theme.bubble:
                    this.optionsButton.Image = Properties.Resources.bubble_options_button;
                    break;

                case theme.dark:
                    this.optionsButton.Image = Properties.Resources.dark_options_button;
                    break;

            }

            // stats button
            switch (newTheme)
            {
                case theme.cats:
                    this.statsButton.Image = Properties.Resources.cat_stats_button;
                    break;

                case theme.classic:
                    this.statsButton.Image = Properties.Resources.classic_stats_button;
                    break;

                case theme.bubble:
                    this.statsButton.Image = Properties.Resources.bubble_stats_button;
                    break;

                case theme.dark:
                    this.statsButton.Image = Properties.Resources.dark_stats_button;
                    break;

            }

            // help button
            switch (newTheme)
            {
                case theme.cats:
                    this.helpButton.Image = Properties.Resources.cat_help_button;
                    break;

                case theme.classic:
                    this.helpButton.Image = Properties.Resources.classic_help_button;
                    break;

                case theme.bubble:
                    this.helpButton.Image = Properties.Resources.bubble_help_button;
                    break;

                case theme.dark:
                    this.helpButton.Image = Properties.Resources.dark_help_button;
                    break;

            }
        }

        /// <summary>
        /// changes the loading animation to match the given theme.
        /// </summary>
        /// <param name="newTheme"></param>
        private void updateLoadingAnimation(theme newTheme)
        {
            switch (newTheme)
            {
                case theme.cats:
                    this.loadingImage.Image = Properties.Resources.cat_loading_animation;
                    break;

                case theme.classic:
                    this.loadingImage.Image = Properties.Resources.classic_loading_animation;
                    break;

                case theme.bubble:
                    this.loadingImage.Image = Properties.Resources.bubble_loading_animation;
                    break;

                case theme.dark:
                    this.loadingImage.Image = Properties.Resources.dark_loading_animation;
                    break;

            }
        }

        /// <summary>
        /// changes the background color to match the given theme.
        /// </summary>
        /// <param name="newTheme"></param>
        private void updateBGColor(theme newTheme)
        {
            switch (newTheme)
            {
                case theme.cats:
                    this.BackColor = Color.FromArgb(34, 128, 58);
                    break;

                case theme.classic:
                    this.BackColor = Color.FromArgb(160, 160, 160);
                    break;

                case theme.bubble:
                    this.BackColor = Color.FromArgb(14, 66, 77);
                    break;

                case theme.dark:
                    this.BackColor = Color.FromArgb(45, 41, 51);
                    break;

            }
        }

        /// <summary>
        /// changes the given GUI cell to a given state while retaining its current theme.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="newState"></param>
        private void updateGUICellState(GUICell cell, state newState)
        {
            // first update the cell's state to match the new one
            cell.currentState = newState;

            // zero is a special case, we can update it without needing to check for theme because all themes use the same one
            if (newState == state.zero)
            {
                cell.Image = Properties.Resources._0;
                return;
            }

            // check fot the cell's current theme so we can keep the theme constant.
            switch (cell.currentTheme)
            {
                case theme.cats:
                    switch (newState)
                    {
                        case state.one:
                            cell.Image = Properties.Resources.cat_1;
                            break;

                        case state.two:
                            cell.Image = Properties.Resources.cat_2;
                            break;

                        case state.three:
                            cell.Image = Properties.Resources.cat_3;
                            break;

                        case state.four:
                            cell.Image = Properties.Resources.cat_4;
                            break;

                        case state.five:
                            cell.Image = Properties.Resources.cat_5;
                            break;

                        case state.six:
                            cell.Image = Properties.Resources.cat_6;
                            break;

                        case state.seven:
                            cell.Image = Properties.Resources.cat_7;
                            break;

                        case state.eight:
                            cell.Image = Properties.Resources.cat_8;
                            break;

                        case state.blank:
                            cell.Image = Properties.Resources.cat_blank;
                            break;

                        case state.flagged:
                            cell.Image = Properties.Resources.cat_flagged;
                            break;

                        case state.mine:
                            cell.Image = Properties.Resources.cat_mine;
                            break;

                    }
                    break;

                case theme.classic:
                    switch (newState)
                    {
                        case state.one:
                            cell.Image = Properties.Resources.classic_1;
                            break;

                        case state.two:
                            cell.Image = Properties.Resources.classic_2;
                            break;

                        case state.three:
                            cell.Image = Properties.Resources.classic_3;
                            break;

                        case state.four:
                            cell.Image = Properties.Resources.classic_4;
                            break;

                        case state.five:
                            cell.Image = Properties.Resources.classic_5;
                            break;

                        case state.six:
                            cell.Image = Properties.Resources.classic_6;
                            break;

                        case state.seven:
                            cell.Image = Properties.Resources.classic_7;
                            break;

                        case state.eight:
                            cell.Image = Properties.Resources.classic_8;
                            break;

                        case state.blank:
                            cell.Image = Properties.Resources.classic_blank;
                            break;

                        case state.flagged:
                            cell.Image = Properties.Resources.classic_flagged;
                            break;

                        case state.mine:
                            cell.Image = Properties.Resources.classic_mine;
                            break;

                    }
                    break;

                case theme.bubble:
                    switch (newState)
                    {
                        case state.one:
                            cell.Image = Properties.Resources.bubble_1;
                            break;

                        case state.two:
                            cell.Image = Properties.Resources.bubble_2;
                            break;

                        case state.three:
                            cell.Image = Properties.Resources.bubble_3;
                            break;

                        case state.four:
                            cell.Image = Properties.Resources.bubble_4;
                            break;

                        case state.five:
                            cell.Image = Properties.Resources.bubble_5;
                            break;

                        case state.six:
                            cell.Image = Properties.Resources.bubble_6;
                            break;

                        case state.seven:
                            cell.Image = Properties.Resources.bubble_7;
                            break;

                        case state.eight:
                            cell.Image = Properties.Resources.bubble_8;
                            break;

                        case state.blank:
                            cell.Image = Properties.Resources.bubble_blank;
                            break;

                        case state.flagged:
                            cell.Image = Properties.Resources.bubble_flagged;
                            break;

                        case state.mine:
                            cell.Image = Properties.Resources.bubble_mine;
                            break;

                    }
                    break;

                case theme.dark:
                    switch (newState)
                    {
                        case state.one:
                            cell.Image = Properties.Resources.dark_1;
                            break;

                        case state.two:
                            cell.Image = Properties.Resources.dark_2;
                            break;

                        case state.three:
                            cell.Image = Properties.Resources.dark_3;
                            break;

                        case state.four:
                            cell.Image = Properties.Resources.dark_4;
                            break;

                        case state.five:
                            cell.Image = Properties.Resources.dark_5;
                            break;

                        case state.six:
                            cell.Image = Properties.Resources.dark_6;
                            break;

                        case state.seven:
                            cell.Image = Properties.Resources.dark_7;
                            break;

                        case state.eight:
                            cell.Image = Properties.Resources.dark_8;
                            break;

                        case state.blank:
                            cell.Image = Properties.Resources.dark_blank;
                            break;

                        case state.flagged:
                            cell.Image = Properties.Resources.dark_flagged;
                            break;

                        case state.mine:
                            cell.Image = Properties.Resources.dark_mine;
                            break;

                    }
                    break;
            }
        }

        /// <summary>
        /// changes the given GUI cell to the given theme while retaining its current "state".
        /// that is, it will change a cat 3 to a dark 3 or a classic blank to a bubble blank.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="newTheme"></param>
        private void updateGUICellTheme(GUICell cell, theme newTheme)
        {
            // update the cell's current theme to match the new one.
            cell.currentTheme = newTheme;

            // check for the cell's current state so we can keep the state constant.
            switch (cell.currentState)
            {
                // do nothing if the state is zero, all themes use the same zero sprite.
                case state.zero:
                    break;

                case state.one:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_1;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_1;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_1;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_1;
                            break;
                    }
                    break;

                case state.two:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_2;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_2;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_2;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_2;
                            break;
                    }
                    break;

                case state.three:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_3;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_3;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_3;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_3;
                            break;
                    }
                    break;

                case state.four:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_4;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_4;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_4;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_4;
                            break;
                    }
                    break;

                case state.five:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_5;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_5;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_5;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_5;
                            break;
                    }
                    break;

                case state.six:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_6;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_6;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_6;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_6;
                            break;
                    }
                    break;

                case state.seven:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_7;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_7;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_7;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_7;
                            break;
                    }
                    break;

                case state.eight:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_8;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_8;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_8;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_8;
                            break;
                    }
                    break;

                case state.blank:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_blank;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_blank;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_blank;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_blank;
                            break;
                    }
                    break;

                case state.flagged:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_flagged;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_flagged;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_flagged;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_flagged;
                            break;
                    }
                    break;

                case state.mine:
                    switch (newTheme)
                    {
                        case theme.cats:
                            cell.Image = Properties.Resources.cat_mine;
                            break;

                        case theme.classic:
                            cell.Image = Properties.Resources.classic_mine;
                            break;

                        case theme.bubble:
                            cell.Image = Properties.Resources.bubble_mine;
                            break;

                        case theme.dark:
                            cell.Image = Properties.Resources.dark_mine;
                            break;
                    }
                    break;
            }
        }

        /*
         * --------------------
         * STATS BUTTON METHODS
         * --------------------
         */

        /// <summary>
        /// causes the stats button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statsButton_Down(object sender, MouseEventArgs e)
        {
            switch (currentTheme)
            {
                case theme.cats:
                    statsButton.Image = Properties.Resources.cat_stats_button_pressed;
                    break;

                case theme.classic:
                    statsButton.Image = Properties.Resources.classic_stats_button_pressed;
                    break;

                case theme.dark:
                    statsButton.Image = Properties.Resources.dark_stats_button_pressed;
                    break;

                case theme.bubble:
                    statsButton.Image = Properties.Resources.bubble_stats_button_pressed;
                    break;
            }
        }

        /// <summary>
        /// not implemented yet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statsButton_Click(object sender, EventArgs e)
        {
            // this causes the button to pop back up.
            switch (currentTheme)
            {
                case theme.cats:
                    statsButton.Image = Properties.Resources.cat_stats_button;
                    break;

                case theme.classic:
                    statsButton.Image = Properties.Resources.classic_stats_button;
                    break;

                case theme.dark:
                    statsButton.Image = Properties.Resources.dark_stats_button;
                    break;

                case theme.bubble:
                    statsButton.Image = Properties.Resources.bubble_stats_button;
                    break;
            }

            MessageBox.Show("I have not added stats yet.", "oops");
        }

        /*
         * -------------------
         * HELP BUTTON METHODS
         * -------------------
         */

        /// <summary>
        /// causes the help button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton_Down(object sender, MouseEventArgs e)
        {
            switch (currentTheme)
            {
                case theme.cats:
                    helpButton.Image = Properties.Resources.cat_help_button_pressed;
                    break;

                case theme.classic:
                    helpButton.Image = Properties.Resources.classic_help_button_pressed;
                    break;

                case theme.dark:
                    helpButton.Image = Properties.Resources.dark_help_button_pressed;
                    break;

                case theme.bubble:
                    helpButton.Image = Properties.Resources.bubble_help_button_pressed;
                    break;
            }
        }

        /// <summary>
        /// not implemented yet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton_Click(object sender, EventArgs e)
        {
            // this causes the button to pop back up.
            switch (currentTheme)
            {
                case theme.cats:
                    helpButton.Image = Properties.Resources.cat_help_button;
                    break;

                case theme.classic:
                    helpButton.Image = Properties.Resources.classic_help_button;
                    break;

                case theme.dark:
                    helpButton.Image = Properties.Resources.dark_help_button;
                    break;

                case theme.bubble:
                    helpButton.Image = Properties.Resources.bubble_help_button;
                    break;
            }

            string helpContents = "" +
                "How to play Minesweeper:\n\n" +
                "Left-click a cell to reveal it, right-click a cell to flag it." +
                "A revealed cell might have a number on it equal to the number of mines around it." +
                "Flag cells you know are mines, and reveal cells you know to be safe." +
                "Clicking and holding a revealed cell highlights every hidden cell around it." +
                "If all mines surrounding it have been flagged already, left-clicking reveals the others.\n\n" +
                "The goal of the game is to uncover every safe cell to reveal the image underneath!";

            MessageBox.Show(helpContents, "Help");
        }
        
        /*
         * -----------------
         * MAIN GAME METHODS
         * -----------------
         */

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
            bool isTargetFlagged = GUICells[cellx + (celly * mapWidth)].currentState == state.flagged;

            // left clicking a cell reveals it unless it is flagged.
            if (e.Button == MouseButtons.Left && !isTargetFlagged)
            {
                updateGUICellState(GUICells[cellx + (celly * mapWidth)], state.zero);
            }
            // right clicking a cell toggles flagged state.
            else if (e.Button == MouseButtons.Right)
            {
                // if the cell is already flagged, unflag it and increase the counter, 
                // otherwise flag it and decrease the counter instead.
                if (isTargetFlagged)
                {
                    updateGUICellState(GUICells[cellx + (celly * mapWidth)], state.blank);
                    numMines++;
                    setMinesDisplay();
                }
                else
                {
                    updateGUICellState(GUICells[cellx + (celly * mapWidth)], state.flagged);
                    numMines--;
                    setMinesDisplay();
                }                
            }
        }

        /// <summary>
        /// cleanup for when the form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onExit(object sender, EventArgs e)
        {
            // I'm not sure why this bit is necessary or if I'm even using the right value here but it's what stackoverflow said.
            timeEndPeriod(timerAccuracy);
        }

    }
}
