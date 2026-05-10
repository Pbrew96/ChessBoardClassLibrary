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
}