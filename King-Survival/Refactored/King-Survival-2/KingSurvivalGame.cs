// <copyright file="KingSurvivalGame.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// contains the refactored King Survival Game (work in progress)
    /// </summary>
    public static class KingSurvivalGame
    {
        /// <summary>
        /// Counter of number of movements.
        /// </summary>
        internal static int MovementsCounter;

        /// <summary>
        /// holds game completion state
        /// </summary>
        internal static bool GameIsFinished;

        /// <summary>
        /// contains all valid input strings for the king.
        /// </summary>
        private static readonly string[] ValidKingInputs = { "UL", "UR", "DL", "DR" };

        /// <summary>
        /// contains all valid input strings for pawns.
        /// </summary>
        private static readonly string[] ValidPawnInputs = { "DL", "DR" };

        /// <summary>
        /// coordinates of king position.
        /// </summary>
        private static readonly Piece King = new Piece("King", new Coordinates(9, 10));

        /// <summary>
        /// array of pawns.
        /// </summary>
        private static readonly Piece[] Pawns =
        {
            new Piece("A", new Coordinates(2, 4)), 
            new Piece("B", new Coordinates(2, 8)), 
            new Piece("C", new Coordinates(2, 12)), 
            new Piece("D", new Coordinates(2, 16))
        };

        /// <summary>
        /// contains main executable program logic
        /// </summary>
        public static void Main()
        {
            InteractWithUser(MovementsCounter);
            Console.WriteLine("\nThank you for playing this game!\n\n");
        }

        /// <summary>
        /// interaction with user.
        /// </summary>
        /// <param name="turnCounter">Counter of which pieces turn is.</param>
        private static void InteractWithUser(int turnCounter)
        {
            if (GameIsFinished)
            {
                Console.WriteLine("G-A-M-E- -O-V-E-R");
            }
            else
            {
                if (turnCounter % 2 == 0)
                {
                    BoardDisplay.DisplayBoard();
                    ProcessKingSide();
                }
                else
                {
                    BoardDisplay.DisplayBoard();
                    ProcessPawnSide();
                }
            }
        }

       /// <summary>
        /// validates turn and executes it
        /// </summary>
        /// <param name="checkedInput">input parameter</param>
        /// <returns>a boolean true/false value</returns>
       private static bool CheckAndExecuteTurn(string checkedInput)
        {
            bool validCommand = IsValidCommand(checkedInput);
            if (validCommand)
            {
                Coordinates oldCoordinates;
                Coordinates coords;

                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        if (checkedInput[2] == 'L')
                        {
                            oldCoordinates = Pawns[0].Position;
                            coords = PawnsPositioning.CheckNextPownPosition(oldCoordinates, 'L', 'A');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                Pawns[0].Position = coords;
                            }
                        }
                        else
                        {
                            oldCoordinates = Pawns[0].Position;
                            coords = PawnsPositioning.CheckNextPownPosition(oldCoordinates, 'R', 'A');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                Pawns[0].Position = coords;
                            }
                        }

                        return true;

                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            oldCoordinates = Pawns[1].Position;
                            coords = PawnsPositioning.CheckNextPownPosition(oldCoordinates, 'L', 'B');

                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                Pawns[1].Position = coords;
                            }
                        }
                        else
                        {
                            oldCoordinates = Pawns[1].Position;
                            coords = PawnsPositioning.CheckNextPownPosition(oldCoordinates, 'R', 'B');

                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                Pawns[1].Position = coords;
                            }
                        }

                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            oldCoordinates = Pawns[2].Position;
                            coords = PawnsPositioning.CheckNextPownPosition(oldCoordinates, 'L', 'C');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                Pawns[2].Position = coords;
                            }
                        }
                        else
                        {
                            oldCoordinates = Pawns[2].Position;
                            coords = PawnsPositioning.CheckNextPownPosition(oldCoordinates, 'R', 'C');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                Pawns[2].Position = coords;
                            }
                        }

                        return true;

                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            oldCoordinates = Pawns[3].Position;
                            coords = PawnsPositioning.CheckNextPownPosition(oldCoordinates, 'L', 'D');

                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                Pawns[3].Position = coords;
                            }
                        }
                        else
                        {
                            oldCoordinates = Pawns[3].Position;
                            coords = PawnsPositioning.CheckNextPownPosition(oldCoordinates, 'R', 'D');
                            if (coords.XCoord != 0 && coords.YCoord != 0)
                            {
                                Pawns[3].Position = coords;
                            }
                        }

                        return true;
                    case 'K':
                        oldCoordinates = King.Position;
                        string command = checkedInput.Substring(1);
                        coords = KingPositioning.CheckNextKingPosition(oldCoordinates, command);
                        if (coords.XCoord != 0 && coords.YCoord != 0)
                        {
                            King.Position = coords;
                        }

                        return true;

                    default: Console.WriteLine("Sorry, there are some errors, but I can't tell you anything! You broked my program!");
                        return false;
                }
            }

           return false;
        }

        /// <summary>
        /// perform a check if command is valid
        /// </summary>
        /// <param name="checkedString">checked parameter string</param>
        /// <returns>a true/false boolean value</returns>
        private static bool IsValidCommand(string checkedString)
        {
            if (MovementsCounter % 2 == 0)
            {
                var equal = new int[4];
                for (int i = 0; i < ValidKingInputs.Length; i++)
                {
                    string reference = "K" + ValidKingInputs[i];
                    int result = String.Compare(checkedString, reference, StringComparison.Ordinal);
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
                var equal = new int[2];
                bool hasAnEqual = false;
                if (startLetter == 'A' || startLetter == 'B' || startLetter == 'C' || startLetter == 'D')
                {
                    for (int i = 0; i < ValidPawnInputs.Length; i++)
                    {
                        string reference = startLetter + ValidPawnInputs[i];

                        int result = String.Compare(checkedString, reference, StringComparison.Ordinal);

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
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }

            InteractWithUser(MovementsCounter);
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
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }

            InteractWithUser(MovementsCounter);
        }
    }
}