// <copyright file="KingPositioning.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>
namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// used to position the king
    /// </summary>
    public static class KingPositioning
    {
        /// <summary>
        /// existing moves for the king
        /// </summary>
        private static readonly bool[] KingExistingMoves = { true, true, true, true };

        /// <summary>
        /// checks the next position if the king is to move
        /// </summary>
        /// <param name="currentCoordinates">current coordinates of the king</param>
        /// <param name="inputDirection">current direction of the king</param>
        /// <returns>new coordinates</returns>
        public static Coordinates CheckNextKingPosition(Coordinates currentCoordinates, string inputDirection)
        {
            var displasmentDownLeft = new Coordinates(1, -2);
            var displasmentDownRight = new Coordinates(1, 2);
            var displasmentUpLeft = new Coordinates(-1, -2);
            var displasmentUpRight = new Coordinates(-1, 2);

            var directions = new Dictionary<string, Coordinates>
            {
                { "UL", displasmentUpLeft },
                { "UR", displasmentUpRight },
                { "DL", displasmentDownLeft },
                { "DR", displasmentDownRight }
            };

            Coordinates newCoords = currentCoordinates + directions[inputDirection];
            if (BoardRenderer.CheckIfCoordsAreWithinGameField(newCoords) && BoardRenderer.Board[newCoords.YCoord, newCoords.XCoord] == ' ')
            {
                char sign = BoardRenderer.Board[currentCoordinates.YCoord, currentCoordinates.XCoord];
                BoardRenderer.Board[currentCoordinates.YCoord, currentCoordinates.XCoord] = ' ';
                BoardRenderer.Board[newCoords.YCoord, newCoords.XCoord] = sign;
                KingSurvivalGame.MovementsCounter++;
                for (int i = 0; i < 4; i++)
                {
                    KingExistingMoves[i] = true;
                }

                CheckForKingExit(newCoords.YCoord);
                return newCoords;
            }

            KingExistingMoves[0] = false;
            bool allAreFalse = true;
            for (int i = 0; i < 4; i++)
            {
                if (KingExistingMoves[i])
                {
                    allAreFalse = false;
                }
            }

            if (allAreFalse)
            {
                KingSurvivalGame.GameIsFinished = true;
                Console.WriteLine("King loses!");
                return null;
            }

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You can't go in this direction! ");
            Console.ResetColor();
            return new Coordinates(0, 0);
        }

        /// <summary>
        /// checks if king is able to make a move
        /// </summary>
        /// <param name="currentKingXAxe">parameter integer</param>
        private static void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", KingSurvivalGame.MovementsCounter / 2);
                KingSurvivalGame.GameIsFinished = true;
            }
        }
    }
}