using System.Windows.Forms;

namespace MinesweeperGUI
{
    /// <summary>
    /// extremely basic wrapper class for PictureBox, it only adds two additional bits of info: state and theme.
    /// </summary>
    class GUICell : PictureBox
    {
        public state currentState;
        public theme currentTheme;        
    }
}
