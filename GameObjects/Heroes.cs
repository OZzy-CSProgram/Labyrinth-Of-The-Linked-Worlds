using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;

namespace GameObjects
{
    class Hero
    {
        ////propeties////
        public string name;
        public string info;
        public int id;
        public int health;
        public int attack;
        public int cooldown;
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
            if (Maze[location[0], location[1] + 1] == 1)
            {
                Console.WriteLine("You can't move in that direction mate! :/");
            }
            else
            {
                location[1]++;
            }
            return location;
        }
        public int[] moveleft(int[] location, int[,] Maze)
        {
            if (Maze[location[0], location[1] - 1] == 1)
            {
                Console.WriteLine("You can't move in that direction mate! :/");
            }
            else
            {
                location[1]--;
            }
            return location;
        }
        public int[] moveup(int[] location, int[,] Maze)
        {
            if (Maze[location[0] - 1, location[1]] == 1)
            {
                Console.WriteLine("You can't move in that direction mate! :/");
            }
            else
            {
                location[0]--;
            }
            return location;
        }
        public int[] movedown(int[] location, int[,] Maze)
        {
            if (Maze[location[0] + 1, location[1]] == 1)
            {
                Console.WriteLine("You can't move in that direction mate! :/");
            }
            else
            {
                location[0]++;
            }
            return location;
        }
        public static void DisplayList(List<Hero> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║  Heroe number " + (i + 1) + " >>>   " + list[i].name);
                Console.WriteLine("╠═════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  📜 Info      >  " + list[i].info);
                Console.WriteLine("║  💗 Health    >  " + list[i].health);
                Console.WriteLine("║  🔪 Attack   >  " + list[i].attack);
                Console.WriteLine("║  💠 Cooldown >  " + list[i].cooldown);
                Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            }
        }
    
        public virtual void CastSpell()
        {
        Console.WriteLine("Casting Spell");
        }
    }


class Teleporter : Hero
{
    //Constructor for Teleporter//
    public Teleporter(int id, string name, string info, int health, int attack, int cooldown, int[,] maze) : base(id,name, info, health, attack, cooldown, maze)
    //Call to base constructor
    {
    }
    public override void CastSpell()
    {
        Console.WriteLine(name + ": Thou cannot reach my magic! .. Teleporting");
        int[] receptor = Maze.GetRandomPath();
        while (receptor[0] == location[0] && receptor[0] == location[0])
        {
            receptor = Maze.GetRandomPath();
        }
        Console.WriteLine(name + " Teleports to " + location);
    }
}
class WallBreaker : Hero
{
    //Constructor for WallBreaker//
    public WallBreaker(int id,string name, string info, int health, int attack, int cooldown, int[,] maze) : base(id,name, info, health, attack, cooldown, maze)//Call to base constructor
    {
    }
    public override void CastSpell()
    {
        // Console.WriteLine(Name + "The bigger the wall is, the easier it falls down :D");
        while (true)
        {
            Console.WriteLine("Which wall would you like " + name + " to destroy");
            //================================================================================================================ PENDIENTE! decirle al usuario q para arriba presione w, para abajo s, a izq, derecha d,
            ConsoleKeyInfo Direction = Console.ReadKey(true);
            if (Direction.KeyChar == 'w')
            {
                if (!HandleWallBreaking(-1, 0))
                    continue;
            }
            else if (Direction.KeyChar == 's')
            {
                if (!HandleWallBreaking(1, 0))
                    continue;
            }
            else if (Direction.KeyChar == 'a')
            {
                if (!HandleWallBreaking(0, -1))
                    continue;
            }
            else if (Direction.KeyChar == 'd')
            {
                if (!HandleWallBreaking(0, 1))
                    continue;
            }
            break;
        }
    }
    private bool HandleWallBreaking(int dirRow, int dirCol)
    {
        if (!Maze.isValidLocation(location[0] + dirRow, location[1] + dirCol))
        {
            Console.WriteLine("You can not break in that direction!");
            System.Console.ReadKey();
            return false;
        }
        if (map[location[0] + dirRow, location[1] + dirCol] != 1)
        {
            Console.WriteLine("There is no wall there mate, was your head on the clouds?!");
            return false;
        }
        BreakWall(location[0] + dirRow, location[1] + dirCol);
        return true;
    }
    private void BreakWall(int row, int col)
    {
        //=============================================================================================== PENDIENTE!!
    }
}
}
