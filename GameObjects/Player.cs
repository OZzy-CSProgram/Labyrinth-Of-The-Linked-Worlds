using System.Net.Security;
using Spectre.Console;
namespace GameObjects
{
    public class Player
    {
        public static bool play = true;
        public static bool exit = false;
        public bool turn;
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



        public static ConsoleKeyInfo ValidPosition(ConsoleKeyInfo action, int[,] map, Player p, Hero hero)
        {
            while (action.KeyChar != 'w' && action.KeyChar != 'W' && action.KeyChar != 'a' && action.KeyChar != 'A' && action.KeyChar != 's' && action.KeyChar != 'S' && action.KeyChar != 'd' && action.KeyChar != 'D' && action.KeyChar != 'r' && action.KeyChar != 'R')
            {
                Console.Clear();
                Console.WriteLine("thats not a valid action)");
                Console.WriteLine("\n\n\n");
                Menu.KeyToContinue();
                Console.Clear();
                action = GetAction(map, p, hero);

                if (action.KeyChar == 'w' || action.KeyChar == 'W' || action.KeyChar == 'a' || action.KeyChar == 'A' || action.KeyChar == 's' || action.KeyChar == 'S' || action.KeyChar == 'd' || action.KeyChar == 'D')
                {
                    break;
                }
            }
            return action;
        }
        public static ConsoleKeyInfo GetAction(int[,] map, Player p, Hero hero)
        {
            Console.Clear();
            var table = new Table();

            var w = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("W ⬆ ").Centered());

            var a = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("A ⬅ ").Centered());

