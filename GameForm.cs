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
        public Form MainMenu { get; set; }  // Here we store parent main menu form in order to show it again after this window is closed
        public System.Timers.Timer Timer { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public GameForm(Form mainMenu)
        {
            InitializeComponent();
            MainMenu = mainMenu;
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)  // Stop timer and show main menu when window is closed
        {
            Timer.Stop();
            MainMenu.Show();
        }

        private void GameForm_Load(object sender, EventArgs e)  // Initialize timer when form loads
        {
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
