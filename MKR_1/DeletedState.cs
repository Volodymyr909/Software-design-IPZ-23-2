using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class DeletedState : IElementState
    {
        public void Handle(LightElementNode element)
        {
            Console.WriteLine($"Element {element.TagName} is marked for deletion");
        }

        public string GetStateDescription() => "Deleted";
        public bool CanAddChild() => false;
        public bool CanModifyClasses() => false;
        public string GetDisplayStyle() => "none";
    }
}
