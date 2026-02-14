using FieldForm.Contracts;

namespace Sokoban
{
    public class Game
    {

        private int currentLevel;

        private List<GameObject> objects;
        private List<IDisplayObject> displayObjects;

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


        internal int[,] GetStage(int level)
        {
            if (level == 1)
            {
                int[,] initArray = new int[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    initArray[i, 0] = 2;
                    initArray[i, 4] = 2;
                    initArray[0, i] = 2;
                    initArray[4, i] = 2;
                }
                for (int i = 1; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        initArray[i, j] = 1;
                    }
                }

                initArray[3, 3] = 3;
                return initArray;
            }
            throw new NotImplementedException();
        }
        
    }
}
