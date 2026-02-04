using FieldForm.API;

namespace FieldForm
{
    public class GridView : IGridView
    {

        public int Height { get; private set; }
        public int Width { get; private set; }

        private Field[,] Fields { get; set; }

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
    }
}
