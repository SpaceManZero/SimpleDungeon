using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class Coin : Item
    {
        public Coin() : base("Coin")
        {

        }

        public override void PickUp(Player player)
        {
            player.Backpack.Add(this);
        }
    }
}
