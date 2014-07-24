using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    /// <summary>
    /// Holds information about the coordinates of each element.
    /// </summary>
    class Coordinates
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        int xCoord;

        /// <summary>
        /// The Y coordinate.
        /// </summary>
        int yCoord;

        /// <summary>
        /// Creates an instance of this class with the designated coordinates.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Coordinates(int y, int x)
        {
            this.yCoord = y;
            this.xCoord = x;
        }

        /// <summary>
        /// The X coordinate.
        /// </summary>
        public int XCoord
        {
            get
            {
                return xCoord;
            }
            set
            {
                xCoord = value;
            }
        }

        /// <summary>
        /// The Y coordinate.
        /// </summary>
        public int YCoord
        {
            get
            {
                return yCoord;
            }
            set
            {
                yCoord = value;
            }
        }

        /// <summary>
        /// Compares two coordinates. Returns true if they are equal, and false if they're not equal.
        /// </summary>
        /// <param name="first">The first coordinates.</param>
        /// <param name="second">The second coordinates.</param>
        /// <returns>A bool value, indicating whether both coordinates are equal.</returns>
        public static bool operator ==(Coordinates first, Coordinates second)
        {
            return first.Equals(second);
        }

        /// <summary>
        /// Compares two coordinates. Returns true if they are not equal, and false if they're equal.
        /// </summary>
        /// <param name="first">The first coordinates.</param>
        /// <param name="second">The second coordinates.</param>
        /// <returns>A bool value, indicating whether both coordinates are not equal.</returns>
        public static bool operator !=(Coordinates first, Coordinates second)
        {
            return !first.Equals(second);
        }

        /// <summary>
        /// Adds two coordinates together.
        /// </summary>
        /// <param name="first">The first coordinates.</param>
        /// <param name="second">The second coordinates.</param>
        /// <returns>A new coordinate value with the first's and second's x and y added.</returns>
        public static Coordinates operator +(Coordinates first, Coordinates second)
        {
            return new Coordinates(first.YCoord + second.YCoord, first.XCoord + second.XCoord);
        }

        /// <summary>
        /// Compares two coordinates. Returns true if they are equal, and false if they're not equal.
        /// </summary>
        /// <param name="obj">An object, which will be cast as Coordinates, to carry on with the comparison.</param>
        /// <returns>A bool value, indicating whether the coordinates are equal.</returns>
        public override bool Equals(object obj)
        {
            Coordinates objAsMatrixCoords = obj as Coordinates;

            if (obj == null)
            {
                return false;
            }

            return (this.XCoord == objAsMatrixCoords.XCoord) &&
                   (this.YCoord == objAsMatrixCoords.YCoord);
        }
    }
}
