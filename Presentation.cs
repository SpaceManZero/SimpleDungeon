using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    abstract class Presentation
    {
        public abstract void DisplayWorld(Player player, Room[,] rooms);
        public abstract void DisplayStats(Player player, Room room);
        public abstract void ManageInput(Player player, Room[,] rooms);
        public abstract bool HandleEncounter(Player player, Room room);
    }
}
