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
                KingSurvivalGame.DisplayBoard();
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
        /// <param name="gameObject">game object passed as parameter</param>
        public static void Display(KingSurvivalGame gameObject)
        {
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

                    Console.WriteLine();
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

                    Console.WriteLine();
                }
            }            
            Console.BackgroundColor = ConsoleColor.Black;

        }
    }
}
