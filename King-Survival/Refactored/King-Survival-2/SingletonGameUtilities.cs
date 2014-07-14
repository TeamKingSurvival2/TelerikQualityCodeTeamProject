// <copyright file="SingletonGameUtilities.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvivalGame
{
    using System;

    /// <summary>
    /// alternates between two function calls depending on a condition
    /// </summary>
    public static class SingletonGameUtilities
    {
        /// <summary>
        /// interacts with an object
        /// </summary>
        /// <param name="isGameFinished">boolean parameter</param>
        /// <param name="turnCounter">turn counter</param>
        public static void Interact(bool isGameFinished, int turnCounter)
        {
            KingSurvivalGame.MovementsCounter = turnCounter;
            if (isGameFinished)
            {
                Console.WriteLine("G-A-M-E- -O-V-E-R");
                KingSurvivalGame.GameIsFinished = true;       
                return;
            }
            else
            {
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
    }
}
