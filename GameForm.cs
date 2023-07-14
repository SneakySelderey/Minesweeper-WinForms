using Minesweeper_WinForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_WinForms
{
    public partial class GameForm : Form
    {
        internal Form MainMenu { get; set; } // Here we store parent main menu form in order to show it again after this window is closed
        internal Core GameCoreInstance { get; set; } // Here we store game core instance to actually play the game
        internal System.Timers.Timer Timer { get; set; }
        internal int Minutes { get; set; }
        internal int Seconds { get; set; }

        internal GameForm(Form mainMenu, Core core)
        {
            InitializeComponent();
            MainMenu = mainMenu;
            GameCoreInstance = core;
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e) // Stop timer and show main menu when window is closed
        {
            Timer.Stop();
            MainMenu.Show();
        }

        private void GameForm_Load(object sender, EventArgs e) // Initialize timer when form loads
        {
            FlagsCountLabel.Text = $"Mines left: {Convert.ToString(GameCoreInstance.FlagsCounter)}";
            float cellSize = 100 / GameCoreInstance.MatrixSize; // calculate a cell size in percents
            var rowStyles = FieldTable.RowStyles;
            var columnStyles = FieldTable.ColumnStyles;
            FieldTable.RowCount = GameCoreInstance.MatrixSize; // set table's size...
            FieldTable.ColumnCount = GameCoreInstance.MatrixSize; // ...to a given one

            rowStyles[0].SizeType = SizeType.Percent; // Change first row's size type...
            rowStyles[0].Height = cellSize; // ... and height
            columnStyles[0].SizeType = SizeType.Percent; // Same with first column
            columnStyles[0].Width = cellSize;
            for (int i = 0; i < GameCoreInstance.MatrixSize - 1; i++) // Add a given number of both row and column styles
            {
                rowStyles.Add(new RowStyle(SizeType.Percent, cellSize));
                columnStyles.Add(new ColumnStyle(SizeType.Percent, cellSize));
            }

            for (int i = 0; i < GameCoreInstance.MatrixSize; i++) // Add a button to every table's cell
            {
                for (int j = 0; j < GameCoreInstance.MatrixSize; j++)
                {
                    Button newButton = new() // Generate new button with correct properties...
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0, 0, 0, 0)
                    };
                    FieldTable.Controls.Add(newButton, i, j); // ...and add it to the table
                }
            }

            foreach (Button button in FieldTable.Controls)
            {
                button.MouseDown += new MouseEventHandler(MouseDownButton); // add a custom event for every buttom generated
            }

            Timer = new();
            Timer.Interval = 1000; // timer will generate an event every 1 second
            Timer.Elapsed += Timer_Elapsed; // add a method called when an event occurs
            Timer.Enabled = true;
        }

        private void MouseDownButton(object sender, MouseEventArgs e)
        {
            int row = FieldTable.GetRow((Button)sender);
            int column = FieldTable.GetColumn((Button)sender);
            Button button = (Button)FieldTable.GetControlFromPosition(column, row);
            if (e.Button == MouseButtons.Left && button.Image == null && button.BackColor != Color.LightGray) // Open tiles on left click. If the button is flagged or it is painted grey, do not respond
            {
                int[,] matrix = GameCoreInstance.Matrix;
                bool gameLost = GameCoreInstance.CheckGameLost(row, column);
                if (gameLost) // if the game is lost, open all the tiles
                {
                    Timer.Stop();
                    button.BackColor = Color.Red; // paint the tile, where the player failed, in red...
                    for (int i = 0; i < GameCoreInstance.MatrixSize; i++)
                    {
                        for (int j = 0; j < GameCoreInstance.MatrixSize; j++)
                        {
                            button = (Button)FieldTable.GetControlFromPosition(j, i);
                            if (button.BackColor != Color.Red)
                                button.BackColor = Color.LightGray; // ...paint all the others tiles in grey
                            if (matrix[i, j] == -1 && button.Image == null)
                            {
                                button.Image = Resources.mine; // show mines
                            }
                            else if (matrix[i, j] != 0 && button.Image == null)
                            {
                                button.Text = Convert.ToString(matrix[i, j]); // mark tiles near the mines with numbers
                                button.Font = new Font("Segoe UI", 16);
                            }
                        }
                    }
                    MessageBox.Show("You lost!");
                }
                else // if the game continues, open part of the tiles
                {
                    List<List<int>> openedCells = GameCoreInstance.CheckTiles(row, column, new List<List<int>> { }); // get tiles which need to be opened
                    foreach (List<int> coords in openedCells) // open every tile in the list...
                    {
                        button = (Button)FieldTable.GetControlFromPosition(coords[1], coords[0]);
                        button.BackColor = Color.LightGray; // ...paint them gray...
                        if (matrix[coords[0], coords[1]] != 0)
                            button.Text = Convert.ToString(matrix[coords[0], coords[1]]); // ...mark if needed...
                        GameCoreInstance.DisabledTiles += 1;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right && button.BackColor != Color.LightGray && button.BackColor != Color.Red && GameCoreInstance.GameWonFlag == false) // Place flag on right click. If the button is painted grey or it is painted red or the game is already won, do not respond
            {
                button = (Button)FieldTable.GetControlFromPosition(column, row);
                if (button.Image == null) // there is no flag on the tile
                {
                    button.Image = Resources.flag; // place flag
                    GameCoreInstance.DisabledTiles += 1;
                    GameCoreInstance.FlagsCounter -= 1;
                    FlagsCountLabel.Text = $"Mines left: {Convert.ToString(GameCoreInstance.FlagsCounter)}"; // update counter's lable
                }
                else // there is a flag on the tile
                {
                    button.Image = null; // remove the flag
                    GameCoreInstance.DisabledTiles -= 1;
                    GameCoreInstance.FlagsCounter += 1;
                    FlagsCountLabel.Text = $"Mines left: {Convert.ToString(GameCoreInstance.FlagsCounter)}"; // update counter's lable
                }
            }

            if (GameCoreInstance.CheckGameWon() && GameCoreInstance.GameWonFlag == false) // if all mines are marked with flags
            {
                Timer.Stop();
                GameCoreInstance.GameWonFlag = true;
                MessageBox.Show("You won!");
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)  // Update timer label text
        {
            Invoke(new Action(() =>
            {
                Seconds += 1;
                if (Seconds == 60)
                {
                    Minutes += 1;
                    Seconds = 0;
                }
                TimerLabel.Text = $"Time elapsed: {Minutes} min {Seconds} sec";
            }));
        }
    }
}
