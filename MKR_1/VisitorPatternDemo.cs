using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public static class VisitorPatternDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("=== ДЕМОНСТРАЦІЯ ШАБЛОНУ ВІДВІДУВАЧ (VISITOR PATTERN) ===");
            Console.WriteLine(new string('=', 60));

            var document = CreateSampleDocument();

            Console.WriteLine("Створена HTML структура:");
            Console.WriteLine(document.OuterHTML);

            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("1. ЗБІР СТАТИСТИКИ");
            Console.WriteLine(new string('-', 40));

            var statisticsVisitor = new HtmlStatisticsVisitor();
            document.Accept(statisticsVisitor);
            statisticsVisitor.PrintStatistics();

            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("2. ВАЛІДАЦІЯ HTML");
            Console.WriteLine(new string('-', 40));

            var validatorVisitor = new HtmlValidatorVisitor();
            document.Accept(validatorVisitor);
            validatorVisitor.PrintValidationResults();

            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("3. ЕКСПОРТ В XML");
            Console.WriteLine(new string('-', 40));

            var xmlVisitor = new XmlExportVisitor();
            document.Accept(xmlVisitor);
            Console.WriteLine("XML представлення:");
            Console.WriteLine(xmlVisitor.XmlResult);

            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("4. ЕКСПОРТ В JSON");
            Console.WriteLine(new string('-', 40));

            var jsonVisitor = new JsonExportVisitor();
            jsonVisitor.StartDocument();
            document.Accept(jsonVisitor);
            jsonVisitor.EndDocument();
            Console.WriteLine("JSON представлення:");
            Console.WriteLine(jsonVisitor.JsonResult);

            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("5. РОБОТА З РІЗНИМИ СТАНАМИ ЕЛЕМЕНТІВ");
            Console.WriteLine(new string('-', 40));

            DemonstrateWithDifferentStates();
        }

        private static LightElementNode CreateSampleDocument()
        {
            var mainDiv = new LightElementNode("div", "block", "closing");
            mainDiv.AddCssClass("container");
            mainDiv.AddCssClass("main-content");

            var header = new LightElementNode("h1", "block", "closing");
            header.AddCssClass("title");
            header.AddCssClass("primary");
            header.AddChild(new LightTextNode("Головний заголовок"));
            mainDiv.AddChild(header);

            var paragraph = new LightElementNode("p", "block", "closing");
            paragraph.AddCssClass("text");
            paragraph.AddCssClass("description");
            paragraph.AddChild(new LightTextNode("Це приклад параграфу з деяким текстом для демонстрації."));
            mainDiv.AddChild(paragraph);

            var list = new LightElementNode("ul", "block", "closing");
            list.AddCssClass("list");

            for (int i = 1; i <= 3; i++)
            {
                var listItem = new LightElementNode("li", "block", "closing");
                listItem.AddCssClass("list-item");
                listItem.AddChild(new LightTextNode($"Елемент списку #{i}"));
                list.AddChild(listItem);
            }
            mainDiv.AddChild(list);

            var nestedDiv = new LightElementNode("div", "block", "closing");
            nestedDiv.AddCssClass("nested");
            nestedDiv.AddCssClass("content");

            var span = new LightElementNode("span", "inline", "closing");
            span.AddCssClass("highlight");
            span.AddChild(new LightTextNode("Виділений текст"));
            nestedDiv.AddChild(span);

            nestedDiv.AddChild(new LightTextNode(" і звичайний текст після нього."));
            mainDiv.AddChild(nestedDiv);

            var image = new LightElementNode("img", "inline", "self-closing");
            image.AddCssClass("image");
            image.AddCssClass("responsive");
            mainDiv.AddChild(image);

            return mainDiv;
        }

        private static void DemonstrateWithDifferentStates()
        {
            var activeElement = new LightElementNode("div", "block", "closing");
            activeElement.AddCssClass("active-element");
            activeElement.AddChild(new LightTextNode("Активний елемент"));
            activeElement.Activate();

            var hiddenElement = new LightElementNode("div", "block", "closing");
            hiddenElement.AddCssClass("hidden-element");
            hiddenElement.AddChild(new LightTextNode("Прихований елемент"));
            hiddenElement.Hide();

            var lockedElement = new LightElementNode("div", "block", "closing");
            lockedElement.AddCssClass("locked-element");
            lockedElement.AddChild(new LightTextNode("Заблокований елемент"));
            lockedElement.Lock();

            var deletedElement = new LightElementNode("div", "block", "closing");
            deletedElement.AddCssClass("deleted-element");
            deletedElement.AddChild(new LightTextNode("Видалений елемент"));
            deletedElement.MarkForDeletion();

            var container = new LightElementNode("div", "block", "closing");
            container.AddCssClass("state-demo-container");
            container.AddChild(activeElement);
            container.AddChild(hiddenElement);
            container.AddChild(lockedElement);
            container.AddChild(deletedElement);

            var statisticsVisitor = new HtmlStatisticsVisitor();
            container.Accept(statisticsVisitor);

            Console.WriteLine("Статистика елементів в різних станах:");
            statisticsVisitor.PrintStatistics();

            var validatorVisitor = new HtmlValidatorVisitor();
            container.Accept(validatorVisitor);
            validatorVisitor.PrintValidationResults();

            Console.WriteLine("\nHTML з урахуванням станів елементів:");
            Console.WriteLine(container.OuterHTML);
        }
    }
}
