using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class InteractiveElementLifecycleManager : ElementLifecycleManager
    {
        protected override void OnElementInserted(LightElementNode element)
        {
            base.OnElementInserted(element);
            Console.WriteLine($"[Lifecycle] {element.TagName} - Attaching event listeners for interactivity");
        }

        protected override void OnBeforeElementRemove(LightElementNode element)
        {
            base.OnBeforeElementRemove(element);
            Console.WriteLine($"[Lifecycle] {element.TagName} - Removing event listeners");
        }
    }
}
