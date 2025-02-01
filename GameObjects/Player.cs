using System.Net.Security;
using Spectre.Console;
namespace GameObjects
{
    public class Player
    {
        public static bool inmainmenu = true;
        public static bool play = true;
        public static bool exit = false;
        public bool turn;
        public bool haveKey;
        public bool Victory;
        public int HeroesInCentre;
        public List<Hero> Party = new List<Hero>();
        public string name;
        public static string intname(string name, Player p)
        {

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("I dont like that name, write another one! And take this serious!");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    break;
                }
                p.name = name;
            }
            return name;
        }
        public void Greet()
        {
            Console.Write("            ✅(Valid name !!!)");
        }
        public static Hero GetPlayerChoice(List<Hero> list)
        {
            while (true)
            {
                Console.Write("Write the number of the Hero you want to choose: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int index) && index > 0 && index <= list.Count)
                {
                    if (list[index - 1].stunned > 0)
                    {
                        Console.WriteLine("\n\nYou cant play with that hero yet!");
                        continue;
                    }
                    if (list[index - 1].restturns > 0)
                    {
                        Console.WriteLine("\n\nYou cant play with that hero yet!");
                        continue;
                    }
                    return list[index - 1]; // Retorna el token elegido
                }

                Console.WriteLine("Invalid choice. Please Try Again.");
            }
        }
        public static void Roleplay1()
        {
            // var roleplay1 = new Table();
            // roleplay1.AddColumn(new TableColumn("LADY ELARA"));
            // roleplay1.AddColumn(new TableColumn(""));
            // roleplay1.AddRow("         w*W*W*W*w       ");
            // roleplay1.AddRow("          \'.'.'/        ");
            // roleplay1.AddRow("           //`\\         ");
            // roleplay1.AddRow("          (/a a\)        ");
            // roleplay1.AddRow("          (\_-_/)        ");
            // roleplay1.AddRow("         .-~'='~-.       ");
            // roleplay1.AddRow("        /`~`'Y'`~`\      ");
            // roleplay1.AddRow("       / /(_ * _)\ \     ");
            // roleplay1.AddRow("      / /  )   (  \ \    ");
            // roleplay1.AddRow("      \ \_/\\_//\_/ /    ");
            // roleplay1.AddRow("       \/_) '*' (_\/     ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("     w * W * W * W * w   ");

            // roleplay1.AddRow("", "a");
        }



        public static ConsoleKeyInfo ValidPosition(ConsoleKeyInfo action, int[,] map, Player p, Player otherp, Hero hero)
        {
            while (action.KeyChar != 'k' && action.KeyChar != 'q' && action.KeyChar != 'e' && action.KeyChar != 'w' && action.KeyChar != 'W' && action.KeyChar != 'a' && action.KeyChar != 'A' && action.KeyChar != 's' && action.KeyChar != 'S' && action.KeyChar != 'd' && action.KeyChar != 'D' && action.KeyChar != 'r' && action.KeyChar != 'R')
            {
                Console.Clear();
                Console.WriteLine("thats not a valid action)");
                Console.WriteLine("\n\n\n");
                Menu.KeyToContinue();
                Console.Clear();
                action = GetAction(map, p, otherp, hero);

                if (action.KeyChar == 'k' || action.KeyChar == 'w' || action.KeyChar == 'W' || action.KeyChar == 'a' || action.KeyChar == 'A' || action.KeyChar == 's' || action.KeyChar == 'S' || action.KeyChar == 'd' || action.KeyChar == 'D')
                {
                    break;
                }
            }
            return action;
        }
        public static ConsoleKeyInfo GetAction(int[,] map, Player p, Player otherp, Hero hero)
        {
            Console.Clear();
            var table = new Table();

            var w = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("W ⬆  ").Centered());

            var q = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.SkyBlue3)
            .AddColumn(new TableColumn("Q 👢[bold red]↙[/]"));

            var e = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.SkyBlue3)
            .AddColumn(new TableColumn("E 👢[bold green]↗[/]"));

            var a = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("A ⬅  ").Centered());

            var s = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("S ⬇  ").Centered());

            var d = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("D ➡  ").Centered());

            var r = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.Red)
            .AddColumn(new TableColumn("R > Super Power! ").Centered());

            var actionsleft = new Table()
            .NoBorder();

            if (p.haveKey == false && otherp.haveKey == false)
            {
                int Distance = Maze.DistanceFromKey(hero, Maze.KeyLocation[0], Maze.KeyLocation[1], Maze.size);


                var NearKey = new BarChart()
                .Label("Key Distance");

                if (Distance == 1)
                {
                    NearKey.Width(10);
                    NearKey.AddItem("Block(s)", Distance, Color.Red3);
                }
                else if (Distance == 2)
                {
                    NearKey.Width(20);
                    NearKey.AddItem("Block(s)", Distance, Color.Red1);
                }
                else if (Distance == 3)
                {
                    NearKey.Width(30);
                    NearKey.AddItem("Block(s)", Distance, Color.OrangeRed1);
                }
                else if (Distance == 4)
                {
                    NearKey.Width(30);
                    NearKey.AddItem("Block(s)", Distance, Color.Orange3);
                }
                else if (Distance == 5)
                {
                    NearKey.Width(30);
                    NearKey.AddItem("Block(s)", Distance, Color.Orange1);
                }
                else if (Distance == 6)
                {
                    NearKey.Width(30);
                    NearKey.AddItem("Block(s)", Distance, Color.Yellow2);
                }
                else if (Distance == 7)
                {
                    NearKey.Width(30);
                    NearKey.AddItem("Block(s)", Distance, Color.Yellow3_1);
                }
                else if (Distance == 8)
                {
                    NearKey.Width(30);
                    NearKey.AddItem("Block(s)", Distance, Color.Yellow);
                }
                else if (Distance == 9)
                {
                    NearKey.Width(30);
                    NearKey.AddItem("Block(s)", Distance, Color.LightYellow3);
                }
                else if (Distance >= 10)
                {
                    NearKey.Width(30);
                    NearKey.AddItem("Block(s)", Distance, Color.White);
                }



                actionsleft.AddColumn(new TableColumn(NearKey).Centered());
            }
            if (hero.maxspeed == 1)
            {
                table.AddColumn(new TableColumn("").Centered()).NoBorder();
                table.AddColumn(new TableColumn(w).Centered()).NoBorder();
                table.AddColumn(new TableColumn("").Centered()).NoBorder();
                table.AddColumn(new TableColumn(r).Centered()).NoBorder();

                table.AddRow(a.Centered(), s.Centered(), d.Centered(), actionsleft.Centered());
                Maze.PrintMaze2(map, $" {p.name}'s Turn!!!    {hero.actionsRemaining} Actions Remaining     ", table, hero);
            }
            else
            {
                table.AddColumn(new TableColumn(q).Centered()).NoBorder();
                table.AddColumn(new TableColumn(w).Centered()).NoBorder();
                table.AddColumn(new TableColumn(e).Centered()).NoBorder();
                table.AddColumn(new TableColumn(r).Centered()).NoBorder();

                table.AddRow(a.Centered(), s.Centered(), d.Centered(), actionsleft.Centered());
                Maze.PrintMaze2(map, $" {p.name}'s Turn!!!    {hero.actionsRemaining} Actions Remaining     ", table, hero);
            }
            ConsoleKeyInfo action = Console.ReadKey(true);
            action = ValidPosition(action, map, p, otherp, hero);
            return action;
        }
        public static void PassTurn(int[,] map, string name, Hero hero)
        {
            Console.Clear();
            var table = new Table()
            .BorderColor(Color.Red);
            // table.AddColumn(new TableColumn($"{name} Has moved {hero.name} to [  {hero.location[0]}  ,  {hero.location[1]}  ] ").Centered());
            table.AddColumn(new TableColumn("Press a key to finish your turn").Centered());
            table.Centered();
            Maze.PrintMaze2(map, $" {name}'s Turn!!!         ", table, hero);
            Console.ReadKey(true);
        }
        public static void Play(ConsoleKeyInfo action, Hero hero, Player player, Player otherplayer, int[,] map, List<Trap> Traps, List<Box> Boxes)
        {
            while (true)
            {
                ///break whiletrue
                if (hero.actionsRemaining == 0)
                {
                    hero.actionsRemaining = 5;
                    break;
                }
                ///break whiletrue
                if (hero.health == 0)
                {
                    hero.actionsRemaining = 5;
                    break;
                }
                // PRESSED W
                if (action.KeyChar == 'w' || action.KeyChar == 'W')
                {
                    hero.moveup(hero, player, otherplayer, map);
                }
                ///PRESSED A
                else if (action.KeyChar == 'a' || action.KeyChar == 'A')
                {
                    hero.moveleft(hero, player, otherplayer, map);
                }
                /// PRESSED S
                else if (action.KeyChar == 's' || action.KeyChar == 'S')
                {
                    hero.movedown(hero, player, otherplayer, map);
                }
                /// PRESED D
                else if (action.KeyChar == 'd' || action.KeyChar == 'D')
                {
                    hero.moveright(hero, player, otherplayer, map);
                }

                ///// HACK FOR TESTNG
                else if (action.KeyChar == 'k')
                {
                    hero.maxspeed++;
                    hero.speed++;
                    hero.mana++;
                    Menu.WriteTable($"[red]hacked speed[/] [bold yellow]x{hero.speed}/{hero.maxspeed}[/]");
                    Menu.KeyToContinue();
                }
                else if (action.KeyChar == 'q')
                {
                    if (hero.speed > 1)
                    {
                        hero.speed--;
                    }

                }
                else if (action.KeyChar == 'e')
                {
                    if (hero.speed >= 1 && hero.speed < hero.maxspeed)
                    {
                        hero.speed++;
                    }

                }
                else if (action.KeyChar == 'r' || action.KeyChar == 'R')
                {
                    if (hero.mana >= hero.cooldown)
                    {
                        hero.mana = hero.mana - hero.cooldown;
                        Console.Clear();
                        Menu.WriteTable("\n[bold #d480ff] Activating the Super of [/][bold #80d1ff]" + hero.name + "[/] [bold #d480ff] ![/]\n");
                        Menu.KeyToContinue();
                        hero.CastSpell(map, player, otherplayer);
                        
                        hero.actionsRemaining--;
                    }
                    else
                    {
                        Console.Clear();
                        Menu.HeroDialogue(hero, "I cant do that yet, I need at least " + hero.cooldown + " points of mana to use my power!");
                        Menu.KeyToContinue();
                        action = GetAction(map, player, otherplayer, hero);
                        continue;
                    }

                }
                if (hero.trapped == true)
                {
                    Random randomTrap = new Random();
                    int index = randomTrap.Next(Traps.Count);
                    Console.Clear();
                    Menu.WriteTable("\n[yellow bold]OHHH NO!! YOU HAVE FALL INTO A[/][red bold] TRAP[/][yellow bold] ![/]\n");
                    Menu.KeyToContinue();
                    Traps[index].CastTrap(hero, map);
                    hero.trapped = false;
                }
                if (hero.inbox == true)
                {
                    Random randomBox = new Random();
                    int index = randomBox.Next(Boxes.Count);
                    Console.Clear();
                    Boxes[index].CastBox(hero, map);
                    hero.inbox = false;
                }
                ////check if there are actions remaining 
                if (hero.actionsRemaining > 0)
                {
                    action = GetAction(map, player, otherplayer, hero);
                    continue;
                }
            }
        }
    }
}