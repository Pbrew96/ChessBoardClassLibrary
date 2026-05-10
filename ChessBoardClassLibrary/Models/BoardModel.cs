/*
 * Patrick
 * CST-250
 * 05/09/2026
 * Chess Board Project
 * Activity 2
 */

using System.Drawing;

namespace ChessBoardClassLibrary.Models;

public class BoardModel
{
    // Class level properties
    // 'get' is public so other classes can read it,
    // 'private set' ensures only this class can modify it.
    // This is an exmaple of encapsulation: internal details are hidden and controlled.

    public int Size { get; private set; }
    public CellModel[,] Grid { get; private set; }

    /// <summary>
    /// Parameterized Constructor for BoardModel
    /// </summary>
    /// <param name="size"></param>
    public BoardModel(int size)
    {
        //Initialzie the properties for the model
        Size = size;
        Grid = new CellModel[Size, Size];

        //Create the board
        InitializeBoard();
        
    }

    private void InitializeBoard()
        {
            //Loop through the rows of the grid
            for (int row = 0; row < Size; row++)
            {
                //Loop through the columns
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new CellModel(row, col);
                }
            }
        }
    }


