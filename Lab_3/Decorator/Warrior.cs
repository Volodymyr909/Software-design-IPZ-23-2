using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Warrior : IHero
    {
        public string Name => "Warrior";
        public int Health => 100;
        public int Attack => 20;

        public void DisplayStats()
        {
            Console.WriteLine($"Hero: {Name}, Health: {Health}, Attack: {Attack}");
        }
    }

    public class Mage : IHero
    {
        public string Name => "Mage";
        public int Health => 80;
        public int Attack => 30;

        public void DisplayStats()
        {
            Console.WriteLine($"Hero: {Name}, Health: {Health}, Attack: {Attack}");
        }
    }

    public class Paladin : IHero
    {
        public string Name => "Paladin";
        public int Health => 120;
        public int Attack => 15;

        public void DisplayStats()
        {
            Console.WriteLine($"Hero: {Name}, Health: {Health}, Attack: {Attack}");
        }
    }
}
