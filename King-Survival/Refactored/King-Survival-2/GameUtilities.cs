// <copyright file="GameUtilities.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// alternates between two function calls depending on a condition
    /// </summary>
    public static class GameUtilities
    {
        /// <summary>
        /// interacts with a game object
        /// </summary>
        /// <param name="isGameFinished">boolean parameter</param>
        /// <param name="turnCounter">turn counter</param>
        public static void Interact(bool isGameFinished, int turnCounter)
        {
            if (isGameFinished)
            {
                Console.WriteLine("G-A-M-E- -O-V-E-R");
                KingSurvivalGame.GameIsFinished = true;
                return;
            }
            else
            {
                KingSurvivalGame.MovementsCounter = turnCounter;
                //GameUtilities.Display();
                KingSurvivalGame.DisplayBoard();
                Console.WriteLine("King: [{0}, {1}]", KingSurvivalGame.KingPosition[0], KingSurvivalGame.KingPosition[1]);
                Console.WriteLine("Pawn A: [{0}, {1}]", KingSurvivalGame.PawnPositions[0, 0], KingSurvivalGame.PawnPositions[0, 1]);
                Console.WriteLine("Pawn B: [{0}, {1}]", KingSurvivalGame.PawnPositions[1, 0], KingSurvivalGame.PawnPositions[1, 1]);
                Console.WriteLine("Pawn C: [{0}, {1}]", KingSurvivalGame.PawnPositions[2, 0], KingSurvivalGame.PawnPositions[2, 1]);
                Console.WriteLine("Pawn D: [{0}, {1}]", KingSurvivalGame.PawnPositions[3, 0], KingSurvivalGame.PawnPositions[3, 1]);
                if (turnCounter % 2 == 0)
                {
                    Console.WriteLine("Turn number {0} - King's turn", KingSurvivalGame.MovementsCounter);
                    KingSurvivalGame.ProcessKingSide();
                }
                else
                {
                    Console.WriteLine("Turn number {0} - pawn's turn", KingSurvivalGame.MovementsCounter);
                    KingSurvivalGame.ProcessPawnSide();
                }                
            }
        }

        /// <summary>
        /// displays the current turn of the King Survival game
        /// </summary>        
        public static void Display()
        {
            //// draw game board
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("     ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("     ");
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("     ");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("     ");
                    }
                }
            }

            //// draw King
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            int kingX = KingSurvivalGame.KingPosition[0];
            int kingY = KingSurvivalGame.KingPosition[1];
            Console.CursorLeft = 2 + ((kingX - 6) * 5);
            Console.CursorTop = 1 + ((kingY - 3) * 3);
            Console.Write('K');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            //// draw Pawns
            Console.BackgroundColor = ConsoleColor.Red;
            int pawnAX = KingSurvivalGame.PawnPositions[0, 0];
            int pawnAY = KingSurvivalGame.PawnPositions[0, 1];
            Console.Write(pawnAX + " " + pawnAY);
            Console.CursorLeft = 2 + ((pawnAX - 2) * 5);
            Console.CursorTop = 1 + ((pawnAY - 4) * 3);
            Console.Write('A');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            int pawnBX = KingSurvivalGame.PawnPositions[1, 0];
            int pawnBY = KingSurvivalGame.PawnPositions[1, 1];
            Console.CursorLeft = 2 + (pawnBX * 5);
            Console.CursorTop = 1 + ((pawnBY - 8) * 3);
            Console.Write('B');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            int pawnCX = KingSurvivalGame.PawnPositions[2, 0];
            int pawnCY = KingSurvivalGame.PawnPositions[2, 1];
            Console.CursorLeft = 2 + ((pawnCX + 2) * 5);
            Console.CursorTop = 1 + ((pawnCY - 12) * 3);
            Console.Write('C');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            int pawnDX = KingSurvivalGame.PawnPositions[3, 0];
            int pawnDY = KingSurvivalGame.PawnPositions[3, 1];
            Console.CursorLeft = 2 + ((pawnDX + 4) * 5);
            Console.CursorTop = 1 + ((pawnDY - 16) * 3);
            Console.Write('D');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
