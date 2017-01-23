using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class Troll : Monster
    {
        public Troll() : base("Troll", 40)
        {
            Damage = 10;
        }

        public override void Fight(Creature opponent)
        {
            base.Fight(opponent);
            Health += 2;
        }
    }
}
