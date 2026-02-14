using System.ComponentModel;

namespace Sokoban
{
    internal class Hero : GameObject
    {
        private static readonly int hero_id = 4;

        internal Hero(int x, int y) : base(hero_id, x, y)
        {
            
        }
    }
}
