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
                button.MouseClick += new MouseEventHandler(ClickOnButton); // add a custom event for every buttom generated
            }

            Timer = new();
            Timer.Interval = 1000; // timer will generate an event every 1 second
            Timer.Elapsed += Timer_Elapsed; // add a method called when an event occurs
            Timer.Enabled = true;
        }

        private void ClickOnButton(object sender, MouseEventArgs e)
        {
            // TODO: call the tile check method from core here
            // ex.: CheckCell(tableLayoutPanel.GetRow((Button)sender), tableLayoutPanel.GetColumn((Button)sender))
            //Button button = (Button)sender;
            //button.Enabled = false;
            //button.BackColor = Color.LightGray;
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
