using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(20, 15);
            game.Start();

            //Console.ReadKey(true);
        }
    }
}
