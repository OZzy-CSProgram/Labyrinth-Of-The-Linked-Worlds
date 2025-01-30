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
        public int speed;
        public int maxspeed = 1;
        public string icon;
        public int health;
        public int attack;
        public int mana;
        public bool haveKey;
        public int restturns;
        public bool trapped = false;
        public int stunned = 0;
        public int toughness;
        public int cooldown;

        public int actionsRemaining = 5;
        public List<int[]> locationlog = new List<int[]>();
        public int[,] map;
        public int[] location = new int[2];
        /////constructor////
        public Hero(int id, string icon, string name, string info, int health, int attack, int speed, int mana, int cooldown, int toughness, int[,] maze)
        {
            this.id = id;
            this.icon = icon;
            this.name = name;
            this.info = info;
            this.health = health;
            this.attack = attack;
            this.speed = speed;
            this.mana = mana;
            this.cooldown = cooldown;
            this.toughness = toughness;
            this.map = maze;

        }
        /////methods/////

        public int Movenumber(Hero hero, int speed, int[,] map, string dir)
        {
            if (dir == "up")
            {
                for (int i = 1; i <= speed; i++)
                {
                    if (map[hero.location[0] - i, hero.location[1]] == 1)
                    {
                        return i - 1;
                    }
                    if (map[hero.location[0] - i, hero.location[1]] != 0)
                    {
                        return i;
                    }
                    // if (map[hero.location[0] - i, hero.location[1]] == 0 && (map[hero.location[0] - i, hero.location[1] - 1] == 0 || map[hero.location[0] - i, hero.location[1] + 1] == 0 ))
                    // {
                    //     return i;
                    // }
                }
            }
            else if (dir == "down")
            {
                for (int i = 1; i <= speed; i++)
                {
                    if (map[hero.location[0] + i, hero.location[1]] == 1)
                    {
                        return i - 1;
                    }
                    if (map[hero.location[0] + i, hero.location[1]] != 0)
                    {
                        return i;
                    }
                }
            }
            else if (dir == "left")
            {
                for (int i = 1; i <= speed; i++)
                {
                    if (map[hero.location[0], hero.location[1] - i] == 1)
                    {
                        return i - 1;
                    }
                    if (map[hero.location[0], hero.location[1] - i] != 0)
                    {
                        return i;
                    }
                }
            }
            else if (dir == "right")
            {
                for (int i = 1; i <= speed; i++)
                {
                    if (map[hero.location[0], hero.location[1] + i] == 1)
                    {
                        return i - 1;
                    }
                    if (map[hero.location[0], hero.location[1] + i] != 0)
                    {
                        return i;
                    }
                }
            }


            return speed;

        }

        public Hero GetHeroById(Player player, Player otherplayer, int id)
        {
            for (int i = 0; i < player.Party.Count; i++)
            {
                if (player.Party[i].id == id)
                {
                    return player.Party[i];
                }
            }
            for (int i = 0; i < otherplayer.Party.Count; i++)
            {
                if (otherplayer.Party[i].id == id)
                {
                    return otherplayer.Party[i];
                }
            }
            //esto nunca pasa es para q no me de Not all codes return a value error;
            return player.Party[0];
        }
        public bool isHeroInParty(Player player, Hero hero)
        {
            for (int i = 0; i < player.Party.Count; i++)
            {
                if (player.Party[i].id == hero.id)
                {
                    return true;
                }
            }
            return false;
        }
        public void moveright(Hero hero, Player player, Player otherplayer, int[,] map)
        {
            while (true)
            {
                int movenumber = Movenumber(hero, hero.speed, map, "right");
                if (movenumber == 0)
                {
                    Console.Clear();
                    Menu.HeroDialogue(hero, "I can not move in that direction mate!\n\n");
                    Menu.KeyToContinue();
                    break;
                }
                else if (movenumber != 0)
                {
                    int newposition = map[hero.location[0], hero.location[1] + movenumber];

                    if (newposition == 3)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[1] += movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.trapped = true;
                        hero.actionsRemaining--;

                    }
                    //moving to a player
                    else if (newposition == 11 || newposition == 13 || newposition == 15 || newposition == 17 || newposition == 19 || newposition == 21)
                    {
                        Hero herotomove = GetHeroById(player, otherplayer, newposition);
                        if (hero.toughness > herotomove.toughness)
                        {
                            map[hero.location[0], hero.location[1]] = 0;

                            hero.location[0] = herotomove.location[0];
                            hero.location[1] = herotomove.location[1];

                            herotomove.location[1]--;

                            map[hero.location[0], hero.location[1]] = hero.id;
                            map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                            hero.actionsRemaining--;
                        }
                        if (hero.toughness < herotomove.toughness)
                        {
                            if (isHeroInParty(player, herotomove))//means hero is in my team so I will be able to move
                            {
                                map[hero.location[0], hero.location[1]] = 0;

                                hero.location[0] = herotomove.location[0];
                                hero.location[1] = herotomove.location[1];

                                herotomove.location[1]--;

                                map[hero.location[0], hero.location[1]] = hero.id;
                                map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                                hero.actionsRemaining--;
                            }
                            else
                            {
                                Console.Clear();
                                Menu.HeroDialogue(hero, "My god, look at that hero's toughness 'tis hugelly higher than mine, I cant dare to make him to move! Let the choco do it! :D");//que lo haga el choco!!XXD
                                Menu.KeyToContinue();
                            }
                        }

                    }
                    ///moving to a Door
                    else if (newposition == 6)
                    {
                        if (hero.haveKey)
                        {
                            Console.Clear();
                            Menu.WriteTable("Do you want to use the key to open the door?\n\nWrite 'yes' to accept or 'no' to cancel");
                            string choosing = Console.ReadLine().ToLower();
                            if (choosing == "yes")
                            {
                                Console.Clear();
                                Menu.WriteTable($"{hero.name} has open the gates of the Chamber Of The Heart of Ebony.");
                                map[hero.location[0], hero.location[1] + movenumber] = 0;
                                Menu.KeyToContinue();
                            }
                            else if (choosing != "yess" && choosing != "no")
                            {
                                Console.Clear();
                                Menu.WriteTable("[red]That is not a valid action![/]\n\n");
                                Menu.KeyToContinue();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Menu.HeroDialogue(hero, "I need a key to open that door!");
                            Menu.KeyToContinue();
                        }
                    }
                    //moving to a key
                    else if (newposition == 8)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[1] += movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        Console.Clear();
                        Menu.HeroDialogue(hero, "Finally, the master key to open the doors of the treasure chamber!");
                        Menu.KeyToContinue();
                        hero.haveKey = true;
                        player.haveKey = true;



                    }
                    //moving to the centre, the goal
                    else if (newposition == 4)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        //remove from list
                        player.Party.Remove(hero);
                        player.HeroesInCentre++;
                        hero.actionsRemaining = 0;
                        break;
                    }
                    //moving to a path
                    else if (newposition == 0)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[1] += movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.actionsRemaining--;
                    }
                }
                break;
            }
        }
        public void moveleft(Hero hero, Player player, Player otherplayer, int[,] map)
        {
            while (true)
            {
                int movenumber = Movenumber(hero, hero.speed, map, "left");
                if (movenumber == 0)
                {
                    Console.Clear();
                    Menu.HeroDialogue(hero, "I can not move in that direction mate!\n\n");
                    Menu.KeyToContinue();
                    break;
                }
                else if (movenumber != 0)
                {
                    int newposition = map[hero.location[0], hero.location[1] - movenumber];
                    if (newposition == 3)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[1] -= movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.trapped = true;
                        hero.actionsRemaining--;

                    }
                    //moving to a hero
                    else if (newposition == 11 || newposition == 13 || newposition == 15 || newposition == 17 || newposition == 19 || newposition == 21)
                    {
                        Hero herotomove = GetHeroById(player, otherplayer, newposition);
                        if (hero.toughness > herotomove.toughness)
                        {
                            map[hero.location[0], hero.location[1]] = 0;

                            hero.location[0] = herotomove.location[0];
                            hero.location[1] = herotomove.location[1];

                            herotomove.location[1]++;

                            map[hero.location[0], hero.location[1]] = hero.id;
                            map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                            hero.actionsRemaining--;
                        }
                        if (hero.toughness < herotomove.toughness)
                        {
                            if (isHeroInParty(player, herotomove))//means hero is in my team so I will be able to move
                            {
                                map[hero.location[0], hero.location[1]] = 0;

                                hero.location[0] = herotomove.location[0];
                                hero.location[1] = herotomove.location[1];

                                herotomove.location[1]++;

                                map[hero.location[0], hero.location[1]] = hero.id;
                                map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                                hero.actionsRemaining--;
                            }
                            else
                            {
                                Console.Clear();
                                Menu.HeroDialogue(hero, "My god, look at that hero's toughness 'tis hugelly higher than mine, is [yellow bold]" + herotomove.toughness + "[/]  I cant dare to make him to move! Let the choco do it! :D");//que lo haga el choco!!XXD
                                Menu.KeyToContinue();
                            }
                        }
                    }
                    ///moving to a Door
                    else if (newposition == 6)
                    {
                        if (hero.haveKey)
                        {
                            Console.Clear();
                            Menu.WriteTable("Do you want to use the key to open the door?\n\nWrite 'yes' to accept or 'no' to cancel");
                            string choosing = Console.ReadLine().ToLower();
                            if (choosing == "yes")
                            {
                                Console.Clear();
                                Menu.WriteTable($"{hero.name} has open the gates of the Chamber Of The Heart of Ebony.");
                                map[hero.location[0], hero.location[1] - movenumber] = 0;
                                Menu.KeyToContinue();
                            }
                            else if (choosing != "yess" && choosing != "no")
                            {
                                Console.Clear();
                                Menu.WriteTable("[red]That is not a valid action![/]\n\n");
                                Menu.KeyToContinue();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Menu.HeroDialogue(hero, "I need a key to open that door!");
                            Menu.KeyToContinue();
                        }

                    }
                    //moving to a key
                    else if (newposition == 8)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[1] -= movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        Console.Clear();
                        Menu.HeroDialogue(hero, "Finally, the master key to open the doors of the treasure chamber!");
                        Menu.KeyToContinue();
                        hero.haveKey = true;
                        player.haveKey = true;



                    }
                    //moving to the centre, the goal
                    else if (newposition == 4)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        //remove from list
                        player.Party.Remove(hero);
                        player.HeroesInCentre++;
                        hero.actionsRemaining = 0;
                        break;
                    }
                    //moving to a path
                    else if (newposition == 0)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[1] -= movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.actionsRemaining--;
                    }
                }
                break;
            }
        }

        public void moveup(Hero hero, Player player, Player otherplayer, int[,] map)
        {

            while (true)
            {
                int movenumber = Movenumber(hero, hero.speed, map, "up");
                if (movenumber == 0)
                {
                    Console.Clear();
                    Menu.HeroDialogue(hero, "I can not move in that direction mate!\n\n");
                    Menu.KeyToContinue();
                    break;
                }
                else if (movenumber != 0)
                {
                    int newposition = map[hero.location[0] - movenumber, hero.location[1]];
                    if (newposition == 3)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[0] -= movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.trapped = true;
                        hero.actionsRemaining--;

                    }
                    //moving to a hero
                    else if (newposition == 11 || newposition == 13 || newposition == 15 || newposition == 17 || newposition == 19 || newposition == 21)
                    {
                        Hero herotomove = GetHeroById(player, otherplayer, newposition);
                        if (hero.toughness > herotomove.toughness)
                        {
                            map[hero.location[0], hero.location[1]] = 0;

                            hero.location[0] = herotomove.location[0];
                            hero.location[1] = herotomove.location[1];

                            herotomove.location[0]++;

                            map[hero.location[0], hero.location[1]] = hero.id;
                            map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                            hero.actionsRemaining--;
                        }
                        if (hero.toughness < herotomove.toughness)
                        {
                            if (isHeroInParty(player, herotomove))//means hero is in my team so I will be able to move
                            {
                                map[hero.location[0], hero.location[1]] = 0;

                                hero.location[0] = herotomove.location[0];
                                hero.location[1] = herotomove.location[1];

                                herotomove.location[0]++;

                                map[hero.location[0], hero.location[1]] = hero.id;
                                map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                                hero.actionsRemaining--;
                            }
                            else
                            {
                                Console.Clear();
                                Menu.HeroDialogue(hero, "My god, look at that hero's toughness 'tis hugelly higher than mine, is [yellow bold]" + herotomove.toughness + "[/]  I cant dare to make him to move!");//que lo haga el choco!!XXD
                                Menu.KeyToContinue();
                            }
                        }
                    }
                    ///moving to a Door
                    else if (newposition == 6)
                    {
                        if (hero.haveKey)
                        {
                            Console.Clear();
                            Menu.WriteTable("Do you want to use the key to open the door?\n\nWrite 'yes' to accept or 'no' to cancel");
                            string choosing = Console.ReadLine().ToLower();
                            if (choosing == "yes")
                            {
                                Console.Clear();
                                Menu.WriteTable($"{hero.name} has open the gates of the Chamber Of The Heart of Ebony.");
                                map[hero.location[0] - movenumber, hero.location[1]] = 0;
                                Menu.KeyToContinue();
                            }
                            else if (choosing != "yess" && choosing != "no")
                            {
                                Console.Clear();
                                Menu.WriteTable("[red]That is not a valid action![/]\n\n");
                                Menu.KeyToContinue();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Menu.HeroDialogue(hero, "I need a key to open that door!");
                            Menu.KeyToContinue();
                        }

                    }
                    //moving to a key
                    else if (newposition == 8)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[0] -= movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        Console.Clear();
                        Menu.HeroDialogue(hero, "Finally, the master key to open the doors of the treasure chamber!");
                        Menu.KeyToContinue();
                        hero.haveKey = true;
                        player.haveKey = true;



                    }
                    //moving to the centre, the goal
                    else if (newposition == 4)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        //remove from list
                        player.Party.Remove(hero);
                        player.HeroesInCentre++;
                        hero.actionsRemaining = 0;
                        break;
                    }
                    //moving to a path
                    else if (newposition == 0)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[0] -= movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.actionsRemaining--;
                    }
                }
                break;
            }

        }
        public void movedown(Hero hero, Player player, Player otherplayer, int[,] map)
        {
            while (true)
            {
                int movenumber = Movenumber(hero, hero.speed, map, "down");
                if (movenumber == 0)
                {
                    Console.Clear();
                    Menu.HeroDialogue(hero, "I can not move in that direction mate!\n\n");
                    Menu.KeyToContinue();
                    break;
                }
                else if (movenumber != 0)
                {
                    int newposition = map[hero.location[0] + movenumber, hero.location[1]];
                    if (newposition == 3)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[0] += movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.trapped = true;
                        hero.actionsRemaining--;

                    }
                    else if (newposition == 11 || newposition == 13 || newposition == 15 || newposition == 17 || newposition == 19 || newposition == 21)
                    {
                        Hero herotomove = GetHeroById(player, otherplayer, newposition);
                        if (hero.toughness > herotomove.toughness)
                        {
                            map[hero.location[0], hero.location[1]] = 0;

                            hero.location[0] = herotomove.location[0];
                            hero.location[1] = herotomove.location[1];

                            herotomove.location[0]--;

                            map[hero.location[0], hero.location[1]] = hero.id;
                            map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                            hero.actionsRemaining--;
                        }
                        if (hero.toughness < herotomove.toughness)
                        {
                            if (isHeroInParty(player, herotomove))//means hero is in my team so I will be able to move
                            {
                                map[hero.location[0], hero.location[1]] = 0;

                                hero.location[0] = herotomove.location[0];
                                hero.location[1] = herotomove.location[1];

                                herotomove.location[0]--;

                                map[hero.location[0], hero.location[1]] = hero.id;
                                map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                                hero.actionsRemaining--;
                            }
                            else
                            {
                                Console.Clear();
                                Menu.HeroDialogue(hero, "My god, look at that hero's toughness 'tis hugelly higher than mine, is [yellow bold]" + herotomove.toughness + "[/]  I cant dare to make him to move!");//que lo haga el choco!!XXD
                                Menu.KeyToContinue();
                            }
                        }
                    }
                    ///moving to a Door
                    else if (newposition == 6)
                    {
                        if (hero.haveKey)
                        {
                            Console.Clear();
                            Menu.WriteTable("Do you want to use the key to open the door?\n\nWrite 'yes' to accept or 'no' to cancel");
                            string choosing = Console.ReadLine().ToLower();
                            if (choosing == "yes")
                            {
                                Console.Clear();
                                Menu.WriteTable($"{hero.name} has open the gates of the Chamber Of The Heart of Ebony.");
                                map[hero.location[0] + movenumber, hero.location[1]] = 0;
                                Menu.KeyToContinue();
                            }
                            else if (choosing != "yess" && choosing != "no")
                            {
                                Console.Clear();
                                Menu.WriteTable("[red]That is not a valid action![/]\n\n");
                                Menu.KeyToContinue();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Menu.HeroDialogue(hero, "I need a key to open that door!");
                            Menu.KeyToContinue();
                        }

                    }
                    //moving to a key
                    else if (newposition == 8)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[0] += movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        Console.Clear();
                        Menu.HeroDialogue(hero, "Finally, the master key to open the doors of the treasure chamber!");
                        Menu.KeyToContinue();
                        hero.haveKey = true;
                        player.haveKey = true;



                    }
                    //moving to the centre, the goal
                    else if (newposition == 4)
                    {
                        // Make player current position equals 0
                        map[hero.location[0], hero.location[1]] = 0;
                        //remove from list
                        player.Party.Remove(hero);
                        player.HeroesInCentre++;
                        hero.actionsRemaining = 0;
                        break;
                    }
                    //moving to a path
                    else if (newposition == 0)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[0] += movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.actionsRemaining--;
                    }
                }
                break;
            }
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
                table1.AddRow(" 👢 [bold #e9e9e9]Speed[/]   >  " + list[i].speed);
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
                var stats = new BarChart();

                if (list[i].health >= 7)
                {
                    stats.Width(50);
                    stats.AddItem("💓", list[i].health, Color.Green4);
                    stats.AddItem("💙", list[i].mana, Color.Blue);
                }
                else if (list[i].health >= 5)
                {
                    stats.Width(50);
                    stats.AddItem("💓", list[i].health, Color.Yellow2);
                    stats.AddItem("💙", list[i].mana, Color.Blue);
                }
                else if (list[i].health >= 3)
                {
                    stats.Width(50);
                    stats.AddItem("💓", list[i].health, Color.Orange1);
                    stats.AddItem("💙", list[i].mana, Color.Blue);
                }
                else if (list[i].health >= 0)
                {
                    stats.Width(50);
                    stats.AddItem("💓", list[i].health, Color.DarkRed);
                    stats.AddItem("💙", list[i].mana, Color.Blue);
                }
                ///////////////////////////////////////////////////////////////////
                if (list[i].stunned > 0)
                {
                    var table1 = new Table();
                    table1.AddColumn("[bold #fbd022] " + (i + 1) + "[/][#783806] >>[/]  [black] " + list[i].icon + "[/] [bold]" + list[i].name + "[/]       [bold red]MUST WAIT " + list[i].stunned + " TURN(S)[/]");
                    table1.AddRow(" 📜 [bold #e9e9e9]Info  [/]   >  [#f9d380]" + list[i].info + "[/]");
                    table1.AddRow(stats);
                    table1.AddRow(" 🔪 [bold #e9e9e9]Attack[/]   >  " + list[i].attack);
                    table1.AddRow(" 👢 [bold #e9e9e9]Speed[/]   >  " + list[i].speed);
                    table1.AddRow(" 💠 [bold #e9e9e9]Super Requires[/] > Mana " + list[i].cooldown + "💙");
                    table.AddRow(table1);
                    table1.BorderColor(Color.Red);
                }
                else if (list[i].restturns > 0)
                {
                    list[i].health++;
                    var table1 = new Table();
                    table1.AddColumn("[bold #fbd022] " + (i + 1) + "[/][#783806] >>[/]  [black] " + list[i].icon + "[/][bold] " + list[i].name + "[/] [bold red]RECOVERING, WAIT " + list[i].restturns + " TURN(S)[/]");
                    table1.AddRow(" 📜 [bold #e9e9e9]Info  [/]   >  [#f9d380]" + list[i].info + "[/]");
                    table1.AddRow(stats);
                    table1.AddRow(" 🔪 [bold #e9e9e9]Attack[/]   >  " + list[i].attack);
                    table1.AddRow(" 👢 [bold #e9e9e9]Speed[/]   >  " + list[i].speed);
                    table1.AddRow(" 💠 [bold #e9e9e9]Super Requires[/] > Mana " + list[i].cooldown + "💙");
                    list[i].restturns--;
                    table.AddRow(table1);
                    table1.BorderColor(Color.Red);
                }
                else if (list[i].stunned <= 0 && list[i].health > 0 && list[i].restturns <= 0)
                {
                    var table1 = new Table();
                    table1.AddColumn("[bold #fbd022] " + (i + 1) + "[/][#783806] >>[/]  [black] " + list[i].icon + "[/][bold] " + list[i].name + "[/]");
                    table1.AddRow(" 📜 [bold #e9e9e9]Info  [/]   >  [#f9d380]" + list[i].info + "[/]");
                    table1.AddRow(stats);
                    table1.AddRow(" 🔪 [bold #e9e9e9]Attack[/]   >  " + list[i].attack);
                    table1.AddRow(" 👢 [bold #e9e9e9]Speed[/]   >  " + list[i].speed);
                    table1.AddRow(" 💠 [bold #e9e9e9]Super Requires[/] > Mana " + list[i].cooldown + "💙");
                    table.AddRow(table1);
                    table1.BorderColor(Color.Chartreuse1);
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

    ////////////////////    Other Classes of Hero
    public class Teleporter : Hero
    {
        //Constructor for Teleporter//
        public Teleporter(int id, string icon, string name, string info, int health, int attack, int speed, int mana, int cooldown, int toughness, int[,] maze) : base(id, icon, name, info, health, attack, speed, mana, cooldown, toughness, maze)
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
        public Switcher(int id, string icon, string name, string info, int health, int attack, int speed, int mana, int cooldown, int toughness, int[,] maze) : base(id, icon, name, info, health, attack, speed, mana, cooldown, toughness, maze)
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
        public Witcher(int id, string icon, string name, string info, int health, int attack, int speed, int mana, int cooldown, int toughness, int[,] maze) : base(id, icon, name, info, health, attack, speed, mana, cooldown, toughness, maze)
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
        public Manner(int id, string icon, string name, string info, int health, int attack, int speed, int mana, int cooldown, int toughness, int[,] maze) : base(id, icon, name, info, health, attack, speed, mana, cooldown, toughness, maze)
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
            if (heroselected.mana < 3)
            {
                savedmana = heroselected.mana;
                heroselected.mana = 0;
                player.Party[index].mana += savedmana;
            }
            else
            {
                savedmana = 3;
                heroselected.mana -= 3;
                player.Party[index].mana += 3;
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
        public Jumper(int id, string icon, string name, string info, int health, int attack, int speed, int mana, int cooldown, int toughness, int[,] maze) : base(id, icon, name, info, health, attack, speed, mana, cooldown, toughness, maze)
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
            Menu.KeyToContinue();

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
        public WallBreaker(int id, string icon, string name, string info, int health, int attack, int speed, int mana, int cooldown, int toughness, int[,] maze) : base(id, icon, name, info, health, attack, speed, mana, cooldown, toughness, maze)//Call to base constructor
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
                    Menu.WriteTable("[red]That is not a valid direction![/]");
                    Menu.KeyToContinue();

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
                var dialogue = new Table()
                .RoundedBorder();
                dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                dialogue.AddColumn(new TableColumn("[bold blue]> [/]I can not break that wall :(").Centered());
                AnsiConsole.Write(dialogue);
                Menu.KeyToContinue();
                return false;
            }
            if (map[location[0] + dirRow, location[1] + dirCol] != 1)
            {
                Console.Clear();
                var dialogue = new Table()
                .RoundedBorder();
                dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                dialogue.AddColumn(new TableColumn("[bold blue]> [/]There is no wall there!!! , is your head on the clouds? :/").Centered());
                AnsiConsole.Write(dialogue);
                Menu.KeyToContinue();
                return false;
            }
            map[location[0] + dirRow, location[1] + dirCol] = 0;
            Maze.FreePath.Add(new int[] { location[0] + dirRow, location[1] + dirCol });
            return true;
        }
    }
}
