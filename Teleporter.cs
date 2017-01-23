using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class Teleporter : Item
    {
        private int width, height;

        public Teleporter(int width, int height) : base("Teleporter")
        {
            this.width = width;
            this.height = height;
        }

        public override void PickUp(Player player)
        {
            Random bounce = new Random();
            player.X = bounce.Next(width);
            player.Y = bounce.Next(height);
        }
    }
}
