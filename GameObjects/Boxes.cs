using System.Data;
using Spectre.Console;
namespace GameObjects
{
    public class Box
    {
        public static List<int[]> PosibleSpawns = new List<int[]>();
        public virtual void CastBox(Hero hero, int[,] map)
        {
            Console.WriteLine("Casting Trap");
        }
        public static void SpawnBoxes(int[,] map)
        {
            
            for (int i = 0; i < Maze.size; i++)
            {
                for (int j = 0; j < Maze.size; j++)
                {
                    if(map[i,j] == 0)
                    PosibleSpawns.Add(new int[] { i, j });
                }
            }
            int[] Box1 = Maze.GetRandomPath(PosibleSpawns);
            map[Box1[0], Box1[1]] = 5;

            int[] Box2 = GetBox(map);
            map[Box2[0], Box2[1]] = 5;

            int[] Box3 = GetBox(map);
            map[Box3[0], Box3[1]] = 5;

            int[] Box4 = GetBox(map);
            map[Box4[0], Box4[1]] = 5;

            int[] Box5 = GetBox(map);
            map[Box5[0], Box5[1]] = 5;

            int[] Box6 = GetBox(map);
            map[Box6[0], Box6[1]] = 5;

            int[] Box7 = GetBox(map);
            map[Box7[0], Box7[1]] = 5;

            int[] Box8 = GetBox(map);
            map[Box8[0], Box8[1]] = 5;

            int[] Box9 = GetBox(map);
            map[Box9[0], Box9[1]] = 5;

            int[] Box10 = GetBox(map);
            map[Box10[0], Box10[1]] = 5;

            int[] Box11 = GetBox(map);
            map[Box11[0], Box11[1]] = 5;

            int[] Box12 = GetBox(map);
            map[Box12[0], Box12[1]] = 5;
        }

        public static int[] GetBox(int[,] map)
        {
            int[] Box;
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
                Box = Maze.GetRandomPath(PosibleSpawns);
                for (int i = 1; i < 4; i++)
                {
                    if (Box[0] + Dir[0][0] * i >= 1 && Box[0] + Dir[0][0] * i < Maze.size - 1 && Box[1] + Dir[0][1] * i >= 1 && Box[1] + Dir[0][1] * i < Maze.size - 1)
                    {
                        if (map[Box[0] + Dir[0][0] * i, Box[1] + Dir[0][1] * i] == 5) //Up
                            break;
                    }
                    if (Box[0] + Dir[1][0] * i >= 1 && Box[0] + Dir[1][0] * i < Maze.size - 1 && Box[1] + Dir[1][1] * i >= 1 && Box[1] + Dir[1][1] * i < Maze.size - 1)
                    {
                        if (map[Box[0] + Dir[1][0] * i, Box[1] + Dir[1][1] * i] == 5) //Down
                            break;
                    }
                    if (Box[0] + Dir[2][0] * i >= 1 && Box[0] + Dir[2][0] * i < Maze.size - 1 && Box[1] + Dir[2][1] * i >= 1 && Box[1] + Dir[2][1] * i < Maze.size - 1)
                    {
                        if (map[Box[0] + Dir[2][0] * i, Box[1] + Dir[2][1] * i] == 5) //Right
                            break;
                    }
                    if (Box[0] + Dir[3][0] * i >= 1 && Box[0] + Dir[3][0] * i < Maze.size - 1 && Box[1] + Dir[3][1] * i >= 1 && Box[1] + Dir[3][1] * i < Maze.size - 1)
                    {
                        if (map[Box[0] + Dir[3][0] * i, Box[1] + Dir[3][1] * i] == 5) //Left
                            break;
                    }
                    //Diagonals Up
                    if (Box[0] + Dir[4][0] * i >= 1 && Box[0] + Dir[4][0] * i < Maze.size - 1 && Box[1] + Dir[4][1] * i >= 1 && Box[1] + Dir[4][1] * i < Maze.size - 1)
                    {
                        if (map[Box[0] + Dir[4][0], Box[1] + Dir[4][1]] == 5)
                            break;
                    }
                    if (Box[0] + Dir[5][0] * i >= 1 && Box[0] + Dir[5][0] * i < Maze.size - 1 && Box[1] + Dir[5][1] * i >= 1 && Box[1] + Dir[5][1] * i < Maze.size - 1)
                    {
                        if (map[Box[0] + Dir[5][0], Box[1] + Dir[5][1]] == 5)
                            break;
                    }
                    //Diagonals Down
                    if (Box[0] + Dir[6][0] * i >= 1 && Box[0] + Dir[6][0] * i < Maze.size - 1 && Box[1] + Dir[6][1] * i >= 1 && Box[1] + Dir[6][1] * i < Maze.size - 1)
                    {
                        if (map[Box[0] + Dir[6][0], Box[1] + Dir[6][1]] == 5)
                            break;
                    }
                    if (Box[0] + Dir[7][0] * i >= 1 && Box[0] + Dir[7][0] * i < Maze.size - 1 && Box[1] + Dir[7][1] * i >= 1 && Box[1] + Dir[7][1] * i < Maze.size - 1)
                    {
                        if (map[Box[0] + Dir[7][0], Box[1] + Dir[7][1]] == 5)
                            break;
                    }
                    if (i == 3)
                        return Box;
                }
            }
        }
    }
    class MoreHealth : Box
    {
        public override void CastBox(Hero hero, int[,] map)
        {
            Console.Clear();
            Menu.WriteTable("[yellow bold]Gift Box![/][blue bold] >[/] [blue]Your health has been incremented [/][green]5 points[/][blue]!!![/]");
            Menu.KeyToContinue();
            hero.health+=5;
        }
    }
    class MoreMana : Box
    {
        public override void CastBox(Hero hero, int[,] map)
        {
            Console.Clear();
            Menu.WriteTable("[yellow bold]Gift Box![/][blue bold] >[/] [blue]Your mana has been incremented [/][green]5 points[/][blue]!!![/]");
            Menu.KeyToContinue();
            hero.mana+=5;
        }
    }
    class MoreToughness : Box
    {
        public override void CastBox(Hero hero, int[,] map)
        {
            Console.Clear();
            Menu.WriteTable("[yellow bold]Gift Box![/][blue bold] >[/] [blue]Your toughness has been incremented [/][green]6 points[/][blue]!!![/]");
            Menu.KeyToContinue();
            hero.toughness+=6;
        }
    }
    class MoreSpeed : Box
    {
        public override void CastBox(Hero hero, int[,] map)
        {
            Console.Clear();
            Menu.WriteTable("[yellow bold]Gift Box![/][blue bold] >[/] [blue]Your speed has been incremented by [/][green]1x[/][blue]!!![/]");
            Menu.KeyToContinue();
            hero.speed++;
            hero.maxspeed++;
        }
    }
}