using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public abstract class ElementLifecycleManager
    {
        // Шаблонний метод - визначає алгоритм життєвого циклу елемента
        public void ProcessElementLifecycle(LightElementNode element)
        {
            OnElementCreated(element);
            OnStylesApplying(element);
            OnClassListApplying(element);
            OnElementInserted(element);
            OnTextRendered(element);
            OnLifecycleCompleted(element);
        }

        // Шаблонний метод для видалення елемента
        public void ProcessElementRemoval(LightElementNode element)
        {
            OnBeforeElementRemove(element);
            OnElementRemoving(element);
            OnAfterElementRemove(element);
        }

        // Хуки життєвого циклу - віртуальні методи для перевизначення
        protected virtual void OnElementCreated(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - Element created");
        }

        protected virtual void OnStylesApplying(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - Styles applying");
        }

        protected virtual void OnClassListApplying(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - CSS classes applying");
            if (element.CssClasses.Count > 0)
            {
                Console.WriteLine($"[Lifecycle] {element.TagName} - Classes: {string.Join(", ", element.CssClasses)}");
            }
        }

        protected virtual void OnElementInserted(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - Element inserted into DOM");
        }

        protected virtual void OnTextRendered(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - Text content rendered");
        }

        protected virtual void OnLifecycleCompleted(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - Lifecycle completed");
        }

        // Хуки для видалення
        protected virtual void OnBeforeElementRemove(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - Preparing for removal");
        }

        protected virtual void OnElementRemoving(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - Element removing");
        }

        protected virtual void OnAfterElementRemove(LightElementNode element)
        {
            Console.WriteLine($"[Lifecycle] {element.TagName} - Cleanup after removal");
        }
    }
}
