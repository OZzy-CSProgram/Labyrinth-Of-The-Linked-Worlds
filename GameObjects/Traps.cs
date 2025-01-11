using System.Data;
using Spectre.Console;
namespace GameObjects
{
    class Trap
    {
        public virtual void CastTrap(Hero hero, int[,] map)
        {
            Console.WriteLine("Casting Trap");
        }
        public static void SpawnTraps(int[,] map)
        {
            int[] Trap1 = Maze.GetRandomPath();
            map[Trap1[0], Trap1[1]] = 3;

            int[] Trap2 = GetTrap(map);
            map[Trap2[0], Trap2[1]] = 3;

            int[] Trap3 = GetTrap(map);
            map[Trap3[0], Trap3[1]] = 3;

            int[] Trap4 = GetTrap(map);
            map[Trap4[0], Trap4[1]] = 3;

            int[] Trap5 = GetTrap(map);
            map[Trap5[0], Trap5[1]] = 3;

            int[] Trap6 = GetTrap(map);
            map[Trap6[0], Trap6[1]] = 3;

            int[] Trap7 = GetTrap(map);
            map[Trap7[0], Trap7[1]] = 3;

            int[] Trap8 = GetTrap(map);
            map[Trap8[0], Trap8[1]] = 3;

            int[] Trap9 = GetTrap(map);
            map[Trap9[0], Trap9[1]] = 3;

            int[] Trap10 = GetTrap(map);
            map[Trap10[0], Trap10[1]] = 3;
        }
        public static int[] GetTrap(int[,] map)
        {
            int[] Trap;
            int[][] Dir = new int[][]
            { 
                //Up Down Right Left
             new int[] {-1, 0 },      //⬆    0
             new int[] { 1, 0 },      //⬇    1
             new int[] { 0, 1 },      //➡   2
             new int[] { 0, -1 },     //⬅   3
               //Diagonals UP
             new int[] {-1, -1 },    //↖     4
             new int[] {-1, 1 },     //↗     5
 
               //Diagonals Down
             new int[] {1, -1 },    //↙      6
             new int[] {1, 1 }     //↘       7
             };
            while (true)
            {
                Trap = Maze.GetRandomPath();
                for (int i = 1; i < 4; i++)
                {
                    if (Trap[0] + Dir[0][0] * i >= 1 && Trap[0] + Dir[0][0] * i < Maze.size - 1 && Trap[1] + Dir[0][1] * i >= 1 && Trap[1] + Dir[0][1] * i < Maze.size - 1)
                    {
                        if (map[Trap[0] + Dir[0][0] * i, Trap[1] + Dir[0][1] * i] == 3) //Up
                            break;
                    }
                    if (Trap[0] + Dir[1][0] * i >= 1 && Trap[0] + Dir[1][0] * i < Maze.size - 1 && Trap[1] + Dir[1][1] * i >= 1 && Trap[1] + Dir[1][1] * i < Maze.size - 1)
                    {
                        if (map[Trap[0] + Dir[1][0] * i, Trap[1] + Dir[1][1] * i] == 3) //Down
                            break;
                    }
                    if (Trap[0] + Dir[2][0] * i >= 1 && Trap[0] + Dir[2][0] * i < Maze.size - 1 && Trap[1] + Dir[2][1] * i >= 1 && Trap[1] + Dir[2][1] * i < Maze.size - 1)
                    {
                        if (map[Trap[0] + Dir[2][0] * i, Trap[1] + Dir[2][1] * i] == 3) //Right
                            break;
                    }
                    if (Trap[0] + Dir[3][0] * i >= 1 && Trap[0] + Dir[3][0] * i < Maze.size - 1 && Trap[1] + Dir[3][1] * i >= 1 && Trap[1] + Dir[3][1] * i < Maze.size - 1)
                    {
                        if (map[Trap[0] + Dir[3][0] * i, Trap[1] + Dir[3][1] * i] == 3) //Left
                            break;
                    }
                    //Diagonals Up
                    if (Trap[0] + Dir[4][0] * i >= 1 && Trap[0] + Dir[4][0] * i < Maze.size - 1 && Trap[1] + Dir[4][1] * i >= 1 && Trap[1] + Dir[4][1] * i < Maze.size - 1)
                    {
                        if (map[Trap[0] + Dir[4][0], Trap[1] + Dir[4][1]] == 3)
                            break;
                    }
                    if (Trap[0] + Dir[5][0] * i >= 1 && Trap[0] + Dir[5][0] * i < Maze.size - 1 && Trap[1] + Dir[5][1] * i >= 1 && Trap[1] + Dir[5][1] * i < Maze.size - 1)
                    {
                        if (map[Trap[0] + Dir[5][0], Trap[1] + Dir[5][1]] == 3)
                            break;
                    }
                    //Diagonals Down
                    if (Trap[0] + Dir[6][0] * i >= 1 && Trap[0] + Dir[6][0] * i < Maze.size - 1 && Trap[1] + Dir[6][1] * i >= 1 && Trap[1] + Dir[6][1] * i < Maze.size - 1)
                    {
                        if (map[Trap[0] + Dir[6][0], Trap[1] + Dir[6][1]] == 3)
                            break;
                    }
                    if (Trap[0] + Dir[7][0] * i >= 1 && Trap[0] + Dir[7][0] * i < Maze.size - 1 && Trap[1] + Dir[7][1] * i >= 1 && Trap[1] + Dir[7][1] * i < Maze.size - 1)
                    {
                        if (map[Trap[0] + Dir[7][0], Trap[1] + Dir[7][1]] == 3)
                            break;
                    }
                    if (i == 3)
                        return Trap;
                }
            }
        }
    }
    class TReturn10 : Trap
    {
        public override void CastTrap(Hero hero, int[,] map)
        {
            Console.Clear();
            Console.WriteLine("YOU SHALL TRAVEL IN TIME TO THE PLACE YOU WERE 5 MOVEMENTS AGO!");
            Console.WriteLine("");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
            if (hero.locationlog.Count < 6)
            {
                map[hero.location[0], hero.location[1]] = 0;
                hero.location[0] = hero.locationlog[0][0];
                hero.location[1] = hero.locationlog[0][1];
                map[hero.location[0], hero.location[1]] = hero.id;
            }
            else
            {
                map[hero.location[0], hero.location[1]] = 0;
                hero.location[0] = hero.locationlog[hero.locationlog.Count - 6][0];
                hero.location[1] = hero.locationlog[hero.locationlog.Count - 6][1];
                map[hero.location[0], hero.location[1]] = hero.id;
            }
        }
    }
    class TReturn5 : Trap
    {
        public override void CastTrap(Hero hero, int[,] map)
        {
            Console.Clear();
            Console.WriteLine("YOU SHALL TRAVEL IN TIME TO THE PLACE YOU WERE 10 MOVEMENTS AGO!");
            Console.WriteLine("");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
            if (hero.locationlog.Count < 11)
            {
                map[hero.location[0], hero.location[1]] = 0;
                hero.location[0] = hero.locationlog[0][0];
                hero.location[1] = hero.locationlog[0][1];
                map[hero.location[0], hero.location[1]] = hero.id;
            }
            else
            {
                map[hero.location[0], hero.location[1]] = 0;
                hero.location[0] = hero.locationlog[hero.locationlog.Count - 11][0];
                hero.location[1] = hero.locationlog[hero.locationlog.Count - 11][1];
                map[hero.location[0], hero.location[1]] = hero.id;
            }
        }
    }
    class TLoseMana5 : Trap
    {
        public override void CastTrap(Hero hero, int[,] map)
        {
            Console.Clear();
            Console.WriteLine("5 POINTS OF MANA ARE TAKEN FROM YOU!");
            Console.WriteLine("");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
            if (hero.mana < 5)
            {
                hero.mana = 0;
            }
            else
            {
                hero.mana = hero.mana -5;
            }
        }
    }
}