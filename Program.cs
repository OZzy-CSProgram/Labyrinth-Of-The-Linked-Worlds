using GameObjects;
using Spectre.Console;
while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to Labyrinth Of The Linked Worlds!!!");
    Console.WriteLine("");
    Console.WriteLine("1 to Play!! (lettsss gooo!)");
    Console.WriteLine("2 to Exit Game! (U scared? :'(");
    ConsoleKeyInfo decition = Console.ReadKey(true);
    if (decition.KeyChar == '1')
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Letsss goooo!!!");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Genering The Maze...");
        int[,] maze = Maze.Generator();
        Maze.PrintMaze(maze);
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("For The Player 1");
        Console.WriteLine("(The Player 1 should be the one playing, at this current time!)");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
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
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
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
        Console.Clear();
        Console.WriteLine("Lady Elara> Greetings " + nameofP1 + " we have summoned you, from your world because we need your help!");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
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
        while (decition2.KeyChar == '1')
        {
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
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("thats not a valid answer)");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("(press a key to continue)");
                Console.ReadKey(true);
                continue;
            }
            break;
        }
        if (decition2.KeyChar != '2' && decition2.KeyChar != '1')
        {
            Console.WriteLine("thats not a valid answer)");
        }
        if (decition2.KeyChar == '2')
        {
            Console.Clear();
            Console.WriteLine("Lady Elara> Thank you " + nameofP1 + " ! Your quest would be to go inside the Labyrinth of the Linked Worlds and get the Heart of Ebony, dont worry, you will not be alone, you will be leading a party of brave heroes of our kingdom, you can personally choose them!");
        }
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
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
        Player Player2 = new Player(nameofP1);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Player1.Greet();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(press a key to continue)");
        Console.ReadKey(true);
        Console.Clear();


    }
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
