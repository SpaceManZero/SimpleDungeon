using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class Ogre : Monster
    {
        public Ogre() : base("Ogre", 100)
        {
            Damage = 10;
        }
    }
}
