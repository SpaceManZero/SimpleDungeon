using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class Goblin : Monster
    {
        public Goblin() : base("Goblin", 50)
        {
            Damage = 5;
        }
    }
}
