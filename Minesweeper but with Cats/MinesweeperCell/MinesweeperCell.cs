using System;
using System.Collections.Generic;

namespace MinesweeperModel
{
    /// <summary>
    /// This class represents a single cell in Minesweeper. 
    /// A cell keeps track of whether it has a mine, has been flagged, is currently visible, along with how many mines neighbor it.
    /// </summary>
    public class MinesweeperCell
    {
        public bool hasMine;
        public bool isVisible;
        public bool isFlagged;
        public int neighboringMines;

        /// <summary>
        /// Constructor. Default values are:
        /// hasMine: false
        /// isVisible: false
        /// isFlagged: false
        /// neighboring Mines: 0
        /// </summary>
        public MinesweeperCell()
        {
            hasMine = false;
            isVisible = false;
            isFlagged = false;
            neighboringMines = 0;
        }

    }
}
