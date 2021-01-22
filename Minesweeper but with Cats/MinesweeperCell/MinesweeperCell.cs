using System;
using System.Collections.Generic;

namespace MinesweeperCell
{
    /// <summary>
    /// This class represents a single cell in Minesweeper. 
    /// A cell keeps track of whether it has a mine, has been flagged, is currently visible, along with how many mines neighbor it.
    /// A cell also keeps pointers to its neighboring cells.
    /// </summary>
    public class MinesweeperCell
    {
        public bool hasMine;
        public bool isVisible;
        public bool isFlagged;
        public int neighboringMines;
        public List<MinesweeperCell> neighbors;

        /// <summary>
        /// Constructor. Default values are:
        /// hasMine: false
        /// isVisible: false
        /// isFlagged: false
        /// neighboring Mines: 0
        /// neighbors: empty List
        /// </summary>
        public MinesweeperCell()
        {
            hasMine = false;
            isVisible = false;
            isFlagged = false;
            neighboringMines = 0;
            neighbors = new List<MinesweeperCell>();
        }

    }
}
