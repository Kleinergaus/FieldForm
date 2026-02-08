using FieldForm.API;

namespace FieldForm.Factory
{
    public static class GridFactory
    {
        public static IGridView? CreateGridView(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                return null;
            }

            return new GridView(width, height);
        }

        
    }
}
