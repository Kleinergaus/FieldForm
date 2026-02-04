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
    }
}
