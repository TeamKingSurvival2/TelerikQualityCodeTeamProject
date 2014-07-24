namespace KingSurvivalGame
{
    using System;
    using System.Linq;

    public class Piece
    {
        /// <summary>
        /// Creates an instance of this class King with it's position.
        /// </summary>
        public Piece(string name, Coordinates position)
        {
            this.Name = name;
            this.Position = position;
        }

        /// <summary>
        /// Gets or sets the Piece's position.
        /// </summary>
        public Coordinates Position { get; set; }

        /// <summary>
        /// Gets or sets the Piece's name.
        /// </summary>
        public string Name { get; set; }
    }
}
