// <copyright file="GameUtilities.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a Facade class to replace the original functionality of the King Survival game
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
                GameUtilities.Display();
                ////KingSurvivalGame.DisplayBoard();
                ////Console.WriteLine("King: [{0}, {1}] ", KingSurvivalGame.KingPosition[0], KingSurvivalGame.KingPosition[1]);
                ////Console.Write("Pawn A: [{0}, {1}] ", KingSurvivalGame.PawnPositions[0, 0], KingSurvivalGame.PawnPositions[0, 1]);
                ////Console.Write("Pawn B: [{0}, {1}] ", KingSurvivalGame.PawnPositions[1, 0], KingSurvivalGame.PawnPositions[1, 1]);
                ////Console.Write("Pawn C: [{0}, {1}] ", KingSurvivalGame.PawnPositions[2, 0], KingSurvivalGame.PawnPositions[2, 1]);
                ////Console.Write("Pawn D: [{0}, {1}] ", KingSurvivalGame.PawnPositions[3, 0], KingSurvivalGame.PawnPositions[3, 1]);
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
        /// displays the current turn on screen
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
            int kingX = GameUtilities.GetXFromOriginalCoordinate(KingSurvivalGame.KingPosition[1]);
            int kingY = GameUtilities.GetYFromOriginalCoordinate(KingSurvivalGame.KingPosition[0]);
            Console.CursorLeft = kingX;
            Console.CursorTop = kingY;
            Console.Write('K');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            //// draw Pawns
            Console.BackgroundColor = ConsoleColor.Red;
            int pawnAX = GameUtilities.GetXFromOriginalCoordinate(KingSurvivalGame.PawnPositions[0, 1]);
            int pawnAY = GameUtilities.GetYFromOriginalCoordinate(KingSurvivalGame.PawnPositions[0, 0]);
            Console.CursorLeft = pawnAX;
            Console.CursorTop = pawnAY;
            Console.Write('A');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            int pawnBX = GameUtilities.GetXFromOriginalCoordinate(KingSurvivalGame.PawnPositions[1, 1]);
            int pawnBY = GameUtilities.GetYFromOriginalCoordinate(KingSurvivalGame.PawnPositions[1, 0]);
            Console.CursorLeft = pawnBX;
            Console.CursorTop = pawnBY;
            Console.Write('B');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            int pawnCX = GameUtilities.GetXFromOriginalCoordinate(KingSurvivalGame.PawnPositions[2, 1]);
            int pawnCY = GameUtilities.GetYFromOriginalCoordinate(KingSurvivalGame.PawnPositions[2, 0]);
            Console.CursorLeft = pawnCX;
            Console.CursorTop = pawnCY;
            Console.Write('C');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            int pawnDX = GameUtilities.GetXFromOriginalCoordinate(KingSurvivalGame.PawnPositions[3, 1]);
            int pawnDY = GameUtilities.GetYFromOriginalCoordinate(KingSurvivalGame.PawnPositions[3, 0]);
            Console.CursorLeft = pawnDX;
            Console.CursorTop = pawnDY;
            Console.Write('D');
            Console.CursorLeft = 0;
            Console.CursorTop = 24;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// calculates the X cursor coordinate based on info from the original implementation
        /// </summary>
        /// <param name="originalCoord">cursor X coordinate</param>
        /// <returns>new cursor X coordinate for console drawing</returns>
        public static int GetXFromOriginalCoordinate(int originalCoord)
        {
            switch (originalCoord)
            {
                case 4: return 2;
                case 6: return 7;
                case 8: return 12;
                case 10: return 17;
                case 12: return 22;
                case 14: return 27;
                case 16: return 32;
                case 18: return 37;
                default: throw new ArgumentOutOfRangeException("X coordinate is invalid!");                    
            }
        }

        /// <summary>
        /// calculates the Y cursor coordinate based on info from the original implementation
        /// </summary>
        /// <param name="originalCoord">cursor Y coordinate</param>
        /// <returns>new cursor Y coordinate for console drawing</returns>
        public static int GetYFromOriginalCoordinate(int originalCoord)
        {
            switch (originalCoord)
            {
                case 2: return 1;
                case 3: return 4;
                case 4: return 7;
                case 5: return 10;
                case 6: return 13;
                case 7: return 16;                
                case 8: return 19;
                case 9: return 22;                
                default: throw new ArgumentOutOfRangeException("Y coordinate is invalid!");
            }
        }
    }
}
