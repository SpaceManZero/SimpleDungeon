using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class Player : Creature
    {
        public Player(int health) : base("Player", health)
        {
            Damage = 10;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public List<Item> Backpack { get; } = new List<Item>();
    }
}
