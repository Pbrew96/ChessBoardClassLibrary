/*
 * Patrick
 * CST-250
 * 05/09/2026
 * Chess Board Project
 * Activity 2
 */
using ChessBoardClassLibrary.Models;

namespace ChessBoardClassLibrary.Services.BusinessLogicLayer;

public class BoardLogic
{
    private BoardModel ResetBoard(BoardModel board)
    {
        // Use a foreach loop to iterate over every cell
        foreach (CellModel cell in board.Grid)
        {
            // Set the properties to their defaults
            cell.IsLegalNextMove = false;
            cell.PieceOccupyingCell = "";

        }

        return board;
    }

    private bool IsOnBoard(BoardModel board, int row, int col)
    {
        //Get the size of the board
        int size = board.Size;
        //Check if the row is on the board
        bool IsRowSafe = row >= 0 && row < size;
        //Check if the column is on the board
        bool IsColumnSafe = col >= 0 && col < size;
        //Return true if both row and column are safe
        return IsRowSafe && IsColumnSafe;
    }

    public BoardModel MarkLegalMoves(BoardModel board, CellModel currentCell, string chessPiece)
    {
        //Reset the board
        board = ResetBoard(board);
        //Use a switch statement to determine the behavior of the piece
        switch (chessPiece.ToLower())
        {
            case "knight":
                // Set the occupying property for the current cell
                board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "N";
                // Mark the valid moves for the knight
                board = MarkValidKnightMoves(board, currentCell);
                break;
            case "rook":
                board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "R";
                board = MarkValidRookMoves(board, currentCell);
                break;
            case "bishop":
                board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "B";
                board = MarkValidBishopMoves(board, currentCell);
                break;
            case "queen":
                board = MarkValidRookMoves(board, currentCell);
                board = MarkValidBishopMoves(board, currentCell);
                break;
            case "king":
                board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "K";
                board = MarkValidKingMoves(board, currentCell);
                break;
            default:
                //If the piece is not valid, return the board as is
                return board;
        }

        return board;
    } //End of MarkLegal Moves Method

    private BoardModel MarkValidKnightMoves(BoardModel board, CellModel currentCell)
    {
        // Set the occupying property for the current cell
        board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "N";
        //Posibble moves for knight row
        int[] knightRowMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
        //Possible moves for knight column
        int[] knightColMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };
        //Loop through the knights moves
        for (int i = 0; i < knightRowMoves.Length; i++)
        {
            //Check if each move is on the board
            if (IsOnBoard(board, currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]))
            {
                //If the cell is on the board, label it as a possible move for the knight
                board.Grid[currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]]
                    .IsLegalNextMove = true;
            }
        }

        return board;
    }
    private BoardModel MarkValidRookMoves(BoardModel board, CellModel currentCell)
    {
        for (int row = 0; row < board.Size; row++)
        {
            if (row != currentCell.Row)
            {
                board.Grid[row, currentCell.Column].IsLegalNextMove = true;
            }
        }

        for (int col = 0; col < board.Size; col++)
        {
            if (col != currentCell.Column)
            {
                board.Grid[currentCell.Row, col].IsLegalNextMove = true;
            }
        }

        return board;
    }
    private BoardModel MarkValidBishopMoves(BoardModel board, CellModel currentCell)
    {
        int[] rowDirections = { -1, -1, 1, 1 };
        int[] colDirections = { -1, 1, -1, 1 };

        for (int i = 0; i < rowDirections.Length; i++)
        {
            int row = currentCell.Row + rowDirections[i];
            int col = currentCell.Column + colDirections[i];

            while (IsOnBoard(board, row, col))
            {
                board.Grid[row, col].IsLegalNextMove = true;

                row += rowDirections[i];
                col += colDirections[i];
            }
        }

        return board;
    }
    private BoardModel MarkValidQueenMoves(BoardModel board, CellModel currentCell)
    {
        
        board = MarkValidRookMoves(board, currentCell);
        board = MarkValidBishopMoves(board, currentCell);

        return board;
    }
    private BoardModel MarkValidKingMoves(BoardModel board, CellModel currentCell)
    {
        // Possible king moves
        int[] rowMoves = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] colMoves = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int i = 0; i < rowMoves.Length; i++)
        {
            int newRow = currentCell.Row + rowMoves[i];
            int newCol = currentCell.Column + colMoves[i];

            if (IsOnBoard(board, newRow, newCol))
            {
                board.Grid[newRow, newCol].IsLegalNextMove = true;
            }
        }

        return board;
    }
    
}