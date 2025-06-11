using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        string Description { get; }
    }
}
