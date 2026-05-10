namespace ChessBoardGUIApp
{
    partial class FrmChessBoard
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
            cmbChessPieces = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            pnlChessBoard = new Panel();
            SuspendLayout();
            // 
            // cmbChessPieces
            // 
            cmbChessPieces.FormattingEnabled = true;
            cmbChessPieces.Items.AddRange(new object[] { "King", "Queen", "Bishop", "Knight", "Rook" });
            cmbChessPieces.Location = new Point(667, 12);
            cmbChessPieces.Name = "cmbChessPieces";
            cmbChessPieces.Size = new Size(121, 23);
            cmbChessPieces.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(394, 15);
            label1.TabIndex = 1;
            label1.Text = "Select a chess piece and its location on the board and see the legal moves";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(615, 15);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 2;
            label2.Text = "Pieces: ";
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.Location = new Point(3, 30);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(500, 500);
            pnlChessBoard.TabIndex = 3;
            // 
            // FrmChessBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 595);
            Controls.Add(pnlChessBoard);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbChessPieces);
            Name = "FrmChessBoard";
            Text = "Chess Board";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbChessPieces;
        private Label label1;
        private Label label2;
        private Panel pnlChessBoard;
    }
}
