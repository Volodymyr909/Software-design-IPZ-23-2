using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IHero
    {
        string Name { get; }
        int Health { get; }
        int Attack { get; }
        void DisplayStats();
    }
}
