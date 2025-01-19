using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Transactions;
using Spectre.Console;
namespace GameObjects
{
    public class Hero
    {
        ////propeties////
        public string name;
        public string info;
        public int id;

        public string icon;
        public int health;
        public int attack;
        public int mana;

        public bool haveKey;

        public bool trapped = false;
        public int stunned = 0;
        public int toughness;
        public int cooldown;

        public int actionsRemaining = 5;
        public List<int[]> locationlog = new List<int[]>();
        public int[,] map;
        public int[] location = new int[2];
        /////constructor////
        public Hero(int id, string icon, string name, string info, int health, int attack, int mana, int cooldown, int[,] maze)
        {
            this.id = id;
            this.icon = icon;
            this.name = name;
            this.info = info;
            this.health = health;
            this.attack = attack;
            this.mana = mana;
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
                table1.AddColumn("[bold #ff7400] " + (i + 1) + "[/][yellow] >>[/]  [black]  " + list[i].icon + " [/] [bold]" + list[i].name + "[/]  ");
                table1.AddRow(" 📜 [bold]Info  [/]   >  " + list[i].info);
                table1.AddRow(" 💗 [bold]Health[/]    >  " + list[i].health);
                table1.AddRow(" 💙 [bold] Max Mana[/] >  20");
                table1.AddRow(" 🔪 [bold]Attack[/]   >  " + list[i].attack);
                table1.AddRow(" 💠 [bold]Super Requirements[/] > Mana " + list[i].cooldown + "💙");
                table.AddRow(table1);
                table1.BorderColor(Color.DarkGoldenrod);
            }
            table.AddRow("");
            table.BorderColor(Color.SlateBlue1);
            table.Centered();
            AnsiConsole.Write(table);
        }
        public static void DisplayList2(List<Hero> list, string s, int[,] map)
        {
            var print = new Table();
            var table = new Table();
            table.AddColumn(new TableColumn(s).Centered());
            table.AddRow("");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < list.Count; i++)
            {
                var stats = new BarChart()
                .Width(60)
                .AddItem("💗 [bold #e9e9e9]Health[/]", list[i].health, Color.DarkRed)
                .AddItem("💙 [bold #e9e9e9]Mana[/]", list[i].mana, Color.DarkBlue);


                if (list[i].stunned > 0)
                {
                    var table1 = new Table();
                    table1.AddColumn("[bold #fbd022] " + (i + 1) + "[/][#783806] >>[/]  [black] " + list[i].icon + "[/] [bold]" + list[i].name + "[/]       [bold red]MUST WAIT " + list[i].stunned + " TURN(S)[/]");
                    table1.AddRow(" 📜 [bold #e9e9e9]Info  [/]   >  [#f9d380]" + list[i].info + "[/]");
                    table1.AddRow(stats);
                    table1.AddRow(" 🔪 [bold #e9e9e9]Attack[/]   >  " + list[i].attack);
                    table1.AddRow(" 💠 [bold #e9e9e9]Super Requires[/] > Mana " + list[i].cooldown + "💙");
                    table.AddRow(table1);
                    table1.BorderColor(Color.Red);
                }
                if (list[i].health == 0)
                {
                    list[i].stunned = 10;
                    list[i].health = 6;
                    var table1 = new Table();
                    table1.AddColumn("[bold #fbd022] " + (i + 1) + "[/][#783806] >>[/]  [black] " + list[i].icon + "[/][bold] " + list[i].name + "[/] [bold red]RECOVERING, WAIT " + list[i].stunned + " TURN(S)[/]");
                    table1.AddRow(" 📜 [bold #e9e9e9]Info  [/]   >  [#f9d380]" + list[i].info + "[/]");
                    table1.AddRow(stats);
                    table1.AddRow(" 🔪 [bold #e9e9e9]Attack[/]   >  " + list[i].attack);
                    table1.AddRow(" 💠 [bold #e9e9e9]Super Requires[/] > Mana " + list[i].cooldown + "💙");
                    table.AddRow(table1);
                    table1.BorderColor(Color.Red);
                }
                if (list[i].stunned <= 0 && list[i].health > 0)
                {
                    var table1 = new Table();
                    table1.AddColumn("[bold #fbd022] " + (i + 1) + "[/][#783806] >>[/]  [black] " + list[i].icon + "[/][bold] " + list[i].name + "[/]");
                    table1.AddRow(" 📜 [bold #e9e9e9]Info  [/]   >  [#f9d380]" + list[i].info + "[/]");
                    table1.AddRow(stats);
                    table1.AddRow(" 🔪 [bold #e9e9e9]Attack[/]   >  " + list[i].attack);
                    table1.AddRow(" 💠 [bold #e9e9e9]Super Requires[/] > Mana " + list[i].cooldown + "💙");
                    table.AddRow(table1);
                    table1.BorderColor(Color.Yellow);
                }
            }
            table.AddRow("");
            table.BorderColor(Color.SlateBlue1);
            print.AddColumn(new TableColumn("")).HideHeaders();
            print.AddColumn(new TableColumn("")).HideHeaders();
            print.AddRow(Maze.PrintMaze(map, " MAP "), table);
            AnsiConsole.Write(print);
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

