using System.Net.Security;

namespace GameObjects
{
    public class Player
    {
        public string Name;
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
    }
}