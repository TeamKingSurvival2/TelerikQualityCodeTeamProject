// <copyright file="Coordinates.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>
namespace KingSurvivalGame
{
    /// <summary>
    /// Holds information about the coordinates of each element.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.Initializes a new instance of the object with the designated coordinates.
        /// </summary>
        /// <param name="y">The Y coordinate.</param>
        /// <param name="x">The X coordinate.</param>
        public Coordinates(int y, int x)
        {
            this.YCoord = y;
            this.XCoord = x;
        }

        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        public int XCoord { get; private set; }

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        public int YCoord { get; private set; }

        /// <summary>
        /// Compares two coordinates. Returns true if they are equal, and false if they're not equal.
        /// </summary>
        /// <param name="first">The first coordinates.</param>
        /// <param name="second">The second coordinates.</param>
        /// <returns>A boolean value, indicating whether both coordinates are equal.</returns>
        public static bool operator ==(Coordinates first, Coordinates second)
        {
            return first != null && first.Equals(second);
        }

        /// <summary>
        /// Compares two coordinates. Returns true if they are not equal, and false if they're equal.
        /// </summary>
        /// <param name="first">The first coordinates.</param>
        /// <param name="second">The second coordinates.</param>
        /// <returns>A boolean value, indicating whether both coordinates are not equal.</returns>
        public static bool operator !=(Coordinates first, Coordinates second)
        {
            return first != null && !first.Equals(second);
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
        /// <returns>A boolean value, indicating whether the coordinates are equal.</returns>
        public override bool Equals(object obj)
        {
            var objAsMatrixCoords = obj as Coordinates;

            if (obj == null)
            {
                return false;
            }

            return objAsMatrixCoords != null && ((this.XCoord == objAsMatrixCoords.XCoord) &&
                                                 (this.YCoord == objAsMatrixCoords.YCoord));
        }
    }
}
