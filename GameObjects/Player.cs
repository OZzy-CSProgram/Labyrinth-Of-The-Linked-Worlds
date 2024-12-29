using System.Net.Security;

namespace GameObjects
{
    class Player
    {
        public string Name;
        public static List<Hero> Heroes = new List<Hero>();
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
            Console.WriteLine("(Valid name," + Name + "!!!)");
        }
    }
}