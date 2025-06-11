using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public static class LightElementNodeExtensions
    {
        private static readonly Dictionary<string, ElementLifecycleManager> _lifecycleManagers =
            new Dictionary<string, ElementLifecycleManager>
            {
                { "block", new BlockElementLifecycleManager() },
                { "inline", new InlineElementLifecycleManager() },
                { "self-closing", new SelfClosingElementLifecycleManager() },
                { "interactive", new InteractiveElementLifecycleManager() }
            };

        public static void ProcessLifecycle(this LightElementNode element)
        {
            var manager = GetLifecycleManager(element);
            manager.ProcessElementLifecycle(element);
        }

        public static void ProcessRemoval(this LightElementNode element)
        {
            var manager = GetLifecycleManager(element);
            manager.ProcessElementRemoval(element);
        }

        private static ElementLifecycleManager GetLifecycleManager(LightElementNode element)
        {
            // Визначаємо тип lifecycle manager на основі властивостей елемента
            if (IsInteractiveElement(element.TagName))
            {
                return _lifecycleManagers["interactive"];
            }
            else if (element.ClosingType == "self-closing")
            {
                return _lifecycleManagers["self-closing"];
            }
            else if (element.DisplayType == "block")
            {
                return _lifecycleManagers["block"];
            }
            else
            {
                return _lifecycleManagers["inline"];
            }
        }

        private static bool IsInteractiveElement(string tagName)
        {
            var interactiveTags = new[] { "button", "input", "select", "textarea", "a" };
            return Array.Exists(interactiveTags, tag => tag.Equals(tagName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
