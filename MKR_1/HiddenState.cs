using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class HiddenState : IElementState
    {
        public void Handle(LightElementNode element)
        {
            Console.WriteLine($"Element {element.TagName} is Hidden");
        }

        public string GetStateDescription() => "Hidden";
        public bool CanAddChild() => true;
        public bool CanModifyClasses() => true;
        public string GetDisplayStyle() => "none";
    }
}
