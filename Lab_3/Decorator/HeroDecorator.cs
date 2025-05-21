using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class HeroDecorator : IHero
    {
        protected IHero _hero;

        public HeroDecorator(IHero hero)
        {
            _hero = hero;
        }

        public virtual string Name => _hero.Name;
        public virtual int Health => _hero.Health;
        public virtual int Attack => _hero.Attack;

        public virtual void DisplayStats()
        {
            _hero.DisplayStats();
        }
    }

}
