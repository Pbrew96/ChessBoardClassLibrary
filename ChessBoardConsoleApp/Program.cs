/*
 * Patrick
 * CST-250
 * 05/09/2026
 * Chess Board Project
 * Activity 2
 */

using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;

//--------------------------------
// Start of Main Method
//--------------------------------
 
//Declare and initialize
string piece = "";
Tuple<int, int>? result;
BoardLogic boardLogic = new BoardLogic();
// Print a welcome message for the user
Console.WriteLine("Hello, Chess Players!");

// Create a new chess board
BoardModel board = new BoardModel(8);
// Show the empty board
Utility.PrintBoard(board);
// Prompt the user for the type of chess piece
while (true)
{
    Console.Write("Enter the type of piece you want to place (Knight, Rook, Bishop, Queen, King): ");
    piece = Console.ReadLine();

    if (piece != null &&
        (piece.ToLower() == "knight" ||
         piece.ToLower() == "rook" ||
         piece.ToLower() == "bishop" ||
         piece.ToLower() == "queen" ||
         piece.ToLower() == "king"))
    {
        break;
    }

    Console.WriteLine("Invalid piece. Please enter Knight, Rook, Bishop, Queen, or King.");
}
// Prompt the user for the location of the chess piece
result = Utility.GetRowAndCol(board);
// Mark the legal moves based on the input
board = boardLogic.MarkLegalMoves(board, board.Grid[result.Item1, result.Item2], piece);
// Print out the new chess board
Utility.PrintBoard(board);
//--------------------------------
// End of Main Method
//--------------------------------

//--------------------------------
// Define a Utility class
//--------------------------------

public static class Utility
{
    /// <summary>
    /// Displays the current state of the chess board
    /// including chess pieces and legal moves
    /// </summary>
    /// <param name="board"></param>
    internal static void PrintBoard(BoardModel board)
    {
        // Print column headers
        Console.Write("   ");

        for (int col = 0; col < board.Size; col++)
        {
            Console.Write($" {col}  ");
        }

        Console.WriteLine();

        // Loop over the rows of the board
        for (int row = 0; row < board.Size; row++)
        {
            // Print the top border for each row
            Console.Write("  ");

            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("+---");
            }

            Console.WriteLine("+");

            // Print the row number
            Console.Write($"{row} ");

            // Loop over the columns of the board
            for (int col = 0; col < board.Size; col++)
            {
                CellModel cell = board.Grid[row, col];

                string displayValue = ".";

                if (cell.IsLegalNextMove)
                {
                    displayValue = "+";
                }
                else if (cell.PieceOccupyingCell != "")
                {
                    displayValue = cell.PieceOccupyingCell;
                }

                Console.Write($"| {displayValue} ");
            }

            Console.WriteLine("|");
        }

        // Print the bottom border
        Console.Write("  ");

        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("+---");
        }

        Console.WriteLine("+");
    }
/// <summary>
/// Prompts the user to enter a valid row and column
/// position for placing a chess piece on the board
/// </summary>
/// <param name="board">The chess board used for bounds checking</param>
/// <returns></returns>
    internal static Tuple<int, int> GetRowAndCol(BoardModel board)
    {
        int row;
        int col;

        // Get the row from the user
        while (true)
        {
            Console.Write("Enter the row number of the piece: ");

            if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < board.Size)
            {
                break;
            }

            Console.WriteLine($"Invalid row. Enter a number between 0 and {board.Size - 1}.");
        }

        // Get the column from the user
        while (true)
        {
            Console.Write("Enter the column number of the piece: ");

            if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < board.Size)
            {
                break;
            }

            Console.WriteLine($"Invalid column. Enter a number between 0 and {board.Size - 1}.");
        }

        // Return the data
        return Tuple.Create(row, col);
    }
}