using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class CreatedState : IElementState
    {
        public void Handle(LightElementNode element)
        {
            Console.WriteLine($"Element {element.TagName} is in Created state");
        }

        public string GetStateDescription() => "Created";
        public bool CanAddChild() => true;
        public bool CanModifyClasses() => true;
        public string GetDisplayStyle() => "initial";
    }
}
