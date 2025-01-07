using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using Spectre.Console;
namespace GameObjects
{
    public class Hero
    {
        ////propeties////
        public string name;
        public string info;
        public int id;
        public int health;
        public int attack;
        public int cooldown;
        public List<int[]> locationlog = new List<int[]>();
        public int[,] map;
        public int[] location = new int[2];
        /////constructor////
        public Hero(int id, string name, string info, int health, int attack, int cooldown, int[,] maze)
        {
            this.id = id;
            this.name = name;
            this.info = info;
            this.health = health;
            this.attack = attack;
            this.cooldown = cooldown;
            this.map = maze;

        }
        /////methods/////
        public int[] moveright(int[] location, int[,] Maze)
        {
            location[1]++;
            return location;
        }
        public int[] moveleft(int[] location, int[,] Maze)
        {
            location[1]--;
            return location;
        }
        public int[] moveup(int[] location, int[,] Maze)
        {

            location[0]--;
            return location;
        }
        public int[] movedown(int[] location, int[,] Maze)
        {
            location[0]++;
            return location;
        }
        public static void DisplayList(List<Hero> list, string s)
        {
            var table = new Table();
            table.AddColumn(new TableColumn(s).Centered());
            table.AddRow("");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < list.Count; i++)
            {
                var table1 = new Table();
                table1.AddColumn("Heroe number " + (i + 1) + " >>>   " + list[i].name);
                table1.AddRow(" 📜 Info      >  " + list[i].info);
                table1.AddRow(" 💗 Health    >  " + list[i].health);
                table1.AddRow(" 🔪 Attack   >  " + list[i].attack);
                table1.AddRow(" 💠 Cooldown >  " + list[i].cooldown);
                table.AddRow(table1);
                table1.BorderColor(Color.DarkGoldenrod);
            }
            table.AddRow("");
            table.BorderColor(Color.SlateBlue1);
            AnsiConsole.Write(table);
        }
        public static void FallInTrap(Hero hero, int[,] map)
        {
            Console.Clear();
            Console.WriteLine("Upppss!! It seems like you have fell in a trap");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("(press a key to proceed)");
            Console.ReadKey(true);
            Console.Clear();
        }

