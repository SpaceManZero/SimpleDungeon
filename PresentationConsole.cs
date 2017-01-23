using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfLexicon
{
    class PresentationConsole : Presentation
    {
        public int Height { get; set; }
        public int Width { get; set; }

        enum Symbols
        {
            //EmptyRoom = 0x2591,
            EmptyRoom = ' ',
            Player = 0x263A,
            Ogre = 0x263B,
            Troll = 0x0398,
            Goblin = 0x2660,
            Splat = 0x263C,
            Teleporter = 0x00AB,
            HealthPotion = 0x2665,
            Coin = '$'
        }

        enum Colors
        {
            Background = ConsoleColor.White,
            BackgroundStats = ConsoleColor.Gray,
            Foreground = ConsoleColor.Black,
            EmptyRoom = ConsoleColor.White,
            Player = ConsoleColor.Blue,
            Ogre = ConsoleColor.Black,
            Troll = ConsoleColor.DarkMagenta,
            Goblin = ConsoleColor.DarkGreen,
            Splat = ConsoleColor.Red,
            Teleporter = ConsoleColor.Gray,
            HealthPotion = ConsoleColor.Red,
            Coin = ConsoleColor.DarkYellow
        }

        public PresentationConsole(int height, int width)
        {
            Height = height;
            Width = width;

            Console.OutputEncoding = new UTF8Encoding();
            Console.CursorVisible = false;
            //Console.WindowWidth = Width * 3;
            //Console.WindowHeight = Height * 2;
            //Console.BufferWidth = Width * 5;
            //Console.BufferHeight = Height * 3;
			Console.WindowWidth = Width * 2 + 1;
			Console.WindowHeight = Height * 2;
			Console.BufferWidth = Width * 2 + 1;
			Console.BufferHeight = Height * 2;
		}

        public override void DisplayWorld(Player player, Room[,] rooms)
        {
            Console.SetCursorPosition(0, 0);
            for (int height = 0; height < Height; height++)
            {
                for (int width = 0; width < Width; width++)
                {
                    Console.BackgroundColor = (ConsoleColor)Colors.Background;
                    Console.ForegroundColor = (ConsoleColor)Colors.Foreground;

                    if (height == player.Y && width == player.X)
                    {
                        Console.ForegroundColor = (ConsoleColor)Colors.Player;
                        Console.Write((char)Symbols.Player);
                    }
                    else if (rooms[width, height].Object != null)
                    {
                        string content = rooms[width, height].Object.GetType().Name;
                        ConsoleColor symbolColor;
                        char symbol;
                        switch (content)
                        {
                            case "Teleporter":
                                symbolColor = (ConsoleColor)Colors.Teleporter;
                                symbol = (char)Symbols.Teleporter;
                                break;
                            case "HealthPotion":
                                symbolColor = (ConsoleColor)Colors.HealthPotion;
                                symbol = (char)Symbols.HealthPotion;
                                break;
                            case "Goblin":
                                symbolColor = (ConsoleColor)Colors.Goblin;
                                symbol = (char)Symbols.Goblin;
                                break;
                            case "Ogre":
                                symbolColor = (ConsoleColor)Colors.Ogre;
                                symbol = (char)Symbols.Ogre;
                                break;
                            case "Troll":
                                symbolColor = (ConsoleColor)Colors.Troll;
                                symbol = (char)Symbols.Troll;
                                break;
                            case "Splat":
                                symbolColor = (ConsoleColor)Colors.Splat;
                                symbol = (char)Symbols.Splat;
                                break;
                            case "Coin":
                                symbolColor = (ConsoleColor)Colors.Coin;
                                symbol = (char)Symbols.Coin;
                                break;
                            default:
                                symbolColor = (ConsoleColor)Colors.EmptyRoom;
                                symbol = (char)Symbols.EmptyRoom;
                                break;
                        }
                        Console.ForegroundColor = symbolColor;
                        Console.Write(symbol);
                        Console.ForegroundColor = (ConsoleColor)Colors.Foreground;
                    }
                    else
                    {
                        Console.Write((char)Symbols.EmptyRoom);
                    }
                    Console.Write((char)Symbols.EmptyRoom);
                }
                // End of row
                Console.Write(Environment.NewLine);    // New Line
            }
            Console.ResetColor();
        }

        public override void DisplayStats(Player player, Room room)
        {
            Console.BackgroundColor = (ConsoleColor)Colors.BackgroundStats;
            Console.ForegroundColor = ConsoleColor.Black;
            int RowOne = Height;
            int RowTwo = Height + 1;
            int RowThree = Height + 2;
            //Console.SetCursorPosition(0, Height + 1);
            //for (int column = 0; column < Width * 2; column++)
            //    Console.Write((char)0x2588);

            // Display column 1 (player)
            Console.SetCursorPosition(0, RowOne);
            Console.Write($"{player.Name}".PadRight(Width, ' '));
            Console.SetCursorPosition(0, RowTwo);
            Console.Write($"Health: {player.Health}".PadRight(Width, ' '));
            Console.SetCursorPosition(0, RowThree);
            Console.Write($"Backpack: {player.Backpack.Count(i => i.Name == "Coin")} Coins".PadRight(Width*2, ' '));

            // Display column 2 (monsters and items)
            Console.SetCursorPosition(Width, RowOne);
            GameObject content = room.Object;
            if (content != null)
            {
                Console.Write(content.GetType().Name.PadRight(Width, ' '));
                Console.SetCursorPosition(Width, RowTwo);
                if (content.GetType().BaseType == typeof(Monster))
                {
                    Console.Write($"{(content as Monster).Health}".PadRight(Width, ' '));
                }
                else
                    Console.Write("".PadRight(Width, ' '));
            }
            else
            {
                Console.Write("".PadRight(Width, ' '));
                Console.SetCursorPosition(Width, RowTwo);
                Console.Write("".PadRight(Width, ' '));
            }

            Console.ResetColor();
        }

        public override void ManageInput(Player player, Room[,] rooms)
        {
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.DownArrow:
                    player.Y = Math.Min(Height - 1, player.Y + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    player.X = Math.Max(0, player.X - 1);
                    break;
                case ConsoleKey.RightArrow:
                    player.X = Math.Min(Width - 1, player.X + 1);
                    break;
                case ConsoleKey.UpArrow:
                    player.Y = Math.Max(0, player.Y - 1);
                    break;
                case ConsoleKey.Escape:
                    player.Health = 0;
                    break;
                case ConsoleKey.Spacebar:
                    break;
                default:
                    break;
            }
        }

        public override bool HandleEncounter(Player player, Room room)
        {
            bool callAgain = false;

            if (room.Object != null)
            {
                int x = player.X;
                int y = player.Y;
                if (room.Object.GetType().BaseType == typeof(Monster))
                {
                    player.Fight(room.Object as Monster);
                    if ((room.Object as Monster).Health <= 0)
                        room.Object = new Splat();
                    else
                        (room.Object as Monster).Fight(player);
                }
                else if (room.Object.GetType().BaseType == typeof(Item))
                {
                    if (room.Object.GetType() == typeof(Teleporter))
                        callAgain = true;
                    room.Object.PickUp(player);
                    room.Object = null;
                }
            }
            return callAgain;
        }
    }
}
