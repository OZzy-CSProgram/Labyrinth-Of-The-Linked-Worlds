using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;
using Spectre.Console;
namespace GameObjects
{
    public class Maze
    {
        public static int size = 7;
        public int Trap;
        public int Path;
        public int obstacle;
        public static List<int[]> FreePath = new List<int[]>();
        public static void GetPathes(int[,] maze)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (maze[i, j] != 1)
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
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            // { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            // { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            { 1,1,1,1,1,1,1},
            { 1,0,1,0,1,0,1},
            { 1,1,1,1,1,1,1},
            { 1,0,1,0,1,0,1},
            { 1,1,1,1,1,1,1},
            { 1,0,1,0,1,0,1},
            { 1,1,1,1,1,1,1},
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
            GetPathes(maze);
            //                        ALDOUS-BRODER ALGORYTHM

            //1 Mark all cells as unvisited
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
            int[] AdyacentCell = new int[] {0,0};
            UnvisitedCells.RemoveAt(index);
            while (UnvisitedCells.Count > 0)
            {
                //pick a Direction
                int index1 = Random.Next(Dir.Length);
                int[] SelectedDir = Dir[index1];
                Console.WriteLine($"escoji al dir [{Dir[index1][0]},{Dir[index1][1]}]");
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
                                Console.WriteLine($"entre al if y el tama;o es {UnvisitedCells.Count}");
                                Console.WriteLine($"escoji al cell [{SelectedCell[0]},{SelectedCell[1]}");
                                Console.WriteLine($"escoji al vecino [{AdyacentCell[0]},{AdyacentCell[1]}");

                                //Break Wall between SelectedCell and AdyacentCell
                                maze[SelectedCell[0] + SelectedDir[0], SelectedCell[1] + SelectedDir[1]] = 0;
                                Console.WriteLine($"Voy  a picar en [{SelectedCell[0] + SelectedDir[0]},{SelectedCell[1] + SelectedDir[1]}");
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
                        PrintMaze(maze,"aaa");
                        Console.ReadKey(true);
                        Console.WriteLine($"EStoy en [{SelectedCell[0]},{SelectedCell[1]}");

                    }
                }

            }
            return maze;
        }


        public static bool isValidLocation(int row, int col)
        {
            //=======================================================================================================PENDIENTE!!completar esta Pingueta
            return true;
        }
        public virtual void CastSpell()
        {
            Console.WriteLine("Casting Spell");
        }
        public static void PrintMaze(int[,] maze, string a)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var table = new Table();
            table.AddColumn(new TableColumn("✣  " + a + "  ✣").Centered());

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
                        case 0: // FreePath
                            cellMarkup = "[#232324]███[/]"; // Gray Pathes♥
                            break;
                        case 3: // Trap
                            cellMarkup = "[red] ✸ [/]"; // Red Trap
                            break;
                        case 4: // Meta
                            cellMarkup = "[#4D017C]💜 [/]"; // Heart of Ebony
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
                        default:
                            cellMarkup = "[transparent]███[/]";
                            break;
                    }
                    rowMarkup += cellMarkup;
                }
                table.AddRow(new Markup(rowMarkup));
            }
            AnsiConsole.Write(table);
        }
    }

}
