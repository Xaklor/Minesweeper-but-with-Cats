﻿using System;
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
        public theme selectedTheme;

        public MinesweeperSettingsDialog(theme parentTheme)
        {
            confirmed = false;
            InitializeComponent();

            // sets the dialog's theme to match the main window for consistency.
            switch (parentTheme)
            {
                case (theme.cats):
                    setCatTheme(null, null);
                    break;

                case (theme.classic):
                    setClassicTheme(null, null);
                    break;

                case (theme.bubble):
                    setBubbleTheme(null, null);
                    break;

                case (theme.dark):
                    setDarkTheme(null, null);
                    break;

            }
        }

        /// <summary>
        /// sets the theme of the dialog and the main window to the cat theme, and updates elements accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setCatTheme(object sender, EventArgs e)
        {
            selectedTheme = theme.cats;
            this.BackColor = Color.FromArgb(34, 128, 58);
            easyDifficultyButton.Image   = Properties.Resources.cat_easy_button;
            normalDifficultyButton.Image = Properties.Resources.cat_normal_button;
            hardDifficultyButton.Image   = Properties.Resources.cat_hard_button;
            confirmButton.Image          = Properties.Resources.cat_confirm_button;
            cancelButton.Image           = Properties.Resources.cat_cancel_button;
            
        }

        /// <summary>
        /// sets the theme of the dialog and the main window to the classic theme, and updates elements accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setClassicTheme(object sender, EventArgs e)
        {
            selectedTheme = theme.classic;
            this.BackColor = Color.FromArgb(160, 160, 160);
            easyDifficultyButton.Image   = Properties.Resources.classic_easy_button;
            normalDifficultyButton.Image = Properties.Resources.classic_normal_button;
            hardDifficultyButton.Image   = Properties.Resources.classic_hard_button;
            confirmButton.Image          = Properties.Resources.classic_confirm_button;
            cancelButton.Image           = Properties.Resources.classic_cancel_button;
        }

        /// <summary>
        /// sets the theme of the dialog and the main window to the bubble theme, and updates elements accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setBubbleTheme(object sender, EventArgs e)
        {
            selectedTheme = theme.bubble;
            this.BackColor = Color.FromArgb(14, 66, 77);
            easyDifficultyButton.Image   = Properties.Resources.bubble_easy_button;
            normalDifficultyButton.Image = Properties.Resources.bubble_normal_button;
            hardDifficultyButton.Image   = Properties.Resources.bubble_hard_button;
            confirmButton.Image          = Properties.Resources.bubble_confirm_button;
            cancelButton.Image           = Properties.Resources.bubble_cancel_button;
        }

        /// <summary>
        /// sets the theme of the dialog and the main window to the dark theme, and updates elements accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setDarkTheme(object sender, EventArgs e)
        {
            selectedTheme = theme.dark;
            this.BackColor = Color.FromArgb(45, 41, 51);
            easyDifficultyButton.Image   = Properties.Resources.dark_easy_button;
            normalDifficultyButton.Image = Properties.Resources.dark_normal_button;
            hardDifficultyButton.Image   = Properties.Resources.dark_hard_button;
            confirmButton.Image          = Properties.Resources.dark_confirm_button;
            cancelButton.Image           = Properties.Resources.dark_cancel_button;
        }

        /// <summary>
        /// causes the button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void normalButton_Down(object sender, MouseEventArgs e)
        {
            switch (selectedTheme)
            {
                case theme.cats:
                    normalDifficultyButton.Image = Properties.Resources.cat_normal_button_pressed;
                    break;

                case theme.classic:
                    normalDifficultyButton.Image = Properties.Resources.classic_normal_button_pressed;
                    break;

                case theme.dark:
                    normalDifficultyButton.Image = Properties.Resources.dark_normal_button_pressed;
                    break;

                case theme.bubble:
                    normalDifficultyButton.Image = Properties.Resources.bubble_normal_button_pressed;
                    break;
            }
        }

        /// <summary>
        /// makes the normal difficulty button appear unpressed and sets difficulty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void normalButton_Up(object sender, MouseEventArgs e)
        {
            customWidthBox.Value = 16;
            customHeightBox.Value = 16;
            customMinesBox.Value = 40;

            switch (selectedTheme)
            {
                case theme.cats:
                    normalDifficultyButton.Image = Properties.Resources.cat_normal_button;
                    break;

                case theme.classic:
                    normalDifficultyButton.Image = Properties.Resources.classic_normal_button;
                    break;

                case theme.dark:
                    normalDifficultyButton.Image = Properties.Resources.dark_normal_button;
                    break;

                case theme.bubble:
                    normalDifficultyButton.Image = Properties.Resources.bubble_normal_button;
                    break;
            }
        }

        /// <summary>
        /// causes the easy difficulty button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void easyButton_Down(object sender, MouseEventArgs e)
        {
            switch (selectedTheme)
            {
                case theme.cats:
                    easyDifficultyButton.Image = Properties.Resources.cat_easy_button_pressed;
                    break;

                case theme.classic:
                    easyDifficultyButton.Image = Properties.Resources.classic_easy_button_pressed;
                    break;

                case theme.dark:
                    easyDifficultyButton.Image = Properties.Resources.dark_easy_button_pressed;
                    break;

                case theme.bubble:
                    easyDifficultyButton.Image = Properties.Resources.bubble_easy_button_pressed;
                    break;
            }
        }

        /// <summary>
        /// makes the easy difficulty button appear unpressed and sets difficulty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void easyButton_Up(object sender, MouseEventArgs e)
        {
            customWidthBox.Value = 9;
            customHeightBox.Value = 9;
            customMinesBox.Value = 10;

            switch (selectedTheme)
            {
                case theme.cats:
                    easyDifficultyButton.Image = Properties.Resources.cat_easy_button;
                    break;

                case theme.classic:
                    easyDifficultyButton.Image = Properties.Resources.classic_easy_button;
                    break;

                case theme.dark:
                    easyDifficultyButton.Image = Properties.Resources.dark_easy_button;
                    break;

                case theme.bubble:
                    easyDifficultyButton.Image = Properties.Resources.bubble_easy_button;
                    break;
            }
        }

        /// <summary>
        /// causes the hard difficulty button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hardButton_Down(object sender, MouseEventArgs e)
        {
            switch (selectedTheme)
            {
                case theme.cats:
                    hardDifficultyButton.Image = Properties.Resources.cat_hard_button_pressed;
                    break;

                case theme.classic:
                    hardDifficultyButton.Image = Properties.Resources.classic_hard_button_pressed;
                    break;

                case theme.dark:
                    hardDifficultyButton.Image = Properties.Resources.dark_hard_button_pressed;
                    break;

                case theme.bubble:
                    hardDifficultyButton.Image = Properties.Resources.bubble_hard_button_pressed;
                    break;
            }
        }

        /// <summary>
        /// makes the hard difficulty button appear unpressed and sets difficulty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hardButton_Up(object sender, MouseEventArgs e)
        {
            customWidthBox.Value = 30;
            customHeightBox.Value = 16;
            customMinesBox.Value = 99;

            switch (selectedTheme)
            {
                case theme.cats:
                    hardDifficultyButton.Image = Properties.Resources.cat_hard_button;
                    break;

                case theme.classic:
                    hardDifficultyButton.Image = Properties.Resources.classic_hard_button;
                    break;

                case theme.dark:
                    hardDifficultyButton.Image = Properties.Resources.dark_hard_button;
                    break;

                case theme.bubble:
                    hardDifficultyButton.Image = Properties.Resources.bubble_hard_button;
                    break;
            }
        }

        /// <summary>
        /// causes the cancel button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Down(object sender, MouseEventArgs e)
        {
            switch (selectedTheme)
            {
                case theme.cats:
                    cancelButton.Image = Properties.Resources.cat_cancel_button_pressed;
                    break;

                case theme.classic:
                    cancelButton.Image = Properties.Resources.classic_cancel_button_pressed;
                    break;

                case theme.dark:
                    cancelButton.Image = Properties.Resources.dark_cancel_button_pressed;
                    break;

                case theme.bubble:
                    cancelButton.Image = Properties.Resources.bubble_cancel_button_pressed;
                    break;
            }
        }

        /// <summary>
        /// closes the dialog without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Up(object sender, MouseEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// causes the button to appear pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Down(object sender, EventArgs e)
        {
            switch (selectedTheme)
            {
                case theme.cats:
                    confirmButton.Image = Properties.Resources.cat_confirm_button_pressed;
                    break;

                case theme.classic:
                    confirmButton.Image = Properties.Resources.classic_confirm_button_pressed;
                    break;

                case theme.dark:
                    confirmButton.Image = Properties.Resources.dark_confirm_button_pressed;
                    break;

                case theme.bubble:
                    confirmButton.Image = Properties.Resources.bubble_confirm_button_pressed;
                    break;
            }
        }

        /// <summary>
        /// saves inputs and closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Up(object sender, EventArgs e)
        {
            confirmed = true;
            mapWidth = (int)customWidthBox.Value;
            mapHeight = (int)customHeightBox.Value;
            numMines = (int)customMinesBox.Value;
            this.Close();
        }

    }
}