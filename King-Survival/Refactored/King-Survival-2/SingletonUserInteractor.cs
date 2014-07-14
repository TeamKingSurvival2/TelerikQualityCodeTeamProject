// <copyright file="SingletonUserInteractor.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvivalGame
{
    using System;

    /// <summary>
    /// alternates between two function calls depending on a condition
    /// </summary>
    public static class SingletonUserInteractor
    {
        /// <summary>
        /// interacts with an object
        /// </summary>
        /// <param name="objectParameter">object passed as parameter</param>
        /// <param name="turnCounter">turn counter</param>
        public static void Interact(KingSurvivalGame objectParameter, int turnCounter)
        {
            if (KingSurvivalGame.GameIsFinished)
            {
                Console.WriteLine("G-A-M-E- -O-V-E-R");
                return;
            }
            else
            {
                KingSurvivalGame.DisplayBoard();
                if (turnCounter % 2 == 0)
                {
                    Console.WriteLine("Turn number {0} - King's turn", turnCounter);
                    KingSurvivalGame.ProcessKingSide();
                }
                else
                {
                    Console.WriteLine("Turn number {0} - pawn's turn", turnCounter);
                    KingSurvivalGame.ProcessPawnSide();
                }
            }
        }
    }
}
