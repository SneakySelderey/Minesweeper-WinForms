﻿namespace Minesweeper_WinForms
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            TimerLabel = new Label();
            FieldTable = new TableLayoutPanel();
            FlagsCountLabel = new Label();
            SuspendLayout();
            // 
            // TimerLabel
            // 
            TimerLabel.Anchor = AnchorStyles.Bottom;
            TimerLabel.AutoSize = true;
            TimerLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            TimerLabel.Location = new Point(934, 1064);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(448, 51);
            TimerLabel.TabIndex = 0;
            TimerLabel.Text = "Time elapsed: 0 min 0 sec";
            // 
            // FieldTable
            // 
            FieldTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FieldTable.AutoScroll = true;
            FieldTable.AutoSize = true;
            FieldTable.ColumnCount = 1;
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            FieldTable.Location = new Point(1, -1);
            FieldTable.Name = "FieldTable";
            FieldTable.RowCount = 1;
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            FieldTable.Size = new Size(1637, 1062);
            FieldTable.TabIndex = 1;
            // 
            // FlagsCountLabel
            // 
            FlagsCountLabel.Anchor = AnchorStyles.Bottom;
            FlagsCountLabel.AutoSize = true;
            FlagsCountLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            FlagsCountLabel.Location = new Point(397, 1064);
            FlagsCountLabel.Name = "FlagsCountLabel";
            FlagsCountLabel.Size = new Size(195, 51);
            FlagsCountLabel.TabIndex = 2;
            FlagsCountLabel.Text = "Mines left:";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1636, 1124);
            Controls.Add(FlagsCountLabel);
            Controls.Add(FieldTable);
            Controls.Add(TimerLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameForm";
            Text = "GameForm";
            FormClosed += GameForm_FormClosed;
            Load += GameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label TimerLabel;
        private TableLayoutPanel FieldTable;
        private Label FlagsCountLabel;
    }
}