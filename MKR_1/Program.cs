using Composer;
using MKR1;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Модульна контрольна робота №1 ===");
        Console.WriteLine("Демонстрація поведінкових шаблонів проєктування\n");

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

        Console.WriteLine("\n=== State Pattern Demo ===");

        div.Activate();
        p.Activate();

        Console.WriteLine($"Div state: {div.GetCurrentStateDescription()}");
        Console.WriteLine($"P state: {p.GetCurrentStateDescription()}");

        p.AddCssClass("active");
        Console.WriteLine($"P HTML після додавання класу: {p.OuterHTML}");

        Console.WriteLine("\n--- Блокування елемента ---");
        p.Lock();

        p.AddCssClass("blocked");

        Console.WriteLine("\n--- Приховування елемента ---");
        span.Hide();
        Console.WriteLine("HTML після приховування span:");
        Console.WriteLine(div.OuterHTML);

        Console.WriteLine("\n--- Відновлення елемента ---");
        span.Restore();
        Console.WriteLine("HTML після відновлення span:");
        Console.WriteLine(div.OuterHTML);

        Console.WriteLine("\n--- Позначення для видалення ---");
        img.MarkForDeletion();
        Console.WriteLine("HTML після позначення img для видалення:");
        Console.WriteLine(div.OuterHTML);

        Console.WriteLine("\n=== Iterator Pattern Demo ===");
        Console.WriteLine("=== Обхід в глибину ===");
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

        Console.WriteLine("\n" + new string('=', 60));
        TemplateMethodDemo.RunDemo();

        Console.WriteLine("\n=== Demonstrating Template Method with existing elements ===");
        Console.WriteLine("Processing lifecycle for existing elements:");

        Console.WriteLine("\n--- Processing div lifecycle ---");
        div.ProcessLifecycle();

        Console.WriteLine("\n--- Processing span lifecycle ---");
        span.ProcessLifecycle();

        Console.WriteLine("\n--- Processing img lifecycle ---");
        img.ProcessLifecycle();

        Console.WriteLine("\n--- Processing element removal ---");
        h1.ProcessRemoval();

        VisitorPatternDemo.RunDemo();

        Console.WriteLine("\n=== Демонстрація Visitor Pattern з існуючими елементами ===");

        Console.WriteLine("\nАналіз статистики основного документу:");
        var stats = new HtmlStatisticsVisitor();
        div.Accept(stats);
        stats.PrintStatistics();

        Console.WriteLine("\nВалідація основного документу:");
        var validator = new HtmlValidatorVisitor();
        div.Accept(validator);
        validator.PrintValidationResults();

        Console.WriteLine("\nЕкспорт основного документу в XML:");
        var xmlExporter = new XmlExportVisitor();
        div.Accept(xmlExporter);
        Console.WriteLine(xmlExporter.XmlResult);

        Console.WriteLine("\n" + new string('=', 60));
        Console.WriteLine("=== ЗАВЕРШЕННЯ ДЕМОНСТРАЦІЇ ===");
        Console.WriteLine("Успішно продемонстровано всі 5 поведінкових шаблонів:");
        Console.WriteLine("Iterator Pattern - для обходу елементів");
        Console.WriteLine("Command Pattern - для виконання команд з undo/redo");
        Console.WriteLine("State Pattern - для управління станами елементів");
        Console.WriteLine("Template Method Pattern - для життєвого циклу елементів");
        Console.WriteLine("Visitor Pattern - для обробки та аналізу елементів");
        Console.WriteLine(new string('=', 60));
    }
}