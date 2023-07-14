namespace Minesweeper_WinForms
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            MainLabel = new Label();
            InstructionLabel = new Label();
            StartButton = new Button();
            MatrixSizeTextBox = new TextBox();
            MinesNumTextBox = new TextBox();
            SuspendLayout();
            // 
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.BackColor = Color.Transparent;
            MainLabel.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            MainLabel.ForeColor = SystemColors.Window;
            MainLabel.Location = new Point(838, 458);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(371, 70);
            MainLabel.TabIndex = 0;
            MainLabel.Text = "MINESWEEPER";
            // 
            // InstructionLabel
            // 
            InstructionLabel.AutoSize = true;
            InstructionLabel.BackColor = Color.Transparent;
            InstructionLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            InstructionLabel.ForeColor = SystemColors.Window;
            InstructionLabel.Location = new Point(866, 528);
            InstructionLabel.Name = "InstructionLabel";
            InstructionLabel.Size = new Size(301, 45);
            InstructionLabel.TabIndex = 1;
            InstructionLabel.Text = "Press START to play";
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.Transparent;
            StartButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StartButton.Location = new Point(782, 743);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(131, 45);
            StartButton.TabIndex = 2;
            StartButton.Text = "START";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // MatrixSizeTextBox
            // 
            MatrixSizeTextBox.BackColor = SystemColors.Window;
            MatrixSizeTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MatrixSizeTextBox.Location = new Point(976, 711);
            MatrixSizeTextBox.Name = "MatrixSizeTextBox";
            MatrixSizeTextBox.PlaceholderText = "Minefield size (n*n)";
            MatrixSizeTextBox.Size = new Size(255, 45);
            MatrixSizeTextBox.TabIndex = 3;
            // 
            // MinesNumTextBox
            // 
            MinesNumTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinesNumTextBox.Location = new Point(976, 779);
            MinesNumTextBox.Name = "MinesNumTextBox";
            MinesNumTextBox.PlaceholderText = "Number of mines";
            MinesNumTextBox.Size = new Size(255, 45);
            MinesNumTextBox.TabIndex = 4;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.minefield_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1991, 1154);
            Controls.Add(MinesNumTextBox);
            Controls.Add(MatrixSizeTextBox);
            Controls.Add(StartButton);
            Controls.Add(InstructionLabel);
            Controls.Add(MainLabel);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenuForm";
            Text = "Main Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MainLabel;
        private Label InstructionLabel;
        private Button StartButton;
        private TextBox MatrixSizeTextBox;
        private TextBox MinesNumTextBox;
    }
}