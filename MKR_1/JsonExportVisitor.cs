using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class JsonExportVisitor : ILightNodeVisitor
    {
        private StringBuilder _jsonBuilder;
        private int _indentLevel;
        private bool _isFirstChild;
        private Stack<bool> _firstChildStack;
        private const string INDENT = "  ";

        public string JsonResult => _jsonBuilder.ToString();

        public JsonExportVisitor()
        {
            _jsonBuilder = new StringBuilder();
            _indentLevel = 0;
            _firstChildStack = new Stack<bool>();
        }

        public void StartDocument()
        {
            _jsonBuilder.AppendLine("{");
            _indentLevel++;
            _jsonBuilder.AppendLine($"{GetIndent()}\"document\": {{");
            _indentLevel++;
            _jsonBuilder.AppendLine($"{GetIndent()}\"children\": [");
            _indentLevel++;
            _isFirstChild = true;
        }

        public void EndDocument()
        {
            _indentLevel--;
            _jsonBuilder.AppendLine();
            _jsonBuilder.AppendLine($"{GetIndent()}]");
            _indentLevel--;
            _jsonBuilder.AppendLine($"{GetIndent()}}}");
            _indentLevel--;
            _jsonBuilder.AppendLine("}");
        }

        public void Visit(LightElementNode elementNode)
        {
            if (!_isFirstChild)
            {
                _jsonBuilder.AppendLine(",");
            }
            _isFirstChild = false;

            string indent = GetIndent();
            _jsonBuilder.AppendLine($"{indent}{{");
            _indentLevel++;

            _jsonBuilder.AppendLine($"{GetIndent()}\"type\": \"element\",");
            _jsonBuilder.AppendLine($"{GetIndent()}\"tagName\": \"{EscapeJson(elementNode.TagName)}\",");
            _jsonBuilder.AppendLine($"{GetIndent()}\"displayType\": \"{EscapeJson(elementNode.DisplayType)}\",");
            _jsonBuilder.AppendLine($"{GetIndent()}\"closingType\": \"{EscapeJson(elementNode.ClosingType)}\",");
            _jsonBuilder.AppendLine($"{GetIndent()}\"state\": \"{EscapeJson(elementNode.GetCurrentStateDescription())}\",");

            _jsonBuilder.Append($"{GetIndent()}\"cssClasses\": [");
            if (elementNode.CssClasses.Count > 0)
            {
                _jsonBuilder.Append(string.Join(", ", elementNode.CssClasses.Select(c => $"\"{EscapeJson(c)}\"")));
            }
            _jsonBuilder.AppendLine("],");

            if (elementNode.Children.Count > 0)
            {
                _jsonBuilder.AppendLine($"{GetIndent()}\"children\": [");
                _indentLevel++;

                _firstChildStack.Push(_isFirstChild);
                _isFirstChild = true;

                foreach (var child in elementNode.Children)
                {
                    child.Accept(this);
                }

                _isFirstChild = _firstChildStack.Pop();

                _indentLevel--;
                _jsonBuilder.AppendLine();
                _jsonBuilder.Append($"{GetIndent()}]");
            }
            else
            {
                _jsonBuilder.Append($"{GetIndent()}\"children\": []");
            }

            _indentLevel--;
            _jsonBuilder.Append($"\n{indent}}}");
        }

        public void Visit(LightTextNode textNode)
        {
            if (!_isFirstChild)
            {
                _jsonBuilder.AppendLine(",");
            }
            _isFirstChild = false;

            string indent = GetIndent();
            _jsonBuilder.Append($"{indent}{{");
            _jsonBuilder.Append($"\n{GetIndent()}\"type\": \"text\",");
            _jsonBuilder.Append($"\n{GetIndent()}\"content\": \"{EscapeJson(textNode.Text)}\"");
            _jsonBuilder.Append($"\n{indent}}}");
        }

        private string GetIndent()
        {
            return new string(' ', _indentLevel * INDENT.Length);
        }

        private string EscapeJson(string text)
        {
            return text
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t");
        }

        public void Reset()
        {
            _jsonBuilder.Clear();
            _indentLevel = 0;
            _isFirstChild = true;
            _firstChildStack.Clear();
        }

        public void SaveToFile(string filePath)
        {
            System.IO.File.WriteAllText(filePath, JsonResult);
        }
    }
}
