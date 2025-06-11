using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class TemplateMethodDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("=== Template Method Pattern Demo ===\n");

            // Створення різних типів елементів
            Console.WriteLine("--- Creating block element (div) ---");
            var div = new LightElementNode("div", "block", "closing");
            div.AddCssClass("container");
            div.ProcessLifecycle();

            Console.WriteLine("\n--- Creating inline element (span) ---");
            var span = new LightElementNode("span", "inline", "closing");
            span.AddCssClass("text");
            span.ProcessLifecycle();

            Console.WriteLine("\n--- Creating self-closing element (img) ---");
            var img = new LightElementNode("img", "inline", "self-closing");
            img.AddCssClass("image");
            img.ProcessLifecycle();

            Console.WriteLine("\n--- Creating interactive element (button) ---");
            var button = new LightElementNode("button", "inline", "closing");
            button.AddCssClass("btn");
            button.ProcessLifecycle();

            Console.WriteLine("\n--- Demonstrating element removal lifecycle ---");
            Console.WriteLine("Removing button:");
            button.ProcessRemoval();

            Console.WriteLine("\nRemoving img:");
            img.ProcessRemoval();

            Console.WriteLine("\n--- Generated HTML ---");
            Console.WriteLine($"Div: {div.OuterHTML}");
            Console.WriteLine($"Span: {span.OuterHTML}");
        }
    }
}
