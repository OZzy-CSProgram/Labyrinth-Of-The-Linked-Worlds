using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using GameObjects;
using Spectre.Console;
while (true)
{
    ///////////////////      MAIN MENU         /////////////
    Console.Clear();
    Console.WriteLine("Welcome to Labyrinth Of The Linked Worlds!!!");

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("1  Play");
    Console.WriteLine("(Letsss gooo!)");

    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("2 Exit Game!");
    Console.WriteLine("(U scared? :'(  )");

    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("(Type 1 or 2 according to what you want to do!)");

    ConsoleKeyInfo decition = Console.ReadKey(true);
    if (decition.KeyChar == '1')
    {

        ///////////////////      PLAY- Choise   Setting Players   Generating Maze    ///////////////////////

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Letsss goooo!!!");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        //// MAP GENERATION
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Genering The Map...");
        int[,] map = Maze.Generator();

        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        ////Clear//////
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("For The Player 1");
        Console.WriteLine("(The Player 1 should be the one playing, at this current time!)");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);

        ////Clear//////
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(you wake up in a stranger place!)");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        ////Clear//////
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Lady Elara> We have been waiting for you warrior!");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        ////Clear//////
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Lady Elara> Wait, We have not properly meet, What is your name?!");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write("(Enter your name to continue) : ");
        string nameofP1 = Player.intname(Console.ReadLine());
        Player Player1 = new Player(nameofP1);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Player1.Greet();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        ////Clear//////
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Lady Elara> Greetings " + nameofP1 + " we have summoned you, from your world because we need your help!");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        ////Clear//////
        Console.Clear();

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Lady Elara> I have had a vision of a future where darkness consumes all of my world, I have seen in my visions that the only way to stop the darkness from spreading is by using an ancient and lost artifact called The Heart of Ebony... ");
        Console.WriteLine("Lady Elara> A group of our elder mages has discover that this artifact lays in a dangerous place called 'The Labyrinth of The Linked Worlds' So... Can you help us " + nameofP1 + " ?");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(Choose your answer)");
        Console.WriteLine("");
        Console.WriteLine("1 Why me?");
        Console.WriteLine("2 What exactly do you want me to do!");
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
            Console.WriteLine("Lady Elara> I have had a vision of a future where darkness consumes all of my world, I have seen in my visions that the only way to stop the darkness from spreading is by using an ancient and lost artifact called The Heart of Ebony... ");
            Console.WriteLine("Lady Elara> A group of our elder mages has discover that this artifact lays in a dangerous place called 'The Labyrinth of The Linked Worlds' So... Can you help us " + nameofP1 + " ?");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("(Choose your answer)");
            Console.WriteLine();
            Console.WriteLine("1 Why me?");
            Console.WriteLine("2 What exactly do you want me to do!");
            decition2 = Console.ReadKey(true);

            if (decition2.KeyChar == '2' || decition2.KeyChar == '1')
            {
                break;
            }
        }
        while (decition2.KeyChar == '1')
        {
            ////Clear//////
            Console.Clear();
            Console.WriteLine("Lady Elara> I understand the question " + nameofP1 + " ,there is a prophecy about this labyrinth that says 'Nobody in this world shall carry the Heart of Ebony out of the Labyrinth', and so we have decided to summon someone from another world to help us! ... Can you?");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("(Choose your answer)");
            Console.WriteLine("");
            Console.WriteLine("2 What exactly do you want me to do!");
            decition2 = Console.ReadKey(true);

            if (decition2.KeyChar != '2')
            {
                ////Clear//////
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("(thats not a valid answer)");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("(press a key to continue)");
                Console.ReadKey(true);
                ////Clear//////
                Console.Clear();
                Console.WriteLine("Lady Elara> I understand the question " + nameofP1 + " ,there is a prophecy about this labyrinth that says 'Nobody in this world shall carry the Heart of Ebony out of the Labyrinth', and so we have decided to summon someone from another world to help us! ... Can you?");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("(Choose your answer)");
                Console.WriteLine("");
                Console.WriteLine("2 What exactly do you want me to do!");
                continue;
            }
            break;
        }
        if (decition2.KeyChar == '2')
        {
            Console.Clear();
            Console.WriteLine("Lady Elara> Thank you " + nameofP1 + " ! Your quest would be to go inside the Labyrinth of the Linked Worlds and get the Heart of Ebony, dont worry, you will not be alone, you will be leading a party of brave heroes of our kingdom, you can personally choose them!");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        Console.Clear();

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("For The Player 2");
        Console.WriteLine("(The Player 2 should be the one playing, at this current time!)");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Lady Elara> Wait, We have not properly meet, What is your name?!");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write("(Enter your name to continue) : ");
        string nameofP2 = Player.intname(Console.ReadLine());
        Player Player2 = new Player(nameofP2);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Player2.Greet();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        Console.Clear();
        ///////////////////////////////////////////////////////////////////////////////////
        //////////////////////////      Heroes Selection         //////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
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
        Teleporter Mediv = new Teleporter(11, "Mediv The Guardian", "A powerfull mage with the magical power of teleporting to a random position in the maze!", 110, 140, 10, map);
        Heroes.Add(Mediv);
        WallBreaker Eledron = new WallBreaker(13, "Eledron The WallBreaker", "A strong Dwarv with a big Hammer,He has got the ability to break walls!", 160, 90, 10, map);
        Heroes.Add(Eledron);

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
        Hero.DisplayList(Heroes);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        while (Heroes.Count > 0)
        {
            ////Player 1 Choose
            Console.WriteLine($"{nameofP1} , ITS YOUR TURN! Write the number of the hero you want for your party !!!");
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
            Hero.DisplayList(Heroes);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{nameofP2} , ITS YOUR TURN! Write the number of the hero you want for your party !!!");
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
        // //Spawn of Second Hero
        // Player1.Party[1].location[0] = 1;
        // Player1.Party[1].location[1] = Maze.size / 2 + 1;
        // int[] spawn2p1 = new int[] { 1, Maze.size / 2 + 1 };
        // //Spawn of Third Hero
        // Player1.Party[2].location[0] = 1;
        // Player1.Party[2].location[1] = Maze.size - 1;
        // int[] spawn3p1 = new int[] { 1, Maze.size - 1 };
        //                       Player 2
        //Spawn of First Hero
        Player2.Party[0].location[0] = Maze.size - 2;
        Player2.Party[0].location[1] = 1;
        int[] spawn1p2 = new int[] { Maze.size - 2, 1 };
        // //Spawn of Second Hero
        // Player2.Party[1].location[0] = Maze.size - 1;
        // Player2.Party[1].location[1] = Maze.size/2 + 1;
        // int[] spawn2p2 = new int[] { Maze.size - 1, Maze.size / 2 + 1 };
        // //Spawn of Third Hero
        // Player2.Party[2].location[0] = Maze.size - 1;
        // Player2.Party[2].location[1] = Maze.size - 1;
        // int[] spawn3p2 = new int[] { Maze.size - 1, Maze.size - 1 };

        //                 Printing Players in the Map
        //Player1
        switch (Player1.Party[0].GetType().Name)
        {
            case nameof(Teleporter): // wall
                map[spawn1p1[0], spawn1p1[1]] = Mediv.id;
                break;
            case nameof(WallBreaker): // wall
                map[spawn1p1[0], spawn1p1[1]] = Eledron.id;
                break;
            default:
                break;
        }
        // switch (Player1.Party[1].GetType().Name)
        // {
        //     case nameof(Teleporter): // wall
        //         map[spawn2p1[0], spawn2p1[1]] = 11;
        //         break;
        //     case nameof(WallBreaker): // wall
        //         map[spawn2p1[0], spawn2p1[1]] = 13;
        //         break;
        //     default:
        //         break;
        // }
        // switch (Player1.Party[2].GetType().Name)
        // {
        //     case nameof(Teleporter): // wall
        //         map[spawn3p1[0], spawn3p1[1]] = 11;
        //         break;
        //     case nameof(WallBreaker): // wall
        //         map[spawn3p1[0], spawn3p1[1]] = 13;
        //         break;
        //     default:
        //         break;
        // }
        /// Player 2
        switch (Player2.Party[0].GetType().Name)
        {
            case nameof(Teleporter): // wall
                map[spawn1p2[0], spawn1p2[1]] = Mediv.id;
                break;
            case nameof(WallBreaker): // wall
                map[spawn1p2[0], spawn1p2[1]] = Eledron.id;
                break;
            default:
                break;
        }
        // switch (Player2.Party[1].GetType().Name)
        // {
        //     case nameof(Teleporter): // wall
        //         map[spawn2p2[0], spawn2p2[1]] = 11;
        //         break;
        //     case nameof(WallBreaker): // wall
        //         map[spawn2p2[0], spawn2p2[1]] = 13;
        //         break;
        //     default:
        //         break;
        // }
        // switch (Player2.Party[2].GetType().Name)
        // {
        //     case nameof(Teleporter): // wall
        //         map[spawn3p2[0], spawn3p2[1]] = 11;
        //         break;
        //     case nameof(WallBreaker): // wall
        //         map[spawn3p2[0], spawn3p2[1]] = 13;
        //         break;
        //     default:
        //         break;
        // }
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
                    Maze.PrintMaze(map, $" {name}'s Turn!                  Hero ➧           {hero.name}    Selected! ");
                    //Console.WriteLine("╔════════════════╦══════════════════╦══════════════════╦═══════════════════╦══════════════════════╗");
                    Console.WriteLine("║ W > to move up ║ A > to move left ║ S > to move down ║ D > to move right ║ R > to activate Super ║");
                    Console.WriteLine("╚════════════════╩══════════════════╩══════════════════╩═══════════════════╩═══════════════════════╝");
                    action = Console.ReadKey(true);

                    if (action.KeyChar == 'w' || action.KeyChar == 'W' || action.KeyChar == 'a' || action.KeyChar == 'A' || action.KeyChar == 's' || action.KeyChar == 'S' ||action.KeyChar == 'd' || action.KeyChar == 'D')
                    {
                        break;
                    }
                }
                return action;
            }
            static ConsoleKeyInfo CantMoveThere(int[,] map, string name, Hero hero)
            {
                Console.Clear();
                Console.WriteLine("You can't move in that direction mate! :/");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("(press a key to continue)");
                Console.ReadKey(true);
                Console.Clear();
                Maze.PrintMaze(map, $" {name}'s Turn!                  Hero ➧           {hero.name}    Selected! ");
                //Console.WriteLine("╔════════════════╦══════════════════╦══════════════════╦═══════════════════╦══════════════════════╗");
                Console.WriteLine("║ W > to move up ║ A > to move left ║ S > to move down ║ D > to move right ║ R > to activate Super ║");
                Console.WriteLine("╚════════════════╩══════════════════╩══════════════════╩═══════════════════╩═══════════════════════╝");
                ConsoleKeyInfo action = Console.ReadKey(true);
                action = ValidPosition(action, map, name, hero);
                return action;
            }
            Maze.PrintMaze(map, $" {nameofP1}'s Turn! ");
            while (Player1.turn == true)
            {
                Console.Clear();
                Console.WriteLine($"{nameofP1} IS YOUR TURN! Select the player in your party you want to play with!");
                Console.WriteLine($"            {nameofP1}'s Party!");
                Hero.DisplayList(Player1.Party);
                Hero choice1 = Player.GetPlayerChoice(Player1.Party);
                Console.WriteLine("Hero selected! Correctly");
                Console.WriteLine("(press a key to continue)");
                Console.ReadKey(true);
                Console.Clear();
                Maze.PrintMaze(map, $" {nameofP1}'s Turn!!!                  Hero ➧           {choice1.name}    Selected! ");
                //Console.WriteLine("╔════════════════╦══════════════════╦══════════════════╦═══════════════════╦══════════════════════╗");
                Console.WriteLine("║ W > to move up ║ A > to move left ║ S > to move down ║ D > to move right ║ R > to activate Super ║");
                Console.WriteLine("╚════════════════╩══════════════════╩══════════════════╩═══════════════════╩═══════════════════════╝");
                ConsoleKeyInfo action = Console.ReadKey(true);
                action = ValidPosition(action, map, nameofP1, choice1);
                while (true)
                {
                    if (action.KeyChar == 'w')
                    {
                        if (map[choice1.location[0] - 1, choice1.location[1]] == 1)
                        {
                            action = CantMoveThere(map, nameofP1, choice1);
                            continue;

                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveup(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        break;
                    }
                    if (action.KeyChar == 'W')
                    {
                        if (map[choice1.location[0] - 1, choice1.location[1]] == 1)
                        {
                            action = CantMoveThere(map, nameofP1, choice1);
                            continue;

                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveup(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        break;
                    }
                    if (action.KeyChar == 'a')
                    {
                        if (map[choice1.location[0], choice1.location[1] - 1] == 1)
                        {
                            action = CantMoveThere(map, nameofP1, choice1);
                            continue;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveleft(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        break;
                    }
                    if (action.KeyChar == 'A')
                    {
                        if (map[choice1.location[0], choice1.location[1] - 1] == 1)
                        {
                            action = CantMoveThere(map, nameofP1, choice1);
                            continue;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveleft(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        break;
                    }
                    if (action.KeyChar == 's')
                    {
                        if (map[choice1.location[0] + 1, choice1.location[1]] == 1)
                        {
                            action = CantMoveThere(map, nameofP1, choice1);
                            continue;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.movedown(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        break;
                    }
                    if (action.KeyChar == 'S')
                    {
                        if (map[choice1.location[0] + 1, choice1.location[1]] == 1)
                        {
                            action = CantMoveThere(map, nameofP1, choice1);
                            continue;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.movedown(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        break;
                    }
                    if (action.KeyChar == 'd')
                    {
                        if (map[choice1.location[0], choice1.location[1] + 1] == 1)
                        {
                            action = CantMoveThere(map, nameofP1, choice1);
                            continue;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveright(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        break;
                    }
                    if (action.KeyChar == 'D')
                    {
                        if (map[choice1.location[0], choice1.location[1] + 1] == 1)
                        {
                            action = CantMoveThere(map, nameofP1, choice1);
                            continue;
                        }
                        map[choice1.location[0], choice1.location[1]] = 0;
                        choice1.moveright(choice1.location, map);
                        map[choice1.location[0], choice1.location[1]] = choice1.id;
                        break;
                    }
                    if (action.KeyChar == 'r')
                    {
                    }
                    if (action.KeyChar == 'R')
                    {
                    }
                    break;
                }
                Console.Clear();
                Maze.PrintMaze(map, $" {nameofP1}, Press a key to finish your Turn! ");
                //Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"║ {nameofP1} Has moved {choice1.name} to [{choice1.location[0]},{choice1.location[1]}] ║      Press a Key to finish your turn");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.ReadKey(true);
                Player1.turn = false;
                Player2.turn = true;
                continue;
            }
            while (Player2.turn == true)
            {
                Console.Clear();
                Console.WriteLine($"{nameofP2} IS YOUR TURN! Select the player in your party you want to play with!");
                Console.WriteLine($"            {nameofP2}'s Party!");
                Hero.DisplayList(Player2.Party);
                Hero choice2 = Player.GetPlayerChoice(Player2.Party);
                Console.WriteLine("Hero selected! Correctly");
                Console.WriteLine("(press a key to continue)");
                Console.ReadKey(true);
                Console.Clear();
                Maze.PrintMaze(map, $" {nameofP2}'s Turn!                  Hero ➧           {choice2.name}    Selected! ");
                //Console.WriteLine("╔════════════════╦══════════════════╦══════════════════╦═══════════════════╦══════════════════════╗");
                Console.WriteLine("║ W > to move up ║ A > to move left ║ S > to move down ║ D > to move right ║ R > to activate Super ║");
                Console.WriteLine("╚════════════════╩══════════════════╩══════════════════╩═══════════════════╩═══════════════════════╝");
                ConsoleKeyInfo action = Console.ReadKey(true);
                action = ValidPosition(action, map, nameofP2, choice2);


                while (true)
                {
                    if (action.KeyChar == 'w')
                    {
                        if (map[choice2.location[0] - 1, choice2.location[1]] == 1)
                        {
                            action = CantMoveThere(map, nameofP2, choice2);
                            continue;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveup(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        break;
                    }
                    if (action.KeyChar == 'W')
                    {
                        if (map[choice2.location[0] - 1, choice2.location[1]] == 1)
                        {
                            action = CantMoveThere(map, nameofP2, choice2);
                            continue;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveup(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        break;
                    }
                    if (action.KeyChar == 'a')
                    {
                        if (map[choice2.location[0], choice2.location[1] - 1] == 1)
                        {
                            action = CantMoveThere(map, nameofP2,choice2);
                            continue;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveleft(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        break;
                    }
                    if (action.KeyChar == 'A')
                    {
                        if (map[choice2.location[0], choice2.location[1] - 1] == 1)
                        {
                            action = CantMoveThere(map, nameofP2,choice2);
                            continue;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveleft(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        break;
                    }
                    if (action.KeyChar == 's')
                    {
                        if (map[choice2.location[0] + 1, choice2.location[1]] == 1)
                        {
                            action = CantMoveThere(map, nameofP2,choice2);
                            continue;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.movedown(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        break;
                    }
                    if (action.KeyChar == 'S')
                    {
                        if (map[choice2.location[0] + 1, choice2.location[1]] == 1)
                        {
                            action = CantMoveThere(map, nameofP2,choice2);
                            continue;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.movedown(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        break;
                    }
                    if (action.KeyChar == 'd')
                    {
                        if (map[choice2.location[0], choice2.location[1] + 1] == 1)
                        {
                            action = CantMoveThere(map, nameofP2,choice2);
                            continue;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveright(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        break;
                    }
                    if (action.KeyChar == 'D')
                    {
                        if (map[choice2.location[0], choice2.location[1] + 1] == 1)
                        {
                            action = CantMoveThere(map, nameofP2,choice2);
                            continue;
                        }
                        map[choice2.location[0], choice2.location[1]] = 0;
                        choice2.moveright(choice2.location, map);
                        map[choice2.location[0], choice2.location[1]] = choice2.id;
                        break;
                    }
                    if (action.KeyChar == 'r')
                    {
                    }
                    if (action.KeyChar == 'R')
                    {
                    }
                    break;
                }
                Console.Clear();
                Maze.PrintMaze(map, $" {nameofP2}, Press a key to finish your Turn! ");
                //Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine($" {nameofP1} Has moved {choice2.name} to [{choice2.location[0]},{choice2.location[1]}] ║      Press a Key to finish your turn");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.ReadKey(true);
                Player2.turn = false;
                Player1.turn = true;
                continue;
            }
        }
        //////////////////// Close game////////////////
        if (decition.KeyChar == '2')
        {
            Console.WriteLine("I was not expecting that mate! but see you next time");
            Console.ReadKey();
            break;
        }
        if (decition.KeyChar != '2' && decition.KeyChar != '1')
        {
            Console.WriteLine("MARCEEEEEELLOOO WHAT you doing!!!!");
            Console.ReadKey();
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
}