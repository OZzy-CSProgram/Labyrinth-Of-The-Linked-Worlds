using Spectre.Console;
namespace GameObjects
{
    class Trap
    {
        public virtual void CastTrap(Hero hero, int[,] map)
        {
            Console.WriteLine("Casting Trap");
        }
    }
    class Trap1 : Trap
    {
        public override void CastTrap(Hero hero, int[,] map)
        {
            Console.Clear();
            Console.WriteLine("YOU SHALL TRAVEL IN TIME TO THE PLACE YOU WERE 5 CELLS AGO!");
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
    class Trap2 : Trap
    {
        public override void CastTrap(Hero hero, int[,] map)
        {
            Console.Clear();
            Console.WriteLine("YOU SHALL TRAVEL IN TIME TO THE PLACE YOU WERE 10 CELLS AGO!");
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
}