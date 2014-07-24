using System;
using System.Linq;

namespace KingSurvivalGame
{
    class Piece
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
        /// Piece's position.
        /// </summary>
        public Coordinates Position { get; set; }

        /// <summary>
        /// Piece's position.
        /// </summary>
        public string Name { get; set; }


    }
    //class King
    //{
    //    /// <summary>
    //    /// King's position.
    //    /// </summary>
    //    private Coordinates position;

    //    /// <summary>
    //    /// Creates an instance of this class King with it's position.
    //    /// </summary>
    //    public King()
    //    {
    //        this.Position = new Coordinates(9, 10);
    //    }

    //    /// <summary>
    //    /// King's position.
    //    /// </summary>
    //    public Coordinates Position
    //    {
    //        get
    //        {
    //            return position;
    //        }
    //        set
    //        {
    //            position = value;
    //        }
    //    }

    //}
}
