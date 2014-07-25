// <copyright file="PawnsPositioning.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Used to position the pawns
    /// </summary>
    public static class PawnsPositioning
    {
        /// <summary>
        /// existing moves for pawns
        /// </summary>
        private static readonly bool[,] PawnExistingMoves = 
        {
            { true, true }, 
            { true, true }, 
            { true, true },
            { true, true }            
        };

        /// <summary>
        /// check the next possible move of a pawn
        /// </summary>
        /// <param name="currentCoordinates">current pawn coordinates</param>
        /// <param name="checkDirection">direction to check</param>
        /// <param name="currentPawn">pawn parameter</param>
        /// <returns>new coordinates</returns>
        public static Coordinates CheckNextPownPosition(Coordinates currentCoordinates, char checkDirection, char currentPawn)
        {
            var displasmentDownLeft = new Coordinates(1, -2);
            var displasmentDownRight = new Coordinates(1, 2);
            var directions = new Dictionary<char, Coordinates> { { 'L', displasmentDownLeft }, { 'R', displasmentDownRight } };

            Coordinates newCoords = currentCoordinates + directions[checkDirection];
            Console.WriteLine(directions[checkDirection].XCoord.ToString(CultureInfo.InvariantCulture));
            Console.WriteLine(newCoords.YCoord.ToString(CultureInfo.InvariantCulture) + newCoords.XCoord.ToString(CultureInfo.InvariantCulture));
            Console.WriteLine(BoardRenderer.CheckIfCoordsAreWithinGameField(newCoords));
            if (BoardRenderer.CheckIfCoordsAreWithinGameField(newCoords) && BoardRenderer.Board[newCoords.YCoord, newCoords.XCoord] == ' ')
            {
                char sign = BoardRenderer.Board[currentCoordinates.YCoord, currentCoordinates.XCoord];
                BoardRenderer.Board[currentCoordinates.YCoord, currentCoordinates.XCoord] = ' ';
                BoardRenderer.Board[newCoords.YCoord, newCoords.XCoord] = sign;
                KingSurvivalGame.MovementsCounter++;
                switch (currentPawn)
                {
                    case 'A':
                        PawnExistingMoves[0, 0] = true;
                        PawnExistingMoves[0, 1] = true;
                        break;

                    case 'B':
                        PawnExistingMoves[1, 0] = true;
                        PawnExistingMoves[1, 1] = true;
                        break;
                    case 'C':
                        PawnExistingMoves[2, 0] = true;
                        PawnExistingMoves[2, 1] = true;
                        break;

                    case 'D':
                        PawnExistingMoves[3, 0] = true;
                        PawnExistingMoves[3, 1] = true;
                        break;

                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                return newCoords;
            }

            bool allAreFalse = true;
            switch (currentPawn)
            {
                case 'A':
                    PawnExistingMoves[0, 0] = false;
                    break;

                case 'B':
                    PawnExistingMoves[1, 0] = false;

                    break;
                case 'C':
                    PawnExistingMoves[2, 0] = false;

                    break;

                case 'D':
                    PawnExistingMoves[3, 0] = false;
                    break;

                default:
                    Console.WriteLine("ERROR!");
                    break;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (PawnExistingMoves[i, j])
                    {
                        allAreFalse = false;
                    }
                }
            }

            if (allAreFalse)
            {
                KingSurvivalGame.GameIsFinished = true;
                Console.WriteLine("King wins!");
                KingSurvivalGame.GameIsFinished = true;
                return null;
            }

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You can't go in this direction! ");
            Console.ResetColor();
            return new Coordinates(0, 0);
        }
    }
}