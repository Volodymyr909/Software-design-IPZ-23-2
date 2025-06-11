using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class HtmlValidatorVisitor : ILightNodeVisitor
    {
        public List<string> ValidationErrors { get; private set; }
        public List<string> ValidationWarnings { get; private set; }
        public bool IsValid => ValidationErrors.Count == 0;

        private readonly HashSet<string> _selfClosingTags = new HashSet<string>
        {
            "img", "br", "hr", "input", "meta", "link", "area", "base", "col", "embed", "source", "track", "wbr"
        };

        private readonly HashSet<string> _blockElements = new HashSet<string>
        {
            "div", "p", "h1", "h2", "h3", "h4", "h5", "h6", "section", "article", "header", "footer", "main", "nav"
        };

        private readonly HashSet<string> _inlineElements = new HashSet<string>
        {
            "span", "a", "strong", "em", "b", "i", "u", "small", "mark", "del", "ins", "sub", "sup"
        };

        public HtmlValidatorVisitor()
        {
            ValidationErrors = new List<string>();
            ValidationWarnings = new List<string>();
        }

        public void Visit(LightElementNode elementNode)
        {
            ValidateTagName(elementNode);
            ValidateClosingType(elementNode);
            ValidateDisplayType(elementNode);
            ValidateCssClasses(elementNode);
            ValidateNesting(elementNode);
        }

        public void Visit(LightTextNode textNode)
        {
            if (string.IsNullOrWhiteSpace(textNode.Text))
            {
                ValidationWarnings.Add("Знайдено порожній або пробільний текстовий вузол");
            }
        }

        private void ValidateTagName(LightElementNode elementNode)
        {
            if (string.IsNullOrWhiteSpace(elementNode.TagName))
            {
                ValidationErrors.Add("Знайдено елемент з порожнім або відсутнім ім'ям тегу");
                return;
            }

            if (!IsValidTagName(elementNode.TagName))
            {
                ValidationWarnings.Add($"Тег '{elementNode.TagName}' може бути нестандартним");
            }
        }

        private void ValidateClosingType(LightElementNode elementNode)
        {
            bool shouldBeSelfClosing = _selfClosingTags.Contains(elementNode.TagName.ToLower());
            bool isSelfClosing = elementNode.ClosingType == "self-closing";

            if (shouldBeSelfClosing && !isSelfClosing)
            {
                ValidationErrors.Add($"Тег '{elementNode.TagName}' повинен бути самозакривним");
            }
            else if (!shouldBeSelfClosing && isSelfClosing)
            {
                ValidationWarnings.Add($"Тег '{elementNode.TagName}' зазвичай не є самозакривним");
            }
        }

        private void ValidateDisplayType(LightElementNode elementNode)
        {
            string tagName = elementNode.TagName.ToLower();
            bool shouldBeBlock = _blockElements.Contains(tagName);
            bool shouldBeInline = _inlineElements.Contains(tagName);
            bool isBlock = elementNode.DisplayType == "block";

            if (shouldBeBlock && !isBlock)
            {
                ValidationWarnings.Add($"Тег '{elementNode.TagName}' зазвичай є блочним елементом");
            }
            else if (shouldBeInline && isBlock)
            {
                ValidationWarnings.Add($"Тег '{elementNode.TagName}' зазвичай є рядковим елементом");
            }
        }

        private void ValidateCssClasses(LightElementNode elementNode)
        {
            foreach (var cssClass in elementNode.CssClasses)
            {
                if (string.IsNullOrWhiteSpace(cssClass))
                {
                    ValidationErrors.Add($"Знайдено порожній CSS клас в елементі '{elementNode.TagName}'");
                }
                else if (!IsValidCssClassName(cssClass))
                {
                    ValidationWarnings.Add($"CSS клас '{cssClass}' може мати неправильний формат");
                }
            }
        }

        private void ValidateNesting(LightElementNode elementNode)
        {
            if (_inlineElements.Contains(elementNode.TagName.ToLower()))
            {
                foreach (var child in elementNode.Children.OfType<LightElementNode>())
                {
                    if (_blockElements.Contains(child.TagName.ToLower()))
                    {
                        ValidationErrors.Add($"Блочний елемент '{child.TagName}' не може бути вкладеним в рядковий елемент '{elementNode.TagName}'");
                    }
                }
            }
        }

        private bool IsValidTagName(string tagName)
        {
            var commonTags = new HashSet<string>
            {
                "div", "span", "p", "a", "img", "h1", "h2", "h3", "h4", "h5", "h6",
                "ul", "ol", "li", "table", "tr", "td", "th", "form", "input", "button",
                "section", "article", "header", "footer", "main", "nav", "aside"
            };
            return commonTags.Contains(tagName.ToLower());
        }

        private bool IsValidCssClassName(string className)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(className, @"^[a-zA-Z][a-zA-Z0-9_-]*$");
        }

        public void PrintValidationResults()
        {
            Console.WriteLine("=== Результати валідації HTML ===");
            Console.WriteLine($"Статус: {(IsValid ? "✅ Валідний" : "❌ Містить помилки")}");
            Console.WriteLine($"Помилок: {ValidationErrors.Count}");
            Console.WriteLine($"Попереджень: {ValidationWarnings.Count}");

            if (ValidationErrors.Count > 0)
            {
                Console.WriteLine("\n--- Помилки ---");
                foreach (var error in ValidationErrors)
                {
                    Console.WriteLine($" {error}");
                }
            }

            if (ValidationWarnings.Count > 0)
            {
                Console.WriteLine("\n--- Попередження ---");
                foreach (var warning in ValidationWarnings)
                {
                    Console.WriteLine($" {warning}");
                }
            }
        }

        public void Reset()
        {
            ValidationErrors.Clear();
            ValidationWarnings.Clear();
        }
    }
}
