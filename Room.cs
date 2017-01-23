using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class Room
    {
        public GameObject Object { get; set; }
        
        public Room()
        {
        }

        public Room(GameObject item)
        {
            Object = item;
        }

        public override string ToString()
        {
            return "Room";
        }
    }
}
