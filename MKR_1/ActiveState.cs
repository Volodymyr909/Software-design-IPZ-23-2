using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class ActiveState : IElementState
    {
        public void Handle(LightElementNode element)
        {
            Console.WriteLine($"Element {element.TagName} is Active and ready");
        }

        public string GetStateDescription() => "Active";
        public bool CanAddChild() => true;
        public bool CanModifyClasses() => true;
        public string GetDisplayStyle() => "block";
    }
}
