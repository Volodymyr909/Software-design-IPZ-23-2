using Composer;
using MKR1;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        LightElementNode div = new LightElementNode("div", "block", "closing");
        div.AddCssClass("container");
        div.AddCssClass("main");

        LightElementNode p = new LightElementNode("p", "block", "closing");
        p.AddCssClass("text");
        LightTextNode textNode = new LightTextNode("Hello, this is a paragraph.");
        p.AddChild(textNode);
        div.AddChild(p);

        LightElementNode img = new LightElementNode("img", "inline", "self-closing");
        img.AddCssClass("image");
        div.AddChild(img);

        LightElementNode span = new LightElementNode("span", "inline", "closing");
        span.AddCssClass("text");
        span.AddChild(new LightTextNode("Span text"));
        div.AddChild(span);

        LightElementNode nestedDiv = new LightElementNode("div", "block", "closing");
        nestedDiv.AddCssClass("nested");
        nestedDiv.AddChild(new LightTextNode("Nested div text"));
        div.AddChild(nestedDiv);

        Console.WriteLine("OuterHTML of div:");
        Console.WriteLine(div.OuterHTML);
        Console.WriteLine("\nInnerHTML of div:");
        Console.WriteLine(div.InnerHTML);

        Console.WriteLine("\n=== Command Pattern Demo ===");
        CommandInvoker invoker = new CommandInvoker();

        LightElementNode h1 = new LightElementNode("h1", "block", "closing");

        div.AddChildWithCommand(h1, invoker);

        h1.AddCssClassWithCommand("title", invoker);
        h1.AddCssClassWithCommand("main-title", invoker);

        LightTextNode titleText = new LightTextNode("Main Title");
        h1.AddChildWithCommand(titleText, invoker);

        Console.WriteLine("\nПісля виконання команд:");
        Console.WriteLine(div.OuterHTML);

        invoker.ShowHistory();

        Console.WriteLine("\n=== Undo операції ===");
        invoker.Undo();
        invoker.Undo();
        invoker.Undo();

        Console.WriteLine("\nПісля undo:");
        Console.WriteLine(div.OuterHTML);

        Console.WriteLine("\n=== Redo операції ===");
        invoker.Redo();
        invoker.Redo();

        Console.WriteLine("\nПісля redo:");
        Console.WriteLine(div.OuterHTML);

        Console.WriteLine("\n=== Обхід в глибину ===");
        foreach (var node in div.TraverseDepthFirst())
        {
            if (node is LightElementNode element)
            {
                Console.WriteLine($"Елемент: {element.TagName}");
            }
            else if (node is LightTextNode textNodeItem)
            {
                Console.WriteLine($"Текст: {textNodeItem.Text}");
            }
        }

        Console.WriteLine("\n=== Обхід в ширину ===");
        foreach (var node in div.TraverseBreadthFirst())
        {
            if (node is LightElementNode element)
            {
                Console.WriteLine($"Елемент: {element.TagName}");
            }
            else if (node is LightTextNode textNodeItem)
            {
                Console.WriteLine($"Текст: {textNodeItem.Text}");
            }
        }

        Console.WriteLine("\n=== Пошук за класом 'text' ===");
        foreach (var element in div.FindByClass("text"))
        {
            Console.WriteLine($"Знайдено елемент: {element.TagName} з класом 'text'");
        }

        Console.WriteLine("\n=== Всі текстові вузли ===");
        foreach (var textNodeItem in div.GetAllTextNodes())
        {
            Console.WriteLine($"Текст: {textNodeItem.Text}");
        }
    }
}