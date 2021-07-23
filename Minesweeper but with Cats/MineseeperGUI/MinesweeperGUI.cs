﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
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

        private MinesweeperMap gameMap;
        private bool hasMapGenerated;
        private List<(int, int)> selectedCoords;
        private HashSet<(int, int)> animatedCoords;
        private int clickSafetyX, clickSafetyY;

        private int gameElapsedSeconds;
        private bool isGamePlaying;
        private bool isGameAnimating;
        private bool isGameLost;

        // tiles
        private bool drawMap;
        private Point  tileAnchor;
        private Bitmap blankTile;
        private Bitmap selectTile;
        private Bitmap flaggedTile;
        private Bitmap mineTile;
        private Bitmap zeroTile;
        private Bitmap oneTile;
        private Bitmap twoTile;
        private Bitmap threeTile;
        private Bitmap fourTile;
        private Bitmap fiveTile;
        private Bitmap sixTile;
        private Bitmap sevenTile;
        private Bitmap eightTile;   

        private Bitmap mapBackgroundImage;

        // used for updating the timer display from one of the background workers
        private delegate void updateTimerDelegate(MinesweeperGUI GUI, bool startup);
        updateTimerDelegate updateTimer = updateTimerDisplay;

        // used for the game win animation
        private delegate void animationTimerDelegate(MinesweeperGUI GUI, int x, int y);
        animationTimerDelegate animationTimer = animateWinState;

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
            selectedCoords = new List<(int, int)>();
            animatedCoords = new HashSet<(int, int)>();
            clickSafetyX = 0;
            clickSafetyY = 0;

            gameElapsedSeconds = 0;
            // used for turning off the timekeeper
            isGamePlaying = false;
            isGameAnimating = false;
            isGameLost = false;

            drawMap = false;
            tileAnchor  = new Point(278, 112);
            blankTile   = Properties.Resources.cat_blank;
            selectTile  = Properties.Resources.cat_selected;
            flaggedTile = Properties.Resources.cat_flagged;
            mineTile    = Properties.Resources.cat_mine;
            zeroTile    = Properties.Resources._0;
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
            initializeSaves();
            changeTheme(currentTheme);

            // this sets the internal timer to the new speed.
            timeBeginPeriod(timerAccuracy);
        }

        /// <summary>
        /// attempts to read the settings file and save its contents. makes no changes if it finds bad data.
        /// also verifies the stats file exists and creates a fresh one if it's missing.
        /// </summary>
        private void initializeSaves()
        {
            // if a settings file exists, read from it for settings
            if (File.Exists("settings"))
            {
                try
                {
                    int settingsWidth = mapWidth;
                    int settingsHeight = mapHeight;
                    int settingsMines = numMinesInit;
                    theme settingsTheme = currentTheme;
                    bool settingsAnimations = animationsOn;

                    IEnumerable<string> settings = File.ReadAllLines("settings");
                    IEnumerator<string> settingsReader = settings.GetEnumerator();
                    settingsReader.MoveNext();

                    // first item should be width, which must be between 5 and 30
                    settingsWidth = int.Parse(settingsReader.Current);
                    if (settingsWidth < 5 || settingsWidth > 30)
                    {
                        throw new FileFormatException("invalid width found.");
                    }
                    settingsReader.MoveNext();

                    // second item should be height, which must be between 5 and 30
                    settingsHeight = int.Parse(settingsReader.Current);
                    if (settingsHeight < 5 || settingsHeight > 30)
                    {
                        throw new FileFormatException("invalid height found.");
                    }
                    settingsReader.MoveNext();

                    // third item should be mines, which must be between 1 and 899
                    settingsMines = int.Parse(settingsReader.Current);
                    if (settingsMines < 1 || settingsMines > 899)
                    {
                        throw new FileFormatException("invalid mines found.");
                    }
                    settingsReader.MoveNext();

                    // fourth item should be theme, which must either be cats, classic, bubble, or dark
                    switch (settingsReader.Current)
                    {
                        case ("cats"):
                            settingsTheme = theme.cats;
                            break;

                        case ("classic"):
                            settingsTheme = theme.classic;
                            break;

                        case ("bubble"):
                            settingsTheme = theme.bubble;
                            break;

                        case ("dark"):
                            settingsTheme = theme.dark;
                            break;

                        default:
                            throw new FileFormatException("invalid theme found.");
                    }
                    settingsReader.MoveNext();

                    // fifth item should be loading animations, which must be true or false
                    switch (settingsReader.Current)
                    {
                        case ("True"):
                            settingsAnimations = true;
                            break;

                        case ("False"):
                            settingsAnimations = false;
                            break;

                        default:
                            throw new FileFormatException("invalid animations setting found.");
                    }

                    // if we made it here, we have all the data we need and it's all safe
                    mapWidth = settingsWidth;
                    mapHeight = settingsHeight;
                    numMines = settingsMines;
                    numMinesInit = settingsMines;
                    currentTheme = settingsTheme;
                    animationsOn = settingsAnimations;

                    // based on the map size, we can determine if the main window also needs resizing
                    int w = Math.Max(610, tileAnchor.X + (mapWidth + 1) * 25);
                    int h = Math.Max(550, tileAnchor.Y + (mapHeight + 2) * 25);
                    this.MinimumSize = new Size(w, h);
                    this.Size = MinimumSize;

                }
                catch (Exception e)
                {
                    MessageBox.Show($"something went wrong reading your settings file:\n{e.Message}", "oops");
                }
            }

            // if the stats save file doesn't exist, create a fresh one here
            if (!File.Exists("stats"))
            {
                List<string> stats = new List<string>();
                stats.Add("0");
                stats.Add("0");
                stats.Add("5999");
                stats.Add("5999");
                stats.Add("5999");
                stats.Add("0");
                stats.Add("0");
                stats.Add("5999");
                stats.Add("5999");
                stats.Add("5999");
                stats.Add("0");
                stats.Add("0");
                stats.Add("5999");
                stats.Add("5999");
                stats.Add("5999");
                File.WriteAllLines("stats", stats);
            }
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

            gameMap = new MinesweeperMap(mapWidth, mapHeight, numMines);
            hasMapGenerated = false;

            isGameLost = false;
            isGamePlaying = false;
            gameElapsedSeconds = 0;
            updateTimer(this, true);

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
                drawMap = true;
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
            drawMap = true;
            Invalidate();
        }

        /// <summary>
        /// constantly updates the timer display to show time increasing in real time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeKeeperWork(object sender, DoWorkEventArgs e)
        {
            isGamePlaying = true;
            while (isGamePlaying)
            {
                // forces the updateTimer delegate to run on the main thread so it can change the pictureboxes
                Invoke(updateTimer, new object[] { this, false });

                // waits one second, then updates again
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// updates the game timer pictureboxes to match the current time.
        /// </summary>
        /// <param name="GUI"></param>
        /// <param name="startup"></param>
        private static void updateTimerDisplay(MinesweeperGUI GUI, bool startup)
        {
            // one second should have passed since this was last called, so we can update it here
            // if this is on game startup, don't increment
            if (!startup)
            {
                GUI.gameElapsedSeconds++;
            }

            // if we are past 99:59, just stop updating and leave this alone
            if (GUI.gameElapsedSeconds >= 5999)
            {
                GUI.timerDisplay10m.Image = Properties.Resources.display_9;
                GUI.timerDisplay1m.Image = Properties.Resources.display_9;
                GUI.timerDisplay10s.Image = Properties.Resources.display_9;
                GUI.timerDisplay1s.Image = Properties.Resources.display_9;
                GUI.isGamePlaying = false;
            }
            else
            {
                // one seconds
                switch (GUI.gameElapsedSeconds % 10)
                {
                    case 0:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_0;
                        break;
                    case 1:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_1;
                        break;
                    case 2:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_2;
                        break;
                    case 3:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_3;
                        break;
                    case 4:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_4;
                        break;
                    case 5:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_5;
                        break;
                    case 6:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_6;
                        break;
                    case 7:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_7;
                        break;
                    case 8:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_8;
                        break;
                    case 9:
                        GUI.timerDisplay1s.Image = Properties.Resources.display_9;
                        break;
                }

                // ten seconds
                switch (GUI.gameElapsedSeconds % 60 / 10)
                {
                    case 0:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_0;
                        break;
                    case 1:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_1;
                        break;
                    case 2:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_2;
                        break;
                    case 3:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_3;
                        break;
                    case 4:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_4;
                        break;
                    case 5:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_5;
                        break;
                    case 6:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_6;
                        break;
                    case 7:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_7;
                        break;
                    case 8:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_8;
                        break;
                    case 9:
                        GUI.timerDisplay10s.Image = Properties.Resources.display_9;
                        break;
                }

                // one minutes
                switch (GUI.gameElapsedSeconds % 600 / 60)
                {
                    case 0:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_0;
                        break;
                    case 1:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_1;
                        break;
                    case 2:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_2;
                        break;
                    case 3:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_3;
                        break;
                    case 4:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_4;
                        break;
                    case 5:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_5;
                        break;
                    case 6:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_6;
                        break;
                    case 7:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_7;
                        break;
                    case 8:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_8;
                        break;
                    case 9:
                        GUI.timerDisplay1m.Image = Properties.Resources.display_9;
                        break;
                }

                // ten minutes
                switch (GUI.gameElapsedSeconds / 600)
                {
                    case 0:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_0;
                        break;
                    case 1:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_1;
                        break;
                    case 2:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_2;
                        break;
                    case 3:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_3;
                        break;
                    case 4:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_4;
                        break;
                    case 5:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_5;
                        break;
                    case 6:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_6;
                        break;
                    case 7:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_7;
                        break;
                    case 8:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_8;
                        break;
                    case 9:
                        GUI.timerDisplay10m.Image = Properties.Resources.display_9;
                        break;
                }
            }
        }

        /// <summary>
        /// sets the mines displays to match the current number of shown mines. if this is called on game startup, 
        /// then it will also hide the hundreds place if it is unneeded.
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
            bool isGamePaused = false;
    
            // pause the timer if it is running
            if (isGamePlaying)
            {
                isGamePlaying = false;
                isGamePaused = true;
            }

            MinesweeperSettingsDialog settingsDialog = new MinesweeperSettingsDialog(this.currentTheme, mapWidth, mapHeight, numMinesInit, animationsOn);
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
                int w = Math.Max(610, tileAnchor.X + (mapWidth + 1) * 25);
                int h = Math.Max(550, tileAnchor.Y + (mapHeight + 2) * 25);
                this.MinimumSize = new Size(w, h);
                this.Size = MinimumSize;

                // save these settings in the settings file.
                List<string> settings = new List<string>();
                settings.Add($"{mapWidth}");
                settings.Add($"{mapHeight}");
                settings.Add($"{numMinesInit}");
                settings.Add($"{currentTheme}");
                settings.Add($"{animationsOn}");
                File.WriteAllLines("settings", settings);

                // this starts a new game with the new settings.
                newgameButton_Click(null, null);

            }
            // if changes were NOT made and the game was paused by the dialog, resume the timer
            else if(isGamePaused)
            {
                // make sure the timer thread actually had a chance to stop before telling it to run again
                if (!timeKeeper.IsBusy)
                {
                    timeKeeper.RunWorkerAsync();
                }
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
        /// opens up a message box displaying saved stats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statsButton_Click(object sender, EventArgs e)
        {
            bool isGamePaused = false;

            // pause the timer if it is running
            if (isGamePlaying)
            {
                isGamePlaying = false;
                isGamePaused = true;
            }

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

            try
            {
                List<string> stats = new List<string>();
                foreach (string statistic in File.ReadAllLines("stats"))
                {
                    stats.Add(statistic);
                }

                if (stats.Count != 15)
                {
                    throw new FileFormatException("invalid stats format found.");
                }

                string easyNumGames      = stats[0];
                string easyWonGames      = stats[1];
                string easyFirstPlace    = convertSecondsToScore(stats[2]);
                string easySecondPlace   = convertSecondsToScore(stats[3]);
                string easyThirdPlace    = convertSecondsToScore(stats[4]);
                string normalNumGames    = stats[5];
                string normalWonGames    = stats[6];
                string normalFirstPlace  = convertSecondsToScore(stats[7]);
                string normalSecondPlace = convertSecondsToScore(stats[8]);
                string normalThirdPlace  = convertSecondsToScore(stats[9]);
                string hardNumGames      = stats[10];
                string hardWonGames      = stats[11];
                string hardFirstPlace    = convertSecondsToScore(stats[12]);
                string hardSecondPlace   = convertSecondsToScore(stats[13]);
                string hardThirdPlace    = convertSecondsToScore(stats[14]);

                string statsContents = $"" +
                    $"Easy games played: {easyNumGames}\n" +
                    $"Easy games won: {easyWonGames}\n" +
                    $"Easy best times:\n" +
                    $"1st: {easyFirstPlace}\n" +
                    $"2nd: {easySecondPlace}\n" +
                    $"3rd: {easyThirdPlace}\n\n" +
                    $"Normal games played: {normalNumGames}\n" +
                    $"Normal games won: {normalWonGames}\n" +
                    $"Normal best times:\n" +
                    $"1st: {normalFirstPlace}\n" +
                    $"2nd: {normalSecondPlace}\n" +
                    $"3rd: {normalThirdPlace}\n\n" +
                    $"Hard games played: {hardNumGames}\n" +
                    $"Hard games won: {hardWonGames}\n" +
                    $"Hard best times:\n" +
                    $"1st: {hardFirstPlace}\n" +
                    $"2nd: {hardSecondPlace}\n" +
                    $"3rd: {hardThirdPlace}\n\n";

                MessageBox.Show(statsContents, "Stats");

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Something went wrong reading stats:\n{exception.Message}", "oops");
            }


            // if the game was paused by this dialog, resume the timer
            if (isGamePaused)
            {
                // make sure the timer thread actually had a chance to stop before telling it to run again
                if (!timeKeeper.IsBusy)
                {
                    timeKeeper.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// converts a given amount of seconds into a time score, that is: 86s -> 01:26, 1317s -> 21:57
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        private string convertSecondsToScore(string seconds)
        {
            int numSeconds = int.Parse(seconds);
            int second1s  = numSeconds % 10;
            int second10s = numSeconds % 60  / 10;
            int minute1s  = numSeconds % 600 / 60;
            int minute10s = numSeconds / 600;

            return $"{minute10s}{minute1s}:{second10s}{second1s}";
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
            bool isGamePaused = false;

            // pause the timer if it is running
            if (isGamePlaying)
            {
                isGamePlaying = false;
                isGamePaused = true;
            }

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

            // if the game was paused by this dialog, resume the timer
            if (isGamePaused)
            {
                // make sure the timer thread actually had a chance to stop before telling it to run again
                if (!timeKeeper.IsBusy)
                {
                    timeKeeper.RunWorkerAsync();
                }
            }
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
            // MousePosition is relative to the screen, to get it relative to the form we convert 
            Point relativeMousePosition = PointToClient(MousePosition);

            // verify the mouse position is within the board before doing anything
            bool isValidX = relativeMousePosition.X > tileAnchor.X && relativeMousePosition.X < tileAnchor.X + (mapWidth * 25);
            bool isValidY = relativeMousePosition.Y > tileAnchor.Y && relativeMousePosition.Y < tileAnchor.Y + (mapHeight * 25);

            // map coordinates are relative to the tile anchor and scaled based on tile size
            int cellx = (relativeMousePosition.X - tileAnchor.X) / 25;
            int celly = (relativeMousePosition.Y - tileAnchor.Y) / 25;

            // this is for clickup safety, we don't want the player clicking up on a cell they didn't click down on by accident
            clickSafetyX = cellx;
            clickSafetyY = celly;

            // to explain the if statement to the reader:
            // valid X and Y ensure the mouse is inside the map
            // isGameAnimating is used by the game won animation and stops the player from clicking on things while it's playing
            // drawMap is used by the new game process to start drawing a map, here it stops the player from clicking on a board before drawing
            // isGameLost is used by the game loss state and prevents the player from continuing to click on things after losing
            // loading is used by the optional loading animations and here it prevents the player from clicking on the loading animation
            // and finally, we only care about animating mouse down tiles if the left button was clicked, so we ignore the right button
            if (isValidX && isValidY && !isGameAnimating && drawMap && !isGameLost && !loading && e.Button == MouseButtons.Left)
            {
                MinesweeperCell target = gameMap.GetCell(cellx, celly);

                // if the target is visible, highlight its neighbors, otherwise highlight itself
                if (target.isVisible)
                {
                    selectedCoords.AddRange(gameMap.GetCellNeighborPositions(cellx, celly));
                }
                else
                {
                    selectedCoords.Add((cellx, celly));
                }
            }

            // repaint the form to see changes
            Invalidate();
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

            // to explain the if statement to the reader:
            // valid X and Y ensure the mouse is inside the map
            // isGameAnimating is used by the game won animation and stops the player from clicking on things while it's playing
            // drawMap is used by the new game process to start drawing a map, here it stops the player from clicking on a board before drawing
            // isGameLost is used by the game loss state and prevents the player from continuing to click on things after losing
            // loading is used by the optional loading animations and here it prevents the player from clicking on the loading animation
            if (isValidX && isValidY && !isGameAnimating && !isGameLost && drawMap && !loading)
            {
                // map coordinates are relative to the tile anchor and scaled based on tile size
                int cellx = (relativeMousePosition.X - tileAnchor.X) / 25;
                int celly = (relativeMousePosition.Y - tileAnchor.Y) / 25;

                // if this cell isn't the one that was clicked down on, stop immediately
                if (cellx != clickSafetyX || celly != clickSafetyY)
                {
                    // reset these for safety since 0, 0 will never be on the board
                    clickSafetyX = 0;
                    clickSafetyY = 0;

                    // unselect any highlighted tiles, and repaint the form to see changes
                    selectedCoords.Clear();
                    Invalidate();

                    return;
                }

                MinesweeperCell target = gameMap.GetCell(cellx, celly);

                // if this is a right click and the cell is hidden, toggle flagged status
                if (e.Button == MouseButtons.Right && !target.isVisible)
                {
                    gameMap.MarkCell(cellx, celly);
                    numMines = gameMap.GetRemainingMines();
                    setMinesDisplay();
                }
                // if this is a left click and the cell isn't visible or flagged, reveal it
                else if (e.Button == MouseButtons.Left && !target.isVisible && !target.isFlagged)
                {
                    // if the map hasn't been generated (because this is the first click), generate it and start the game.
                    if (!hasMapGenerated)
                    {
                        gameMap.GenerateMines(cellx, celly);
                        hasMapGenerated = true;

                        timeKeeper.RunWorkerAsync();
                    }

                    try
                    {
                        gameMap.RevealCell(cellx, celly);
                    }
                    catch(GameOverException exception)
                    {
                        gameFinished(exception.Message);
                    }
                }
                // if this is a left click and the cell IS revealed, reveal its neighbors if it has the right number of flags nearby
                else if (e.Button == MouseButtons.Left && target.isVisible && target.neighboringMines > 0)
                {
                    int count = 0;
                    foreach ((int x, int y) neighborPos in gameMap.GetCellNeighborPositions(cellx, celly))
                    {
                        if (gameMap.GetCell(neighborPos.x, neighborPos.y).isFlagged)
                        {
                            count++;
                        }
                    }

                    if (count == target.neighboringMines)
                    {                        
                        try
                        {
                            gameMap.RevealNeighbors(cellx, celly);
                        }
                        catch (GameOverException exception)
                        {
                            gameFinished(exception.Message);
                        }
                    }
                }
            }

            // reset these for safety since (0, 0) will never be on the board
            clickSafetyX = 0;
            clickSafetyY = 0;

            // unselect any highlighted tiles, and repaint the form to see changes
            selectedCoords.Clear();
            Invalidate();

        }

        /// <summary>
        /// stops the board from being drawn, triggers either win or loss graphics, and saves to the stats file.
        /// </summary>
        /// <param name="winState">must be "lost" or "won" depending on which state the game is in.</param>
        private void gameFinished(string winState)
        {
            isGamePlaying = false;

            // if this game was one of the preset difficulties (easy, normal, or hard), update stats
            // stats data is not tracked for custom boards since they have far too much variety to be meaningful
            bool isEasy   = mapWidth == 9  && mapHeight == 9  && numMinesInit == 10;
            bool isNormal = mapWidth == 16 && mapHeight == 16 && numMinesInit == 40;
            bool isHard   = mapWidth == 30 && mapHeight == 16 && numMinesInit == 99;

            if (isEasy || isNormal || isHard)
                statsWorker.RunWorkerAsync(argument: winState);

            // reveals all unflagged mines, including the one that was clicked on
            if (winState == "lost")
                isGameLost = true;

            // starts the win animation
            if (winState == "won")
                winAnimator.RunWorkerAsync();

        }

        /// <summary>
        /// reads in the stats file and updates it if necessary based on the outcome of this game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveStats(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<string> stats = new List<string>();
                foreach (string statistic in File.ReadAllLines("stats"))
                {
                    stats.Add(statistic);
                }

                if (stats.Count != 15)
                {
                    throw new FileFormatException("invalid stats format found.");
                }

                int easyNumGames      = int.Parse(stats[0]);
                int easyWonGames      = int.Parse(stats[1]);
                int easyFirstPlace    = int.Parse(stats[2]);
                int easySecondPlace   = int.Parse(stats[3]);
                int easyThirdPlace    = int.Parse(stats[4]);
                int normalNumGames    = int.Parse(stats[5]);
                int normalWonGames    = int.Parse(stats[6]);
                int normalFirstPlace  = int.Parse(stats[7]);
                int normalSecondPlace = int.Parse(stats[8]);
                int normalThirdPlace  = int.Parse(stats[9]);
                int hardNumGames      = int.Parse(stats[10]);
                int hardWonGames      = int.Parse(stats[11]);
                int hardFirstPlace    = int.Parse(stats[12]);
                int hardSecondPlace   = int.Parse(stats[13]);
                int hardThirdPlace    = int.Parse(stats[14]);

                // determine which difficulty setting the game was on
                bool isEasy   = mapWidth == 9  && mapHeight == 9  && numMinesInit == 10;
                bool isNormal = mapWidth == 16 && mapHeight == 16 && numMinesInit == 40;
                bool isHard   = mapWidth == 30 && mapHeight == 16 && numMinesInit == 99;

                if (isEasy)
                {
                    List<string> easyStats = updateStats(easyNumGames, easyWonGames, easyFirstPlace, easySecondPlace, easyThirdPlace, e.Argument as string == "won");
                    List<string> updatedStats = new List<string>();
                    updatedStats.AddRange(easyStats);
                    updatedStats.Add(normalNumGames.ToString());
                    updatedStats.Add(normalWonGames.ToString());
                    updatedStats.Add(normalFirstPlace.ToString());
                    updatedStats.Add(normalSecondPlace.ToString());
                    updatedStats.Add(normalThirdPlace.ToString());
                    updatedStats.Add(hardNumGames.ToString());
                    updatedStats.Add(hardWonGames.ToString());
                    updatedStats.Add(hardFirstPlace.ToString());
                    updatedStats.Add(hardSecondPlace.ToString());
                    updatedStats.Add(hardThirdPlace.ToString());

                    File.WriteAllLines("stats", updatedStats);
                }

                if (isNormal)
                {
                    List<string> normalStats = updateStats(normalNumGames, normalWonGames, normalFirstPlace, normalSecondPlace, normalThirdPlace, e.Argument as string == "won");
                    List<string> updatedStats = new List<string>();
                    updatedStats.Add(easyNumGames.ToString());
                    updatedStats.Add(easyWonGames.ToString());
                    updatedStats.Add(easyFirstPlace.ToString());
                    updatedStats.Add(easySecondPlace.ToString());
                    updatedStats.Add(easyThirdPlace.ToString());
                    updatedStats.AddRange(normalStats);
                    updatedStats.Add(hardNumGames.ToString());
                    updatedStats.Add(hardWonGames.ToString());
                    updatedStats.Add(hardFirstPlace.ToString());
                    updatedStats.Add(hardSecondPlace.ToString());
                    updatedStats.Add(hardThirdPlace.ToString());

                    File.WriteAllLines("stats", updatedStats);
                }

                if (isHard)
                {
                    List<string> hardStats = updateStats(hardNumGames, hardWonGames, hardFirstPlace, hardSecondPlace, hardThirdPlace, e.Argument as string == "won");
                    List<string> updatedStats = new List<string>();
                    updatedStats.Add(easyNumGames.ToString());
                    updatedStats.Add(easyWonGames.ToString());
                    updatedStats.Add(easyFirstPlace.ToString());
                    updatedStats.Add(easySecondPlace.ToString());
                    updatedStats.Add(easyThirdPlace.ToString());
                    updatedStats.Add(normalNumGames.ToString());
                    updatedStats.Add(normalWonGames.ToString());
                    updatedStats.Add(normalFirstPlace.ToString());
                    updatedStats.Add(normalSecondPlace.ToString());
                    updatedStats.Add(normalThirdPlace.ToString());
                    updatedStats.AddRange(hardStats);

                    File.WriteAllLines("stats", updatedStats);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Something went wrong updating stats:\n{exception.Message}", "oops");
            }

        }

        /// <summary>
        /// updates a given set of stats based on victory status
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="won"></param>
        /// <returns></returns>
        private List<string> updateStats(int numGames, int wonGames, int firstPlace, int secondPlace, int thirdPlace, bool won)
        {
            // increment games played regardless of victory
            numGames++;
            
            // if the game was won, increment games won and update best times
            if (won)
            {
                wonGames++;

                if (gameElapsedSeconds < firstPlace)
                {
                    thirdPlace = secondPlace;
                    secondPlace = firstPlace;
                    firstPlace = gameElapsedSeconds;
                }
                else if (gameElapsedSeconds < secondPlace)
                {
                    thirdPlace = secondPlace;
                    secondPlace = gameElapsedSeconds;
                }
                else if (gameElapsedSeconds < thirdPlace)
                {
                    thirdPlace = gameElapsedSeconds;
                }
            }

            List<string> updatedStats = new List<string>();
            updatedStats.Add(numGames.ToString());
            updatedStats.Add(wonGames.ToString());
            updatedStats.Add(firstPlace.ToString());
            updatedStats.Add(secondPlace.ToString());
            updatedStats.Add(thirdPlace.ToString());
            return updatedStats;
        }

        /// <summary>
        /// start point for the game win animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void winAnimatorWork(object sender, DoWorkEventArgs e)
        {
            isGameAnimating = true;

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    Thread.Sleep(10);
                    Invoke(animationTimer, new object[] { this, j, i });
                }
            }
        }        

        /// <summary>
        /// flags the given tile for removal to animate the game being won.
        /// </summary>
        /// <param name="GUI"></param>
        private static void animateWinState(MinesweeperGUI GUI, int x, int y)
        {
            GUI.animatedCoords.Add((x, y));
            GUI.Invalidate();
        }

        /// <summary>
        /// end point for the game win animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endWinAnimation(object sender, RunWorkerCompletedEventArgs e)
        {
            animatedCoords.Clear();
            isGameAnimating = false;
            drawMap = false;
            Invalidate();
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

            // only draw a map if we're ready for one
            if (drawMap)
            {
                MinesweeperCell target;
                Point targetPos;
                for (int i = 0; i < mapWidth; i++)
                {
                    for (int j = 0; j < mapHeight; j++)
                    {
                        target = gameMap.GetCell(i, j);
                        targetPos = new Point(tileAnchor.X + (i * 25), tileAnchor.Y + (j * 25));

                        // if this is part of the game won animation, draw a 0 no matter what
                        if (animatedCoords.Contains((i, j)))
                        {
                            e.Graphics.DrawImage(zeroTile, targetPos);
                        }

                        // if the target is not visible, then we either draw a blank or flagged tile, or a mine if the game is lost.
                        else if (!target.isVisible)
                        {
                            if (target.isFlagged)
                            {
                                e.Graphics.DrawImage(flaggedTile, targetPos);
                            }
                            else if (target.hasMine && isGameLost)
                            {
                                e.Graphics.DrawImage(mineTile, targetPos);
                            }
                            else
                            {
                                e.Graphics.DrawImage(blankTile, targetPos);
                            }
                        }

                        // if the target IS visible and has a mine, draw that
                        else if (target.hasMine)
                        {
                            e.Graphics.DrawImage(mineTile, targetPos);
                        }

                        // otherwise, draw the tile corresponding to the number of neighboring mines
                        else
                        {
                            switch (target.neighboringMines)
                            {
                                case (0):
                                    e.Graphics.DrawImage(zeroTile, targetPos);
                                    break;

                                case (1):
                                    e.Graphics.DrawImage(oneTile, targetPos);
                                    break;

                                case (2):
                                    e.Graphics.DrawImage(twoTile, targetPos);
                                    break;

                                case (3):
                                    e.Graphics.DrawImage(threeTile, targetPos);
                                    break;

                                case (4):
                                    e.Graphics.DrawImage(fourTile, targetPos);
                                    break;

                                case (5):
                                    e.Graphics.DrawImage(fiveTile, targetPos);
                                    break;

                                case (6):
                                    e.Graphics.DrawImage(sixTile, targetPos);
                                    break;

                                case (7):
                                    e.Graphics.DrawImage(sevenTile, targetPos);
                                    break;

                                case (8):
                                    e.Graphics.DrawImage(eightTile, targetPos);
                                    break;
                            }
                        }
                    }
                }

                // if there are any cells highlighted by the user, we need to draw those as well
                MinesweeperCell selected;
                foreach ((int x, int y) in selectedCoords)
                {
                    selected = gameMap.GetCell(x, y);
                    // only covered, non-flagged cells can be highlighted.
                    if (!selected.isVisible && !selected.isFlagged)
                    {
                        e.Graphics.DrawImage(selectTile, tileAnchor.X + (x * 25), tileAnchor.Y + (y * 25));
                    }
                }
            }
        }
    }
}
