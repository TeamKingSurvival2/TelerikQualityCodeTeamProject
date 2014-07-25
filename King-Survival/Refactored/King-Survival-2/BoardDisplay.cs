// <copyright file="BoardDisplay.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>
namespace KingSurvivalGame
{
    using System;

    /// <summary>
    /// displays the game board on screen
    /// </summary>
    public static class BoardDisplay
    {
        /// <summary>
        /// displays the game board on screen
        /// </summary>
        public static void DisplayBoard()
        {
            Console.WriteLine();
            for (int row = 0; row < BoardRenderer.Board.GetLength(0); row++)
            {
                for (int col = 0; col < BoardRenderer.Board.GetLength(1); col++)
                {
                    var coordinates = new Coordinates(row, col);
                    bool isCellIn = BoardRenderer.CheckIfCoordsAreWithinGameField(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(BoardRenderer.Board[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(BoardRenderer.Board[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(BoardRenderer.Board[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(BoardRenderer.Board[row, col]);
                            Console.ResetColor();
                        }
                        else if (col % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(BoardRenderer.Board[row, col]);
                            Console.ResetColor();
                        }
                        else if (col % 2 != 0)
                        {
                            Console.Write(BoardRenderer.Board[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(BoardRenderer.Board[row, col]);
                    }
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}