        public virtual void CastSpell(int[,] map, Player player, Player otherplayer)
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
                    Console.Clear();
                    var table = new Table()
                    .NoBorder();
                    var w = new Table()
                    .Border(TableBorder.Double)
                    .BorderColor(Color.SandyBrown)
                    .AddColumn(new TableColumn("W ⬆ above").Centered());

                    var a = new Table()
                    .Border(TableBorder.Double)
                    .BorderColor(Color.SandyBrown)
                    .AddColumn(new TableColumn("A ⬅ left").Centered());

                    var s = new Table()
                    .Border(TableBorder.Double)
                    .BorderColor(Color.SandyBrown)
                    .AddColumn(new TableColumn("S ⬇ below").Centered());

                    var d = new Table()
                    .Border(TableBorder.Double)
                    .BorderColor(Color.SandyBrown)
                    .AddColumn(new TableColumn("D ➡ right").Centered());


                    table.AddColumn(new TableColumn("").Centered()).NoBorder();
                    table.AddColumn(new TableColumn(w).Centered()).NoBorder();
                    table.AddColumn(new TableColumn("").Centered()).NoBorder();

                    table.AddRow(a.Centered(), s.Centered(), d.Centered());
                    AnsiConsole.Write(table);
                    Direction = Console.ReadKey(true);

