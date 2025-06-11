using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public interface IElementState
    {
        void Handle(LightElementNode element);
        string GetStateDescription();
        bool CanAddChild();
        bool CanModifyClasses();
        string GetDisplayStyle();
    }
}
