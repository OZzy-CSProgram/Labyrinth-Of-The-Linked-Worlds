﻿using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using GameObjects;
using Spectre.Console;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using NAudio.Wave;
///Play music
string soundFilePath1 = "Mainsong.wav"; // Replace with your sound file path
Menu.Sound(soundFilePath1, "playloop");
while (true)
{
    ///////////////////      MAIN MENU         /////////////
    Console.Clear();
    Console.Beep();
    var GameGui1 = new Table()
    .BorderColor(Spectre.Console.Color.DeepSkyBlue3);
    var GameGui2 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.Blue);
    var GameGui3 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.Blue);
    var GameGui4 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.Blue);
    var GameGui5 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.Blue);
    var GameGui6 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.Blue);
    var GameGui7 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.Blue);
    var GameGui8 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.Blue);
    var GameGui9 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.OrangeRed1);
    var GameGui10 = new Table()
   .Border(TableBorder.Heavy)
   .BorderColor(Spectre.Console.Color.OrangeRed1);
    var GameGui11 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.OrangeRed1);
    var GameGui12 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.OrangeRed1);
    var GameGui13 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.OrangeRed1);
    var GameGui14 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.OrangeRed1);
    var GameGui15 = new Table()
    .Border(TableBorder.Heavy)
    .BorderColor(Spectre.Console.Color.OrangeRed1);


    Menu.GetMainMenu(GameGui1);

    ConsoleKeyInfo Selection = Console.ReadKey(true);
    if (Selection.KeyChar == 's' || Selection.Key == ConsoleKey.DownArrow)
    {
        if (Player.exit)
        {
            Player.exit = false;
            Player.play = true;
        }
        else if (Player.play)
        {
            Player.exit = true;
            Player.play = false;
        }
        continue;
    }
    if (Selection.KeyChar == 'w' || Selection.Key == ConsoleKey.UpArrow)
    {
        if (Player.exit)
        {
            Player.exit = false;
            Player.play = true;
        }
        else if (Player.play)
        {
            Player.exit = true;
            Player.play = false;
        }
        continue;
    }
    if (Selection.KeyChar == (char)13 && Player.play == true)
    {

        ///////////////////      PLAY- Choise   Setting Players   Generating Maze    ///////////////////////
        Player.inmainmenu = false;
        Console.Clear();
        Console.WriteLine("\n\n\n");
        Console.WriteLine("Letsss goooo!!!");
        var letsgo = Menu.CreateTable("[bold #c159ff]" + @"  _    ___ _____ _ ___    ___  ___  _ " + "\n" + @" | |  | __|_   _( ) __|  / __|/ _ \| |" + "\n" + @" | |__| _|  | | |/\__ \ | (_ | (_) |_|" + "\n" + @" |____|___| |_|   |___/  \___|\___/(_)" + "\n" + "[/]");
        AnsiConsole.Write(letsgo);

        Menu.KeyToContinue();
        Player.inmainmenu = true;
        string soundFilePath3 = "ElaraVibes.wav"; // Replace with your sound file path
        Menu.Sound(soundFilePath3, "playloop");



        Console.Clear();
        Console.WriteLine("\n\n\n");



        Player Player1 = new Player();
        while (true)
        {


            //Phase 1
            var ForP1 = Menu.CreateTable("[bold]FOR THE PLAYER 1[/]\n\n (The Player 1 should be the one playing, at this current time!)");
            AnsiConsole.Write(ForP1);
            Console.WriteLine("\n\n\n");


            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player1.skipselected = true;
                break;
            }

            Console.Clear();
            Console.WriteLine("\n\n\n");

            //Roleplay
            var RoleP11 = Menu.CreateTable("(you wake up in a stranger place!)");
            AnsiConsole.Write(RoleP11);



            Console.WriteLine("\n\n\n");
            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player1.skipselected = true;
                break;
            }

            Console.Clear();
            Console.WriteLine("\n\n\n");

            //More Roleplay

            var instance1 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance1.AddColumn(new TableColumn("")).HideHeaders();
            instance1.AddRow("[bold green]Lady Elara [/] [yellow]>[/] We have been waiting for you warrior!").Centered();
            instance1.AddRow("\n\n\n");

            var Stage1 = Menu.LadyElara(GameGui2, instance1);
            AnsiConsole.Write(Stage1);
            string soundFilePath = "elara2.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath, "play");

            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player1.skipselected = true;
                break;
            }

            break;
        }
        Console.Clear();
        var instance2 = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Spectre.Console.Color.Gold1);
        instance2.AddColumn(new TableColumn("")).HideHeaders();
        instance2.AddRow("[bold green]Lady Elara [/] [yellow]>[/] Wait, We have not properly meet, What is your name?!").Centered();
        instance2.AddRow("\n\n\n");
        var Stage2 = Menu.LadyElara(GameGui3, instance2);
        AnsiConsole.Write(Stage2);
        string soundFilePath4 = "Elara3.wav"; // Replace with your sound file path
        Menu.Sound(soundFilePath4, "play");

        Menu.KeyToContinue();

        Console.Clear();
        var EnterName = Menu.CreateTable("[bold #91e4f2] \nEnter your name to continue\n[/]");
        AnsiConsole.Write(EnterName);
        string nameofP1 = Player.intname(Console.ReadLine(), Player1);
        Console.WriteLine("\n\n\n");
        Player1.Greet();
        Console.WriteLine("\n\n\n");
        Console.WriteLine("\n\n\n");
        Menu.KeyToContinue();
        Console.Clear();
        while (!Player1.skipselected)// Not selected the option of skip this
        {
            Console.Clear();
            var instance3 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance3.AddColumn(new TableColumn("")).HideHeaders();
            instance3.AddRow("[bold green]Lady Elara [/] [yellow]>[/] Greetings, we have summoned you, from your world because we need your help!").Centered();
            instance3.AddRow("\n\n\n");
            var Stage3 = Menu.LadyElara(GameGui4, instance3);
            AnsiConsole.Write(Stage3);
            string soundFilePath5 = "Elara4.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath5, "play");
            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player1.skipselected = true;
                break;
            }

            Console.Clear();
            var instance4 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance4.AddColumn(new TableColumn("")).HideHeaders();
            instance4.AddRow("[bold green]Lady Elara [/] [yellow]>[/] I have had a vision of a future where darkness consumes all of my world,\nI have seen in my visions that the only way to stop the darkness from spreading\n is by using an ancient and lost artifact called The Heart of Ebony... \n \n\nA group of our elder mages has discover that this artifact lays in a dangerous place called \n'The Labyrinth of The Linked Worlds' So... Can you help us ?").Centered();
            instance4.AddRow("\n\n");
            instance4.AddRow("(   Choose your answer   )").Centered();
            instance4.AddRow("\n\n");
            instance4.AddRow("[bold red]1[/] Why me?").Centered();
            instance4.AddRow("[bold red]2[/] What exactly do you want me to do!").Centered();
            var Stage4 = Menu.LadyElara(GameGui5, instance4);
            AnsiConsole.Write(Stage4);
            string soundFilePath6 = "Elara5.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath6, "play");

            ConsoleKeyInfo decition2 = Console.ReadKey(true);
            while (decition2.KeyChar != '2' && decition2.KeyChar != '1')
            {
                Console.Clear();

                Console.WriteLine("thats not a valid answer)");
                Console.WriteLine("\n\n\n");
                Menu.KeyToContinue();

                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n");
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
                .BorderColor(Spectre.Console.Color.Gold1);
                instance5.AddColumn(new TableColumn("")).HideHeaders();
                instance5.AddRow("[bold green]Lady Elara [/] [yellow]>[/] I understand the question ,there is a prophecy about this labyrinth that says \n'Nobody in this world shall carry the Heart of Ebony out of the Labyrinth',\n and so we have decided to summon someone from another world to help us!\n \n... Can you?").Centered();
                instance5.AddRow("\n\n");
                instance5.AddRow("(   Choose your answer   )").Centered();
                instance5.AddRow("\n\n");
                instance5.AddRow("[bold red]2[/] What exactly do you want me to do!").Centered();
                var Stage5 = Menu.LadyElara(GameGui7, instance5);
                AnsiConsole.Write(Stage5);
                string soundFilePath7 = "Elara6.wav"; // Replace with your sound file path
                Menu.Sound(soundFilePath7, "play");
                decition2 = Console.ReadKey(true);

                while (decition2.KeyChar != '2')
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("(thats not a valid answer)");
                    Console.WriteLine("\n\n\n");
                    Menu.KeyToContinue();

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
            .BorderColor(Spectre.Console.Color.Gold1);
            instance6.AddColumn(new TableColumn("")).HideHeaders();
            instance6.AddRow("[bold green]Lady Elara [/] [yellow]>[/] Thank you  ! Your quest would be to go inside the Labyrinth of the Linked Worlds and get\n the Heart of Ebony, dont worry, you will not be alone, you will be leading \na party of brave heroes of our kingdom, you can personally choose them! ").Centered();
            instance6.AddRow("\n\n\n\n");
            var Stage6 = Menu.LadyElara(GameGui8, instance6);
            AnsiConsole.Write(Stage6);
            string soundFilePath8 = "Elara7.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath8, "play");
            Menu.KeyToContinue();

            Console.Clear();
            Console.WriteLine("\n\n\n");
            break;
        }
        //Phase 2
        Player Player2 = new Player();
        while (true)
        {


            var ForP2 = Menu.CreateTable("[bold]FOR THE PLAYER 2[/]\n\n (The Player 2 should be the one playing, at this current time!)");
            AnsiConsole.Write(ForP2);
            Console.WriteLine("\n\n\n");
            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player2.skipselected = true;
                break;
            }

            Console.Clear();
            var instance7 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance7.AddColumn(new TableColumn("")).HideHeaders();
            instance7.AddRow("[bold #580081]Lord Kaelg [/] [yellow]>[/] Oh, I see you are awake...   ! ").Centered();
            instance7.AddRow("\n\n\n\n");
            var Stage7 = Menu.LordKaeg(GameGui9, instance7);
            AnsiConsole.Write(Stage7);
            string soundFilePath9 = "K1.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath9, "play");
            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player2.skipselected = true;
                break;
            }

            Console.Clear();
            var instance8 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance8.AddColumn(new TableColumn("")).HideHeaders();
            instance8.AddRow("[bold #580081]Lord Kaelg [/] [yellow]>[/] Well let me inform you, you are now under my command, Traveler   ! ...").Centered();
            instance8.AddRow("\n\n\n\n");
            var Stage8 = Menu.LordKaeg(GameGui10, instance8);
            AnsiConsole.Write(Stage8);
            string soundFilePath10 = "K2.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath10, "play");
            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player2.skipselected = true;
                break;
            }

            Console.Clear();
            var instance9 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance9.AddColumn(new TableColumn("")).HideHeaders();
            instance9.AddRow("[bold #580081]Lord Kaelg [/] [yellow]>[/]  My apologies, I didn't meant to talk like that, but we have summoned you!,\n If you want to get back to your world you shall first serve me well!!!").Centered();
            instance9.AddRow("\n\n\n\n");
            var Stage9 = Menu.LordKaeg(GameGui11, instance9);
            AnsiConsole.Write(Stage9);
            string soundFilePath11 = "K3.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath11, "play");
            Menu.KeyToContinue();

            Console.Clear();
            break;
        }
        var instance10 = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Spectre.Console.Color.Gold1);
        instance10.AddColumn(new TableColumn("")).HideHeaders();
        instance10.AddRow("[bold #580081]Lord Kaelg [/] [yellow]>[/] Now tell me what your name is!").Centered();
        instance10.AddRow("\n\n\n\n");
        var Stage10 = Menu.LordKaeg(GameGui12, instance10);
        AnsiConsole.Write(Stage10);
        string soundFilePath12 = "K4.wav"; // Replace with your sound file path
        Menu.Sound(soundFilePath12, "play");

        Console.Clear();
        AnsiConsole.Write(EnterName);
        string nameofP2 = Player.intname(Console.ReadLine(), Player2);
        Player2.name = nameofP2;
        Console.WriteLine("\n\n\n");
        Player2.Greet();
        Console.WriteLine("\n\n\n");
        Console.WriteLine("\n\n\n");
        Menu.KeyToContinue();

        Console.Clear();
        while (!Player2.skipselected)
        {


            var instance11 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance11.AddColumn(new TableColumn("")).HideHeaders();
            instance11.AddRow("[bold #580081]Lord Kaelg [/] [yellow]>[/] Alright, Listen. I have been informed that my adversaries have summoned yet\n another Traveler to guide a host directly to a Labyrinth wherein lies a device capable of ruining my nefarious plan!\n\n\nI shall not remain with arms crossed, witnessing how they thwart my plans before my very eyes!").Centered();
            instance11.AddRow("\n\n\n\n");
            var Stage11 = Menu.LordKaeg(GameGui13, instance11);
            AnsiConsole.Write(Stage11);
            string soundFilePath13 = "K5.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath13, "play");
            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player2.skipselected = true;
                break;
            }

            Console.Clear();
            var instance12 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance12.AddColumn(new TableColumn("")).HideHeaders();
            instance12.AddRow("[bold #580081]Lord Kaelg [/] [yellow]>[/]  That is where you come into play; your objective shall be to obtain\n the aforementioned artifact before they do. Will you be able to accomplish this?").Centered();
            instance12.AddRow("\n\n\n\n");
            var Stage12 = Menu.LordKaeg(GameGui14, instance12);
            AnsiConsole.Write(Stage12);
            string soundFilePath14 = "K6.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath14, "play");
            if (Menu.CheckSkip(Menu.KeyAction()))
            {
                Console.Clear();
                Player2.skipselected = true;
                break;
            }

            Console.Clear();
            var instance13 = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Gold1);
            instance13.AddColumn(new TableColumn("")).HideHeaders();
            instance13.AddRow("[bold #580081]Lord Kaelg [/] [yellow]>[/]  'Tis decided then, good luck in the mision!").Centered();
            instance13.AddRow("\n\n\n\n");
            var Stage13 = Menu.LordKaeg(GameGui15, instance13);
            AnsiConsole.Write(Stage13);
            string soundFilePath15 = "K7.wav"; // Replace with your sound file path
            Menu.Sound(soundFilePath15, "play");
            Menu.KeyToContinue();
            break;
        }
        Console.Clear();
        //// MAP GENERATION
        Console.Clear();
        Console.WriteLine("\n\n\n");

        Console.WriteLine("Genering The Map...");
        int[,] map = Maze.Generator();

        var mapprinted = Maze.PrintMaze(map, "  Generated Map !");
        AnsiConsole.Write(mapprinted);



        Player.inmainmenu = false;
        Menu.KeyToContinue();
        Player.inmainmenu = true;
        string soundFilePath20 = "PlayingSong.wav"; // Replace with your sound file path
        Menu.Sound(soundFilePath20, "playloop");
        ///////////////////////////////////////////////////////////////////////////////////
        //////////////////////////      Heroes Selection         //////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        Console.Clear();
        var HeroSelectionTable = Menu.CreateTable("[bold #ff1e00] _____                        _____     _         _   _         [/]\n[bold #ff3800]|  |  |___ ___ ___ ___ ___   |   __|___| |___ ___| |_|_|___ ___ [/]\n[bold #ff4e00]|     | -_|  _| . | -_|_ -|  |__   | -_| | -_|  _|  _| | . |   |[/]\n[bold #ff6400]|__|__|___|_| |___|___|___|  |_____|___|_|___|___|_| |_|___|_|_|[/]\n");
        AnsiConsole.Write(HeroSelectionTable);
        Console.WriteLine("Allright, Lets proceed to the Heroes Selection");
        Console.WriteLine("\n\n\n");
        Menu.KeyToContinue();
        List<Hero> Heroes = new List<Hero>();
        Teleporter Mediv = new Teleporter(11, "🧙🏻‍♂️", "Mediv The Guardian", "A powerfull mage with the magical power \n of teleporting to a random position in the maze!", /*health*/10, /*attack*/6, /*speed*/1, /*mana*/0, /*superreq*/4, /*toughness*/ 35, map);            ///Mage
        Heroes.Add(Mediv);
        WallBreaker Eledron = new WallBreaker(13, "👳‍♂️", "Eledron The WallBreaker", "A strong Dwarv with a big Hammer\n He has got the ability to break walls!",  /*health*/16, /*attack*/4, /*speed*/1, /*mana*/0, /*superreq*/5, /*toughness*/45, map);                    //Wallbreaker
        Heroes.Add(Eledron);
        Jumper Monkinho = new Jumper(15, "🐵", "Monkinho The Jumper", "A monkey with the amazing ability of\n jumping throught a walls \n ", /*health*/12, /*attack*/5, /*speed*/1, /*mana*/0, /*superreq*/3, /*toughness*/25, map);         //Monkey
        Heroes.Add(Monkinho);
        Switcher Warlus = new Switcher(17, "🧞", "Warlus The Genius", "A Genius with the great power of,\n switching position with an enemy hero selected!", /*health*/10, /*attack*/5, /*speed*/1, /*mana*/0, /*superreq*/4,/*toughness*/30, map);                       ///switcher
        Heroes.Add(Warlus);
        Witcher Galia = new Witcher(19, "👹", "Galia The Witch", "A tenebrous witch with the dangerous power,\n of paralyzing the enemy hero selected!", /*health*/9, /*attack*/7, /*speed*/1, /*mana*/0, /*superreq*/6,/*toughness*/15, map);                              ///witch
        Heroes.Add(Galia);
        Manner Elymnis = new Manner(21, "👽", "Elymnis The Creator", "One of the first mages that used mana,\nas a supply of energy, she can remove 3 points\nof mana to the selected enemy hero and transfer it\nto a random player in the host!", /*health*/13, /*attack*/4, /*speed*/1, /*mana*/0, /*superreq*/4, /*toughness*/20, map);
        Heroes.Add(Elymnis);
        HeroSelectionTable.Centered();
        var menu = new Table();
        var player1party = new Table();
        var player2party = new Table();
        var HeroesAvalibles = new Table();
        menu.AddColumn(new TableColumn(player1party).Centered());
        menu.AddColumn(new TableColumn(HeroesAvalibles).Centered());
        menu.AddColumn(new TableColumn(player2party).Centered());
        while (Heroes.Count > 0)
        {
            ////Player 1 Choose
            Console.Clear();
            player1party = Hero.DisplayListP1(Player1.Party, $"[blue bold]{nameofP1}'s Party [/]");
            player2party = Hero.DisplayListP2(Player2.Party, $"[red bold]{nameofP2}'s Party [/]");

            // Hero choice1 = Player.GetPlayerChoice(Heroes);
            Hero choice1 = Hero.DisplayList3(player1party, Heroes, player2party, $"[yellow bold]{nameofP1}'s Turn    {Heroes.Count} Heroes Remaining[/]", "p1");
            if (choice1 != null)
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                Console.WriteLine($"{nameofP1} has chosen {choice1.name} !");
                Player1.Party.Add(choice1);
                Heroes.Remove(choice1);
                Console.WriteLine("\n\n\n");
                Menu.KeyToContinue();
            }
            if (Heroes.Count == 0)
            {
                break;
            }
            //// Player 2 Choose
            Console.Clear();
            AnsiConsole.Write(HeroSelectionTable);
            Console.WriteLine();
            player1party = Hero.DisplayListP1(Player1.Party, $"[blue bold]{nameofP1}'s Party [/]");
            player2party = Hero.DisplayListP2(Player2.Party, $"[red bold]{nameofP2}'s Party [/]");
            Menu.HeroSelection(player1party, HeroesAvalibles, player2party);
            Hero choice2 = Hero.DisplayList3(player1party, Heroes, player2party, $"[yellow bold]{nameofP1}'s Turn    {Heroes.Count} Heroes Remaining[/]", "p2");
            if (choice2 != null)
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                Console.WriteLine($"{nameofP2} has chosen {choice2.name}");
                Player2.Party.Add(choice2);
                Heroes.Remove(choice2);
                Console.WriteLine("\n\n");
                Menu.KeyToContinue();
            }
            continue;
        }
        Console.Clear();
        Console.WriteLine("\n\n");
        Menu.WriteTable("Heroes selection finished...\n\n\n The victory awaits, for the champion of the maze!");
        Menu.KeyToContinue();

        ///Heroes Spwans
        //                       Player 1
        //Spawn of First Hero
        Player1.Party[0].location[0] = 1;
        Player1.Party[0].location[1] = 1;
        int[] spawn1p1 = new int[] { 1, 1 };

        //Spawn of Second Hero
        Player1.Party[1].location[0] = 1;
        Player1.Party[1].location[1] = Maze.size / 2;
        int[] spawn2p1 = new int[] { 1, Maze.size / 2 };

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
        Player2.Party[1].location[1] = Maze.size / 2;
        int[] spawn2p2 = new int[] { Maze.size - 2, Maze.size / 2 };

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
        //TRAP SETTINGS
        Maze.GetPathes(map);
        Trap.SpawnTraps(map);//spawn 12 traps
        Trap.SpawnTraps(map);//spawn 12 more traps

        List<Trap> Traps = new List<Trap>();
        TReturn5 Return5 = new TReturn5();
        Traps.Add(Return5);
        TReturn10 Return10 = new TReturn10();
        Traps.Add(Return10);
        TLoseMana5 LoseMana5 = new TLoseMana5();
        Traps.Add(LoseMana5);
        TLoseHealth6 LoseHealth6 = new TLoseHealth6();
        Traps.Add(LoseHealth6);

        /////BOXES SETTINGS
        Box.SpawnBoxes(map);
        List<Box> Boxes = new List<Box>();
        MoreHealth health5 = new MoreHealth();
        Boxes.Add(health5);
        MoreMana mana5 = new MoreMana();
        Boxes.Add(mana5);
        MoreToughness toughness6 = new MoreToughness();
        Boxes.Add(toughness6);
        MoreSpeed speedx1 = new MoreSpeed();
        Boxes.Add(speedx1);

        Player1.turn = true;
        Player2.turn = false;
        while (true)
        {
            ///Check if victory condition is satisfaced
            if (Player1.HeroesInCentre == 3)
            {
                Player1.Victory = true;
                break;
            }
            if (Player2.HeroesInCentre == 3)
            {
                Player2.Victory = true;
                break;
            }


            //////Methods for Game Actions



            while (Player1.turn == true)
            {

                Console.Clear();
                Console.WriteLine($"{nameofP1} IS YOUR TURN!");
                Hero.DisplayList2(Player1.Party, $"            {nameofP1}'s Party!", map);
                if (Player1.Party.Count == 3)
                {
                    if (!(Player1.Party[0].stunned == 0 || Player1.Party[1].stunned == 0 || Player1.Party[2].stunned == 0))
                    {
                        Menu.WriteTable("You have no hero avalaible to select right now, Press a key to finish your turn...");
                        Console.ReadKey(true);
                        //Decrease Stun

                        Player1.Party[0].stunned--;
                        Player1.Party[1].stunned--;
                        Player1.Party[2].stunned--;

                        Player1.turn = false;
                        Player2.turn = true;
                        break;
                    }
                }
                else if (Player1.Party.Count == 2)
                {
                    if (!(Player1.Party[0].stunned == 0 || Player1.Party[1].stunned == 0))
                    {
                        Menu.WriteTable("You have no hero avalaible to select right now, Press a key to finish your turn...");
                        Console.ReadKey(true);
                        //Decrease Stun

                        Player1.Party[0].stunned--;
                        Player1.Party[1].stunned--;

                        Player1.turn = false;
                        Player2.turn = true;
                        break;
                    }
                }
                else if (Player1.Party.Count == 1)
                {
                    if (!(Player1.Party[0].stunned == 0))
                    {
                        Menu.WriteTable("You have no hero avalaible to select right now, Press a key to finish your turn...");
                        Console.ReadKey(true);
                        //Decrease Stun

                        Player1.Party[0].stunned--;

                        Player1.turn = false;
                        Player2.turn = true;
                        break;
                    }
                }
                Hero choice1 = Player.GetPlayerChoice(Player1.Party);
                ConsoleKeyInfo action;
                action = Player.GetAction(map, Player1, Player2, choice1);
                //method play



                Player.Play(action, choice1, Player1, Player2, map, Traps, Boxes);

                //victory condition
                if (Player1.HeroesInCentre == 3)
                {
                    Player1.Victory = true;
                    break;
                }
                ///Decrease restturns points before passing turn
                if (Player1.Party.Count == 3)
                {
                    if (Player1.Party[0].restturns > 0)
                    {
                        Player1.Party[0].restturns--;
                    }
                    if (Player1.Party[1].restturns > 0)
                    {
                        Player1.Party[1].restturns--;
                    }
                    if (Player1.Party[2].restturns > 0)
                    {
                        Player1.Party[2].restturns--;
                    }
                }
                if (Player1.Party.Count == 2)
                {
                    if (Player1.Party[0].restturns > 0)
                    {
                        Player1.Party[0].restturns--;
                    }
                    if (Player1.Party[1].restturns > 0)
                    {
                        Player1.Party[1].restturns--;
                    }
                }
                if (Player1.Party.Count == 1)
                {
                    if (Player1.Party[0].restturns > 0)
                    {
                        Player1.Party[0].restturns--;
                    }
                }
                ///Decrease Stun points before passing turn
                if (Player1.Party.Count == 3)
                {
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
                }
                if (Player1.Party.Count == 2)
                {
                    if (Player1.Party[0].stunned > 0)
                    {
                        Player1.Party[0].stunned--;
                    }
                    if (Player1.Party[1].stunned > 0)
                    {
                        Player1.Party[1].stunned--;
                    }
                }
                if (Player1.Party.Count == 1)
                {
                    if (Player1.Party[0].stunned > 0)
                    {
                        Player1.Party[0].stunned--;
                    }
                }

                ///HERO IS DEAD

                if (choice1.health == 0)
                {
                    map[choice1.location[0], choice1.location[1]] = 0;
                    choice1.location[0] = choice1.locationlog[0][0];
                    choice1.location[1] = choice1.locationlog[0][1];
                    map[choice1.location[0], choice1.location[1]] = choice1.id;

                    choice1.restturns = 10;

                }


                Player.PassTurn(map, nameofP1, choice1);

                ///check if he's mana is at the maximum amount
                if (Player1.Party.Count == 3)
                {
                    if (Player1.Party[0].mana < Player1.Party[0].cooldown)
                    {
                        Player1.Party[0].mana++;
                    }
                    if (Player1.Party[1].mana < Player1.Party[1].cooldown)
                    {
                        Player1.Party[1].mana++;
                    }
                    if (Player1.Party[2].mana < Player1.Party[2].cooldown)
                    {
                        Player1.Party[2].mana++;
                    }
                }
                if (Player1.Party.Count == 2)
                {
                    if (Player1.Party[0].mana < Player1.Party[0].cooldown)
                    {
                        Player1.Party[0].mana++;
                    }
                    if (Player1.Party[1].mana < Player1.Party[1].cooldown)
                    {
                        Player1.Party[1].mana++;
                    }
                }
                if (Player1.Party.Count == 1)
                {
                    if (Player1.Party[0].mana < Player1.Party[0].cooldown)
                    {
                        Player1.Party[0].mana++;
                    }
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


                ///check if all heroes are not stunned
                if (Player2.Party.Count == 3)
                {
                    if (!(Player2.Party[0].stunned == 0 || Player2.Party[1].stunned == 0 || Player2.Party[2].stunned == 0))
                    {
                        Console.WriteLine("You have no hero avalaible to select right now, Press a key to finish your turn...");
                        Console.ReadKey(true);
                        Player2.turn = false;
                        Player1.turn = true;
                        break;
                    }
                }
                else if (Player2.Party.Count == 2)
                {
                    if (!(Player2.Party[0].stunned == 0 || Player2.Party[1].stunned == 0))
                    {
                        Console.WriteLine("You have no hero avalaible to select right now, Press a key to finish your turn...");
                        Console.ReadKey(true);
                        Player2.turn = false;
                        Player1.turn = true;
                        break;
                    }
                }
                else if (Player2.Party.Count == 1)
                {
                    if (!(Player2.Party[0].stunned == 0))
                    {
                        Console.WriteLine("You have no hero avalaible to select right now, Press a key to finish your turn...");
                        Console.ReadKey(true);
                        Player2.turn = false;
                        Player1.turn = true;
                        break;
                    }
                }
                // keep it going
                Hero choice2 = Player.GetPlayerChoice(Player2.Party);
                ConsoleKeyInfo action;
                action = Player.GetAction(map, Player2, Player1, choice2);

                Player.Play(action, choice2, Player2, Player1, map, Traps, Boxes);

                //victory condition
                if (Player2.HeroesInCentre == 3)
                {
                    Player2.Victory = true;
                    break;
                }
                //Decrease Restturns
                if (Player2.Party.Count == 3)
                {
                    if (Player2.Party[0].restturns > 0)
                    {
                        Player2.Party[0].restturns--;
                    }
                    if (Player2.Party[1].restturns > 0)
                    {
                        Player2.Party[1].restturns--;
                    }
                    if (Player2.Party[2].restturns > 0)
                    {
                        Player2.Party[2].restturns--;
                    }
                }
                if (Player2.Party.Count == 2)
                {
                    if (Player2.Party[0].restturns > 0)
                    {
                        Player2.Party[0].restturns--;
                    }
                    if (Player2.Party[1].restturns > 0)
                    {
                        Player2.Party[1].restturns--;
                    }
                }
                if (Player2.Party.Count == 1)
                {
                    if (Player2.Party[0].restturns > 0)
                    {
                        Player2.Party[0].restturns--;
                    }
                }
                ///Decrease Stun points
                if (Player2.Party.Count == 3)
                {
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
                }
                if (Player2.Party.Count == 2)
                {
                    if (Player2.Party[0].stunned > 0)
                    {
                        Player2.Party[0].stunned--;
                    }
                    if (Player2.Party[1].stunned > 0)
                    {
                        Player2.Party[1].stunned--;
                    }
                }
                if (Player2.Party.Count == 1)
                {
                    if (Player2.Party[0].stunned > 0)
                    {
                        Player2.Party[0].stunned--;
                    }
                }

                ///HERO IS DEAD

                if (choice2.health == 0)
                {
                    map[choice2.location[0], choice2.location[1]] = 0;
                    choice2.location[0] = choice2.locationlog[0][0];
                    choice2.location[1] = choice2.locationlog[0][1];
                    map[choice2.location[0], choice2.location[1]] = choice2.id;
                    choice2.restturns = 10;
                }

                Console.Clear();
                Player.PassTurn(map, nameofP2, choice2);


                ///check if he's mana is at the maximum amount
                if (Player2.Party.Count == 3)
                {
                    if (Player2.Party[0].mana < Player2.Party[0].cooldown)
                    {
                        Player2.Party[0].mana++;
                    }
                    if (Player2.Party[1].mana < Player2.Party[1].cooldown)
                    {
                        Player2.Party[1].mana++;
                    }
                    if (Player2.Party[2].mana < Player2.Party[2].cooldown)
                    {
                        Player2.Party[2].mana++;
                    }
                }
                if (Player2.Party.Count == 2)
                {
                    if (Player2.Party[0].mana < Player2.Party[0].cooldown)
                    {
                        Player2.Party[0].mana++;
                    }
                    if (Player2.Party[1].mana < Player2.Party[1].cooldown)
                    {
                        Player2.Party[1].mana++;
                    }
                }
                if (Player2.Party.Count == 1)
                {
                    if (Player2.Party[0].mana < Player2.Party[0].cooldown)
                    {
                        Player2.Party[0].mana++;
                    }
                }
                Player1.turn = true;
                Player2.turn = false;
                continue;
            }
        }
        //Out of Game PlayerTurns WhileTrue
        if (Player1.Victory == true)
        {
            Console.Clear();
            Menu.WriteTable($"{nameofP1.ToUpper()}'s VICTORY\n\nCongratulations!!!!! YOU'VE WONNNN!! {nameofP1.ToUpper()}");
            Console.ReadKey(true);
            continue;
        }
        if (Player2.Victory == true)
        {
            Console.Clear();
            Menu.WriteTable($"{nameofP1.ToUpper()}'s VICTORY\n\nCongratulations!!!!! YOU'VE WONNNN!! {nameofP1.ToUpper()}");
            Console.ReadKey(true);
            continue;
        }
    }
    //////////////////// Close game////////////////
    if (Selection.KeyChar == (char)13 && Player.play == false)
    {
        Console.Clear();
        Menu.WriteTable("🔹🔷 I was not expecting that mate! but see you next time ...🔷🔹");
        Menu.WriteTable("press a key to exit game '-'");
        Console.ReadKey(true);
        break;
    }
}