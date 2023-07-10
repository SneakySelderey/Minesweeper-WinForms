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
        public Form MainMenu { get; set; }

        public GameForm(Form mainMenu)
        {
            InitializeComponent();
            MainMenu = mainMenu;
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu.Show();
        }
    }
}
