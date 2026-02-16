using FieldForm.Contracts;

namespace Sokoban
{
    public class Game
    {

        private static int wall = 2;
        private static int free = 1;
        private static int exit = 3;

        internal static int rock = 5;

        private int currentLevel;

        private List<GameObject> objects;
        private List<IDisplayObject> displayObjects;

        private int[,] background;

        internal Hero Hero { get; }

        public IList<IDisplayObject> DisplayObjects => displayObjects;

        private void AddGameObjectsToDisplayObjects()
        {
            foreach (var obj in objects)
            {
                displayObjects.Add(obj.DisplayObject);
            }
        }

        public Game() {
            currentLevel = 1;
            objects = new List<GameObject>();
            displayObjects = new List<IDisplayObject>();

            Hero hero = new Hero(1, 3);
            objects.Add(hero);        
            Hero = hero;

            Obstacle obstacle = new Obstacle(1, 2);
            objects.Add(obstacle);
            
            obstacle = new Obstacle(2, 3);
            objects.Add(obstacle);
            AddGameObjectsToDisplayObjects();
        }

        public int[,] GetBackground()
        {
            return GetStage(currentLevel);
        }


        private bool IsFree(int x, int y)
        {
            if (background[x,y] == wall)
            {
                return false;
            }

            foreach(var obj in objects)
            {
                if (obj._posX == x && obj._posY == y)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction">up: 1, right: 2, down: 3, left: 4</param>
        /// <returns></returns>
        private bool CanMoveTo(int x, int y, int direction)
        {
            if (direction < 1 || direction > 4)
            {
                return false;
            }

            if (background[x,y]== wall)
            {
                return false;
            }

            if (ContainsObstacle(x, y))
            {
                int posXBehind = x;
                int posYBehind = y;

                if (direction == 1)
                {
                    posYBehind--;
                }
                if (direction == 2)
                {
                    posXBehind++;
                }
                if (direction == 3)
                {
                    posYBehind++;
                }
                if (direction == 4)
                {
                    posXBehind--;
                }


                if (posYBehind < 0 || posYBehind * posYBehind > background.Length)
                {
                    return false;
                }

                if (IsFree(posXBehind, posYBehind))
                {
                    return true;
                }

                return false; 
            }

            return true;
        }

        private bool ContainsObstacle(int x, int y) {
            foreach(var obj in objects)
            {
                if (obj._posX == x && obj._posY == y)
                {
                    if (obj._id == rock)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        

        public void Move(int direction)
        {
            int posXNew = Hero._posX;
            int posYNew = Hero._posY;
            switch (direction)
            {
                case 1:
                    {
                        posYNew--;
                        break;
                    }
                case 2:
                    {
                        posXNew++;
                        break;
                    }
                case 3:
                    {
                        posYNew++;
                        break;
                    }
                case 4:
                    {
                        posXNew--;
                        break;
                    }
            }
            if (CanMoveTo(posXNew, posYNew, direction))
            {
                MoveTo(direction);
            }
        }
        private void MoveObject(GameObject obj, int direction)
        {
            switch (direction)
            {
                case 1:
                    {
                        obj._posY--;
                        return;
                    }
                case 2:
                    {
                        obj._posX++;
                        return;
                    }
                case 3:
                    {
                        obj._posY++;
                        return;
                    }
                case 4:
                    {
                        obj._posX--;
                        return;
                    }            
            }
        }


        private void MoveTo(int direction)
        {
            switch (direction)
            {
                case 1:
                    {
                        Hero._posY--;
                        break;
                    }
                case 2:
                    {
                        Hero._posX++;
                        break;
                    }
                case 3:
                    {
                        Hero._posY++;
                        break;
                    }
                case 4:
                    {
                        Hero._posX--;
                        break;
                    }

            }

            foreach (var obj in objects)
            {
                if (obj._id != Game.rock)
                {
                    continue;
                }
                if (obj._posX == Hero._posX && obj._posY == Hero._posY)
                {
                    MoveObject(obj, direction);
                }
            }
        }

        internal int[,] GetStage(int level)
        {
            if (level == 1)
            {
                background = new int[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    background[i, 0] = wall;
                    background[i, 4] = wall;
                    background[0, i] = wall;
                    background[4, i] = wall;
                }
                for (int i = 1; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        background[i, j] = free;
                    }
                }

                background[3, 3] = exit;
                return background;
            }
            throw new NotImplementedException();
        }
        
    }
}
