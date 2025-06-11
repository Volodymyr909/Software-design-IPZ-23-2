using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class BlockElementLifecycleManager : ElementLifecycleManager
    {
        protected override void OnStylesApplying(LightElementNode element)
        {
            base.OnStylesApplying(element);
            Console.WriteLine($"[Lifecycle] {element.TagName} - Applying block-level display styles");
        }

        protected override void OnElementInserted(LightElementNode element)
        {
            base.OnElementInserted(element);
            Console.WriteLine($"[Lifecycle] {element.TagName} - Block element takes full width");
        }
    }
}