            var s = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("S ⬇ ").Centered());

            var d = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("D ➡ ").Centered());

            var r = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.Red)
            .AddColumn(new TableColumn("R > Super Power! ").Centered());

            int Distance = Maze.DistanceFromKey(hero, Maze.size / 2 + 2, Maze.size / 2 + 1, Maze.size);


            var NearKey = new BarChart()
            .Label("[yellow bold]" + hero.actionsRemaining + " actions left\n[/]");

            if (Distance == 1)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.Red3);
            }
            else if (Distance == 2)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.Red1);
            }
            else if (Distance == 3)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.OrangeRed1);
            }
            else if (Distance == 4)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.Orange3);
            }
            else if (Distance == 5)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.Orange1);
            }
            else if (Distance == 6)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.Yellow2);
            }
            else if (Distance == 7)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.Yellow3_1);
            }
            else if (Distance == 8)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.Yellow);
            }
            else if (Distance == 9)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.LightYellow3);
            }
            else if (Distance >= 10)
            {
                NearKey.Width(60);
                NearKey.AddItem("Key Distance", Distance, Color.White);
            }



            var actionsleft = new Table()
            .NoBorder()
            .AddColumn(new TableColumn(NearKey).Centered());

            table.AddColumn(new TableColumn("").Centered()).NoBorder();
            table.AddColumn(new TableColumn(w).Centered()).NoBorder();
            table.AddColumn(new TableColumn("").Centered()).NoBorder();
            table.AddColumn(new TableColumn(r).Centered()).NoBorder();

            table.AddRow(a.Centered(), s.Centered(), d.Centered(), actionsleft.Centered());
            Maze.PrintMaze2(map, $" {p.name}'s Turn!!!    {hero.actionsRemaining} Actions Remaining     ", table, hero);
            ConsoleKeyInfo action = Console.ReadKey(true);
            action = ValidPosition(action, map, p, hero);
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
        public static void Play(ConsoleKeyInfo action, Hero hero, Player player, Player otherplayer, int[,] map, List<Trap> Traps)
        {
            while (true)
            {
                ///break whiletrue
                if (hero.actionsRemaining == 0)
                {
                    hero.actionsRemaining = 5;
                    break;
                }
                if (action.KeyChar == 'w' || action.KeyChar == 'W')
                {
                    if (map[hero.location[0] - 1, hero.location[1]] == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You can't move in that direction mate! :/");
                        Console.WriteLine("\n\n\n");
                        Menu.KeyToContinue();
                        action = GetAction(map, player, hero);
                        continue;

                    }
                    else if (map[hero.location[0] - 1, hero.location[1]] == 3)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        // Make Trap Position equals 0
                        map[hero.location[0] - 1, hero.location[1]] = 0;
                        //execute move method, in case the trap does not affect your position
                        hero.moveup(hero.location, map);
                        //change the value in the map of the new position so the hero is displayed there
                        map[hero.location[0], hero.location[1]] = hero.id;

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.trapped = true;
                        hero.actionsRemaining--;

                    }
                    ///moving to a Door
                    else if (map[hero.location[0] - 1, hero.location[1]] == 6)
                    {
                        if (hero.haveKey)
                        {
                            Console.WriteLine("Do you want to use the key to open the door?\n\nWrite 'yes' to accept or 'no' to cancel");
                            string choosing = Console.ReadLine().ToLower();
                            if (choosing == "yes")
                            {
                                Console.WriteLine($"{hero.name} has open the gates of the Chamber Of The Heart of Ebony.");
                                map[hero.location[0] - 1, hero.location[1]] = 0;
                            }
                            else if (choosing != "yess" && choosing != "no")
                            {
                                Console.WriteLine("thats not a valid action!");
                                Console.WriteLine("\n\n\n");
                                Menu.KeyToContinue();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Menu.HeroDialogue(hero, "I need a key to open that door!");
                        }

                    }
                    else if (map[hero.location[0] - 1, hero.location[1]] == 6)
                    {
                        hero.haveKey = true;
                        Console.Clear();


                    }
                    else if (map[hero.location[0] - 1, hero.location[1]] == 4)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        //execute move method
                        hero.moveup(hero.location, map);
                        player.Party.Remove(hero);
                        player.HeroesInCentre++;
                        hero.actionsRemaining = 0;
                        break;
                    }
                    else if (map[hero.location[0] - 1, hero.location[1]] == 0)
                    {
                        map[hero.location[0], hero.location[1]] = 0;
                        hero.moveup(hero.location, map);
                        map[hero.location[0], hero.location[1]] = hero.id;
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.actionsRemaining--;
                    }
                }
                else if (action.KeyChar == 'a' || action.KeyChar == 'A')
                {
                    if (map[hero.location[0], hero.location[1] - 1] == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You can't move in that direction mate! :/");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("(press a key to continue)");
                        Console.ReadKey(true);
                        action = GetAction(map, player, hero);
                        continue;
                    }
                    else if (map[hero.location[0], hero.location[1] - 1] == 3)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        // Make Trap Position equals 0
                        map[hero.location[0], hero.location[1] - 1] = 0;
                        //execute move method, in case the trap does not affect your position
                        hero.moveleft(hero.location, map);
                        //change the value in the map of the new position so the hero is displayed there
                        map[hero.location[0], hero.location[1]] = hero.id;

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.trapped = true;
                        hero.actionsRemaining--;
                    }
                    ///moving to a Door
                    else if (map[hero.location[0], hero.location[1] - 1] == 6)
                    {
                        if (hero.haveKey)
                        {
                            Console.WriteLine("Do you want to use the key to open the door?\n\nWrite 'yes' to accept or 'no' to cancel");
                            string choosing = Console.ReadLine().ToLower();
                            if (choosing == "yes")
                            {
                                Console.WriteLine($"{hero.name} has open the gates of the Chamber Of The Heart of Ebony.");
                                map[hero.location[0], hero.location[1] - 1] = 0;
                            }
                            else if (choosing != "yess" && choosing != "no")
                            {
                                Console.WriteLine("thats not a valid action!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Menu.HeroDialogue(hero, "I need a key to open that door!");
                        }

                    }
                    else if (map[hero.location[0], hero.location[1] - 1] == 4)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        //execute move method
                        hero.moveleft(hero.location, map);
                        player.Party.Remove(hero);
                        player.HeroesInCentre++;
                        hero.actionsRemaining = 0;
                        break;
                    }
                    else if (map[hero.location[0], hero.location[1] - 1] == 0)
                    {
                        map[hero.location[0], hero.location[1]] = 0;
                        hero.moveleft(hero.location, map);
                        map[hero.location[0], hero.location[1]] = hero.id;
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.actionsRemaining--;
                    }
                }
                else if (action.KeyChar == 's' || action.KeyChar == 'S')
                {
                    if (map[hero.location[0] + 1, hero.location[1]] == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You can't move in that direction mate! :/");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("(press a key to continue)");
                        Console.ReadKey(true);
                        action = GetAction(map, player, hero);
                        continue;
                    }
                    else if (map[hero.location[0] + 1, hero.location[1]] == 3)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        // Make Trap Position equals 0
                        map[hero.location[0] + 1, hero.location[1]] = 0;
                        //execute move method, in case the trap does not affect your position
                        hero.movedown(hero.location, map);
                        //change the value in the map of the new position so the hero is displayed there
                        map[hero.location[0], hero.location[1]] = hero.id;

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.trapped = true;
                        hero.actionsRemaining--;
                    }
                    ///moving to a Door
                    else if (map[hero.location[0] + 1, hero.location[1]] == 6)
                    {
                        if (hero.haveKey)
                        {
                            Console.WriteLine("Do you want to use the key to open the door?\n\nWrite 'yes' to accept or 'no' to cancel");
                            string choosing = Console.ReadLine().ToLower();
                            if (choosing == "yes")
                            {
                                Console.WriteLine($"{hero.name} has open the gates of the Chamber Of The Heart of Ebony.");
                                map[hero.location[0] + 1, hero.location[1]] = 0;
                            }
                            else if (choosing != "yess" && choosing != "no")
                            {
                                Console.WriteLine("thats not a valid action!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Menu.HeroDialogue(hero, "I need a key to open that door!");
                        }

                    }
                    else if (map[hero.location[0] + 1, hero.location[1]] == 4)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        //execute move method
                        hero.movedown(hero.location, map);
                        player.Party.Remove(hero);
                        player.HeroesInCentre++;
                        hero.actionsRemaining = 0;
                        break;
                    }
                    else if (map[hero.location[0] + 1, hero.location[1]] == 0)
                    {
                        map[hero.location[0], hero.location[1]] = 0;
                        hero.movedown(hero.location, map);
                        map[hero.location[0], hero.location[1]] = hero.id;
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.actionsRemaining--;
                    }
                }

                else if (action.KeyChar == 'd' || action.KeyChar == 'D')
                {
                    if (map[hero.location[0], hero.location[1] + 1] == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You can't move in that direction mate! :/");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("(press a key to continue)");
                        Console.ReadKey(true);
                        action = GetAction(map, player, hero);
                        continue;
                    }
                    else if (map[hero.location[0], hero.location[1] + 1] == 3)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        // Make Trap Position equals 0
                        map[hero.location[0], hero.location[1] + 1] = 0;
                        //execute move method, in case the trap does not affect your position
                        hero.moveright(hero.location, map);
                        //change the value in the map of the new position so the hero is displayed there
                        map[hero.location[0], hero.location[1]] = hero.id;
                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.trapped = true;
                        hero.actionsRemaining--;
                    }
                    ///moving to a Door
                    else if (map[hero.location[0], hero.location[1] + 1] == 6)
                    {
                        if (hero.haveKey)
                        {
                            Console.WriteLine("Do you want to use the key to open the door?\n\nWrite 'yes' to accept or 'no' to cancel");
                            string choosing = Console.ReadLine().ToLower();
                            if (choosing == "yes")
                            {
                                Console.WriteLine($"{hero.name} has open the gates of the Chamber Of The Heart of Ebony.");
                                map[hero.location[0], hero.location[1] + 1] = 0;
                            }
                            else if (choosing != "yess" && choosing != "no")
                            {
                                Console.WriteLine("thats not a valid action!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Menu.HeroDialogue(hero, "I need a key to open that door!");
                        }

                    }
                    else if (map[hero.location[0], hero.location[1] + 1] == 4)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        //execute move method
                        hero.moveright(hero.location, map);
                        player.Party.Remove(hero);
                        player.HeroesInCentre++;
                        hero.actionsRemaining = 0;
                        break;
                    }
                    else if (map[hero.location[0], hero.location[1] + 1] == 0)
                    {
                        map[hero.location[0], hero.location[1]] = 0;
                        hero.moveright(hero.location, map);
                        map[hero.location[0], hero.location[1]] = hero.id;
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.actionsRemaining--;
                    }
                }

                else if (action.KeyChar == 'r' || action.KeyChar == 'R')
                {
                    if (hero.mana >= hero.cooldown)
                    {
                        hero.mana = hero.mana - hero.cooldown;
                        Console.Clear();
                        Console.WriteLine($"Activating the Super of {hero.name}!");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey(true);
                        hero.CastSpell(map, player, otherplayer);
                        Console.WriteLine();
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey(true);
                        hero.actionsRemaining--;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"{hero.name} >> I cant do that yet, I need at least {hero.cooldown} points of mana to use my power!");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("(press a key to continue)");
                        Console.ReadKey(true);
                        action = GetAction(map, player, hero);
                        continue;
                    }

                }
                if (hero.trapped == true)
                    {
                        Random randomTrap = new Random();
                        int index = randomTrap.Next(Traps.Count);
                        Console.Clear();
                        Console.WriteLine("OHHH NO!! YOU HAVE FALL INTO A TRAP!");
                        Console.WriteLine("");
                        Console.WriteLine("(press a key to proceed :( )");
                        Console.ReadKey(true);
                        Traps[index].CastTrap(hero, map);
                        hero.trapped = false;
                    }
                    ////check if there are actions remaining 
                    if (hero.actionsRemaining > 0)
                    {
                        action = GetAction(map, player, hero);
                        continue;
                    }
            }
        }
    }
}