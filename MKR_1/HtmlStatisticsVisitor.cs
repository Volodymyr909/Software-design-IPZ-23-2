using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class HtmlStatisticsVisitor : ILightNodeVisitor
    {
        public int ElementCount { get; private set; }
        public int TextNodeCount { get; private set; }
        public Dictionary<string, int> TagStatistics { get; private set; }
        public Dictionary<string, int> ClassStatistics { get; private set; }
        public int TotalTextLength { get; private set; }
        public List<string> AllClasses { get; private set; }

        public HtmlStatisticsVisitor()
        {
            TagStatistics = new Dictionary<string, int>();
            ClassStatistics = new Dictionary<string, int>();
            AllClasses = new List<string>();
        }

        public void Visit(LightElementNode elementNode)
        {
            ElementCount++;

            if (TagStatistics.ContainsKey(elementNode.TagName))
                TagStatistics[elementNode.TagName]++;
            else
                TagStatistics[elementNode.TagName] = 1;

            foreach (var cssClass in elementNode.CssClasses)
            {
                AllClasses.Add(cssClass);
                if (ClassStatistics.ContainsKey(cssClass))
                    ClassStatistics[cssClass]++;
                else
                    ClassStatistics[cssClass] = 1;
            }
        }

        public void Visit(LightTextNode textNode)
        {
            TextNodeCount++;
            TotalTextLength += textNode.Text.Length;
        }

        public void PrintStatistics()
        {
            Console.WriteLine("=== HTML Статистика ===");
            Console.WriteLine($"Загальна кількість елементів: {ElementCount}");
            Console.WriteLine($"Загальна кількість текстових вузлів: {TextNodeCount}");
            Console.WriteLine($"Загальна довжина тексту: {TotalTextLength} символів");

            Console.WriteLine("\n--- Статистика тегів ---");
            foreach (var kvp in TagStatistics.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine("\n--- Статистика CSS класів ---");
            foreach (var kvp in ClassStatistics.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        public void Reset()
        {
            ElementCount = 0;
            TextNodeCount = 0;
            TotalTextLength = 0;
            TagStatistics.Clear();
            ClassStatistics.Clear();
            AllClasses.Clear();
        }
    }
}
