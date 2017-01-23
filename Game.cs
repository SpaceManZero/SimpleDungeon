using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    sealed class Game
    {
        private Room[,] rooms;

        private int Width { get; set; }
        private int Height { get; set; }

        private Player player;
        private PresentationConsole presentation;

        public Game(int width, int height)
        {
            Width = width;
            Height = height;

            presentation = new PresentationConsole(height, width);
        }

        public void Start()
        {
            CreatePlayer(100);
            CreateWorld();

            Console.WriteLine("\tWelcome to the Dungeon");
            Thread.Sleep(1000);
            Console.Clear();

			do
            {
                if (presentation.HandleEncounter(player, rooms[player.X, player.Y]))
                    presentation.HandleEncounter(player, rooms[player.X, player.Y]);
                presentation.DisplayWorld(player, rooms);
                presentation.DisplayStats(player, rooms[player.X, player.Y]);
                presentation.ManageInput(player, rooms);
			}
            while (GameContinues());
		}

        private void CreatePlayer(int health)
        {
            player = new Player(health);
        }

        private void CreateWorld()
        {
            rooms = new Room[Width, Height];
            Random rng = new Random();

            for (int height = 0; height < Height; height++)
            {
                for (int width = 0; width < Width; width++)
                {
                    Room room = new Room();
                    int chance = rng.Next(100);
                    if(chance < 3)
                        room.Object = new Teleporter(Width, Height);
                    else if(chance < 6)
                        room.Object = new HealthPotion();
                    else if(chance < 9)
                        room.Object = new Goblin();
                    else if(chance < 12)
                        room.Object = new Ogre();
                    else if(chance < 15)
                        room.Object = new Troll();
                    else if(chance < 25)
                        room.Object = new Coin();

                    rooms[width, height] = room;
                }
            }
        }

		private bool GameContinues()
		{
			var flattenedRooms = from Room room in rooms
								 where room.Object != null && room.Object.Name == "Coin"
								 select room;
			int coinCount = flattenedRooms.Count();

			if (player.Health <= 0 || coinCount == 0)
				return false;
			return true;
		}
    }
}
