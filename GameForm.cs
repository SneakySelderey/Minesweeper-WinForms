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
        internal Form MainMenu { get; set; }  // Here we store parent main menu form in order to show it again after this window is closed
        internal Core GameCoreInstance { get; set; }  // Here we store game core instance to actually play the game
        internal System.Timers.Timer Timer { get; set; }
        internal int Minutes { get; set; }
        internal int Seconds { get; set; }

        internal GameForm(Form mainMenu, Core core)
        {
            InitializeComponent();
            MainMenu = mainMenu;
            GameCoreInstance = core;
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)  // Stop timer and show main menu when window is closed
        {
            Timer.Stop();
            MainMenu.Show();
        }

        private void GameForm_Load(object sender, EventArgs e)  // Initialize timer when form loads
        {
            float cellSize = 100 / GameCoreInstance.MatrixSize;
            var rowStyles = FieldTable.RowStyles;
            var columnStyles = FieldTable.ColumnStyles;
            FieldTable.RowCount = GameCoreInstance.MatrixSize;
            FieldTable.ColumnCount = GameCoreInstance.MatrixSize;

            rowStyles[0].SizeType = SizeType.Percent;
            rowStyles[0].Height = cellSize;
            columnStyles[0].SizeType = SizeType.Percent;
            columnStyles[0].Width = cellSize;
            for (int i = 0; i < GameCoreInstance.MatrixSize - 1; i++)
            {
                rowStyles.Add(new RowStyle(SizeType.Percent, cellSize));
                columnStyles.Add(new ColumnStyle(SizeType.Percent, cellSize));
            }

            for (int i = 0; i < GameCoreInstance.MatrixSize; i++)
            {
                for (int j = 0; j < GameCoreInstance.MatrixSize; j++)
                {
                    Button newButton = new()
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0, 0, 0, 0)
                    };
                    FieldTable.Controls.Add(newButton, i, j);
                }
            }

            Timer = new();
            Timer.Interval = 1000;
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
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
