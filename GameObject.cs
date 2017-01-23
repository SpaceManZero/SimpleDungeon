using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    abstract class GameObject
    {
        public string Name { get; set; }

        public GameObject(string name)
        {
            Name = name;
        }

        public virtual void PickUp(Player player)
        {
        }
    }
}
