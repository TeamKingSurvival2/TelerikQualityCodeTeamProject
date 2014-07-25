// <copyright file="BoardRenderer.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>
namespace KingSurvivalGame
{
    using System;

    /// <summary>
    /// Holds information about the board.
    /// </summary>
    public static class BoardRenderer
    {
        /// <summary>
        /// game board as two-dimensional char array
        /// </summary>
        private static readonly char[,] TheBoard = 
        {                                    
            { 'U', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'U', 'R' },
            { ' ', ' ', ' ', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', ' ', ' ', ' ' },
            { '0', ' ', '|', ' ', 'A', ' ', ' ', ' ', 'B', ' ', ' ', ' ', 'C', ' ', ' ', ' ', 'D', ' ', ' ', ' ', '|', ' ', '0' },
            { '1', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '1' },
            { '2', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2' },
            { '3', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '3' },
            { '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '4' },
            { '5', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '5' },
            { '6', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '6' },
            { '7', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '7' },
            { ' ', ' ', '|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|', ' ', ' ' },
            { 'D', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'D', 'R' }
        };

        /// <summary>
        /// coordinates of board corners
        /// </summary>
        private static readonly Coordinates[] TheBoardCorners =
        {
            new Coordinates(2, 4),
            new Coordinates(10, 19)
        };

        /// <summary>
        /// Gets game board as two-dimensional char array.
        /// </summary>
        public static char[,] Board
        {
            get
            {
                return BoardRenderer.TheBoard;
            }

/*
            private set
            {
                board = value;
            }
*/
        }

/*
        /// <summary>
        /// Gets the coordinates of board corners.
        /// </summary>
        public Coordinates[] BoardCorners
        {
            get
            {
                return boardCorners;
            }

            private set
            {
                boardCorners = value;
            }
        }
*/

        /// <summary>
        /// checks if coordinates are within the game field
        /// </summary>
        /// <param name="positionCoodinates">coordinates integer array parameter</param>
        /// <returns>a true or false boolean value</returns>
        public static bool CheckIfCoordsAreWithinGameField(Coordinates positionCoodinates)
        {
            bool isRowInBoard = (positionCoodinates.XCoord >= TheBoardCorners[0].XCoord) && (positionCoodinates.XCoord <= TheBoardCorners[1].XCoord);
            bool isColInBoard = (positionCoodinates.YCoord >= TheBoardCorners[0].YCoord) && (positionCoodinates.YCoord <= TheBoardCorners[1].YCoord);
            return isRowInBoard && isColInBoard;
        }
    }
}