                    while (Direction.KeyChar != 'w' && Direction.KeyChar != 'W' && Direction.KeyChar != 'a' && Direction.KeyChar != 'A' && Direction.KeyChar != 's' && Direction.KeyChar != 'S' && Direction.KeyChar != 'd' && Direction.KeyChar != 'D' && Direction.KeyChar != 'r' && Direction.KeyChar != 'R')
                    {
                        Console.Clear();

                        Console.WriteLine("thats not a valid Direction)");
                        Console.WriteLine("(press a key to continue)");
                        Console.ReadKey(true);

                        Console.Clear();
                        Maze.PrintMaze(map, "Select A valid Direction !");
                        AnsiConsole.Write(table);
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
        public Teleporter(int id, string icon, string name, string info, int health, int attack, int mana, int cooldown, int[,] maze) : base(id, icon, name, info, health, attack, mana, cooldown, maze)
        //Call to base constructor
        {
        }
        public override void CastSpell(int[,] map, Player player, Player otherplayer)
        {
            Console.Clear();
            var dialogue = new Table()
            .RoundedBorder();
            dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
            dialogue.AddColumn(new TableColumn("[bold blue]> [/] Nobody can reach my magic!  ٩(^ᴗ^)۶   .... Teleporting").Centered());
            AnsiConsole.Write(dialogue);
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
    public class Switcher : Hero
    {
        //Constructor for Teleporter//
        public Switcher(int id, string icon, string name, string info, int health, int attack, int mana, int cooldown, int[,] maze) : base(id, icon, name, info, health, attack, mana, cooldown, maze)
        //Call to base constructor
        {
        }
        public override void CastSpell(int[,] map, Player player, Player otherplayer)
        {
            Console.Clear();

            Hero.DisplayList2(otherplayer.Party, $"Select a Hero of {otherplayer.name}'s Party!\n to switch positions!", map);
            Hero heroselected = Player.GetPlayerChoice(otherplayer.Party);

            Console.Clear();
            var dialogue = new Table()
            .RoundedBorder();
            dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
            dialogue.AddColumn(new TableColumn("[bold blue]> [/] You will be teleported [bold]" + heroselected.name + "[/], and you will not even know why, With the almighty power of space...!!   ≖‿≖").Centered());
            AnsiConsole.Write(dialogue);
            //save other hero Location
            int savedlocationX = heroselected.location[0];
            int savedlocationY = heroselected.location[1];

            //make otherplayer's hero location equal to my current hero location
            heroselected.location[0] = location[0];
            heroselected.location[1] = location[1];

            //make my current hero location equal to the saved location of the otherplayer's hero
            location[0] = savedlocationX;
            location[1] = savedlocationY;

            //update the display map for the PrintMaze method
            map[heroselected.location[0], heroselected.location[1]] = heroselected.id;
            map[location[0], location[1]] = id;

        }
    }
    public class Witcher : Hero
    {
        //Constructor for Teleporter//
        public Witcher(int id, string icon, string name, string info, int health, int attack, int mana, int cooldown, int[,] maze) : base(id, icon, name, info, health, attack, mana, cooldown, maze)
        //Call to base constructor
        {
        }
        public override void CastSpell(int[,] map, Player player, Player otherplayer)
        {
            Console.Clear();

            Hero.DisplayList2(otherplayer.Party, $"Select a Hero of {otherplayer.name}'s Party!\n to Paralyze!", map);
            Hero heroselected = Player.GetPlayerChoice(otherplayer.Party);

            Console.Clear();
            var dialogue = new Table()
            .RoundedBorder();
            dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
            dialogue.AddColumn(new TableColumn("[bold blue]> [/] 'Tis such a shame, but I will paralyze you [bold]" + heroselected.name + "[/], for [bold]5 turns[/] !, ᕚ('▿')ᕘ hahahahahaha").Centered());
            AnsiConsole.Write(dialogue);
            //stun hero
            heroselected.stunned = 5;

        }
    }
    public class Manner : Hero
    {
        //Constructor for Teleporter//
        public Manner(int id, string icon, string name, string info, int health, int attack, int mana, int cooldown, int[,] maze) : base(id, icon, name, info, health, attack, mana, cooldown, maze)
        //Call to base constructor
        {
        }
        public override void CastSpell(int[,] map, Player player, Player otherplayer)
        {
            Console.Clear();
            int savedmana = 0;

            Hero.DisplayList2(otherplayer.Party, $"Select a Hero of {otherplayer.name}'s Party!\n to steal mana from him/her!", map);
            Hero heroselected = Player.GetPlayerChoice(otherplayer.Party);

            //select random hero to transfer mana
            Random randomhero = new Random();
            int index = randomhero.Next(player.Party.Count);
            if (heroselected.mana < 5)
            {
                savedmana = heroselected.mana;
                heroselected.mana = 0;
                player.Party[index].mana += savedmana;
            }
            else
            {
                savedmana = 5;
                heroselected.mana -= 5;
                player.Party[index].mana += 5;
            }
            Console.Clear();
            var dialogue = new Table()
            .RoundedBorder();
            dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
            dialogue.AddColumn(new TableColumn("[bold blue]> [/] Thy mana does not belongs to you [bold]" + heroselected.name + "[/], and I will transfer[bold blue] " + savedmana + "[/] points of it to[bold] " + player.Party[index].name + "[/], haha ⧹(⦁ᴗ⦁)⧸").Centered());
            AnsiConsole.Write(dialogue);
        }
    }
    public class Jumper : Hero
    {
        //Constructor for Teleporter//
        public Jumper(int id, string icon, string name, string info, int health, int attack, int mana, int cooldown, int[,] maze) : base(id, icon, name, info, health, attack, mana, cooldown, maze)
        //Call to base constructor
        {
        }
        public override void CastSpell(int[,] map, Player player, Player otherplayer)
        {
            Console.Clear();
            var dialogue = new Table()
            .RoundedBorder();
            dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
            dialogue.AddColumn(new TableColumn("[bold blue]> [/] Nobody can jump like I can! .... Ahahahaha ?\n\n ").Centered());
            AnsiConsole.Write(dialogue);
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
                        if (map[location[0] + Dir[0] + Dir[0] + Dir[0], location[1] + Dir[1] + Dir[1] + Dir[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[location[0], location[1]] = 0;

                            // Remove trap, and move player to trap
                            location[0] = location[0] + Dir[0] + Dir[0];
                            location[1] = location[1] + Dir[1] + Dir[1];
                            map[location[0], location[1]] = id;

                            //add new position to the log
                            locationlog.Add(new int[] { location[0], location[1] });

                            //point that the player is in a trap
                            trapped = true;
                            Console.Clear();
                            Maze.PrintMaze(map, "Super Activated successfully!");
                            var dialogue2 = new Table()
                            .RoundedBorder();
                            dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                            dialogue2.AddColumn(new TableColumn("[bold blue]> [/] It's amazing!, my jump reached the maximum distance :D").Centered());
                            AnsiConsole.Write(dialogue2);
                            Console.WriteLine();
                        }
                        else if (map[location[0] + Dir[0] + Dir[0] + Dir[0], location[1] + Dir[1] + Dir[1] + Dir[1]] == 0)
                        {
                            location[0] = location[0] + Dir[0] + Dir[0] + Dir[0];
                            location[1] = location[1] + Dir[1] + Dir[1] + Dir[1];
                            map[location[0], location[1]] = id;
                            Console.Clear();
                            Maze.PrintMaze(map, "Super Activated successfully!");
                            var dialogue2 = new Table()
                            .RoundedBorder();
                            dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                            dialogue2.AddColumn(new TableColumn("[bold blue]> [/] It's amazing!, my jump reached the maximum distance :D").Centered());
                            AnsiConsole.Write(dialogue2);
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        if (map[location[0] + Dir[0] + Dir[0], location[1] + Dir[1] + Dir[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[location[0], location[1]] = 0;

                            // Remove trap, and move player to trap
                            location[0] = location[0] + Dir[0] + Dir[0];
                            location[1] = location[1] + Dir[1] + Dir[1];
                            map[location[0], location[1]] = id;

                            //add new position to the log
                            locationlog.Add(new int[] { location[0], location[1] });

                            //point that the player is in a trap
                            trapped = true;
                            Console.Clear();
                            Maze.PrintMaze(map, "Super Activated successfully!");

                            var dialogue2 = new Table()
                            .RoundedBorder();
                            dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                            dialogue2.AddColumn(new TableColumn("[bold blue]> [/] I could have jumped a higher distance but my jump was interruped due to an obstacle :(").Centered());
                            AnsiConsole.Write(dialogue2);

                        }
                        else if (map[location[0] + Dir[0] + Dir[0], location[1] + Dir[1] + Dir[1]] == 0)
                        {
                            location[0] = location[0] + Dir[0] + Dir[0];
                            location[1] = location[1] + Dir[1] + Dir[1];
                            map[location[0], location[1]] = id;
                            Console.Clear();
                            Maze.PrintMaze(map, "Super Activated successfully!");
                            var dialogue2 = new Table()
                            .RoundedBorder();
                            dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                            dialogue2.AddColumn(new TableColumn("[bold blue]> [/] I could have jumped a higher distance but my jump was interruped due to an obstacle :(").Centered());
                            AnsiConsole.Write(dialogue2);
                        }
                    }
                }
                else
                {
                    if (map[location[0] + Dir[0], location[1] + Dir[1]] == 3)
                    {
                        // Make player current position equals 0
                        map[location[0], location[1]] = 0;

                        // Remove trap, and move player to trap
                        location[0] = location[0] + Dir[0];
                        location[1] = location[1] + Dir[1];
                        map[location[0], location[1]] = id;
                        //add new position to the log
                        locationlog.Add(new int[] { location[0], location[1] });
                        //select a random trap in the trap list, to execute to the hero
                        trapped = true;
                        Console.Clear();
                        Maze.PrintMaze(map, "Super Activated successfully!");
                        var dialogue2 = new Table()
                        .RoundedBorder();
                        dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                        dialogue2.AddColumn(new TableColumn("[bold blue]> [/] I could have jumped a higher distance but my jump was interruped due to an obstacle :(").Centered());
                        AnsiConsole.Write(dialogue2);
                    }
                    else if (map[location[0] + Dir[0], location[1] + Dir[1]] == 0)
                    {
                        location[0] = location[0] + Dir[0];
                        location[1] = location[1] + Dir[1];
                        map[location[0], location[1]] = id;
                        Console.Clear();
                        Maze.PrintMaze(map, "Super Activated successfully!");
                        var dialogue2 = new Table()
                        .RoundedBorder();
                        dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                        dialogue2.AddColumn(new TableColumn("[bold blue]> [/] I could have jumped a higher distance but my jump was interruped due to an obstacle :(").Centered());
                        AnsiConsole.Write(dialogue2);
                    }
                }
            }
            map[location[0], location[1]] = id;
        }
    }
    public class WallBreaker : Hero
    {
        //Constructor for WallBreaker//
        public WallBreaker(int id, string icon, string name, string info, int health, int attack, int mana, int cooldown, int[,] maze) : base(id, icon, name, info, health, attack, mana, cooldown, maze)//Call to base constructor
        {
        }
        public override void CastSpell(int[,] map, Player player, Player otherplayer)
        {
            // Console.WriteLine(Name + "The bigger the wall is, the easier it falls down :D");
            while (true)
            {
                Console.Clear();
                var dialogue = new Table()
                .RoundedBorder();
                dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                dialogue.AddColumn(new TableColumn("[bold blue]> [/]Which wall would you like me to destroy mate ? ヽ(ヅ)ノ").Centered());
                AnsiConsole.Write(dialogue);


                var table = new Table()
                .NoBorder();
                var w = new Table()
                .Border(TableBorder.Double)
                .BorderColor(Color.SandyBrown)
                .AddColumn(new TableColumn("W ⬆ above").Centered());

                var a = new Table()
                .Border(TableBorder.Double)
                .BorderColor(Color.SandyBrown)
                .AddColumn(new TableColumn("A ⬅ left").Centered());

                var s = new Table()
                .Border(TableBorder.Double)
                .BorderColor(Color.SandyBrown)
                .AddColumn(new TableColumn("S ⬇ below").Centered());

                var d = new Table()
                .Border(TableBorder.Double)
                .BorderColor(Color.SandyBrown)
                .AddColumn(new TableColumn("D ➡ right").Centered());


                table.AddColumn(new TableColumn("").Centered()).NoBorder();
                table.AddColumn(new TableColumn(w).Centered()).NoBorder();
                table.AddColumn(new TableColumn("").Centered()).NoBorder();

                table.AddRow(a.Centered(), s.Centered(), d.Centered());
                AnsiConsole.Write(table);





                ConsoleKeyInfo Direction = Console.ReadKey(true);
                while (Direction.KeyChar != 'w' && Direction.KeyChar != 'W' && Direction.KeyChar != 'a' && Direction.KeyChar != 'A' && Direction.KeyChar != 's' && Direction.KeyChar != 'S' && Direction.KeyChar != 'd' && Direction.KeyChar != 'D' && Direction.KeyChar != 'r' && Direction.KeyChar != 'R')
                {
                    Console.Clear();

                    Console.WriteLine("thats not a valid Direction)");
                    Console.WriteLine("(press a key to continue)");
                    Console.ReadKey(true);

                    Console.Clear();
                    AnsiConsole.Write(dialogue);
                    AnsiConsole.Write(table);
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
                    else
                    {
                        break;
                    }
                }
                else if (Direction.KeyChar == 's' || Direction.KeyChar == 'S')
                {
                    if (!HandleWallBreaking(1, 0, map))
                        continue;
                    else
                    {
                        break;
                    }
                }
                else if (Direction.KeyChar == 'a' || Direction.KeyChar == 'A')
                {
                    if (!HandleWallBreaking(0, -1, map))
                        continue;
                    else
                    {
                        break;
                    }
                }
                else if (Direction.KeyChar == 'd' || Direction.KeyChar == 'D')
                {
                    if (!HandleWallBreaking(0, 1, map))
                        continue;
                    else
                    {
                        break;
                    }
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
    }
}
