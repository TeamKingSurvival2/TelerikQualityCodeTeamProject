// <copyright file="KingSurvivalGame.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// contains the refactored King Survival Game (work in progress)
    /// </summary>
    public class KingSurvivalGame
    {
        /// <summary>
        /// holds the KingUpRight move value
        /// </summary>
        public const string KingUpRight = "KUR";

        /// <summary>
        /// holds the KingUpLeft move value
        /// </summary>
        public const string KingUpLeft = "KUL";

        /// <summary>
        /// holds the KingDownRight move value
        /// </summary>
        public const string KingDownRight = "KDR";

        /// <summary>
        /// holds the KingDownLeft move value
        /// </summary>
        public const string KingDownLeft = "KDL";

        /// <summary>
        /// holds the PawnADownRight move value
        /// </summary>
        public const string PawnADownRight = "ADR";

        /// <summary>
        /// holds the PawnADownLeft move value
        /// </summary>
        public const string PawnADownLeft = "ADL";

        /// <summary>
        /// holds the PawnBDownRight move value
        /// </summary>
        public const string PawnBDownRight = "BDR";

        /// <summary>
        /// holds the PawnBDownLeft move value
        /// </summary>
        public const string PawnBDownLeft = "BDL";

        /// <summary>
        /// holds the PawnCDownRight move value
        /// </summary>
        public const string PawnCDownRight = "CDR";

        /// <summary>
        /// holds the PawnCDownLeft move value
        /// </summary>
        public const string PawnCDownLeft = "CDL";

        /// <summary>
        /// holds the PawnDDownRight move value
        /// </summary>
        public const string PawnDDownRight = "DDR";

        /// <summary>
        /// holds the PawnDDownLeft move value
        /// </summary>
        public const string PawnDDownLeft = "DDL";

        /// <summary>
        /// self value
        /// </summary>
        private static KingSurvivalGame self;

        /// <summary>
        /// game board as two-dimensional char array
        /// </summary>
        private static char[,] board = 
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
            { 'D', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'D', 'R' },
        };

        /// <summary>
        /// coordinates of board corners
        /// </summary>
        private static int[,] boardCorners = 
        {
            { 2, 4 }, 
            { 2, 18 }, 
            { 9, 4 }, 
            { 9, 18 }            
        };

        /// <summary>
        /// coordinates of king position
        /// </summary>
        private static int[] kingPosition = { 9, 10 };

        /// <summary>
        /// coordinates of pawn positions (2-dimensional array)
        /// </summary>
        private static int[,] pawnPositions = 
        {
            { 2, 4 }, 
            { 2, 8 }, 
            { 2, 12 }, 
            { 2, 16 }            
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
        /// contains all valid input strings for the king
        /// </summary>
        private static string[] validKingInputs = { KingUpLeft, KingUpRight, KingDownLeft, KingDownRight };

        /// <summary>
        /// contains all valid input strings for pawn A
        /// </summary>
        private static string[] validAPawnInputs = { PawnADownLeft, PawnADownRight };

        /// <summary>
        /// contains all valid input strings for pawn B
        /// </summary>
        private static string[] validBPawnInputs = { PawnBDownLeft, PawnBDownRight };

        /// <summary>
        /// contains all valid input strings for pawn C
        /// </summary>
        private static string[] validCPawnInputs = { PawnCDownLeft, PawnCDownRight };

        /// <summary>
        /// contains all valid input strings for pawn D
        /// </summary>
        private static string[] validDPawnInputs = { PawnDDownLeft, PawnDDownRight };

        /// <summary>
        /// counts the number of king/pawn moves made in the game
        /// </summary>
        private static int movementsCounter = 0;

        /// <summary>
        /// holds game completion state
        /// </summary>
        private static bool gameIsFinished = false;

        /// <summary>
        /// Gets or sets a value indicating whether the movementsCounter field.
        /// </summary>
        public static int MovementsCounter
        {
            get { return KingSurvivalGame.movementsCounter; }
            set { KingSurvivalGame.movementsCounter = value; }
        }        

        /// <summary>
        /// Gets or sets a value indicating whether the gameIsFinished field.
        /// </summary>
        public static bool GameIsFinished
        {
            get { return KingSurvivalGame.gameIsFinished; }
            set { KingSurvivalGame.gameIsFinished = value; }
        }

        /// <summary>
        /// contains main executable program logic
        /// </summary>
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.SetWindowSize(40, 23);
            Console.BufferWidth = 41;
            Console.BufferHeight = 26;
            Console.Title = "King Survival Game";

            self = new KingSurvivalGame();
            //GameUtilities.Display(self);
            InteractWithUser(self, movementsCounter);
            Console.WriteLine("\nThank you for playing this game!\n\n");
        }
        
        /// <summary>
        /// execute the king's turn
        /// </summary>
        public static void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("Please enter king's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToUpper(); ////! input =
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

            InteractWithUser(KingSurvivalGame.self, KingSurvivalGame.movementsCounter);
        }

        /// <summary>
        /// process a pawn's turn
        /// </summary>
        public static void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Please enter pawn's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                //// input = input.Trim();
                if ((input != null) && (input != "/n"))
                {
                    //// Console.WriteLine(input);
                    //// Console.WriteLine("hahah");
                    input = input.ToUpper(); ////! input =
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

            InteractWithUser(KingSurvivalGame.self, movementsCounter);
        }

        /// <summary>
        /// displays the game board on screen
        /// </summary>
        public static void DisplayBoard()
        {
            Console.WriteLine();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = CheckIfCoordsAreWithinGameField(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(board[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(board[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(board[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(board[row, col]);
                            Console.ResetColor();
                        }
                        else if (col % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(board[row, col]);
                            Console.ResetColor();
                        }
                        else if (col % 2 != 0)
                        {
                            Console.Write(board[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(board[row, col]);
                    }
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// checks if coordinates are within the game field
        /// </summary>
        /// <param name="positionCoodinates">coordinates integer array parameter</param>
        /// <returns>a true or false boolean value</returns>
        private static bool CheckIfCoordsAreWithinGameField(int[] positionCoodinates)
        {
            int positonRow = positionCoodinates[0];
            bool isRowInBoard = (positonRow >= boardCorners[0, 0]) && (positonRow <= boardCorners[3, 0]);
            int positonCol = positionCoodinates[1];
            bool isColInBoard = (positonCol >= boardCorners[0, 1]) && (positonCol <= boardCorners[3, 1]);
            return isRowInBoard && isColInBoard;
        }

        /// <summary>
        /// alternates between king and pawn turns, checks for end of game
        /// </summary>
        /// <param name="game">game object</param>
        /// <param name="turnCounter">the number of turns passed since the game started</param>
        private static void InteractWithUser(KingSurvivalGame game, int turnCounter)
        {
            GameUtilities.Interact(KingSurvivalGame.GameIsFinished, turnCounter);
        }

        /// <summary>
        /// perform a second check
        /// </summary>
        /// <param name="checkedString">checked parameter string</param>
        /// <returns>a true/false boolean value</returns>
        private static bool SecondCheck(string checkedString)
        {
            if (movementsCounter % 2 == 0)
            {
                int[] equal = new int[4];
                for (int i = 0; i < validKingInputs.Length; i++)
                {
                    string reference = validKingInputs[i];
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
                switch (startLetter)
                {
                    case 'A':
                        for (int i = 0; i < validAPawnInputs.Length; i++)
                        {
                            string reference = validAPawnInputs[i];
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

                        if (!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }

                        return hasAnEqual;

                    case 'B':
                        for (int i = 0; i < validBPawnInputs.Length; i++)
                        {
                            string reference = validBPawnInputs[i];
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

                        if (!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }

                        return hasAnEqual;
                    case 'C':
                        for (int i = 0; i < validCPawnInputs.Length; i++)
                        {
                            string reference = validCPawnInputs[i];
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

                        if (!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }

                        return hasAnEqual;

                    case 'D':
                        for (int i = 0; i < validDPawnInputs.Length; i++)
                        {
                            string reference = validDPawnInputs[i];
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

                        if (!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }

                        return hasAnEqual;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command name!");
                        Console.ResetColor();
                        return false;
                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// validates turn and executes it
        /// </summary>
        /// <param name="checkedInput">input parameter</param>
        /// <returns>a boolean true/false value</returns>
        private static bool CheckAndExecuteTurn(string checkedInput)
        {
            bool commandNameIsOK = SecondCheck(checkedInput);
            if (commandNameIsOK)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnPositions[0, 0];
                            oldCoordinates[1] = pawnPositions[0, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'A');
                            if (coords != null)
                            {
                                pawnPositions[0, 0] = coords[0];
                                pawnPositions[0, 1] = coords[1];
                            }
                        }
                        else
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnPositions[0, 0];

                            oldCoordinates[1] = pawnPositions[0, 1];
                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'A');
                            if (coords != null)
                            {
                                pawnPositions[0, 0] = coords[0];

                                pawnPositions[0, 1] = coords[1];
                            }
                        }

                        return true;

                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnPositions[1, 0];
                            oldCoordinates[1] = pawnPositions[1, 1];

                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'B');
                            if (coords != null)
                            {
                                pawnPositions[1, 0] = coords[0];
                                pawnPositions[1, 1] = coords[1];
                            }
                        }
                        else
                        {
                            int[] oldCoordinates = new int[2];

                            oldCoordinates[0] = pawnPositions[1, 0];

                            oldCoordinates[1] = pawnPositions[1, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'B');
                            if (coords != null)
                            {
                                pawnPositions[1, 0] = coords[0];
                                pawnPositions[1, 1] = coords[1];
                            }
                        }

                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnPositions[2, 0];
                            oldCoordinates[1] = pawnPositions[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'C');
                            if (coords != null)
                            {
                                pawnPositions[2, 0] = coords[0];
                                pawnPositions[2, 1] = coords[1];
                            }
                        }
                        else
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnPositions[2, 0];
                            oldCoordinates[1] = pawnPositions[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'C');
                            if (coords != null)
                            {
                                pawnPositions[1, 0] = coords[0];
                                pawnPositions[1, 1] = coords[1];
                            }
                        }

                        return true;

                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnPositions[3, 0];
                            oldCoordinates[1] = pawnPositions[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'D');
                            if (coords != null)
                            {
                                pawnPositions[3, 0] = coords[0];
                                pawnPositions[3, 1] = coords[1];
                            }
                        }
                        else
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = pawnPositions[3, 0];
                            oldCoordinates[1] = pawnPositions[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'D');
                            if (coords != null)
                            {
                                pawnPositions[3, 0] = coords[0];
                                pawnPositions[3, 1] = coords[1];
                            }
                        }

                        return true;

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = kingPosition[0];
                                oldCoordinates[1] = kingPosition[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'U', 'L');
                                if (coords != null)
                                {
                                    kingPosition[0] = coords[0];
                                    kingPosition[1] = coords[1];
                                }
                            }
                            else
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = kingPosition[0];
                                oldCoordinates[1] = kingPosition[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'U', 'R');
                                if (coords != null)
                                {
                                    kingPosition[0] = coords[0];
                                    kingPosition[1] = coords[1];
                                }
                            }

                            return true;
                        }
                        else
                        {
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = kingPosition[0];
                                oldCoordinates[1] = kingPosition[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'D', 'L');
                                if (coords != null)
                                {
                                    kingPosition[0] = coords[0];
                                    kingPosition[1] = coords[1];
                                }
                            }
                            else
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = kingPosition[0];
                                oldCoordinates[1] = kingPosition[1];
                                int[] coords = new int[2];
                                coords = CheckNextKingPosition(oldCoordinates, 'D', 'R');
                                if (coords != null)
                                {
                                    kingPosition[0] = coords[0];
                                    kingPosition[1] = coords[1];
                                }
                            }

                            return true;
                        }

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
        private static int[] CheckNextPownPosition(int[] currentCoordinates, char checkDirection, char currentPawn)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] newCoords = new int[2];
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                if (CheckIfCoordsAreWithinGameField(newCoords) && board[newCoords[0], newCoords[1]] == ' ')
                {
                    char sign = board[currentCoordinates[0], currentCoordinates[1]];
                    board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                    board[newCoords[0], newCoords[1]] = sign;
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
                    /* switch (currentPawn)
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
                     }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            pawnExistingMoves[0, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[0,i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;

                        case 'B':
                            pawnExistingMoves[1, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[1, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;
                        case 'C':
                            pawnExistingMoves[2, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[2, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;

                        case 'D':
                            pawnExistingMoves[3, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[3, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
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
                    return null;
                }
            }
            else
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                if (CheckIfCoordsAreWithinGameField(newCoords) && board[newCoords[0], newCoords[1]] == ' ')
                {
                    char sign = board[currentCoordinates[0], currentCoordinates[1]];
                    board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                    board[newCoords[0], newCoords[1]] = sign;
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
                    /*   switch (currentPawn)
                       {
                           case 'A':
                               pawnExistingMoves[0, 1] = false;
                               break;

                           case 'B':
                               pawnExistingMoves[1, 1] = false;
                               break;
                           case 'C':
                               pawnExistingMoves[2, 1] = false;
                               break;

                           case 'D':
                               pawnExistingMoves[3, 1] = false;
                               break;

                           default:
                               Console.WriteLine("ERROR!");
                               break;
                       }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            pawnExistingMoves[0, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[0, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;

                        case 'B':
                            pawnExistingMoves[1, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[1, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;
                        case 'C':
                            pawnExistingMoves[2, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[2, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;

                        case 'D':
                            pawnExistingMoves[3, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[3, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
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
                    return null;
                }
            }
        }

        /// <summary>
        /// checks the next position if the king is to move
        /// </summary>
        /// <param name="currentCoordinates">current coordinates of the king</param>
        /// <param name="firstDirection">current direction of the king</param>
        /// <param name="secondDirection">new direction of the king</param>
        /// <returns>new coordinates</returns>
        private static int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] displasmentUpLeft = { -1, -2 };
            int[] displasmentUpRight = { -1, 2 };
            int[] newCoords = new int[2];

            if (firstDirection == 'U')
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpLeft[1];
                    if (CheckIfCoordsAreWithinGameField(newCoords) && board[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = board[currentCoordinates[0], currentCoordinates[1]];
                        board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        board[newCoords[0], newCoords[1]] = sign;
                        movementsCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoords[0]);
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
                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpRight[1];
                    if (CheckIfCoordsAreWithinGameField(newCoords) && board[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = board[currentCoordinates[0], currentCoordinates[1]];
                        board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        board[newCoords[0], newCoords[1]] = sign;
                        movementsCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[1] = false;
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
                        return null;
                    }
                }
            }
            else
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                    if (CheckIfCoordsAreWithinGameField(newCoords) && board[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = board[currentCoordinates[0], currentCoordinates[1]];
                        board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        board[newCoords[0], newCoords[1]] = sign;
                        movementsCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[2] = false;
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
                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                    if (CheckIfCoordsAreWithinGameField(newCoords) && board[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = board[currentCoordinates[0], currentCoordinates[1]];
                        board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        board[newCoords[0], newCoords[1]] = sign;
                        movementsCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[3] = false;
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
                        return null;
                    }
                }
                //// CheckForKingExit();
            }
        }
    }
}