        public virtual void CastSpell(int[,] map)
        {
            Console.WriteLine("Casting Spell");
        }
        public static int[] GetADirection(int[,] map)
        {
            // public ConsoleKeyInfo ValidDirection(ConsoleKeyInfo action);
            {
                ConsoleKeyInfo Direction;
                int[] arr = new int[2];
                while (true)
                {
                    Console.WriteLine("                  ╔════════════════════╗                   ");
                    Console.WriteLine("                  ║   W > Break above  ║                   ");
                    Console.WriteLine("                  ╚════════════════════╝                   ");
                    Console.WriteLine("╔══════════════════╦══════════════════╦═══════════════════╗");
                    Console.WriteLine("║   A > Break left ║  S > Break below ║  D > Break right  ║");
                    Console.WriteLine("╚══════════════════╩══════════════════╩═══════════════════╝");
                    Direction = Console.ReadKey(true);

                    while (Direction.KeyChar != 'w' && Direction.KeyChar != 'W' && Direction.KeyChar != 'a' && Direction.KeyChar != 'A' && Direction.KeyChar != 's' && Direction.KeyChar != 'S' && Direction.KeyChar != 'd' && Direction.KeyChar != 'D' && Direction.KeyChar != 'r' && Direction.KeyChar != 'R')
                    {
                        Console.Clear();

                        Console.WriteLine("thats not a valid Direction)");
                        Console.WriteLine("(press a key to continue)");
                        Console.ReadKey(true);

                        Console.Clear();
                        Maze.PrintMaze(map, "Select A valid Direction !");
                        Console.WriteLine("                  ╔════════════════════╗                   ");
                        Console.WriteLine("                  ║   W > Break above  ║                   ");
                        Console.WriteLine("                  ╚════════════════════╝                   ");
                        Console.WriteLine("╔══════════════════╦══════════════════╦═══════════════════╗");
                        Console.WriteLine("║   A > Break left ║  S > Break below ║  D > Break right  ║");
                        Console.WriteLine("╚══════════════════╩══════════════════╩═══════════════════╝");
                        Direction = Console.ReadKey(true);

                        if (Direction.KeyChar == 'w' || Direction.KeyChar == 'W' || Direction.KeyChar == 'a' || Direction.KeyChar == 'A' || Direction.KeyChar == 's' || Direction.KeyChar == 'S' || Direction.KeyChar == 'd' || Direction.KeyChar == 'D')
                        {
                            break;
                        }
                    }
                    break;
                }
                if (Direction.KeyChar == 'w' || Direction.KeyChar == 'W')
                {
                    arr[0] = -1;
                    arr[1] = 0;
                    return arr;
                }
                else if (Direction.KeyChar == 's' || Direction.KeyChar == 'S')
                {
                    arr[0] = 1;
                    arr[1] = 0;
                    return arr;
                }
                else if (Direction.KeyChar == 'a' || Direction.KeyChar == 'A')
                {
                    arr[0] = 0;
                    arr[1] = -1;
                    return arr;

                }
                else if (Direction.KeyChar == 'd' || Direction.KeyChar == 'D')
                {
                    arr[0] = 0;
                    arr[1] = 1;
                    return arr;
                }
                return arr;
            }
        }
    }


    public class Teleporter : Hero
    {
        //Constructor for Teleporter//
        public Teleporter(int id, string name, string info, int health, int attack, int cooldown, int[,] maze) : base(id, name, info, health, attack, cooldown, maze)
        //Call to base constructor
        {
        }
        public override void CastSpell(int[,] map)
        {
            Console.Clear();
            Console.WriteLine(name + " >> Thou cannot reach my magic! .... Teleporting");
            int[] receptor = Maze.GetRandomPath();
            map[location[0], location[1]] = 0;
            while (receptor[0] == location[0] && receptor[1] == location[1])
            {
                receptor = Maze.GetRandomPath();
            }
            location[0] = receptor[0];
            location[1] = receptor[1];
            map[location[0], location[1]] = id;
            Console.WriteLine();
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine($"{name} has Teleported to  [  {location[0]}  ,  {location[1]}  ]");
        }
    }
    public class Traveler : Hero
    {
        //Constructor for Teleporter//
        public Traveler(int id, string name, string info, int health, int attack, int cooldown, int[,] maze) : base(id, name, info, health, attack, cooldown, maze)
        //Call to base constructor
        {
        }
        public override void CastSpell(int[,] map)
        {
            Console.Clear();
            Console.WriteLine(name + " >> Thou cannot reach my magic! .... Teleporting");
            int[] receptor = Maze.GetRandomPath();
            map[location[0], location[1]] = 0;
            while (receptor[0] == location[0] && receptor[1] == location[1])
            {
                receptor = Maze.GetRandomPath();
            }
            location[0] = receptor[0];
            location[1] = receptor[1];
            map[location[0], location[1]] = id;
            Console.WriteLine();
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine($"{name} has Teleported to  [  {location[0]}  ,  {location[1]}  ]");
        }
    }
    public class Jumper : Hero
    {
        //Constructor for Teleporter//
        public Jumper(int id, string name, string info, int health, int attack, int cooldown, int[,] maze) : base(id, name, info, health, attack, cooldown, maze)
        //Call to base constructor
        {
        }
        public override void CastSpell(int[,] map)
        {
            Console.Clear();
            Console.WriteLine(name + " >> Nobody can jump like I can! .... Ahahahaha");
            Console.WriteLine();
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey(true);

            Console.Clear();
            Maze.PrintMaze(map, "What direction should I you want to jump?");

            map[location[0], location[1]] = 0;
            int[] Dir = Hero.GetADirection(map);

            if (map[location[0] + Dir[0], location[1] + Dir[1]] != 1)
            {
                if (map[location[0] + Dir[0] + Dir[0], location[1] + Dir[1] + Dir[1]] != 1)
                {
                    if (map[location[0] + Dir[0] + Dir[0] + Dir[0], location[1] + Dir[1] + Dir[1] + Dir[1]] != 1)
                    {
                        location[0] = location[0] + Dir[0] + Dir[0] + Dir[0];
                        location[1] = location[1] + Dir[1] + Dir[1] + Dir[1];
                        map[location[0], location[1]] = id;
                        Console.Clear();
                        Maze.PrintMaze(map, "Super Activated successfully!");
                        Console.WriteLine($"{name} >> It's amazing!, my jump reached the maximum distance :D");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        location[0] = location[0] + Dir[0] + Dir[0];
                        location[1] = location[1] + Dir[1] + Dir[1];
                        map[location[0], location[1]] = id;
                        Console.Clear();
                        Maze.PrintMaze(map, "Super Activated successfully!");
                        Console.WriteLine($"{name} >> I could have jumped a higher distance but my jump was interruped due to an obstacle :(");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    location[0] = location[0] + Dir[0];
                    location[1] = location[1] + Dir[1];
                    map[location[0], location[1]] = id;
                    Console.Clear();
                    Maze.PrintMaze(map, "Super Activated successfully!");
                    Console.WriteLine($"{name} >> I could have jumped a higher distance but my jump was interruped due to an obstacle :(");
                    Console.WriteLine();
                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey(true);
                }
            }
            map[location[0], location[1]] = id;
        }
    }
    public class WallBreaker : Hero
    {
        //Constructor for WallBreaker//
        public WallBreaker(int id, string name, string info, int health, int attack, int cooldown, int[,] maze) : base(id, name, info, health, attack, cooldown, maze)//Call to base constructor
        {
        }
        public override void CastSpell(int[,] map)
        {
            // Console.WriteLine(Name + "The bigger the wall is, the easier it falls down :D");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Which wall would you like " + name + " to destroy");
                Console.WriteLine("                  ╔════════════════════╗                   ");
                Console.WriteLine("                  ║   W > Break above  ║                   ");
                Console.WriteLine("                  ╚════════════════════╝                   ");
                Console.WriteLine("╔══════════════════╦══════════════════╦═══════════════════╗");
                Console.WriteLine("║   A > Break left ║  S > Break below ║  D > Break right  ║");
                Console.WriteLine("╚══════════════════╩══════════════════╩═══════════════════╝");
                ConsoleKeyInfo Direction = Console.ReadKey(true);
                while (Direction.KeyChar != 'w' && Direction.KeyChar != 'W' && Direction.KeyChar != 'a' && Direction.KeyChar != 'A' && Direction.KeyChar != 's' && Direction.KeyChar != 'S' && Direction.KeyChar != 'd' && Direction.KeyChar != 'D' && Direction.KeyChar != 'r' && Direction.KeyChar != 'R')
                {
                    Console.Clear();

                    Console.WriteLine("thats not a valid Direction)");
                    Console.WriteLine("(press a key to continue)");
                    Console.ReadKey(true);

                    Console.Clear();
                    Console.WriteLine("Which wall would you like " + name + " to destroy");
                    Console.WriteLine("                  ╔════════════════════╗                   ");
                    Console.WriteLine("                  ║   W > Break above  ║                   ");
                    Console.WriteLine("                  ╚════════════════════╝                   ");
                    Console.WriteLine("╔══════════════════╦══════════════════╦═══════════════════╗");
                    Console.WriteLine("║   A > Break left ║  S > Break below ║  D > Break right  ║");
                    Console.WriteLine("╚══════════════════╩══════════════════╩═══════════════════╝");
                    Direction = Console.ReadKey(true);

                    if (Direction.KeyChar == 'w' || Direction.KeyChar == 'W' || Direction.KeyChar == 'a' || Direction.KeyChar == 'A' || Direction.KeyChar == 's' || Direction.KeyChar == 'S' || Direction.KeyChar == 'd' || Direction.KeyChar == 'D')
                    {
                        break;
                    }
                }

                if (Direction.KeyChar == 'w' || Direction.KeyChar == 'W')
                {
                    if (!HandleWallBreaking(-1, 0, map))
                        continue;
                }
                else if (Direction.KeyChar == 's' || Direction.KeyChar == 'S')
                {
                    if (!HandleWallBreaking(1, 0, map))
                        continue;
                }
                else if (Direction.KeyChar == 'a' || Direction.KeyChar == 'A')
                {
                    if (!HandleWallBreaking(0, -1, map))
                        continue;
                }
                else if (Direction.KeyChar == 'd' || Direction.KeyChar == 'D')
                {
                    if (!HandleWallBreaking(0, 1, map))
                        continue;
                }
                break;
            }
        }
        private bool HandleWallBreaking(int dirRow, int dirCol, int[,] map)
        {
            if (location[0] + dirRow == 0 || location[0] + dirRow == Maze.size - 1 || location[1] + dirCol == 0 || location[1] + dirCol == Maze.size - 1)
            {
                Console.Clear();
                Console.WriteLine("You can not break in that Direction, Thats the edge of the map!");
                Console.WriteLine();
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey();
                return false;
            }
            if (map[location[0] + dirRow, location[1] + dirCol] != 1)
            {
                Console.Clear();
                Console.WriteLine("There is no wall there mate, was your head on the clouds?!");
                Console.WriteLine();
                Console.WriteLine("Press a key to continue...");
                System.Console.ReadKey();
                return false;
            }
            map[location[0] + dirRow, location[1] + dirCol] = 0;
            Maze.FreePath.Add(new int[] { location[0] + dirRow, location[1] + dirCol });
            return true;
        }
        private void BreakWall(int row, int col)
        {
            map[row, col] = 0;

        }
    }
}
