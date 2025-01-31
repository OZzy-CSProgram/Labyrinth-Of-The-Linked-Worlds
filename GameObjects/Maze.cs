using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;
using Spectre.Console;
namespace GameObjects
{
    public class Maze
    {
        public static int size = 43;
        public int Trap;
        public int Path;
        public static int[] KeyLocation;
        public bool KeyOnMap;
        public int obstacle;
        public static List<int[]> FreePath = new List<int[]>();
        public static void GetPathes(int[,] maze)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (maze[i, j] == 0 || maze[i, j] == 3)
                    {
                        FreePath.Add(new int[] { i, j });
                    }
                }
            }
        }
        public static int[] GetRandomPath()
        {
            Random coord = new Random();
            int index = coord.Next(FreePath.Count);
            return FreePath[index];
        }
        public static int[,] Generator()
        {
            int[,] maze =
            {
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,0,0,3,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1},
            // { 1,1,1,0,1,1,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1},
            // { 1,0,0,0,1,0,1,0,1,0,0,0,1,0,3,0,1,0,1,0,1},
            // { 1,0,1,1,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1,0,1},
            // { 1,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,1},
            // { 1,0,1,0,1,1,1,0,1,1,1,1,1,0,1,0,1,1,1,0,1},
            // { 1,0,1,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,0,0,1},
            // { 1,0,1,1,1,0,1,1,1,1,1,0,1,0,1,0,1,1,1,0,1},
            // { 1,0,0,0,1,0,1,0,0,0,1,0,1,0,0,3,1,0,1,0,1},
            // { 1,1,1,0,1,0,1,0,1,4,1,1,1,1,1,0,1,0,1,0,1},
            // { 1,0,3,0,1,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1},
            // { 1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1},
            // { 1,0,0,0,1,0,1,0,1,0,1,0,1,3,1,0,0,0,0,0,1},
            // { 1,1,1,1,1,3,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1},
            // { 1,0,0,0,0,0,1,0,1,0,1,0,1,0,0,0,1,0,0,0,1},
            // { 1,0,1,1,1,1,1,0,1,3,1,0,1,1,1,1,1,0,1,0,1},
            // { 1,3,1,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,0,1},
            // { 1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            ////GENERIC FORM
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,}, //43x43

            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,0,3,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,3,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,4,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,0,3,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };

            //                        ALDOUS-BRODER ALGORYTHM

            //1 Mark all cells as unvisited( add all cells to the unvisited list)
            List<int[]> UnvisitedCells = new List<int[]>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (maze[i, j] != 1)
                    {
                        UnvisitedCells.Add(new int[] { i, j });
                    }
                }
            }
            //// Direction List
            int[][] Dir = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            //Up --- DOwn --Right --- Left
            //2 Choosing  a random cell to start with
            Random Random = new Random();
            int index = Random.Next(UnvisitedCells.Count);
            int[] SelectedCell = UnvisitedCells[index];
            int[] AdyacentCell = new int[] { 0, 0 };
            UnvisitedCells.RemoveAt(index);
            while (UnvisitedCells.Count > 0)
            {
                //pick a Direction
                int index1 = Random.Next(Dir.Length);
                int[] SelectedDir = Dir[index1];
                //Select an adyacent cell
                AdyacentCell[0] = SelectedCell[0] + SelectedDir[0] + SelectedDir[0];
                AdyacentCell[1] = SelectedCell[1] + SelectedDir[1] + SelectedDir[1];
                /// verify limits
                if (AdyacentCell[0] >= 1 && AdyacentCell[0] < size - 1 && AdyacentCell[1] >= 1 && AdyacentCell[1] < size - 1)
                {
                    if (maze[AdyacentCell[0], AdyacentCell[1]] == 0)
                    {
                        for (int i = 0; i < UnvisitedCells.Count; i++)
                        {
                            //if adyacent cell pertenece a la lista de las celdas no visitadas
                            if (AdyacentCell[0] == UnvisitedCells[i][0] && AdyacentCell[1] == UnvisitedCells[i][1])
                            {
                                //Break Wall between SelectedCell and AdyacentCell
                                maze[SelectedCell[0] + SelectedDir[0], SelectedCell[1] + SelectedDir[1]] = 0;
                                UnvisitedCells.RemoveAt(i);
                                SelectedCell[0] = AdyacentCell[0];
                                SelectedCell[1] = AdyacentCell[1];
                                break;
                            }
                            //Above is visited
                            // if (AdyacentCell[0] - 2 != UnvisitedCells[i][0] || AdyacentCell[1] + 0 != UnvisitedCells[i][1])
                            // {
                            //     //Also Down is visited
                            //     if (AdyacentCell[0] + 2 != UnvisitedCells[i][0] || AdyacentCell[1] + 0 != UnvisitedCells[i][1])
                            //     {
                            //         //also Right is visited
                            //         if (AdyacentCell[0] + 0 != UnvisitedCells[i][0] || AdyacentCell[1] + 2 != UnvisitedCells[i][1])
                            //         {
                            //             //Also Left is visited
                            //             if (AdyacentCell[0] + 0 != UnvisitedCells[i][0] || AdyacentCell[1] - 2 != UnvisitedCells[i][1])
                            //             {
                            //                 SelectedCell[0] = AdyacentCell[0];
                            //                 SelectedCell[1] = AdyacentCell[1];
                            //             }
                            //         }
                            //     }
                            // }

                        }
                        SelectedCell[0] = AdyacentCell[0];
                        SelectedCell[1] = AdyacentCell[1];
                    }
                }

            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0)
                    {
                        maze[i, j] = 2;
                    }
                    if (i == size - 1)
                    {
                        maze[i, j] = 2;
                    }
                    if (j == 0)
                    {
                        maze[i, j] = 2;
                    }
                    if (j == size - 1)
                    {
                        maze[i, j] = 2;
                    }
                }
            }
            //spawn artifact
            maze[Maze.size / 2, Maze.size / 2] = 4;
            /// build walls around it
            maze[Maze.size / 2 - 1, Maze.size / 2] = 2; // up
            maze[Maze.size / 2 + 1, Maze.size / 2] = 2;//down
            maze[Maze.size / 2, Maze.size / 2 - 1] = 2;//left
            maze[Maze.size / 2, Maze.size / 2 + 1] = 2;//right
            maze[Maze.size / 2 - 1, Maze.size / 2 - 1] = 2;//upleft
            maze[Maze.size / 2 + 1, Maze.size / 2 + 1] = 2;//downright
            maze[Maze.size / 2 - 1, Maze.size / 2 + 1] = 2;//upright
            maze[Maze.size / 2 + 1, Maze.size / 2 - 1] = 2;//downleft 
                                                          //
                                                          //🟦🟦🟦
                                                          //🟦💜🟦
                                                          //🟦🟦🟦
                                                          //
                                                          //paths arround
            maze[Maze.size / 2 - 2, Maze.size / 2] = 0; // up
            maze[Maze.size / 2 - 2, Maze.size / 2 - 1] = 0; // up
                                                           //🟩🟩
                                                           //🟦🟦🟦
                                                           //🟦💜🟦
                                                           //🟦🟦🟦
                                                           //
            maze[Maze.size / 2 - 2, Maze.size / 2 - 2] = 0; // up
            maze[Maze.size / 2 - 1, Maze.size / 2 - 2] = 0; // up
                                                           //🟩🟩🟩
                                                           //🟩🟦🟦🟦
                                                           //⬛🟦💜🟦
                                                           //⬛🟦🟦🟦
                                                           //
            maze[Maze.size / 2, Maze.size / 2 - 2] = 0; // up
            maze[Maze.size / 2 + 1, Maze.size / 2 - 2] = 0; // up
                                                           //🟩🟩🟩
                                                           //🟩🟦🟦🟦
                                                           //🟩🟦💜🟦
                                                           //🟩🟦🟦🟦
                                                           //
            maze[Maze.size / 2 + 2, Maze.size / 2 - 2] = 0; // up
            maze[Maze.size / 2 + 2, Maze.size / 2 - 1] = 0; // up
                                                           //🟩🟩🟩
                                                           //🟩🟦🟦🟦
                                                           //🟩🟦💜🟦
                                                           //🟩🟦🟦🟦
                                                           //🟩🟩
            maze[Maze.size / 2 + 2, Maze.size / 2] = 0; // up
            maze[Maze.size / 2 + 2, Maze.size / 2 + 1] = 0; // up
                                                           //🟩🟩🟩
                                                           //🟩🟦🟦🟦
                                                           //🟩🟦💜🟦
                                                           //🟩🟦🟦🟦
                                                           //🟩🟩🟩🟩
            maze[Maze.size / 2 + 2, Maze.size / 2 + 2] = 0; // up
            maze[Maze.size / 2 + 1, Maze.size / 2 + 2] = 0; // up
                                                           //🟩🟩🟩
                                                           //🟩🟦🟦🟦
                                                           //🟩🟦💜🟦
                                                           //🟩🟦🟦🟦🟩
                                                           //🟩🟩🟩🟩🟩
            maze[Maze.size / 2, Maze.size / 2 + 2] = 0; // up
            maze[Maze.size / 2 - 1, Maze.size / 2 + 2] = 0; // up
                                                           //🟩🟩🟩
                                                           //🟩🟦🟦🟦🟩
                                                           //🟩🟦💜🟦🟩
                                                           //🟩🟦🟦🟦🟩
                                                           //🟩🟩🟩🟩🟩
            maze[Maze.size / 2 - 2, Maze.size / 2 + 2] = 0; // up
            maze[Maze.size / 2 - 2, Maze.size / 2 + 1] = 0; // up
                                                           //🟩🟩🟩🟩🟩
                                                           //🟩🟦🟦🟦🟩
                                                           //🟩🟦💜🟦🟩
                                                           //🟩🟦🟦🟦🟩
                                                           //🟩🟩🟩🟩🟩
                                                           ////
            //Spawn Door
            Random random = new Random();
            List<int[]> DoorSpawn = new List<int[]>();
            DoorSpawn.Add(new int[] { Maze.size / 2, Maze.size / 2 - 1 });
            DoorSpawn.Add(new int[] { Maze.size / 2, Maze.size / 2 + 1 });

            int doorspawnindex = random.Next(DoorSpawn.Count);
            maze[DoorSpawn[doorspawnindex][0], DoorSpawn[doorspawnindex][1]] = 6;

            int[] KeyLocation = new int[2];
            KeyLocation[0] = Maze.size / 2 + 2;
            KeyLocation[1] = Maze.size / 2 + 1;
            Maze.SpawnKey(maze);
            return maze;
        }
        public virtual void CastSpell()
        {
            Console.WriteLine("Casting Spell");
        }
        public static Table PrintMaze(int[,] maze, string a)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var table = new Table();
            table.AddColumn(new TableColumn("  " + a + "  ").Centered());

            for (int i = 0; i < size; i++)
            {
                string rowMarkup = "";
                var row = new Markup("");
                for (int j = 0; j < size; j++)
                {
                    string cellMarkup;
                    switch (maze[i, j])
                    {
                        case 1: // wall
                            cellMarkup = "[#3A6089]███[/]"; // Wall blue
                            break;
                        case 2: // wall
                            cellMarkup = "[#3a4089]███[/]"; // Wall blue
                            break;
                        case 0: // FreePath
                            cellMarkup = "[#232324]   [/]"; // Gray Pathes♥
                            break;
                        case 3: // Trap
                            cellMarkup = "[red] ✸ [/]"; // Red Trap
                            break;
                        case 4: // Meta
                            cellMarkup = "[#4D017C]💜 [/]"; // Heart of Ebony
                            break;
                        case 6: // Meta
                            cellMarkup = "[#4D017C] 🚪[/]"; // Heart of Ebony
                            break;
                        case 8: // Meta
                            cellMarkup = "[#4D017C] 🔑[/]"; // Heart of Ebony
                            break;
                        case 11: //Mage
                            cellMarkup = "[#4D017C]🧙 [/]"; // Mage
                            break;
                        case 13: //Wallbreaker
                            cellMarkup = "[#4D017C]👳 [/]"; // Mage
                            break;
                        case 15: //HEro
                            cellMarkup = "[#4D017C]🐵 [/]"; // Mage
                            break;
                        case 17: //HEro
                            cellMarkup = "[#4D017C]🧞 [/]"; // Mage
                            break;
                        case 19: //Wallbreaker
                            cellMarkup = "[#4D017C]👹 [/]"; // Mage
                            break;
                        case 21: //HEro
                            cellMarkup = "[#4D017C]👽 [/]"; // Mage
                            break;
                        default:
                            cellMarkup = "[transparent]███[/]";
                            break;
                    }
                    rowMarkup += cellMarkup;
                }
                table.AddRow(new Markup(rowMarkup));
            }
            return table;
        }
        public static void PrintMaze2(int[,] maze, string a, Table downrighttable, Hero hero)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var table = new Table();
            table.AddColumn(new TableColumn("✣  " + a + "  ✣ ").Centered());

            for (int i = 0; i < size; i++)
            {
                string rowMarkup = "";
                var row = new Markup("");
                for (int j = 0; j < size; j++)
                {
                    string cellMarkup;
                    switch (maze[i, j])
                    {
                        case 1: // wall
                            cellMarkup = "[#3A6089]███[/]"; // Wall blue
                            break;
                        case 2: // wall
                            cellMarkup = "[#3a4089]███[/]"; // Wall blue
                            break;
                        case 0: // FreePath
                            cellMarkup = "[#232324]   [/]"; // Gray Pathes♥
                            break;
                        case 3: // Trap
                            cellMarkup = "[red] ✸ [/]"; // Red Trap
                            break;
                        case 4: // Meta
                            cellMarkup = "[#4D017C]💜 [/]"; // Heart of Ebony
                            break;
                        case 6: // Meta
                            cellMarkup = "[#4D017C] 🚪[/]"; // Heart of Ebony
                            break;
                        case 8: // Meta
                            cellMarkup = "[#4D017C] 🔑[/]"; // Heart of Ebony
                            break;
                        case 11: //Mage
                            cellMarkup = "[#4D017C]🧙 [/]"; // Mage
                            break;
                        case 13: //Wallbreaker
                            cellMarkup = "[#4D017C]👳 [/]"; // Mage
                            break;
                        case 15: //HEro
                            cellMarkup = "[#4D017C]🐵 [/]"; // Mage
                            break;
                        case 17: //HEro
                            cellMarkup = "[#4D017C]🧞 [/]"; // Mage
                            break;
                        case 19: //Wallbreaker
                            cellMarkup = "[#4D017C]👹 [/]"; // Mage
                            break;
                        case 21: //HEro
                            cellMarkup = "[#4D017C]👽 [/]"; // Mage
                            break;
                        default:
                            cellMarkup = "[transparent]███[/]";
                            break;
                    }
                    rowMarkup += cellMarkup;
                }
                table.AddRow(new Markup(rowMarkup).Centered());
            }
            var healthmanabar = new BarChart();
            if (hero.health >= 7)
            {
                healthmanabar.Width(50);
                healthmanabar.Label($"[blue bold]| [/][bold #000000]{hero.icon}[/][blue bold] |[/][black]  >>  [/][white] {hero.name}[/]\n").LeftAlignLabel();
                healthmanabar.AddItem("💓", hero.health, Color.Green4);
                healthmanabar.AddItem("💙", hero.mana, Color.Blue);
            }
            else if (hero.health >= 5)
            {
                healthmanabar.Width(50);
                healthmanabar.Label($"[blue bold]| [/][bold #000000]{hero.icon}[/][blue bold] |[/][black]  >>  [/][white] {hero.name}[/]\n").LeftAlignLabel();
                healthmanabar.AddItem("💓", hero.health, Color.Yellow2);
                healthmanabar.AddItem("💙", hero.mana, Color.Blue);
            }
            else if (hero.health >= 3)
            {
                healthmanabar.Width(50);
                healthmanabar.Label($"[blue bold]| [/][bold #000000]{hero.icon}[/][blue bold] |[/][black]  >>  [/][white] {hero.name}[/]\n").LeftAlignLabel();
                healthmanabar.AddItem("💓", hero.health, Color.Orange1);
                healthmanabar.AddItem("💙", hero.mana, Color.Blue);
            }
            else if (hero.health >= 0)
            {
                healthmanabar.Width(50);
                healthmanabar.Label($"[blue bold]| [/][bold #000000]{hero.icon}[/][blue bold] |[/][black]  >>  [/][white] {hero.name}[/]\n").LeftAlignLabel();
                healthmanabar.AddItem("💓", hero.health, Color.DarkRed);
                healthmanabar.AddItem("💙", hero.mana, Color.Blue);
            }
            var stats = new Table()
            .NoBorder()
            .AddColumn(new TableColumn($"🎬[yellow bold] actions left[/] [bold]{hero.actionsRemaining}[/]"))
            .AddRow($"👢[green bold]↗[/] Speed      x[bold #ebff6d]{hero.speed}[/] / x[bold #ebff6d]{hero.maxspeed}[/]").LeftAligned()
            .AddRow($"[black]⚓[/] Toughness   [bold]{hero.toughness}[/]").LeftAligned()
            .AddRow($"💓 Health      [bold]{hero.health}[/]").LeftAligned()
            .AddRow($"💙 Mana        [bold]{hero.mana}[/]").LeftAligned();

            var downtable = new Table();
            downtable.AddColumn(new TableColumn(healthmanabar));
            downtable.AddColumn(new TableColumn(stats));
            downtable.AddColumn(new TableColumn(downrighttable).Centered());
            downtable.Expand();
            table.AddRow(downtable.Centered());
            AnsiConsole.Write(table);
        }
        public static void SpawnKey(int[,] map)
        {
            List<int[]> posiblespawns = new List<int[]>();
            for (int i = 15; i < 27; i++)
            {
                for (int j = 11; j < 29; j++)
                {
                    if (map[i, j] == 0)
                    {
                        posiblespawns.Add(new int[] { i, j });
                    }
                }
            }

            ///take a random
            Random coord = new Random();
            int index = coord.Next(posiblespawns.Count);
            map[posiblespawns[index][0], posiblespawns[index][1]] = 8;
            Maze.KeyLocation = posiblespawns[index];
        }
        public static int DistanceFromKey(Hero hero, int v, int w, int size)
        {
            int Count = 0;
            int[,] map2 = new int[size, size];
            //set the entire matrix as -1
            List<int[]> notchecked = new List<int[]>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    map2[i, j] = -1;
                    Count++;
                }
            }

            ///mark the key location as 0
            map2[v, w] = 0;
            Count--;
            //
            //1️⃣1️⃣1️⃣
            //1️⃣🔑1️⃣
            //1️⃣1️⃣1️⃣
            //
            map2[v - 1, w] = 1; //up
            Count--;

            map2[v + 1, w] = 1; //down
            Count--;

            map2[v, w - 1] = 1; //left
            Count--;

            map2[v, w + 1] = 1; //right
            Count--;


            map2[v - 1, w + 1] = 1; //upright
            Count--;

            map2[v - 1, w - 1] = 1; //upleft
            Count--;

            map2[v + 1, w + 1] = 1; //downright
            Count--;

            map2[v + 1, w - 1] = 1; //downleft
            Count--;

            int x = 1;

            while (Count > 0)
            {
                x++;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (map2[i, j] == x - 1)
                        {
                            //up
                            if (i - 1 >= 0 && i - 1 < size)
                            {
                                if (map2[i - 1, j] == -1)
                                {
                                    Count--;
                                    map2[i - 1, j] = x;
                                }
                            }
                            //down
                            if (i + 1 >= 0 && i + 1 < size)
                            {
                                if (map2[i + 1, j] == -1)
                                {
                                    Count--;
                                    map2[i + 1, j] = x;
                                }
                            }
                            //left
                            if (j - 1 >= 0 && j - 1 < size)
                            {
                                if (map2[i, j - 1] == -1)
                                {
                                    Count--;
                                    map2[i, j - 1] = x;
                                }
                            }
                            //right
                            if (j + 1 >= 0 && j + 1 < size)
                            {
                                if (map2[i, j + 1] == -1)
                                {
                                    Count--;
                                    map2[i, j + 1] = x;
                                }
                            }
                            //diagonals
                            //upleft
                            if (i - 1 >= 0 && i - 1 < size && j - 1 >= 0 && j - 1 < size)
                            {
                                if (map2[i - 1, j - 1] == -1)
                                {
                                    Count--;
                                    map2[i - 1, j - 1] = x;
                                }
                            }
                            //upright
                            if (i - 1 >= 0 && i - 1 < size && j + 1 >= 0 && j + 1 < size)
                            {
                                if (map2[i - 1, j + 1] == -1)
                                {
                                    Count--;
                                    map2[i - 1, j + 1] = x;
                                }
                            }
                            //downleft
                            if (i + 1 >= 0 && i + 1 < size && j - 1 >= 0 && j - 1 < size)
                            {
                                if (map2[i + 1, j - 1] == -1)
                                {
                                    Count--;
                                    map2[i + 1, j - 1] = x;
                                }
                            }
                            //downright
                            if (i + 1 >= 0 && i + 1 < size && j + 1 >= 0 && j + 1 < size)
                            {
                                if (map2[i + 1, j + 1] == -1)
                                {
                                    Count--;
                                    map2[i + 1, j + 1] = x;
                                }
                            }
                        }
                    }
                }






            }
            int distance = map2[hero.location[0], hero.location[1]];
            return distance;
        }

    }

}
