// <copyright file="KingSurvivalGame.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// contains the refactored King Survival Game (work in progress)
    /// </summary>
    public static class KingSurvivalGame
    {
        /// <summary>
        /// coordinates of king position.
        /// </summary>
        private static Piece king = new Piece("King", new Coordinates(9, 10));

        /// <summary>
        /// array of pawns.
        /// </summary>
        private static Piece[] pawns = new Piece[4]
        {
            new Piece("A", new Coordinates(2, 4)), 
            new Piece("B", new Coordinates(2, 8)), 
            new Piece("C", new Coordinates(2, 12)), 
            new Piece("D", new Coordinates(2, 16)),         
        };

        /// <summary>
        /// existing moves for the king
        /// </summary>
        private static bool[] kingExistingMoves = { true, true, true, true };

        /// <summary>
        /// existing moves for pawns
        /// </summary>
        private static bool[,] pawnExistingMoves = 
        {
            { true, true }, 
            { true, true }, 
            { true, true },
            { true, true }            
        };

        /// <summary>
        /// contains all valid input strings for the king.
        /// </summary>
        private static readonly string[] ValidKingInputs = { "UL", "UR", "DL", "DR" };

        /// <summary>
        /// contains all valid input strings for pawns.
        /// </summary>
        private static readonly string[] ValidPawnInputs = { "DL", "DR" };

        /// <summary>
        /// Counter of number of movements.
        /// </summary>
        private static int movementsCounter = 0;

        /// <summary>
        /// holds game completion state
        /// </summary>
        private static bool gameIsFinished = false;

        /// <summary>
        /// interaction with user.
        /// </summary>
        /// <param name="turnCounter">Counter of which pieces turn is.</param>
        public static void InteractWithUser(int turnCounter)
        {
            if (gameIsFinished)
            {
                Console.WriteLine("G-A-M-E- -O-V-E-R");
                return;
            }
            else
            {
                if (turnCounter % 2 == 0)
                {
                    BoardRenderer.DisplayBoard();
                    ProcessKingSide();
                }
                else
                {
                    BoardRenderer.DisplayBoard();
                    ProcessPawnSide();
                }
            }
        }

        /// <summary>
        /// execute the king's turn
        /// </summary>
        private static void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("Please enter king's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if (input != null && (input != "/n"))
                {
                    input = input.ToUpper();
                    isExecuted = CheckAndExecuteTurn(input);
                }
                else
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }

            InteractWithUser(movementsCounter);
        }

        /// <summary>
        /// process a pawn's turn
        /// </summary>
        private static void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Please enter pawn's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if ((input != null) && (input != "/n"))
                {
                    input = input.ToUpper();
                    isExecuted = CheckAndExecuteTurn(input);
                }
                else
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }

            InteractWithUser(movementsCounter);
        }

        /// <summary>
        /// contains main executable program logic
        /// </summary>
        public static void Main()
        {
            InteractWithUser(movementsCounter);
            Console.WriteLine("\nThank you for playing this game!\n\n");
        }

        /// <summary>
        /// perform a check if command is valid
        /// </summary>
        /// <param name="checkedString">checked parameter string</param>
        /// <returns>a true/false boolean value</returns>
        private static bool IsValidCommand(string checkedString)
        {
            if (movementsCounter % 2 == 0)
            {
                int[] equal = new int[4];
                for (int i = 0; i < ValidKingInputs.Length; i++)
                {
                    string reference = "K" + ValidKingInputs[i];
                    int result = checkedString.CompareTo(reference);
                    if (result != 0)
                    {
                        equal[i] = 0;
                    }
                    else
                    {
                        equal[i] = 1;
                    }
                }

                bool hasAnEqual = false;
                for (int i = 0; i < 4; i++)
                {
                    if (equal[i] == 1)
                    {
                        hasAnEqual = true;
                    }
                }

                if (!hasAnEqual)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command name!");
                    Console.ResetColor();
                }

                return hasAnEqual;
            }
            else
            {
                char startLetter = checkedString[0];
                int[] equal = new int[2];
                bool hasAnEqual = false;
                if (startLetter == 'A' || startLetter == 'B' || startLetter == 'C' || startLetter == 'D')
                {
                    for (int i = 0; i < ValidPawnInputs.Length; i++)
                    {
                        string reference = startLetter.ToString() + ValidPawnInputs[i];

                        int result = checkedString.CompareTo(reference);

                        if (result != 0)
                        {
                            equal[i] = 0;
                        }
                        else
                        {
                            equal[i] = 1;
                        }
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        if (equal[i] == 1)
                        {
                            hasAnEqual = true;
                        }
                    }
                }

                if (!hasAnEqual)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command name!");
                    Console.ResetColor();
                }

                return hasAnEqual;
            }
        }

        /// <summary>
        /// validates turn and executes it
        /// </summary>
        /// <param name="checkedInput">input parameter</param>
        /// <returns>a boolean true/false value</returns>
        public static bool CheckAndExecuteTurn(string checkedInput)
        {
            bool validCommand = IsValidCommand(checkedInput);
            if (validCommand)
            {
                Coordinates oldCoordinates = new Coordinates(0, 0);
                Coordinates coords = new Coordinates(0, 0);

                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        if (checkedInput[2] == 'L')
                        {
                            oldCoordinates = pawns[0].Position;
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'A');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                pawns[0].Position = coords;
                            }
                        }
                        else
                        {
                            oldCoordinates = pawns[0].Position;
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'A');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                pawns[0].Position = coords;
                            }
                        }

                        return true;

                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            oldCoordinates = pawns[1].Position;
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'B');

                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                pawns[1].Position = coords;
                            }
                        }
                        else
                        {
                            oldCoordinates = pawns[1].Position;
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'B');

                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                pawns[1].Position = coords;
                            }
                        }

                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            oldCoordinates = pawns[2].Position;
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'C');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                pawns[2].Position = coords;
                            }
                        }
                        else
                        {
                            oldCoordinates = pawns[2].Position;
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'C');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                pawns[2].Position = coords;
                            }
                        }

                        return true;

                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            oldCoordinates = pawns[3].Position;
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'D');

                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                pawns[3].Position = coords;
                            }
                        }
                        else
                        {
                            oldCoordinates = pawns[3].Position;
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'D');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                pawns[3].Position = coords;
                            }
                        }

                        return true;
                    case 'K':
                        oldCoordinates = king.Position;
                        string command = checkedInput.Substring(1);
                        coords = CheckNextKingPosition(oldCoordinates, command);
                        if (coords.XCoord != 0 && coords.YCoord != 0)
                        {
                            king.Position = coords;
                        }

                        return true;

                    default: Console.WriteLine("Sorry, there are some errors, but I can't tell you anything! You broked my program!");
                        return false;
                }
            }
            else
            {
                return false;
            }
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
                Console.WriteLine("King wins in {0} moves!", movementsCounter / 2);
                gameIsFinished = true;
            }
        }

        /// <summary>
        /// check the next possible move of a pawn
        /// </summary>
        /// <param name="currentCoordinates">current pawn coordinates</param>
        /// <param name="checkDirection">direction to check</param>
        /// <param name="currentPawn">pawn parameter</param>
        /// <returns>new coordinates</returns>
        private static Coordinates CheckNextPownPosition(Coordinates currentCoordinates, char checkDirection, char currentPawn)
        {
            Coordinates displasmentDownLeft = new Coordinates(1, -2);
            Coordinates displasmentDownRight = new Coordinates(1, 2);
            Dictionary<char, Coordinates> directions = new Dictionary<char, Coordinates>();
            directions.Add('L', displasmentDownLeft);
            directions.Add('R', displasmentDownRight);

            Coordinates newCoords = new Coordinates(0, 0);
            newCoords = currentCoordinates + directions[checkDirection];
            Console.WriteLine(directions[checkDirection].XCoord.ToString());
            Console.WriteLine(newCoords.YCoord.ToString() + newCoords.XCoord.ToString());
            Console.WriteLine(BoardRenderer.CheckIfCoordsAreWithinGameField(newCoords));
            if (BoardRenderer.CheckIfCoordsAreWithinGameField(newCoords) && BoardRenderer.Board[newCoords.YCoord, newCoords.XCoord] == ' ')
            {
                char sign = BoardRenderer.Board[currentCoordinates.YCoord, currentCoordinates.XCoord];
                BoardRenderer.Board[currentCoordinates.YCoord, currentCoordinates.XCoord] = ' ';
                BoardRenderer.Board[newCoords.YCoord, newCoords.XCoord] = sign;
                movementsCounter++;
                switch (currentPawn)
                {
                    case 'A':
                        pawnExistingMoves[0, 0] = true;
                        pawnExistingMoves[0, 1] = true;
                        break;

                    case 'B':
                        pawnExistingMoves[1, 0] = true;
                        pawnExistingMoves[1, 1] = true;
                        break;
                    case 'C':
                        pawnExistingMoves[2, 0] = true;
                        pawnExistingMoves[2, 1] = true;
                        break;

                    case 'D':
                        pawnExistingMoves[3, 0] = true;
                        pawnExistingMoves[3, 1] = true;
                        break;

                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                return newCoords;
            }
            else
            {
                bool allAreFalse = true;
                switch (currentPawn)
                {
                    case 'A':
                        pawnExistingMoves[0, 0] = false;
                        break;

                    case 'B':
                        pawnExistingMoves[1, 0] = false;

                        break;
                    case 'C':
                        pawnExistingMoves[2, 0] = false;

                        break;

                    case 'D':
                        pawnExistingMoves[3, 0] = false;
                        break;

                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (pawnExistingMoves[i, j] == true)
                        {
                            allAreFalse = false;
                        }
                    }
                }

                if (allAreFalse)
                {
                    gameIsFinished = true;
                    Console.WriteLine("King wins!");
                    gameIsFinished = true;
                    return null;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return new Coordinates(0, 0);
            }
        }

        /// <summary>
        /// checks the next position if the king is to move
        /// </summary>
        /// <param name="currentCoordinates">current coordinates of the king</param>
        /// <param name="inputDirection">current direction of the king</param>
        /// <returns>new coordinates</returns>
        private static Coordinates CheckNextKingPosition(Coordinates currentCoordinates, string inputDirection)
        {
            Coordinates displasmentDownLeft = new Coordinates(1, -2);
            Coordinates displasmentDownRight = new Coordinates(1, 2);
            Coordinates displasmentUpLeft = new Coordinates(-1, -2);
            Coordinates displasmentUpRight = new Coordinates(-1, 2);

            Dictionary<string, Coordinates> directions = new Dictionary<string, Coordinates>();
            directions.Add("UL", displasmentUpLeft);
            directions.Add("UR", displasmentUpRight);
            directions.Add("DL", displasmentDownLeft);
            directions.Add("DR", displasmentDownRight);

            Coordinates newCoords = new Coordinates(0, 0);

            newCoords = currentCoordinates + directions[inputDirection];
            if (BoardRenderer.CheckIfCoordsAreWithinGameField(newCoords) && BoardRenderer.Board[newCoords.YCoord, newCoords.XCoord] == ' ')
            {
                char sign = BoardRenderer.Board[currentCoordinates.YCoord, currentCoordinates.XCoord];
                BoardRenderer.Board[currentCoordinates.YCoord, currentCoordinates.XCoord] = ' ';
                BoardRenderer.Board[newCoords.YCoord, newCoords.XCoord] = sign;
                movementsCounter++;
                for (int i = 0; i < 4; i++)
                {
                    kingExistingMoves[i] = true;
                }

                CheckForKingExit(newCoords.YCoord);
                return newCoords;
            }
            else
            {
                kingExistingMoves[0] = false;
                bool allAreFalse = true;
                for (int i = 0; i < 4; i++)
                {
                    if (kingExistingMoves[i] == true)
                    {
                        allAreFalse = false;
                    }
                }

                if (allAreFalse)
                {
                    gameIsFinished = true;
                    Console.WriteLine("King loses!");
                    return null;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return new Coordinates(0, 0);
            }
        }
    }
}