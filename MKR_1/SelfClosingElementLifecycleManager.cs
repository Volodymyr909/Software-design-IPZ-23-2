using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class SelfClosingElementLifecycleManager : ElementLifecycleManager
    {
        protected override void OnTextRendered(LightElementNode element)
        {
            // Self-closing елементи не мають текстового контенту
            Console.WriteLine($"[Lifecycle] {element.TagName} - Self-closing element, no text content");
        }

        protected override void OnElementInserted(LightElementNode element)
        {
            base.OnElementInserted(element);
            Console.WriteLine($"[Lifecycle] {element.TagName} - Self-closing element rendered");
        }
    }
}
