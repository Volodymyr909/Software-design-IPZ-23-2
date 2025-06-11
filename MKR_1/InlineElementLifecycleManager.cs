using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class InlineElementLifecycleManager : ElementLifecycleManager
    {
        protected override void OnStylesApplying(LightElementNode element)
        {
            base.OnStylesApplying(element);
            Console.WriteLine($"[Lifecycle] {element.TagName} - Applying inline display styles");
        }

        protected override void OnElementInserted(LightElementNode element)
        {
            base.OnElementInserted(element);
            Console.WriteLine($"[Lifecycle] {element.TagName} - Inline element flows with text");
        }
    }
}
