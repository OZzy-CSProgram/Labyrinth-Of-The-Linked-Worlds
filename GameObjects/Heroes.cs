using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Transactions;
using Spectre.Console;
using System.Threading;

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
        public bool inbox = false;
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
                    if (map[hero.location[0] - i, hero.location[1]] == 1 || map[hero.location[0] - i, hero.location[1]] == 2)
                    {
                        return i - 1;
                    }
                    if (map[hero.location[0] - i, hero.location[1]] != 0)
                    {
                        return i;
                    }
                }
            }
            else if (dir == "down")
            {
                for (int i = 1; i <= speed; i++)
                {
                    if (map[hero.location[0] + i, hero.location[1]] == 1 || map[hero.location[0] + i, hero.location[1]] == 2)
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
                    if (map[hero.location[0], hero.location[1] - i] == 1 || map[hero.location[0], hero.location[1] - i] == 2)
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
                    if (map[hero.location[0], hero.location[1] + i] == 1 || map[hero.location[0], hero.location[1] + i] == 2)
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
                    //moving to a trap
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
                    //moving to a box
                    if (newposition == 5)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[1] += movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.inbox = true;
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
                    ///moving to a trap
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
                    //moving to a box
                    if (newposition == 5)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[1] -= movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.inbox = true;
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
                    //moving to a trap
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
                    //moving to a box
                    if (newposition == 5)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[0] -= movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.inbox = true;
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
                    //moving to a trap
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
                    //moving to a box
                    if (newposition == 5)
                    {
                        ///                                    moveup
                        map[hero.location[0], hero.location[1]] = 0;       //make path where player is standing
                        hero.location[0] += movenumber;                        //Change Player location
                        map[hero.location[0], hero.location[1]] = id;    // Make map value = hero.id so when map is display hero appears in that position

                        //add new position to the log
                        hero.locationlog.Add(new int[] { hero.location[0], hero.location[1] });
                        hero.inbox = true;
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

        public static Table DisplayListP1(List<Hero> list, string s)
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
                table1.BorderColor(Color.Blue);
            }
            table.AddRow("");
            table.BorderColor(Color.DarkBlue);
            table.Centered();
            return table;
        }
        public static Table DisplayListP2(List<Hero> list, string s)
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
                table1.BorderColor(Color.Red1);
            }
            table.AddRow("");
            table.BorderColor(Color.DarkRed);
            table.Centered();
            return table;
        }
        public static Table DisplayListOn3(List<Hero> list, Table table, int limit, string s)
        {
            for (int i = 0; i < limit; i++)
            {

                if (i == (limit - 1) / 2)
                {
                    var table1 = new Table();
                    table1.Border(TableBorder.Heavy);
                    table1.BorderColor(Color.Chartreuse3);
                    var table2 = new Table();
                    table2.AddColumn(list[i].icon + " [bold]" + list[i].name + "[/]  ");
                    table2.AddRow(" 📜 [bold]Info  [/]   >  " + list[i].info);
                    table2.AddRow(" 💗 [bold]Health[/]    >  " + list[i].health);
                    table2.AddRow(" 💙 [bold] Max Mana[/] >  20");
                    table2.AddRow(" 🔪 [bold]Attack[/]   >  " + list[i].attack);
                    table2.AddRow(" 👢 [bold #e9e9e9]Speed[/]   >  " + list[i].speed);
                    table2.AddRow(" 💠 [bold]Super Requirements[/] > Mana " + list[i].cooldown + "💙");
                    table1.AddColumn(new TableColumn(table2).Centered());
                    table2.BorderColor(Color.DarkGoldenrod);
                    table.AddRow(table1);
                }
                else
                {
                    var table1 = new Table();
                    table1.NoBorder();
                    var table2 = new Table();
                    table2.AddColumn(list[i].icon + " [bold]" + list[i].name + "[/]  ");
                    table2.AddRow(" 📜 [bold]Info  [/]   >  " + list[i].info);
                    table2.AddRow(" 💗 [bold]Health[/]    >  " + list[i].health);
                    table2.AddRow(" 💙 [bold] Max Mana[/] >  20");
                    table2.AddRow(" 🔪 [bold]Attack[/]   >  " + list[i].attack);
                    table2.AddRow(" 👢 [bold #e9e9e9]Speed[/]   >  " + list[i].speed);
                    table2.AddRow(" 💠 [bold]Super Requirements[/] > Mana " + list[i].cooldown + "💙");
                    table1.AddColumn(new TableColumn(table2).Centered());
                    table2.BorderColor(Color.Grey23);
                    table.AddRow(table1);
                }

            }
            if (s == "p1")
            {
                var enter = new Table();
                enter.Border(TableBorder.Rounded);
                enter.BorderColor(Color.DarkGreen);
                enter.AddColumn(new TableColumn("[bold #00e410]<⬅ <⬅ <⬅ <⬅ Enter[/]"));
                enter.Centered();
                table.AddRow(enter);
            }
            if (s == "p2")
            {
                var enter = new Table();
                enter.Border(TableBorder.Rounded);
                enter.BorderColor(Color.DarkGreen);
                enter.AddColumn(new TableColumn("[bold #00e410]Enter ➡> ➡> ➡> ➡>[/]"));
                enter.Centered();
                table.AddRow(enter);
            }
            table.AddEmptyRow();
            table.BorderColor(Color.SlateBlue1);
            table.Centered();
            return table;
        }
        public static Hero DisplayList3(Table p1, List<Hero> list, Table p2, string s, string dir)
        {
            Console.Clear();
            int limit = 3;
            while (true)
            {
                if (list.Count < 3)
                {
                    limit = list.Count;
                }
                var table = new Table();
                table.AddColumn(new TableColumn(s).Centered());
                table.AddRow("");
                table = DisplayListOn3(list, table, limit, dir);
                Menu.HeroSelection(p1, table, p2);
                ConsoleKeyInfo Selection = Console.ReadKey(true);
                if (Selection.Key == ConsoleKey.DownArrow || Selection.KeyChar == 's')
                {
                    Hero save = list[0];
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == list.Count - 1)
                        {
                            break;
                        }
                        if (list.Count != 1)
                        {
                            list[i] = list[i + 1];
                        }
                    }
                    list[list.Count - 1] = save;
                }
                if (Selection.Key == ConsoleKey.UpArrow || Selection.KeyChar == 'w')
                {
                    Hero save = list[list.Count - 1];
                    for (int i = list.Count - 1; i > 0; i--)
                    {
                        if (i == 0)
                        {
                            break;
                        }
                        if (list.Count != 1)
                        {
                            list[i] = list[i - 1];
                        }
                    }
                    list[0] = save;
                }
                if (Selection.Key == ConsoleKey.Enter)
                {
                    return list[(limit - 1) / 2];
                }
                table = DisplayListOn3(list, table, limit, dir);
                Console.OutputEncoding = System.Text.Encoding.UTF8;

            }
            return list[0];
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
        public virtual void CastSpell(int[,] map, Player player, Player otherplayer)
        {
            Console.WriteLine("Casting Spell");
        }
        public static int[] GetADirection(int[,] map, string s)
        {
            // public ConsoleKeyInfo ValidDirection(ConsoleKeyInfo action);
            {
                ConsoleKeyInfo Direction;
                int[] arr = new int[2];
                while (true)
                {
                    Console.Clear();
                    var printmap = Maze.PrintMaze(map, s);
                    AnsiConsole.Write(printmap);
                    Menu.PrintDirections();
                    Direction = Console.ReadKey(true);
                    if (Direction.Key == ConsoleKey.Tab)
                    {
                        break;
                    }
                    while (Direction.KeyChar != 'w' && Direction.KeyChar != 'W' && Direction.KeyChar != 'a' && Direction.KeyChar != 'A' && Direction.KeyChar != 's' && Direction.KeyChar != 'S' && Direction.KeyChar != 'd' && Direction.KeyChar != 'D' && Direction.KeyChar != 'r' && Direction.KeyChar != 'R')
                    {
                        Console.Clear();

                        Menu.WriteTable("[red]That is not a valid action![/]\n\n");
                        Menu.KeyToContinue();

                        Console.Clear();
                        Maze.PrintMaze(map, "Select A valid Direction !");
                        Menu.PrintDirections();
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
            int[] receptor = Maze.GetRandomPath(Maze.FreePath);
            map[location[0], location[1]] = 0;
            while (receptor[0] == location[0] && receptor[1] == location[1])
            {
                receptor = Maze.GetRandomPath(Maze.FreePath);
            }
            location[0] = receptor[0];
            location[1] = receptor[1];
            map[location[0], location[1]] = id;
            Menu.KeyToContinue();
            Console.Clear();
            Menu.WriteTable($"{name} has Teleported to    {location[0]}  ,  {location[1]}  ");
            Menu.KeyToContinue();
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
            Menu.KeyToContinue();

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
            Menu.KeyToContinue();

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
            Menu.KeyToContinue();
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
            var dialogue = new Table();
            dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
            dialogue.AddColumn(new TableColumn("[bold blue]> [/] Nobody can jump like I can! .... Ahahahaha ?\n\n ").Centered());
            AnsiConsole.Write(dialogue);
            Menu.KeyToContinue();
            while (true)
            {
                int[] Dir = Hero.GetADirection(map, "[bold #000000]" + icon + "[/][bold blue]> [/] What direction should I you want to jump?");
                if (Dir[0] == 0 && Dir[1] == 0)//means the player selected the option, Cancel
                {
                    mana += cooldown;
                    break;
                }
                int positionbetween = map[location[0] + Dir[0], location[1] + Dir[1]];
                int[] newlocation = { location[0] + Dir[0] + Dir[0], location[1] + Dir[1] + Dir[1] };
                if (positionbetween == 1)//there is a wal wall
                {
                    int newposition = map[newlocation[0], newlocation[1]];
                    //landing in a wall
                    if (newposition == 1)
                    {
                        Console.Clear();
                        var dialogue2 = new Table();
                        dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                        dialogue2.AddColumn(new TableColumn("[bold blue]> [/] I can't jump that wall, it seems that through that wall there is not a room! or any space at all \n\n ").Centered());
                        AnsiConsole.Write(dialogue2);
                        Menu.KeyToContinue();
                        continue;
                    }
                    //landing in a trap
                    else if (newposition == 3)
                    {
                        map[location[0], location[1]] = 0;
                        location[0] += Dir[0];
                        location[0] += Dir[0];
                        location[1] += Dir[1];
                        location[1] += Dir[1];
                        map[location[0], location[1]] = id;
                        trapped = true;
                        break;
                    }
                    //landing in box
                    else if (newposition == 5)
                    {
                        map[location[0], location[1]] = 0;
                        location[0] += Dir[0];
                        location[0] += Dir[0];
                        location[1] += Dir[1];
                        location[1] += Dir[1];
                        map[location[0], location[1]] = id;
                        inbox = true;
                        break;
                    }
                    //landing in path
                    else if (newposition == 0)
                    {
                        map[location[0], location[1]] = 0;
                        location[0] += Dir[0];
                        location[0] += Dir[0];
                        location[1] += Dir[1];
                        location[1] += Dir[1];
                        map[location[0], location[1]] = id;
                        break;
                    }
                    //landing in a hero
                    else if (newposition == 11 || newposition == 13 || newposition == 15 || newposition == 17 || newposition == 19 || newposition == 21)
                    {
                        Hero herotomove = GetHeroById(player, otherplayer, newposition);
                        if (toughness > herotomove.toughness)
                        {
                            map[location[0], location[1]] = 0;

                            location[0] = herotomove.location[0];
                            location[1] = herotomove.location[1];

                            if (map[newlocation[0] - 1, newlocation[1]] == 0)
                            {
                                herotomove.location[0]--;
                            }
                            else if (map[newlocation[0] + 1, newlocation[1]] == 0)
                            {
                                herotomove.location[0]++;
                            }
                            else if (map[newlocation[0], newlocation[1] - 1] == 0)
                            {
                                herotomove.location[1]--;
                            }
                            else if (map[newlocation[0], newlocation[1] + 1] == 0)
                            {
                                herotomove.location[1]++;
                            }
                            map[location[0], location[1]] = id;
                            map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                            break;
                        }
                        else if (toughness < herotomove.toughness)
                        {
                            if (isHeroInParty(player, herotomove))//means hero is in my team so I will be able to move
                            {
                                map[location[0], location[1]] = 0;

                                location[0] = herotomove.location[0];
                                location[1] = herotomove.location[1];

                                if (map[newlocation[0] - 1, newlocation[1]] == 0)
                                {
                                    herotomove.location[0]--;
                                }
                                else if (map[newlocation[0] + 1, newlocation[1]] == 0)
                                {
                                    herotomove.location[0]++;
                                }
                                else if (map[newlocation[0], newlocation[1] - 1] == 0)
                                {
                                    herotomove.location[1]--;
                                }
                                else if (map[newlocation[0], newlocation[1] + 1] == 0)
                                {
                                    herotomove.location[1]++;
                                }
                                map[location[0], location[1]] = id;
                                map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                var dialogue2 = new Table();
                                dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                                dialogue2.AddColumn(new TableColumn("[bold blue]> [/] My god, look at that hero's toughness 'tis hugelly higher than mine, is [yellow bold]" + herotomove.toughness + "[/]  I wont dare to move there!").Centered());
                                AnsiConsole.Write(dialogue2);
                                Menu.KeyToContinue();
                                continue;
                            }
                        }
                    }
                    ///moving to a Key
                    else if (newposition == 8)
                    {
                        map[location[0], location[1]] = 0;
                        location[0] += Dir[0];
                        location[0] += Dir[0];
                        location[1] += Dir[1];
                        location[1] += Dir[1];
                        map[location[0], location[1]] = id;
                        Console.Clear();
                        var dialogue2 = new Table();
                        dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                        dialogue2.AddColumn(new TableColumn("[bold blue]> [/] Finally, the master key to open the doors of the treasure chamber!").Centered());
                        AnsiConsole.Write(dialogue2);
                        Menu.KeyToContinue();
                        haveKey = true;
                        player.haveKey = true;
                        break;
                    }
                }
                else if (positionbetween == 2)
                {
                    Console.Clear();
                    var dialogue2 = new Table();
                    dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                    dialogue2.AddColumn(new TableColumn("[bold blue]> [/] I can't jump that wall, itsss quite high, don't you see it?\n\n ").Centered());
                    AnsiConsole.Write(dialogue2);
                    Menu.KeyToContinue();
                    continue;
                }
                else if (positionbetween == 0)
                {
                    int newposition = map[newlocation[0], newlocation[1]];
                    //landing in a wall
                    if (newposition == 1)
                    {
                        Console.Clear();
                        var dialogue2 = new Table();
                        dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                        dialogue2.AddColumn(new TableColumn("[bold blue]> [/] I can't jump that wall, it seems that through that wall there is not a room! or any space at all \n\n ").Centered());
                        AnsiConsole.Write(dialogue2);
                        Menu.KeyToContinue();
                        continue;
                    }
                    //landing in a trap
                    else if (newposition == 3)
                    {
                        map[location[0], location[1]] = 0;
                        location[0] += Dir[0];
                        location[0] += Dir[0];
                        location[1] += Dir[1];
                        location[1] += Dir[1];
                        map[location[0], location[1]] = id;
                        trapped = true;
                        break;
                    }
                    //landing in box
                    else if (newposition == 5)
                    {
                        map[location[0], location[1]] = 0;
                        location[0] += Dir[0];
                        location[0] += Dir[0];
                        location[1] += Dir[1];
                        location[1] += Dir[1];
                        map[location[0], location[1]] = id;
                        inbox = true;
                        break;
                    }
                    //landing in path
                    else if (newposition == 0)
                    {
                        map[location[0], location[1]] = 0;
                        location[0] += Dir[0];
                        location[0] += Dir[0];
                        location[1] += Dir[1];
                        location[1] += Dir[1];
                        map[location[0], location[1]] = id;
                        break;
                    }
                    //landing in a hero
                    else if (newposition == 11 || newposition == 13 || newposition == 15 || newposition == 17 || newposition == 19 || newposition == 21)
                    {
                        Hero herotomove = GetHeroById(player, otherplayer, newposition);
                        if (toughness > herotomove.toughness)
                        {
                            map[location[0], location[1]] = 0;

                            location[0] = herotomove.location[0];
                            location[1] = herotomove.location[1];

                            if (map[newlocation[0] - 1, newlocation[1]] == 0)
                            {
                                herotomove.location[0]--;
                            }
                            else if (map[newlocation[0] + 1, newlocation[1]] == 0)
                            {
                                herotomove.location[0]++;
                            }
                            else if (map[newlocation[0], newlocation[1] - 1] == 0)
                            {
                                herotomove.location[1]--;
                            }
                            else if (map[newlocation[0], newlocation[1] + 1] == 0)
                            {
                                herotomove.location[1]++;
                            }
                            map[location[0], location[1]] = id;
                            map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                            break;
                        }
                        else if (toughness < herotomove.toughness)
                        {
                            if (isHeroInParty(player, herotomove))//means hero is in my team so I will be able to move
                            {
                                map[location[0], location[1]] = 0;

                                location[0] = herotomove.location[0];
                                location[1] = herotomove.location[1];

                                if (map[newlocation[0] - 1, newlocation[1]] == 0)
                                {
                                    herotomove.location[0]--;
                                }
                                else if (map[newlocation[0] + 1, newlocation[1]] == 0)
                                {
                                    herotomove.location[0]++;
                                }
                                else if (map[newlocation[0], newlocation[1] - 1] == 0)
                                {
                                    herotomove.location[1]--;
                                }
                                else if (map[newlocation[0], newlocation[1] + 1] == 0)
                                {
                                    herotomove.location[1]++;
                                }
                                map[location[0], location[1]] = id;
                                map[herotomove.location[0], herotomove.location[1]] = herotomove.id;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                var dialogue2 = new Table();
                                dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                                dialogue2.AddColumn(new TableColumn("[bold blue]> [/] My god, look at that hero's toughness 'tis hugelly higher than mine, is [yellow bold]" + herotomove.toughness + "[/]  I wont dare to move there!").Centered());
                                AnsiConsole.Write(dialogue2);
                                Menu.KeyToContinue();
                                continue;
                            }
                        }
                    }
                    ///moving to a Key
                    else if (newposition == 8)
                    {
                        map[location[0], location[1]] = 0;
                        location[0] += Dir[0];
                        location[0] += Dir[0];
                        location[1] += Dir[1];
                        location[1] += Dir[1];
                        map[location[0], location[1]] = id;
                        Console.Clear();
                        var dialogue2 = new Table();
                        dialogue2.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                        dialogue2.AddColumn(new TableColumn("[bold blue]> [/] Finally, the master key to open the doors of the treasure chamber!").Centered());
                        AnsiConsole.Write(dialogue2);
                        Menu.KeyToContinue();
                        haveKey = true;
                        player.haveKey = true;
                        break;
                    }
                }
                // else if (newposition != 2 && newposition != 1)
                // {

                // }
            }
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
                // var dialogue = new Table()
                // .RoundedBorder();
                // dialogue.AddColumn(new TableColumn("[bold #000000]" + icon + "[/]").Centered());
                // dialogue.AddColumn(new TableColumn("[bold blue]> [/]Which wall would you like me to destroy mate ? ヽ(ヅ)ノ").Centered());
                // AnsiConsole.Write(dialogue);
                var printmap = Maze.PrintMaze(map, "[bold #000000]" + icon + "[/] [bold blue]> [/]Which wall would you like me to destroy mate ? ヽ(ヅ)ノ");
                AnsiConsole.Write(printmap);
                Menu.PrintDirections();


                var Direction = Console.ReadKey(true);
                if (Direction.Key == ConsoleKey.Tab)
                {
                    mana += cooldown;
                    break;
                }
                while (Direction.KeyChar != 'w' && Direction.KeyChar != 'W' && Direction.KeyChar != 'a' && Direction.KeyChar != 'A' && Direction.KeyChar != 's' && Direction.KeyChar != 'S' && Direction.KeyChar != 'd' && Direction.KeyChar != 'D' && Direction.KeyChar != 'r' && Direction.KeyChar != 'R')
                {
                    Console.Clear();
                    Menu.WriteTable("[red]That is not a valid direction![/]");
                    Menu.KeyToContinue();

                    Console.Clear();
                    AnsiConsole.Write(printmap);
                    Menu.PrintDirections();
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
            if (map[location[0] + dirRow, location[1] + dirCol] == 2)
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
            else if (map[location[0] + dirRow, location[1] + dirCol] != 1)
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
