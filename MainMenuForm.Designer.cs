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
            MainLabel.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            MainLabel.Location = new Point(669, 485);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(371, 70);
            MainLabel.TabIndex = 0;
            MainLabel.Text = "MINESWEEPER";
            // 
            // InstructionLabel
            // 
            InstructionLabel.AutoSize = true;
            InstructionLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            InstructionLabel.Location = new Point(705, 555);
            InstructionLabel.Name = "InstructionLabel";
            InstructionLabel.Size = new Size(301, 45);
            InstructionLabel.TabIndex = 1;
            InstructionLabel.Text = "Press START to play";
            // 
            // StartButton
            // 
            StartButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StartButton.Location = new Point(613, 770);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(131, 45);
            StartButton.TabIndex = 2;
            StartButton.Text = "START";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // MatrixSizeTextBox
            // 
            MatrixSizeTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MatrixSizeTextBox.Location = new Point(807, 738);
            MatrixSizeTextBox.Name = "MatrixSizeTextBox";
            MatrixSizeTextBox.PlaceholderText = "Minefield size (n*n)";
            MatrixSizeTextBox.Size = new Size(255, 45);
            MatrixSizeTextBox.TabIndex = 3;
            // 
            // MinesNumTextBox
            // 
            MinesNumTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinesNumTextBox.Location = new Point(807, 806);
            MinesNumTextBox.Name = "MinesNumTextBox";
            MinesNumTextBox.PlaceholderText = "Number of mines";
            MinesNumTextBox.Size = new Size(255, 45);
            MinesNumTextBox.TabIndex = 4;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1717, 1154);
            Controls.Add(MinesNumTextBox);
            Controls.Add(MatrixSizeTextBox);
            Controls.Add(StartButton);
            Controls.Add(InstructionLabel);
            Controls.Add(MainLabel);
            Name = "MainMenu";
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