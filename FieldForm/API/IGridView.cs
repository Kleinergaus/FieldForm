using FieldForm.Contracts;
using System.Drawing;

namespace FieldForm.API
{
    public interface IGridView
    {
        public int Height { get; }
        public int Width { get; }

        public int MarginTop { get; }
        public int MarginLeft { get; }

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

        /// <summary>
        /// Adds Bitmaps from a folder
        /// </summary>
        /// <param name="folder">The folder name,  relative to working dir.</param>
        /// <returns>True if at least one Bitmap was created, otherwise false.</returns>
        public bool AddBitmapsFromFolder(string folder);

        /// <summary>
        /// Call this once all backgrounds are set and all Bitmaps have been loaded.
        /// Will display the boxes on the screen.
        /// </summary>
        /// <param name="parentForm">The parent Form.</param>
        /// <returns>true if successful</returns>
        public bool Init(Form parentForm);

        /// <summary>
        /// Call refresh when changes have been done and the shown image should be updated.
        /// </summary>
        /// <returns>True if no error occured</returns>
        public bool Refresh();

        /// <summary>
        /// Sets the margin (top, left) to the form. (0,0) is upper left corner of the form.
        /// You have to do a init and a refresh that changes take effect.
        /// It is recommended to do the changes before the first Init call.
        /// </summary>
        /// <param name="left">The distance to the left side of the form.</param>
        /// <param name="top">The distance to the top side of the form.</param>
        public void SetMarginLeftTop(int left, int top);


        /// <summary>
        /// Registers objects that should be shown at the GridView
        /// </summary>
        /// <param name="objects">The list of objects to be shown.</param>
        public void RegisterObjects(IList<IDisplayObject> objects);

        /// <summary>
        /// Returns the objects on a specified field.
        /// </summary>
        /// <param name="x">The x position on the field.</param>
        /// <param name="y">The y position on the field.</param>
        /// <returns>The list of objects on the specified field.</returns>
        IList<IDisplayObject> GetObjectsOnFiled(int x, int y);


    }
}
