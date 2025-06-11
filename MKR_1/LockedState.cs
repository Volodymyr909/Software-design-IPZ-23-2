using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class LockedState : IElementState
    {
        public void Handle(LightElementNode element)
        {
            Console.WriteLine($"Element {element.TagName} is Locked - no modifications allowed");
        }

        public string GetStateDescription() => "Locked";
        public bool CanAddChild() => false;
        public bool CanModifyClasses() => false;
        public string GetDisplayStyle() => "none";
    }
}
