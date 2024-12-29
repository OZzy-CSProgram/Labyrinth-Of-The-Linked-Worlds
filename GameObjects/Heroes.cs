using System.Reflection.Metadata.Ecma335;

namespace GameObjects
{
    class Hero
    {
        public string Name;
        public string Info;
        public int health;
        public int Speed;
        public int Cooldown;
        public static int[,] map;
        public int[] location = new int[2];
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
        public int[] movedown(int[] location, int[,] Maze)
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
        public virtual void CastSpell()
        {
            Console.WriteLine("Casting Spell");
        }
    }

    class Teleporter : Hero
    {
        public override void CastSpell()
        {
            Console.WriteLine(Name + ": Thou cannot reach my magic! .. Teleporting");
            int[] receptor = Maze.GetRandomPath();
            while (receptor[0] == location[0] && receptor[0] == location[0])
            {
                receptor = Maze.GetRandomPath();
            }
            Console.WriteLine(Name + " Teleports to " + location);
        }
    }
    class Miner : Hero
    {
        public override void CastSpell()
        {
            // Console.WriteLine(Name + "The bigger the wall is, the easier it falls down :D");
            while (true)
            {
                Console.WriteLine("Which wall would you like " + Name + " to destroy");
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
