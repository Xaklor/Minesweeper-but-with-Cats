using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
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
        private int mapWidth;
        private int mapHeight;
        private int numMines;
        private int numMinesInit;
        private theme currentTheme;
        private bool animationsOn;
        private bool loading;

        // tiles
        private bool draw;
        private Point  tileAnchor;
        private Bitmap blankTile;
        private Bitmap selectTile;
        private Bitmap flaggedTile;
        private Bitmap mineTile;
        private Bitmap oneTile;
        private Bitmap twoTile;
        private Bitmap threeTile;
        private Bitmap fourTile;
        private Bitmap fiveTile;
        private Bitmap sixTile;
        private Bitmap sevenTile;
        private Bitmap eightTile;   

        private Bitmap mapBackgroundImage;

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
            mapWidth = 9;
            mapHeight = 9;
            numMines = 10;
            numMinesInit = 10;
            currentTheme = theme.cats;

            animationsOn = false;
            loading = false;

            draw = false;
            tileAnchor  = new Point(278, 112);
            blankTile   = Properties.Resources.cat_blank;
            selectTile  = Properties.Resources.cat_selected;
            flaggedTile = Properties.Resources.cat_flagged;
            mineTile    = Properties.Resources.cat_mine;
            oneTile     = Properties.Resources.cat_1;
            twoTile     = Properties.Resources.cat_2;
            threeTile   = Properties.Resources.cat_3;
            fourTile    = Properties.Resources.cat_4;
            fiveTile    = Properties.Resources.cat_5;
            sixTile     = Properties.Resources.cat_6;
            sevenTile   = Properties.Resources.cat_7;
            eightTile   = Properties.Resources.cat_8;

            mapBackgroundImage = Properties.Resources.blobcathug;

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
            
            numMines = numMinesInit;
            setMinesDisplay(true);

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

            if (animationsOn)
            {
                // this starts the loading animation playing and adjusts it to match our current map size
                loadingImage.Size = new Size(mapWidth * 25, mapHeight * 25);
                loadingImage.Visible = true;
                loading = true;
                // this starts up a background thread to wait out the loading animation, 
                // since the main thread needs to be idle for the animation to be visible.
                loadingStaller.RunWorkerAsync();
            }
            else
            {
                draw = true;
                Invalidate();
            }

        }

        /// <summary>
        /// does nothing for 1.8 seconds so the loading animation can play.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadingStall(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1800);
        }

        /// <summary>
        /// removes the loading animation and lets the main GUI get back to work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endStall(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingImage.Visible = false;
            loading = false;
            draw = true;
            Invalidate();
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
            MinesweeperSettingsDialog settingsDialog = new MinesweeperSettingsDialog(this.currentTheme, mapWidth, mapHeight, numMines, animationsOn);
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

                animationsOn = settingsDialog.animationsOn;

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
            this.currentTheme = newTheme;

            switch (newTheme)
            {
                case theme.cats:
                    this.BackColor = Color.FromArgb(34, 128, 58);
                    newgameButton.Image = Properties.Resources.cat_newgame_button;
                    optionsButton.Image = Properties.Resources.cat_options_button;
                    statsButton.Image   = Properties.Resources.cat_stats_button;
                    helpButton.Image    = Properties.Resources.cat_help_button;
                    loadingImage.Image  = Properties.Resources.cat_loading_animation;
                    blankTile   = Properties.Resources.cat_blank;
                    selectTile  = Properties.Resources.cat_selected;
                    flaggedTile = Properties.Resources.cat_flagged;
                    mineTile    = Properties.Resources.cat_mine;
                    oneTile     = Properties.Resources.cat_1;
                    twoTile     = Properties.Resources.cat_2;
                    threeTile   = Properties.Resources.cat_3;
                    fourTile    = Properties.Resources.cat_4;
                    fiveTile    = Properties.Resources.cat_5;
                    sixTile     = Properties.Resources.cat_6;
                    sevenTile   = Properties.Resources.cat_7;
                    eightTile   = Properties.Resources.cat_8;
                    break;

                case theme.classic:
                    this.BackColor = Color.FromArgb(160, 160, 160);
                    newgameButton.Image = Properties.Resources.classic_newgame_button;
                    optionsButton.Image = Properties.Resources.classic_options_button;
                    statsButton.Image   = Properties.Resources.classic_stats_button;
                    helpButton.Image    = Properties.Resources.classic_help_button;
                    loadingImage.Image  = Properties.Resources.classic_loading_animation;
                    blankTile   = Properties.Resources.classic_blank;
                    selectTile  = Properties.Resources.classic_selected;
                    flaggedTile = Properties.Resources.classic_flagged;
                    mineTile    = Properties.Resources.classic_mine;
                    oneTile     = Properties.Resources.classic_1;
                    twoTile     = Properties.Resources.classic_2;
                    threeTile   = Properties.Resources.classic_3;
                    fourTile    = Properties.Resources.classic_4;
                    fiveTile    = Properties.Resources.classic_5;
                    sixTile     = Properties.Resources.classic_6;
                    sevenTile   = Properties.Resources.classic_7;
                    eightTile   = Properties.Resources.classic_8;
                    break;

                case theme.bubble:
                    this.BackColor = Color.FromArgb(14, 66, 77);
                    newgameButton.Image = Properties.Resources.bubble_newgame_button;
                    optionsButton.Image = Properties.Resources.bubble_options_button;
                    statsButton.Image   = Properties.Resources.bubble_stats_button;
                    helpButton.Image    = Properties.Resources.bubble_help_button;
                    loadingImage.Image  = Properties.Resources.bubble_loading_animation;
                    blankTile   = Properties.Resources.bubble_blank;
                    selectTile  = Properties.Resources.bubble_selected;
                    flaggedTile = Properties.Resources.bubble_flagged;
                    mineTile    = Properties.Resources.bubble_mine;
                    oneTile     = Properties.Resources.bubble_1;
                    twoTile     = Properties.Resources.bubble_2;
                    threeTile   = Properties.Resources.bubble_3;
                    fourTile    = Properties.Resources.bubble_4;
                    fiveTile    = Properties.Resources.bubble_5;
                    sixTile     = Properties.Resources.bubble_6;
                    sevenTile   = Properties.Resources.bubble_7;
                    eightTile   = Properties.Resources.bubble_8;
                    break;

                case theme.dark:
                    this.BackColor = Color.FromArgb(45, 41, 51);
                    newgameButton.Image = Properties.Resources.dark_newgame_button;
                    optionsButton.Image = Properties.Resources.dark_options_button;
                    statsButton.Image   = Properties.Resources.dark_stats_button;
                    helpButton.Image    = Properties.Resources.dark_help_button;
                    loadingImage.Image  = Properties.Resources.dark_loading_animation;
                    blankTile   = Properties.Resources.dark_blank;
                    selectTile  = Properties.Resources.dark_selected;
                    flaggedTile = Properties.Resources.dark_flagged;
                    mineTile    = Properties.Resources.dark_mine;
                    oneTile     = Properties.Resources.dark_1;
                    twoTile     = Properties.Resources.dark_2;
                    threeTile   = Properties.Resources.dark_3;
                    fourTile    = Properties.Resources.dark_4;
                    fiveTile    = Properties.Resources.dark_5;
                    sixTile     = Properties.Resources.dark_6;
                    sevenTile   = Properties.Resources.dark_7;
                    eightTile   = Properties.Resources.dark_8;
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
        /// mouse down handler for the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tilesMouseDown(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// mouse up handler for the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tilesMouseUp(object sender, MouseEventArgs e)
        {

            // MousePosition is relative to the screen, to get it relative to the form we convert 
            Point relativeMousePosition = PointToClient(MousePosition);

            // verify the mouse position is within the board before doing anything
            bool isValidX = relativeMousePosition.X > tileAnchor.X && relativeMousePosition.X < tileAnchor.X + (mapWidth * 25);
            bool isValidY = relativeMousePosition.Y > tileAnchor.Y && relativeMousePosition.Y < tileAnchor.Y + (mapHeight * 25);
            if (isValidX && isValidY && draw && !loading)
            {
                MessageBox.Show("you clicked on the board!");
            }

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
            /* this method needs to be deleted, but it has information that will help in making the new event handlers.

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

            */
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

        /*
         * --------
         * PAINTING
         * --------
         */

        /// <summary>
        /// paints all GUI elements to the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawBoard(object sender, PaintEventArgs e)
        {
            // draws the hidden background image
            e.Graphics.DrawImage(mapBackgroundImage, tileAnchor.X, tileAnchor.Y, mapWidth * 25, mapHeight * 25);

            // TODO: this is currently hardcoded and needs to be changed to read info from the map instead
            if (draw)
            {
                for (int i = 0; i < mapWidth; i++)
                {
                    for (int j = 0; j < mapHeight; j++)
                    {
                        e.Graphics.DrawImage(blankTile, tileAnchor.X + (i * 25), tileAnchor.Y + (j * 25));
                    }
                }
            }
        }
    }
}
