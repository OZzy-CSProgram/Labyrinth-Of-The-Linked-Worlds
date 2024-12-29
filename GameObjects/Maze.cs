namespace GameObjects
{
    public class Maze
    {
        public static int size = 10;
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
                    if(maze[i,j] != 1)
                    {
                        FreePath.Add(new int[] { i, j});
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
            { 1,1,1,1,1,1,1,1,1,1},
            { 1,0,0,0,0,0,0,0,3,1},
            { 1,1,1,1,0,1,0,1,0,1},
            { 1,0,0,0,3,1,0,1,0,1},
            { 1,0,1,1,1,1,0,1,0,1},
            { 1,0,0,0,1,1,0,1,0,1},
            { 1,1,1,0,1,0,1,3,0,1},
            { 1,0,1,3,0,0,1,1,1,1},
            { 1,0,0,0,1,0,0,0,0,1},
            { 1,1,1,1,1,1,1,1,1,1},
            };
            GetPathes(maze);
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
    }

}
