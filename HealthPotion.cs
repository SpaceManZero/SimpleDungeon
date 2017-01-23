using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class HealthPotion : Item
    {
        public HealthPotion() : base("Health Potion")  // Name
        {
        }

        public override void PickUp(Player player)
        {
            player.Health += 10;
        }
    }
}
