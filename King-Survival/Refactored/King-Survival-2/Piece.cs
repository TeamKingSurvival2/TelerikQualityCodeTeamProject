// <copyright file="Piece.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>
namespace KingSurvivalGame
{
    /// <summary>
    /// Defines the pieces.
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Piece"/> class.Creates an instance of this class King with it's position.
        /// </summary>
        /// <param name="name">The piece name.</param>
        /// <param name="position">The piece position.</param>
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
        private string Name { get; set; }
    }
}
