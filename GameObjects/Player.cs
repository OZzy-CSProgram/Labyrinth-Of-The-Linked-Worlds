using System.Net.Security;
using Spectre.Console;
namespace GameObjects
{
    public class Player
    {
        public string Name;

        public static bool play = true;
        public static bool exit = false;
        public bool turn;
        public List<Hero> Party = new List<Hero>();
        public Player(string name)
        {
            Name = name;
        }
        public static string intname(string s)
        {

            while (s == "")
            {
                Console.WriteLine("I dont like that name, write another one! And take this serious!");
                s = Console.ReadLine();
                if (s != "")
                {
                    break;
                }
            }
            return s;
        }
        public void Greet()
        {
            Console.Write("            ✅(Valid name," + Name + "!!!)");
        }
        public static Hero GetPlayerChoice(List<Hero> list)
        {
            while (true)
            {
                Console.Write("Write the number of the Hero you want to choose: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int index) && index > 0 && index <= list.Count)
                {
                    return list[index - 1]; // Retorna el token elegido
                }

                Console.WriteLine("Invalid choice. Please Try Again.");
            }
        }
        public static void Roleplay1()
        {
            // var roleplay1 = new Table();
            // roleplay1.AddColumn(new TableColumn("LADY ELARA"));
            // roleplay1.AddColumn(new TableColumn(""));
            // roleplay1.AddRow("         w*W*W*W*w       ");
            // roleplay1.AddRow("          \'.'.'/        ");
            // roleplay1.AddRow("           //`\\         ");
            // roleplay1.AddRow("          (/a a\)        ");
            // roleplay1.AddRow("          (\_-_/)        ");
            // roleplay1.AddRow("         .-~'='~-.       ");
            // roleplay1.AddRow("        /`~`'Y'`~`\      ");
            // roleplay1.AddRow("       / /(_ * _)\ \     ");
            // roleplay1.AddRow("      / /  )   (  \ \    ");
            // roleplay1.AddRow("      \ \_/\\_//\_/ /    ");
            // roleplay1.AddRow("       \/_) '*' (_\/     ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("         |       |       ");
            // roleplay1.AddRow("     w * W * W * W * w   ");

            // roleplay1.AddRow("", "a");
        }
    }
}