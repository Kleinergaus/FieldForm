using FieldForm.Contracts;

namespace Sokoban
{
    internal class GameObject
    {
        
        public IDisplayObject DisplayObject { get; private set; }

        internal GameObject(int id, int x, int y)
        {
            _id = id;
            _posX = x;
            _posY = y;
            DisplayObject = new Display(this);
        }

        internal int _id { get; set; }
        internal int _posX { get; set; }
        internal int _posY { get; set; }

        internal class Display : IDisplayObject
        {            

            public int Id => obj._id;
            public int posX => obj._posX;
            public int posY => obj._posY;

            private GameObject obj;

            internal Display(GameObject obj)
            {
                this.obj = obj;
            }
        }
    }
}
