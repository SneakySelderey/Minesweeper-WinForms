using System.Windows.Forms;

namespace Minesweeper_WinForms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int matrixSizeInt = Convert.ToInt32(MatrixSizeTextBox.Text);
            int minesNumInt = Convert.ToInt32(MinesNumTextBox.Text);

            if (!string.IsNullOrEmpty(MatrixSizeTextBox.Text) && !string.IsNullOrEmpty(MinesNumTextBox.Text))
            {
                if (matrixSizeInt > 0 && matrixSizeInt < 20 && minesNumInt > 0 && minesNumInt < matrixSizeInt * matrixSizeInt)
                {
                    Core gameCore = new(matrixSizeInt, minesNumInt);  // if game setting were entered correctly, start the game
                    gameCore.GenerateMatrix();
                    Form gameForm = new GameForm(this);
                    gameForm.Show();
                    Hide();
                }
            }
        }
    }
}