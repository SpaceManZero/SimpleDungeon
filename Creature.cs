using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    abstract class Creature : GameObject
    {
        public int Health { get; set; }
        public int Damage { get; set; }

        public Creature(string name, int health) : base(name)
        {
            Health = health;
        }

        public virtual void Fight(Creature opponent)
        {
            opponent.Health -= Damage;
        }
    }

    abstract class Monster : Creature
    {
        public Monster(string name, int health) : base(name, health)
        {
            Count++;
        }

        public static int Count { get; set; }
    }

    sealed class Splat : GameObject
    {
        public Splat() : base("Splat")
        {
            Monster.Count--;
        }
    }
}
