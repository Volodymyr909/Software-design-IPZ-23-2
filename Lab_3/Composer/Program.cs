using Composer;

public class Program
{
    public static void Main(string[] args)
    {
        // Створення елементів розмітки
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

        // Виведення розмітки в консоль
        Console.WriteLine("OuterHTML of div:");
        Console.WriteLine(div.OuterHTML);

        Console.WriteLine("\nInnerHTML of div:");
        Console.WriteLine(div.InnerHTML);
    }
}
