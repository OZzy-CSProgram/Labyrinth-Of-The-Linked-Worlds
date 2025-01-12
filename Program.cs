﻿using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using GameObjects;
using Spectre.Console;
while (true)
{
    ///////////////////      MAIN MENU         /////////////
    Console.Clear();
    Console.Beep();
    var GameGui1 = new Table()
    .BorderColor(Color.DeepSkyBlue3);
    var GameGui2 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Color.DeepSkyBlue3_1);
    var GameGui3 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Color.SkyBlue1);
    var GameGui4 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Color.CadetBlue);
    var GameGui5 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Color.DodgerBlue1);
    var GameGui6 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Color.DarkGoldenrod);
    var GameGui7 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Color.DarkGreen);
    var GameGui8 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Color.DarkGreen);

    Menu.GetMainMenu(GameGui1);

    ConsoleKeyInfo Selection = Console.ReadKey(true);
    if (Selection.KeyChar == 's')
    {
        Player.exit = true;
        Player.play = false;
        continue;
    }
    if (Selection.KeyChar == 'w')
    {
        Player.exit = false;
        Player.play = true;
        continue;
    }
    if (Selection.KeyChar == (char)13 && Player.play == true)
    {

        ///////////////////      PLAY- Choise   Setting Players   Generating Maze    ///////////////////////

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Letsss goooo!!!");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        //Phase 1
        Console.WriteLine("                   For The Player 1");
        Console.WriteLine("(The Player 1 should be the one playing, at this current time!)");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        //Roleplay
        Console.WriteLine("(you wake up in a stranger place!)");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        //More Roleplay

        var instance1 = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Color.Gold1);
        instance1.AddColumn(new TableColumn("")).HideHeaders();
        instance1.AddRow("[bold green]Lady Elara [/] [yellow]>[/] We have been waiting for you warrior!").Centered();
        instance1.AddEmptyRow();
        instance1.AddEmptyRow();
        instance1.AddEmptyRow();
        instance1.AddRow("(press a key to continue)").Centered();

        var Stage1 = Menu.LadyElara(GameGui2, instance1);
        AnsiConsole.Write(Stage1);
        Console.ReadKey(true);
        Console.Clear();

        Player Player1 = new Player();

        var instance2 = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Color.Gold1);
        instance2.AddColumn(new TableColumn("")).HideHeaders();
        instance2.AddRow("[bold green]Lady Elara [/] [yellow]>[/] Wait, We have not properly meet, What is your name?!").Centered();
        instance2.AddEmptyRow();
        instance2.AddEmptyRow();
        instance2.AddEmptyRow();
        instance2.AddRow(" ").Centered();
        var Stage2 = Menu.LadyElara(GameGui3, instance2);
        AnsiConsole.Write(Stage2);
        Console.WriteLine();
        Console.Write("                             Enter your name to continue) ▶     ");
        string nameofP1 = Player.intname(Console.ReadLine(), Player1);

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        Console.Clear();
        var instance3 = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Color.Gold1);
        instance3.AddColumn(new TableColumn("")).HideHeaders();
        instance3.AddRow("[bold green]Lady Elara [/] [yellow]>[/] Greetings " + nameofP1 + " we have summoned you, from your world because we need your help!").Centered();
        instance3.AddEmptyRow();
        instance3.AddEmptyRow();
        instance3.AddEmptyRow();
        instance3.AddRow("(press a key to continue)").Centered();
        var Stage3 = Menu.LadyElara(GameGui4, instance3);
        AnsiConsole.Write(Stage3);

        Console.Clear();
        var instance4 = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Color.Gold1);
        instance4.AddColumn(new TableColumn("")).HideHeaders();
        instance4.AddRow("[bold green]Lady Elara [/] [yellow]>[/] I have had a vision of a future where darkness consumes all of my world,\nI have seen in my visions that the only way to stop the darkness from spreading\n is by using an ancient and lost artifact called The Heart of Ebony... \n \n\nA group of our elder mages has discover that this artifact lays in a dangerous place called \n'The Labyrinth of The Linked Worlds' So... Can you help us " + nameofP1 + " ?").Centered();
        instance4.AddEmptyRow();
        instance4.AddEmptyRow();
        instance4.AddRow("(   Choose your answer   )").Centered();
        instance4.AddEmptyRow();
        instance4.AddEmptyRow();
        instance4.AddRow("[bold red]1[/] Why me?").Centered();
        instance4.AddRow("[bold red]2[/] What exactly do you want me to do!").Centered();
        var Stage4 = Menu.LadyElara(GameGui5, instance4);
        AnsiConsole.Write(Stage4);

        ConsoleKeyInfo decition2 = Console.ReadKey(true);
        while (decition2.KeyChar != '2' && decition2.KeyChar != '1')
        {
            Console.Clear();

            Console.WriteLine("thats not a valid answer)");
            Console.WriteLine("(press a key to continue)");
            Console.ReadKey(true);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            AnsiConsole.Write(Stage4);
            decition2 = Console.ReadKey(true);

            if (decition2.KeyChar == '2' || decition2.KeyChar == '1')
            {
                break;
            }
        }

        while (decition2.KeyChar == '1')
        {
            Console.Clear();
            var instance5 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Gold1);
            instance5.AddColumn(new TableColumn("")).HideHeaders();
            instance5.AddRow("[bold green]Lady Elara [/] [yellow]>[/] I understand the question " + nameofP1 + " ,there is a prophecy about this labyrinth that says \n'Nobody in this world shall carry the Heart of Ebony out of the Labyrinth',\n and so we have decided to summon someone from another world to help us!\n \n... Can you?").Centered();
            instance5.AddEmptyRow();
            instance5.AddEmptyRow();
            instance5.AddRow("(   Choose your answer   )").Centered();
            instance5.AddEmptyRow();
            instance5.AddEmptyRow();
            instance5.AddRow("[bold red]2[/] What exactly do you want me to do!").Centered();
            var Stage5 = Menu.LadyElara(GameGui7, instance5);
            AnsiConsole.Write(Stage5);
            decition2 = Console.ReadKey(true);

            while (decition2.KeyChar != '2')
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("(thats not a valid answer)");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("(press a key to continue)");
                Console.ReadKey(true);

                Console.Clear();
                AnsiConsole.Write(Stage5);
                decition2 = Console.ReadKey(true);

                if (decition2.KeyChar == '2')
                {
                    break;
                }
            }

        }

        Console.Clear();
        var instance6 = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Color.Gold1);
        instance6.AddColumn(new TableColumn("")).HideHeaders();
        instance6.AddRow("[bold green]Lady Elara [/] [yellow]>[/] Thank you " + nameofP1 + " ! Your quest would be to go inside the Labyrinth of the Linked Worlds and get the Heart of Ebony, dont worry, you will not be alone, you will be leading a party of brave heroes of our kingdom, you can personally choose them! ").Centered();
        instance6.AddEmptyRow();
        instance6.AddEmptyRow();
        instance6.AddRow("(   press a key to continue   )").Centered();
        instance6.AddEmptyRow();
        instance6.AddEmptyRow();
        var Stage6 = Menu.LadyElara(GameGui8, instance6);
        AnsiConsole.Write(Stage6);
        Console.ReadKey(true);
        Console.Clear();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        //Phase 2
        Player Player2 = new Player();
        Console.WriteLine("                    For The Player 2");
        Console.WriteLine("(The Player 2 should be the one playing, at this current time!)");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Lord Kaelg> Wake up!, You are now under my command Switcher!!!");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Lord Kaelg> If you want to get back to your miserable world you shall first serve me well!!!");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Lord Kaelg> Tell me what your name is!!!");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("(Enter your name to continue) : ");
        string nameofP2 = Player.intname(Console.ReadLine(), Player2);
        Player2.name = nameofP2;
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Player2.Greet();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        Console.Clear();
        //// MAP GENERATION
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Genering The Map...");
        int[,] map = Maze.Generator();
        Trap.SpawnTraps(map);

        //spawn artifact
        map[Maze.size / 2, Maze.size / 2 - 1] = 4;
        var mapprinted = Maze.PrintMaze(map, "  Generated Map !");
        AnsiConsole.Write(mapprinted);
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        ///////////////////////////////////////////////////////////////////////////////////
        //////////////////////////      Heroes Selection         //////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        Console.Clear();
        Console.WriteLine(" _____                        _____     _         _   _         ");
        Console.WriteLine("|  |  |___ ___ ___ ___ ___   |   __|___| |___ ___| |_|_|___ ___ ");
        Console.WriteLine("|     | -_|  _| . | -_|_ -|  |__   | -_| | -_|  _|  _| | . |   |");
        Console.WriteLine("|__|__|___|_| |___|___|___|  |_____|___|_|___|___|_| |_|___|_|_|");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Allright, Lets proceed to the Heroes Selection");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        List<Hero> Heroes = new List<Hero>();
        Teleporter Mediv = new Teleporter(11, "🧙🏻‍♂️", "Mediv The Guardian", "A powerfull mage with the magical power \n of teleporting to a random position in the maze!", 10, 6, 0, 12, map);
        Heroes.Add(Mediv);
        WallBreaker Eledron = new WallBreaker(13, "👳‍♂️", "Eledron The WallBreaker", "A strong Dwarv with a big Hammer\n He has got the ability to break walls!", 16, 4, 0, 10, map);
        Heroes.Add(Eledron);
        Jumper Monkinho = new Jumper(15, "🐵", "Monkinho The Jumper", "A monkey with the ability to jump 3 cells \n in front of him, but obstacles can interrupt his jump!", 12, 5, 0, 8, map);
        Heroes.Add(Monkinho);
        Switcher Warlus = new Switcher(17, "🧞", "Warlus The Genius", "A Genius with the great power of,\n switching position with an enemy hero selected!", 10, 5, 0, 2, map);
        Heroes.Add(Warlus);
        Witcher Galia = new Witcher(19, "👹", "Galia The Witch", "A tenebrous witch with the dangerous power,\n of paralyzing the enemy hero selected!", 9, 7, 0, 2, map);
        Heroes.Add(Galia);
        Manner Elymnis = new Manner(21, "👽", "Elymnis The Creator", "One of the first mages that used mana,\nas a supply of energy, she can remove 5 points\nof mana to the selected enemy hero and transfer it\nto a random player in the host!", 13, 4, 0, 2, map);
        Heroes.Add(Elymnis);


        while (Heroes.Count > 0)
        {
            ////Player 1 Choose
            Console.Clear();
            Console.WriteLine(" _____                        _____     _         _   _         ");
            Console.WriteLine("|  |  |___ ___ ___ ___ ___   |   __|___| |___ ___| |_|_|___ ___ ");
            Console.WriteLine("|     | -_|  _| . | -_|_ -|  |__   | -_| | -_|  _|  _| | . |   |");
            Console.WriteLine("|__|__|___|_| |___|___|___|  |_____|___|_|___|___|_| |_|___|_|_|");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Hero.DisplayList(Heroes, $"{nameofP1} , ITS YOUR TURN !!!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Hero choice1 = Player.GetPlayerChoice(Heroes);
            if (choice1 != null)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"{nameofP1} has chosen {choice1.name} !");
                Player1.Party.Add(choice1);
                Heroes.Remove(choice1);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("(press a key to continue)");
                Console.ReadKey(true);
            }
            if (Heroes.Count == 0)
            {
                break;
            }
            //// Player 2 Choose
            Console.Clear();
            Console.WriteLine(" _____                        _____     _         _   _         ");
            Console.WriteLine("|  |  |___ ___ ___ ___ ___   |   __|___| |___ ___| |_|_|___ ___ ");
            Console.WriteLine("|     | -_|  _| . | -_|_ -|  |__   | -_| | -_|  _|  _| | . |   |");
            Console.WriteLine("|__|__|___|_| |___|___|___|  |_____|___|_|___|___|_| |_|___|_|_|");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Hero.DisplayList(Heroes, $"{nameofP2} , ITS YOUR TURN !!!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Hero choice2 = Player.GetPlayerChoice(Heroes);
            if (choice2 != null)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"{nameofP2} has chosen {choice2.name}");
                Player2.Party.Add(choice2);
                Heroes.Remove(choice2);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("(press a key to continue)");
                Console.ReadKey(true);
            }
            continue;
        }
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Heroes selection finished...");
        Console.WriteLine("The victory awaits, for the champion of the maze!");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        ///Heroes Spwans
        //                       Player 1
        //Spawn of First Hero
        Player1.Party[0].location[0] = 1;
        Player1.Party[0].location[1] = 1;
        int[] spawn1p1 = new int[] { 1, 1 };

        //Spawn of Second Hero
        Player1.Party[1].location[0] = 1;
        Player1.Party[1].location[1] = Maze.size / 2 - 1;
        int[] spawn2p1 = new int[] { 1, Maze.size / 2 - 1 };

        //Spawn of Third Hero
        Player1.Party[2].location[0] = 1;
        Player1.Party[2].location[1] = Maze.size - 2;
        int[] spawn3p1 = new int[] { 1, Maze.size - 2 };

        //                       Player 2
        //Spawn of First Hero
        Player2.Party[0].location[0] = Maze.size - 2;
        Player2.Party[0].location[1] = 1;
        int[] spawn1p2 = new int[] { Maze.size - 2, 1 };

        //Spawn of Second Hero
        Player2.Party[1].location[0] = Maze.size - 2;
        Player2.Party[1].location[1] = Maze.size / 2 - 1;
        int[] spawn2p2 = new int[] { Maze.size - 2, Maze.size / 2 - 1 };

        //Spawn of Third Hero
        Player2.Party[2].location[0] = Maze.size - 2;
        Player2.Party[2].location[1] = Maze.size - 2;
        int[] spawn3p2 = new int[] { Maze.size - 2, Maze.size - 2 };

        //                 Printing Players in the Map
        //Player1
        switch (Player1.Party[0].GetType().Name)
        {
            case nameof(Teleporter): // wall
                map[spawn1p1[0], spawn1p1[1]] = Mediv.id;
                Mediv.locationlog.Add(new int[] { spawn1p1[0], spawn1p1[1] });
                break;
            case nameof(WallBreaker): // wall
                map[spawn1p1[0], spawn1p1[1]] = Eledron.id;
                Eledron.locationlog.Add(new int[] { spawn1p1[0], spawn1p1[1] });
                break;
            case nameof(Jumper): // wall
                map[spawn1p1[0], spawn1p1[1]] = Monkinho.id;
                Monkinho.locationlog.Add(new int[] { spawn1p1[0], spawn1p1[1] });
                break;
            case nameof(Switcher): // wall
                map[spawn1p1[0], spawn1p1[1]] = Warlus.id;
                Warlus.locationlog.Add(new int[] { spawn1p1[0], spawn1p1[1] });
                break;
            case nameof(Witcher): // wall
                map[spawn1p1[0], spawn1p1[1]] = Galia.id;
                Galia.locationlog.Add(new int[] { spawn1p1[0], spawn1p1[1] });
                break;
            case nameof(Manner): // wall
                map[spawn1p1[0], spawn1p1[1]] = Elymnis.id;
                Elymnis.locationlog.Add(new int[] { spawn1p1[0], spawn1p1[1] });
                break;
            default:
                break;
        }
        switch (Player1.Party[1].GetType().Name)
        {
            case nameof(Teleporter): // wall
                map[spawn2p1[0], spawn2p1[1]] = Mediv.id;
                Mediv.locationlog.Add(new int[] { spawn2p1[0], spawn2p1[1] });
                break;
            case nameof(WallBreaker): // wall
                map[spawn2p1[0], spawn2p1[1]] = Eledron.id;
                Eledron.locationlog.Add(new int[] { spawn2p1[0], spawn2p1[1] });
                break;
            case nameof(Jumper): // wall
                map[spawn2p1[0], spawn2p1[1]] = Monkinho.id;
                Monkinho.locationlog.Add(new int[] { spawn2p1[0], spawn2p1[1] });
                break;
            case nameof(Switcher): // wall
                map[spawn2p1[0], spawn2p1[1]] = Warlus.id;
                Warlus.locationlog.Add(new int[] { spawn2p1[0], spawn2p1[1] });
                break;
            case nameof(Witcher): // wall
                map[spawn2p1[0], spawn2p1[1]] = Galia.id;
                Galia.locationlog.Add(new int[] { spawn2p1[0], spawn2p1[1] });
                break;
            case nameof(Manner): // wall
                map[spawn2p1[0], spawn2p1[1]] = Elymnis.id;
                Elymnis.locationlog.Add(new int[] { spawn2p1[0], spawn2p1[1] });
                break;
            default:
                break;
        }
        switch (Player1.Party[2].GetType().Name)
        {
            case nameof(Teleporter): // wall
                map[spawn3p1[0], spawn3p1[1]] = Mediv.id;
                Mediv.locationlog.Add(new int[] { spawn3p1[0], spawn3p1[1] });
                break;
            case nameof(WallBreaker): // wall
                map[spawn3p1[0], spawn3p1[1]] = Eledron.id;
                Eledron.locationlog.Add(new int[] { spawn3p1[0], spawn3p1[1] });
                break;
            case nameof(Jumper): // wall
                map[spawn3p1[0], spawn3p1[1]] = Monkinho.id;
                Monkinho.locationlog.Add(new int[] { spawn3p1[0], spawn3p1[1] });
                break;
            case nameof(Switcher): // wall
                map[spawn3p1[0], spawn3p1[1]] = Warlus.id;
                Warlus.locationlog.Add(new int[] { spawn3p1[0], spawn3p1[1] });
                break;
            case nameof(Witcher): // wall
                map[spawn3p1[0], spawn3p1[1]] = Galia.id;
                Galia.locationlog.Add(new int[] { spawn3p1[0], spawn3p1[1] });
                break;
            case nameof(Manner): // wall
                map[spawn3p1[0], spawn3p1[1]] = Elymnis.id;
                Elymnis.locationlog.Add(new int[] { spawn3p1[0], spawn3p1[1] });
                break;
            default:
                break;
        }
        // Player 2
        switch (Player2.Party[0].GetType().Name)
        {
            case nameof(Teleporter): // wall
                map[spawn1p2[0], spawn1p2[1]] = Mediv.id;
                Mediv.locationlog.Add(new int[] { spawn1p2[0], spawn1p2[1] });
                break;
            case nameof(WallBreaker): // wall
                map[spawn1p2[0], spawn1p2[1]] = Eledron.id;
                Eledron.locationlog.Add(new int[] { spawn1p2[0], spawn1p2[1] });
                break;
            case nameof(Jumper): // wall
                map[spawn1p2[0], spawn1p2[1]] = Monkinho.id;
                Monkinho.locationlog.Add(new int[] { spawn1p2[0], spawn1p2[1] });
                break;
            case nameof(Switcher): // wall
                map[spawn1p2[0], spawn1p2[1]] = Warlus.id;
                Warlus.locationlog.Add(new int[] { spawn1p2[0], spawn1p2[1] });
                break;
            case nameof(Witcher): // wall
                map[spawn1p2[0], spawn1p2[1]] = Galia.id;
                Galia.locationlog.Add(new int[] { spawn1p2[0], spawn1p2[1] });
                break;
            case nameof(Manner): // wall
                map[spawn1p2[0], spawn1p2[1]] = Elymnis.id;
                Elymnis.locationlog.Add(new int[] { spawn1p2[0], spawn1p2[1] });
                break;
            default:
                break;
        }
        switch (Player2.Party[1].GetType().Name)
        {
            case nameof(Teleporter): // wall
                map[spawn2p2[0], spawn2p2[1]] = Mediv.id;
                Mediv.locationlog.Add(new int[] { spawn2p2[0], spawn2p2[1] });
                break;
            case nameof(WallBreaker): // wall
                map[spawn2p2[0], spawn2p2[1]] = Eledron.id;
                Eledron.locationlog.Add(new int[] { spawn2p2[0], spawn2p2[1] });
                break;
            case nameof(Jumper): // wall
                map[spawn2p2[0], spawn2p2[1]] = Monkinho.id;
                Monkinho.locationlog.Add(new int[] { spawn2p2[0], spawn2p2[1] });
                break;
            case nameof(Switcher): // wall
                map[spawn2p2[0], spawn2p2[1]] = Warlus.id;
                Warlus.locationlog.Add(new int[] { spawn2p2[0], spawn2p2[1] });
                break;
            case nameof(Witcher): // wall
                map[spawn2p2[0], spawn2p2[1]] = Galia.id;
                Galia.locationlog.Add(new int[] { spawn2p2[0], spawn2p2[1] });
                break;
            case nameof(Manner): // wall
                map[spawn2p2[0], spawn2p2[1]] = Elymnis.id;
                Elymnis.locationlog.Add(new int[] { spawn2p2[0], spawn2p2[1] });
                break;
            default:
                break;
        }
        switch (Player2.Party[2].GetType().Name)
        {
            case nameof(Teleporter): // wall
                map[spawn3p2[0], spawn3p2[1]] = Mediv.id;
                Mediv.locationlog.Add(new int[] { spawn3p2[0], spawn3p2[1] });
                break;
            case nameof(WallBreaker): // wall
                map[spawn3p2[0], spawn3p2[1]] = Eledron.id;
                Eledron.locationlog.Add(new int[] { spawn3p2[0], spawn3p2[1] });
                break;
            case nameof(Jumper): // wall
                map[spawn3p2[0], spawn3p2[1]] = Monkinho.id;
                Monkinho.locationlog.Add(new int[] { spawn3p2[0], spawn3p2[1] });
                break;
            case nameof(Switcher): // wall
                map[spawn3p2[0], spawn3p2[1]] = Warlus.id;
                Warlus.locationlog.Add(new int[] { spawn3p2[0], spawn3p2[1] });
                break;
            case nameof(Witcher): // wall
                map[spawn3p2[0], spawn3p2[1]] = Galia.id;
                Galia.locationlog.Add(new int[] { spawn3p2[0], spawn3p2[1] });
                break;
            case nameof(Manner): // wall
                map[spawn3p2[0], spawn3p2[1]] = Elymnis.id;
                Elymnis.locationlog.Add(new int[] { spawn3p2[0], spawn3p2[1] });
                break;
            default:
                break;
        }
        //Creating Trap List
        List<Trap> Traps = new List<Trap>();
        TReturn5 Return5 = new TReturn5();
        Traps.Add(Return5);
        TReturn10 Return10 = new TReturn10();
        Traps.Add(Return10);
        TLoseMana5 LoseMana5 = new TLoseMana5();
        Traps.Add(LoseMana5);
        TLoseHealth6 LoseHealth6 = new TLoseHealth6();
        Traps.Add(LoseHealth6);

        Player1.turn = true;
        Player2.turn = false;
        while (true)
        {
            static ConsoleKeyInfo ValidPosition(ConsoleKeyInfo action, int[,] map, string name, Hero hero)
            {
                while (action.KeyChar != 'w' && action.KeyChar != 'W' && action.KeyChar != 'a' && action.KeyChar != 'A' && action.KeyChar != 's' && action.KeyChar != 'S' && action.KeyChar != 'd' && action.KeyChar != 'D' && action.KeyChar != 'r' && action.KeyChar != 'R')
                {
                    Console.Clear();
                    Console.WriteLine("thats not a valid action)");
                    Console.WriteLine("(press a key to continue)");
                    Console.ReadKey(true);
                    Console.Clear();
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
                    table.AddColumn(new TableColumn("").Centered()).NoBorder();
                    table.AddColumn(new TableColumn(w).Centered()).NoBorder();
                    table.AddColumn(new TableColumn("").Centered()).NoBorder();
                    table.AddColumn(new TableColumn(r).Centered()).NoBorder();

                    table.AddRow(a.Centered(), s.Centered(), d.Centered());
                    Maze.PrintMaze2(map, $" {name}'s Turn!!!         ", table, hero);
                    action = Console.ReadKey(true);
                    if (action.KeyChar == 'w' || action.KeyChar == 'W' || action.KeyChar == 'a' || action.KeyChar == 'A' || action.KeyChar == 's' || action.KeyChar == 'S' || action.KeyChar == 'd' || action.KeyChar == 'D')
                    {
                        break;
                    }
                }
                return action;
            }
            static ConsoleKeyInfo GetAction(int[,] map, string name, Hero hero)
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
                table.AddColumn(new TableColumn("").Centered()).NoBorder();
                table.AddColumn(new TableColumn(w).Centered()).NoBorder();
                table.AddColumn(new TableColumn("").Centered()).NoBorder();
                table.AddColumn(new TableColumn(r).Centered()).NoBorder();

                table.AddRow(a.Centered(), s.Centered(), d.Centered());
                Maze.PrintMaze2(map, $" {name}'s Turn!!!         ", table, hero);
                ConsoleKeyInfo action = Console.ReadKey(true);
                action = ValidPosition(action, map, name, hero);
                return action;
            }
            static void PassTurn(int[,] map, string name, Hero hero)
            {
                Console.Clear();
                var table = new Table();
                // table.AddColumn(new TableColumn($"{name} Has moved {hero.name} to [  {hero.location[0]}  ,  {hero.location[1]}  ] ").Centered());
                table.AddColumn(new TableColumn("Press a key to finish your turn").Centered());
                Maze.PrintMaze2(map, $" {name}'s Turn!!!         ", table, hero);
                Console.ReadKey(true);
            }
            while (Player1.turn == true)
            {

                Console.Clear();
                Console.WriteLine($"{nameofP1} IS YOUR TURN!");
                Hero.DisplayList2(Player1.Party, $"            {nameofP1}'s Party!", map);
                Hero choice1 = Player.GetPlayerChoice(Player1.Party);
                ConsoleKeyInfo action;
                action = GetAction(map, nameofP1, choice1);
                while (true)
                {
                    if (action.KeyChar == 'w')
                    {
                        if (map[choice1.location[0] - 1, choice1.location[1]] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;

                        }
                        if (map[choice1.location[0] - 1, choice1.location[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[choice1.location[0], choice1.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice1.location[0] - 1, choice1.location[1]] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice1.moveup(choice1.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice1.location[0], choice1.location[1]] = choice1.id;

                            //add new position to the log
                            choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                            choice1.trapped = true;
                            break;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveup(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'W')
                    {
                        if (map[choice1.location[0] - 1, choice1.location[1]] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;

                        }
                        if (map[choice1.location[0] - 1, choice1.location[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[choice1.location[0], choice1.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice1.location[0] - 1, choice1.location[1]] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice1.moveup(choice1.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice1.location[0], choice1.location[1]] = choice1.id;

                            //add new position to the log
                            choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                            choice1.trapped = true;
                            break;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveup(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'a')
                    {
                        if (map[choice1.location[0], choice1.location[1] - 1] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;
                        }
                        if (map[choice1.location[0], choice1.location[1] - 1] == 3)
                        {
                            // Make player current position equals 0
                            map[choice1.location[0], choice1.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice1.location[0], choice1.location[1] - 1] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice1.moveleft(choice1.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice1.location[0], choice1.location[1]] = choice1.id;

                            //add new position to the log
                            choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                            choice1.trapped = true;
                            break;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveleft(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                        break;

                    }
                    if (action.KeyChar == 'A')
                    {
                        if (map[choice1.location[0], choice1.location[1] - 1] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;
                        }
                        if (map[choice1.location[0], choice1.location[1] - 1] == 3)
                        {
                            // Make player current position equals 0
                            map[choice1.location[0], choice1.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice1.location[0], choice1.location[1] - 1] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice1.moveleft(choice1.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice1.location[0], choice1.location[1]] = choice1.id;

                            //add new position to the log
                            choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                            choice1.trapped = true;
                            break;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveleft(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                        break;
                    }
                    if (action.KeyChar == 's')
                    {
                        if (map[choice1.location[0] + 1, choice1.location[1]] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;
                        }
                        if (map[choice1.location[0] + 1, choice1.location[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[choice1.location[0], choice1.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice1.location[0] + 1, choice1.location[1]] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice1.movedown(choice1.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice1.location[0], choice1.location[1]] = choice1.id;

                            //add new position to the log
                            choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                            choice1.trapped = true;
                            break;
                        }

                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.movedown(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'S')
                    {
                        if (map[choice1.location[0] + 1, choice1.location[1]] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;
                        }
                        if (map[choice1.location[0] + 1, choice1.location[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[choice1.location[0], choice1.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice1.location[0] + 1, choice1.location[1]] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice1.movedown(choice1.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice1.location[0], choice1.location[1]] = choice1.id;
                            //add new position to the log
                            choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                            choice1.trapped = true;
                            break;
                        }

                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.movedown(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'd')
                    {
                        if (map[choice1.location[0], choice1.location[1] + 1] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;
                        }
                        if (map[choice1.location[0], choice1.location[1] + 1] == 3)
                        {
                            // Make player current position equals 0
                            map[choice1.location[0], choice1.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice1.location[0], choice1.location[1] + 1] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice1.moveright(choice1.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice1.location[0], choice1.location[1]] = choice1.id;
                            //add new position to the log
                            choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                            choice1.trapped = true;
                            break;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveright(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'D')
                    {
                        if (map[choice1.location[0], choice1.location[1] + 1] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;
                        }
                        if (map[choice1.location[0], choice1.location[1] + 1] == 3)
                        {
                            // Make player current position equals 0
                            map[choice1.location[0], choice1.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice1.location[0], choice1.location[1] + 1] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice1.moveright(choice1.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice1.location[0], choice1.location[1]] = choice1.id;
                            //add new position to the log
                            choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                            choice1.trapped = true;
                            break;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveright(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        choice1.locationlog.Add(new int[] { choice1.location[0], choice1.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'r')
                    {
                        if (choice1.mana >= choice1.cooldown)
                        {
                            choice1.mana = choice1.mana - choice1.cooldown;
                            Console.Clear();
                            Console.WriteLine($"Activating the Super of {choice1.name}!");
                            Console.WriteLine();
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey(true);
                            choice1.CastSpell(map, Player1, Player2);
                            Console.WriteLine();
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{choice1.name} >> I cant do that yet, I need at least {choice1.cooldown} points of mana to use my power!");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;
                        }

                    }
                    if (action.KeyChar == 'R')
                    {
                        if (choice1.mana >= choice1.cooldown)
                        {
                            choice1.mana = choice1.mana - choice1.cooldown;
                            Console.Clear();
                            Console.WriteLine($"Activating the Super of {choice1.name}!");
                            Console.WriteLine();
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey(true);
                            choice1.CastSpell(map, Player1, Player2);
                            Console.WriteLine();
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{choice1.name} >> I cant do that yet, I need at least {choice1.cooldown} points of mana to use my power!");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP1, choice1);
                            continue;
                        }
                    }
                    break;
                }
                if (choice1.trapped == true)
                {
                    Random randomTrap = new Random();
                    int index = randomTrap.Next(Traps.Count);
                    Console.Clear();
                    Console.WriteLine("OHHH NO!! YOU HAVE FALL INTO A TRAP!");
                    Console.WriteLine("");
                    Console.WriteLine("(press a key to proceed :( )");
                    Console.ReadKey(true);
                    Traps[index].CastTrap(choice1, map);
                    choice1.trapped = false;
                }
        
                ///Decrease Stun points
                if (Player1.Party[0].stunned > 0)
                {
                    Player1.Party[0].stunned--;
                }
                if (Player1.Party[1].stunned > 0)
                {
                    Player1.Party[1].stunned--;
                }
                if (Player1.Party[2].stunned > 0)
                {
                    Player1.Party[2].stunned--;
                }
                PassTurn(map, nameofP1, choice1);

                ///check if he's mana is at the maximum amount
                if (Player1.Party[0].mana < 20)
                {
                    Player1.Party[0].mana++;
                }
                if (Player1.Party[1].mana < 20)
                {
                    Player1.Party[1].mana++;
                }
                if (Player1.Party[2].mana < 20)
                {
                    Player1.Party[2].mana++;
                }
                Player1.turn = false;
                Player2.turn = true;
                continue;
            }
            while (Player2.turn == true)
            {
                Console.Clear();
                Console.WriteLine($"{nameofP2} IS YOUR TURN!");
                Hero.DisplayList2(Player2.Party, $"            {nameofP2}'s Party!", map);
                Hero choice2 = Player.GetPlayerChoice(Player2.Party);
                ConsoleKeyInfo action;
                action = GetAction(map, nameofP2, choice2);
                while (true)
                {
                    if (action.KeyChar == 'w')
                    {
                        if (map[choice2.location[0] - 1, choice2.location[1]] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                        if (map[choice2.location[0] - 1, choice2.location[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[choice2.location[0], choice2.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice2.location[0] - 1, choice2.location[1]] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice2.moveup(choice2.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice2.location[0], choice2.location[1]] = choice2.id;
                            //add new position to the log
                            choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                            choice2.trapped = true;
                            break;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveup(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                        break;

                    }
                    if (action.KeyChar == 'W')
                    {
                        if (map[choice2.location[0] - 1, choice2.location[1]] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                        if (map[choice2.location[0] - 1, choice2.location[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[choice2.location[0], choice2.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice2.location[0] - 1, choice2.location[1]] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice2.moveup(choice2.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice2.location[0], choice2.location[1]] = choice2.id;
                            //add new position to the log
                            choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                            choice2.trapped = true;
                            break;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveup(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'a')
                    {
                        if (map[choice2.location[0], choice2.location[1] - 1] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                        if (map[choice2.location[0], choice2.location[1] - 1] == 3)
                        {
                            // Make player current position equals 0
                            map[choice2.location[0], choice2.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice2.location[0], choice2.location[1] - 1] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice2.moveleft(choice2.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice2.location[0], choice2.location[1]] = choice2.id;
                            //add new position to the log
                            choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                            choice2.trapped = true;
                            break;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveleft(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                        break;

                    }
                    if (action.KeyChar == 'A')
                    {
                        if (map[choice2.location[0], choice2.location[1] - 1] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                        if (map[choice2.location[0], choice2.location[1] - 1] == 3)
                        {
                            // Make player current position equals 0
                            map[choice2.location[0], choice2.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice2.location[0], choice2.location[1] - 1] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice2.moveleft(choice2.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice2.location[0], choice2.location[1]] = choice2.id;
                            //add new position to the log
                            choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                            choice2.trapped = true;
                            break;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveleft(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                        break;

                    }
                    if (action.KeyChar == 's')
                    {
                        if (map[choice2.location[0] + 1, choice2.location[1]] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                        if (map[choice2.location[0] + 1, choice2.location[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[choice2.location[0], choice2.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice2.location[0] + 1, choice2.location[1]] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice2.movedown(choice2.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice2.location[0], choice2.location[1]] = choice2.id;
                            //add new position to the log
                            choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                            choice2.trapped = true;
                            break;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.movedown(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                        break;

                    }
                    if (action.KeyChar == 'S')
                    {
                        if (map[choice2.location[0] + 1, choice2.location[1]] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                        if (map[choice2.location[0] + 1, choice2.location[1]] == 3)
                        {
                            // Make player current position equals 0
                            map[choice2.location[0], choice2.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice2.location[0] + 1, choice2.location[1]] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice2.movedown(choice2.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice2.location[0], choice2.location[1]] = choice2.id;
                            //add new position to the log
                            choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                            choice2.trapped = true;
                            break;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.movedown(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'd')
                    {
                        if (map[choice2.location[0], choice2.location[1] + 1] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                        if (map[choice2.location[0], choice2.location[1] + 1] == 3)
                        {
                            // Make player current position equals 0
                            map[choice2.location[0], choice2.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice2.location[0], choice2.location[1] + 1] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice2.moveright(choice2.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice2.location[0], choice2.location[1]] = choice2.id;
                            //add new position to the log
                            choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                            //select a random trap in the trap list, to execute to the hero
                            choice2.trapped = true;
                            break;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveright(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'D')
                    {
                        if (map[choice2.location[0], choice2.location[1] + 1] == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't move in that direction mate! :/");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                        if (map[choice2.location[0], choice2.location[1] + 1] == 3)
                        {
                            // Make player current position equals 0
                            map[choice2.location[0], choice2.location[1]] = 0;
                            // Make Trap Position equals 0
                            map[choice2.location[0], choice2.location[1] + 1] = 0;
                            //execute move method, in case the trap does not affect your position
                            choice2.moveright(choice2.location, map);
                            //change the value in the map of the new position so the hero is displayed there
                            map[choice2.location[0], choice2.location[1]] = choice2.id;
                            //add new position to the log
                            choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                            choice2.trapped = true;
                            break;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveright(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        choice2.locationlog.Add(new int[] { choice2.location[0], choice2.location[1] });
                        break;
                    }
                    if (action.KeyChar == 'r')
                    {
                        if (choice2.mana >= choice2.cooldown)
                        {
                            choice2.mana = choice2.mana - choice2.cooldown;
                            Console.Clear();
                            Console.WriteLine($"Activating the Super of {choice2.name}!");
                            Console.WriteLine();
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey(true);
                            choice2.CastSpell(map, Player2, Player1);
                            Console.WriteLine();
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{choice2.name} >> I cant do that yet, I need at least {choice2.cooldown} points of mana to use my power!");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                    }
                    if (action.KeyChar == 'R')
                    {
                        if (choice2.mana >= choice2.cooldown)
                        {
                            choice2.mana = choice2.mana - choice2.cooldown;
                            Console.Clear();
                            Console.WriteLine($"Activating the Super of {choice2.name}!");
                            Console.WriteLine();
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey(true);
                            choice2.CastSpell(map, Player2, Player1);
                            Console.WriteLine();
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{choice2.name} >> I cant do that yet, I need at least {choice2.cooldown} points of mana to use my power!");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("(press a key to continue)");
                            Console.ReadKey(true);
                            action = GetAction(map, nameofP2, choice2);
                            continue;
                        }
                    }
                    break;
                }
                //check if he moved to a TRAP
                if (choice2.trapped == true)
                {
                    Random randomTrap = new Random();
                    int index = randomTrap.Next(Traps.Count);
                    Console.Clear();
                    Console.WriteLine("OHHH NO!! YOU HAVE FALL INTO A TRAP!");
                    Console.WriteLine("");
                    Console.WriteLine("(press a key to proceed :( )");
                    Console.ReadKey(true);
                    Traps[index].CastTrap(choice2, map);
                    choice2.trapped = false;
                }
                
                ///Decrease Stun points
                if (Player2.Party[0].stunned > 0)
                {
                    Player2.Party[0].stunned--;
                }
                if (Player2.Party[1].stunned > 0)
                {
                    Player2.Party[1].stunned--;
                }
                if (Player2.Party[2].stunned > 0)
                {
                    Player2.Party[2].stunned--;
                }
                Console.Clear();
                PassTurn(map, nameofP2, choice2);
                ///check if he's mana is at the maximum amount
                if (Player2.Party[0].mana < 20)
                {
                    Player2.Party[0].mana++;
                }
                if (Player2.Party[1].mana < 20)
                {
                    Player2.Party[1].mana++;
                }
                if (Player2.Party[2].mana < 20)
                {
                    Player2.Party[2].mana++;
                }
                Player1.turn = true;
                Player2.turn = false;
                continue;
            }
        }
    }
    //////////////////// Close game////////////////
    if (Selection.KeyChar == (char)13 && Player.play == false)
    {
        Console.Clear();
        Console.WriteLine("🔹🔷 I was not expecting that mate! but see you next time ...🔷🔹");
        Console.WriteLine();
        Console.WriteLine("press a key to exit game '-'");
        Console.ReadKey(true);
        break;
    }
    // int desire = int.Parse(Console.ReadLine());
    // if (desire == 1)
    // {
    //     Console.WriteLine("Letsss goooo!!!");
    //     Console.ReadKey();
    //     Console.WriteLine("Genering The Maze!!")
    //     int[,] maze = Maze.Generator();

    // }
    // if (desire == 2)
    // {
    //     Console.WriteLine("I was not expecting that mate! but see you next time");
    //     Console.ReadKey();
    //     break;
    // }
    // if (desire != 1 && desire != 2)
    // {
    //     Console.WriteLine("MARCEEEEEELLOOO WHAT you doing!!!!");
    //     Console.ReadKey();
}
