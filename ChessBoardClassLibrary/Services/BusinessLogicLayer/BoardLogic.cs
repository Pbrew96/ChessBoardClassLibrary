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
                break;
            case "bishop":
                break;
            case "queen":
                break;
            case "king":
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
                board.Grid[currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]].IsLegalNextMove = true;
            }
    }

        return board;
}