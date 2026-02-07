using FieldForm.API;
using System.Drawing;

namespace FieldForm
{
    public class GridView : IGridView
    {

        public int Height { get; private set; }
        public int Width { get; private set; }

        private Field[,] Fields { get; set; }

        private Dictionary<int, Bitmap> bitmaps = new Dictionary<int, Bitmap>();

        internal GridView(int width, int height)
        {
            Height = height;
            Width = width;
            Fields = new Field[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Fields[x, y] = new Field();
                }
            }
        }

        public IField? GetField(int x, int y)
        {
            if (x < 0 || x >= Width)
            {
                return null;
            }
            if (y < 0 || y >= Height)
            {
                return null;
            }
            return Fields[x, y];
        }

        public void SetBackgroundWithArray(int[,] fields)
        {
            for (int x = 0;x < Width; x++)
            {
                for (int y = 0;y < Height; y++)
                {
                    Field field = Fields[x, y];
                    field.Background = fields[x, y];      
                }
            }            
        }

        public void AddBitmap(int index, Bitmap bitmap)
        {
            if (index <= 0 )
            {
                return;
            }
            if (bitmaps.ContainsKey(index))
            {
                bitmaps[index].Dispose();
                bitmaps[index] = bitmap;                
                return;
            }
            bitmaps.Add(index, bitmap);
        }

        public Bitmap? GetBitmap(int index)
        {
            if (bitmaps.ContainsKey(index))
            {
                return bitmaps[index];
            }
            return null;
        }
    }
}
