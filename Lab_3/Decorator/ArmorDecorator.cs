using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class ArmorDecorator : HeroDecorator
    {
        public ArmorDecorator(IHero hero) : base(hero) { }

        public override int Health => _hero.Health + 50;

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Equipped with Armor: +50 Health");
        }
    }

    public class WeaponDecorator : HeroDecorator
    {
        public WeaponDecorator(IHero hero) : base(hero) { }

        public override int Attack => _hero.Attack + 20;

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Equipped with Weapon: +20 Attack");
        }
    }

    public class ArtifactDecorator : HeroDecorator
    {
        public ArtifactDecorator(IHero hero) : base(hero) { }

        public override int Health => _hero.Health + 20;
        public override int Attack => _hero.Attack + 10;

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Equipped with Artifact: +20 Health, +10 Attack");
        }
    }

}
