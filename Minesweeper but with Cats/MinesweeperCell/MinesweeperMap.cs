using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperModel
{
    /// <summary>
    /// this class represents an entire board of cells in a minesweeper game. 
    /// a board keeps track of all cells, and has functions for affecting an individual cell's state.
    /// </summary>
    public class MinesweeperMap
    {
        /// <summary>
        /// this is a 1D array representing a 2D plane of cells. each row's cells come right after the previous row's cells.
        /// to access a cell at (x, y), access this array at [x + (y * rowlength)] to jump ahead the correct number of rows.
        /// </summary>
        private MinesweeperCell[] cells;
        /// <summary>
        /// the length of each row in this map, determined by width at construction.
        /// </summary>
        private int rowLength;
        /// <summary>
        /// the number of mines in the map.
        /// </summary>
        private int numMines;
        /// <summary>
        /// the number of cells in the map.
        /// </summary>
        private int numCells;
        /// <summary>
        /// the number of flagged cells in the map. this is used to determine how many mines the player should think they have left.
        /// a player should believe there are (numMines - flaggedCells) remaining mines, even if they have flagged a non-mine cell.
        /// </summary>
        private int flaggedCells;
        /// <summary>
        /// the number of revealed cells in the map. the game is won when all non-mine cells have been revealed, or when 
        /// numCells - numMines = revealedCells
        /// </summary>
        private int revealedCells;

        /// <summary>
        /// constructor. this builds a fresh map using the same dimensions as given by the parameters and populates it with the 
        /// same number of mines given. if the number of mines can't be less than 1, and there has to be at least one non-mine cell.
        /// </summary>
        /// <param name="width">how wide each row in the map should be</param>
        /// <param name="height">how tall each column in the map should be</param>
        /// <param name="mines">how many mines should be in this map. this constructor ensures there is at least
        /// one mine and one non-mine cell in the map.</param>
        public MinesweeperMap(int width, int height, int mines)
        {
            numCells = width * height;
            rowLength = width;
            flaggedCells = 0;
            revealedCells = 0;
            cells = new MinesweeperCell[numCells];

            // populate the new map with cells
            for (int idx = 0; idx < numCells; idx++)
            {
                cells[idx] = new MinesweeperCell();
            }

            // if the desired number of mines is too great or too little, the real number of mines needs to be capped.
            // there must be at least one mine and one non-mine cell.
            if (mines < 1)
            {
                numMines = 1;
            }
            else if (mines > numCells - 1)
            {
                numMines = numCells - 1;
            }
            else
            {
                numMines = mines;
            }

            GenerateMines();


        }

        /// <summary>
        /// flags a given cell if it isn't flagged, or unflags a cell if it is flagged.
        /// </summary>
        /// <param name="x">the x coordinate of the targeted cell.</param>
        /// <param name="y">the y coordinate of the targeted cell.</param>
        public void MarkCell(int x, int y)
        {
            MinesweeperCell target = cells[x + (y * rowLength)];
            if (target.isFlagged)
            {
                target.isFlagged = false;
            }
            else
            {
                target.isFlagged = true;
            }
        }

        /// <summary>
        /// reveals a given cell if it hasn't been revealed already. if it has been flagged or already revealed, nothing happens.
        /// throws GameOverException if the revealed cell is a mine.
        /// </summary>
        /// <param name="x">the x coordinate of the targeted cell.</param>
        /// <param name="y">the y coordinate of the targeted cell.</param>
        public void RevealCell(int x, int y)
        {

            MinesweeperCell cell = cells[x + (y * rowLength)];

            // flagged cells cannot be revealed, need to check if the cell is flagged first and do nothing else if it is.
            // revealed cells don't need to be revealed again either, so we skip those too.
            if (!cell.isFlagged && !cell.isVisible)
            {
                cell.isVisible = true;
                revealedCells++;

                // if the cell is a mine, the player has lost.
                if (cell.hasMine)
                {
                    throw new GameOverException();
                }

                // if this cell has no neighboring mines, we can safely reveal all neighboring cells for the player automatically.
                else if (cell.neighboringMines == 0)
                {                    
                    RevealNeighbors(x, y);
                } 
            }
        }

        /// <summary>
        /// reveals all non-flagged cells neighboring a given cell. this method is called whenever a trivial cell has been clicked 
        /// (either the cell has 0 neighboring mines or is has flagged neighbors equal to the number of neighboring mines)
        /// </summary>
        /// <param name="x">the x coordinate of the targeted cell.</param>
        /// <param name="y">the y coordinate of the targeted cell.</param>
        private void RevealNeighbors(int x, int y)
        {
            foreach ((int x,  int y) position in GetCellNeighborPositions(x, y))
            {
                RevealCell(position.x, position.y);
            }

        }

        /// <summary>
        /// gets the number of mines the player should think they have left to find, which is the number of mines - the number of flagged cells.
        /// if this number is different than the actual number of remaining mines, the player has incorrectly flagged a cell, which is intended.
        /// </summary>
        /// <returns>the number of remaining unflagged mines based on the number of flagged cells</returns>
        public int GetRemainingMines()
        {
            return numMines - flaggedCells;
        }

        /// <summary>
        /// gets the targeted cell. if the coordinates are out of bounds, throws IndexOutOfRangeException.
        /// </summary>
        /// <param name="x">the x coordinate of the targeted cell</param>
        /// <param name="y">the y coordinate of the targeted cell</param>
        /// <returns>the targeted cell</returns>
        public MinesweeperCell GetCell(int x, int y)
        {
            // because we're using a 1D array, X has the ability to wrap around to later rows, (20, 1) would successful on a 10x10 map.
            // we need to check if X is valid before proceeding.
            if (x < 0 || x > rowLength - 1)
            {
                throw new IndexOutOfRangeException("The desired coordinates are outside of the map's dimensions.");
            }

            try
            {
                return cells[x + (y * rowLength)];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("The desired coordinates are outside of the map's dimensions.");
            }
        }

        /// <summary>
        /// used during construction, this populates the map with the number of mines provided to the constructor.
        /// </summary>
        private void GenerateMines()
        {
            // create a list of positions corresponding to every cell in the map. 
            // then we'll shuffle the list and pick the first X cells to be mines where X is the number of mines in the map.
            List<int> minePositions = new List<int>();
            for (int pos = 0; pos < numCells; pos ++)
            {
                minePositions.Add(pos);
            }

            // fisher yates shuffle, see: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            // essentially randomly move a random number after idx to idx, then increment idx
            // repeat until no positions are left
            Random rand = new Random();
            int randPos = 0;
            int temp = 0;
            for (int idx = 0; idx < minePositions.Count; idx++)
            {
                randPos = rand.Next(idx, minePositions.Count);
                temp = minePositions[randPos];
                minePositions[randPos] = minePositions[idx];
                minePositions[idx] = temp;
            }

            int minePos = 0;
            for (int idx = 0; idx < numMines; idx++)
            {
                minePos = minePositions[idx];
                // because setMine needs the position in (x, y) format to properly set up the neighboring cells, we need to convert.
                // x = minePos % rowLength, minePos = idx / rowLength
                SetMine(minePos % rowLength, minePos / rowLength);
            }

        }

        /// <summary>
        /// private helper method. this makes the targeted cell a mine and increments the mine counts of all its neighbors.
        /// does nothing if the cell already has a mine.
        /// </summary>
        /// <param name="x">the x coordinate of the targeted cell.</param>
        /// <param name="y">the y coordinate of the targeted cell.</param>
        private void SetMine(int x, int y)
        {
            MinesweeperCell target = cells[x + (y * rowLength)];

            // only proceed if this cell doesn't have a mine already to avoid incorrectly incrementing neighbors
            if (!target.hasMine)
            {
                target.hasMine = true;
                foreach ((int x, int y) position in GetCellNeighborPositions(x, y))
                {
                    GetCell(position.x, position.y).neighboringMines++;
                }
            }

        }

        /// <summary>
        /// private helper method. this gets all neighbors of the targeted cell.
        /// 
        /// TODO: MAKE THIS RETURN INDICES OF NEIGHBORS NOT THE NEIGHBORS THEMSELVES.
        /// 
        /// </summary>
        /// <param name="x">the x coordinate of the targeted cell.</param>
        /// <param name="y">the y coordinate of the targeted cell.</param>
        /// <returns>an collection containing all of the cell's neighbors.</returns>
        public IEnumerable<(int, int)> GetCellNeighborPositions(int x,  int y)
        {
            // double check the targeted cell is in a valid range:
            GetCell(x, y);

            List<(int, int)> cellPositions = new List<(int, int)>();

            // get() verifies that the targeted cell is in a valid range, then we add the coordinates to the list if it didn't throw.
            // each get() is in its own try/catch block because we want to try all of them even if some throw, any get()'s that fail 
            // will fail because the cell is an edge cell and doesn't have neighbors there.
            try
            {
                GetCell(x - 1, y - 1);
                cellPositions.Add((x - 1, y - 1));   
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                GetCell(x, y - 1);
                cellPositions.Add((x, y - 1));
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                GetCell(x + 1, y - 1);
                cellPositions.Add((x + 1, y - 1));
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                GetCell(x + 1, y);
                cellPositions.Add((x + 1, y));
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                GetCell(x + 1, y + 1);
                cellPositions.Add((x + 1, y + 1));
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                GetCell(x, y + 1);
                cellPositions.Add((x, y + 1));
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                GetCell(x - 1, y + 1);
                cellPositions.Add((x - 1, y + 1));
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                GetCell(x - 1, y);
                cellPositions.Add((x - 1, y));
            }
            catch (IndexOutOfRangeException) { }

            return cellPositions;
        }

        /// <summary>
        /// the string representation of a map is a space-separated list of numbers 0-8 and the letter m representing mines.
        /// for example, a string for a 5x5 grid with 7 mines on it might look like this:
        /// 1 1 1 0 0
        /// 2 m 3 2 1
        /// 2 m m 3 m
        /// 2 4 3 4 m
        /// m 2 m 2 1
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            StringBuilder mapString = new StringBuilder();
            for (int idx = 0; idx < cells.Length; idx++)
            {
                // if this is a mine, add "m", otherwise add the neighboring mine count
                if (cells[idx].hasMine)
                {
                    mapString.Append("m");
                }
                else
                {
                    mapString.Append($"{cells[idx].neighboringMines}");
                }

                // if this is the end of a row, add "\n", otherwise add " "
                if (idx % rowLength == rowLength - 1)
                {
                    mapString.Append("\n");
                }
                else
                {
                    mapString.Append(" ");
                }
            }
            return mapString.ToString();
        }

        /// <summary>
        /// behaves exactly like ToString(), but replaces all unrevealed cells with * and 0's with " ".
        /// </summary>
        /// <returns></returns>
        public string ToGameString()
        {
            StringBuilder mapString = new StringBuilder();
            for (int idx = 0; idx < cells.Length; idx++)
            {
                if (!cells[idx].isVisible)
                {
                    mapString.Append("*");
                }
                else if (cells[idx].hasMine)
                {
                    mapString.Append("m");
                }
                else
                {
                    if (cells[idx].neighboringMines == 0)
                    {
                        mapString.Append(" ");
                    }
                    else
                    {
                        mapString.Append($"{cells[idx].neighboringMines}");
                    }
                }

                // if this is the end of a row, add "\n", otherwise add " "
                if (idx % rowLength == rowLength - 1)
                {
                    mapString.Append("\n");
                }
                else
                {
                    mapString.Append(" ");
                }
            }
            return mapString.ToString();
        }

    }

    /// <summary>
    /// thrown to indicate the game has been lost. this happens a mine cell is revealed.
    /// </summary>
    public class GameOverException : Exception
    {

    }
}
