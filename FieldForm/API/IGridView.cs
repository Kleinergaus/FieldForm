using System.Drawing;

namespace FieldForm.API
{
    public interface IGridView
    {
        public int Height { get; }
        public int Width { get; }

        /// <summary>
        /// Returns a field (0,0 is upper left, 0,m upper right n,m lower right)
        /// x is first dimension, y second
        /// </summary>
        /// <param name="x">the x coordinate</param>
        /// <param name="y">the y coordinate</param>
        /// <returns></returns>
        public IField? GetField(int x, int y);

        /// <summary>
        /// Sets the background of each tile
        /// </summary>
        /// <param name="fields">the array used to set the background of the tiles</param>
        public void SetBackgroundWithArray(int[,] fields);

        /// <summary>
        /// adds a Bitmap with the given index to the 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="bitmap"></param>
        public void AddBitmap(int index, Bitmap bitmap);

        /// <summary>
        /// Returns the bitmap with the given index.
        /// </summary>
        /// <param name="index">The index to search.</param>
        /// <returns>The bitmap or null if no bitmap was provided for that index.</returns>
        public Bitmap? GetBitmap(int index);
    }
}
