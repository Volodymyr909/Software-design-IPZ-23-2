using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class XmlExportVisitor : ILightNodeVisitor
    {
        private StringBuilder _xmlBuilder;
        private int _indentLevel;
        private const string INDENT = "  ";

        public string XmlResult => _xmlBuilder.ToString();

        public XmlExportVisitor()
        {
            _xmlBuilder = new StringBuilder();
            _indentLevel = 0;
        }

        public void Visit(LightElementNode elementNode)
        {
            string indent = GetIndent();

            _xmlBuilder.Append(indent);
            _xmlBuilder.Append($"<element tag=\"{elementNode.TagName}\" ");
            _xmlBuilder.Append($"displayType=\"{elementNode.DisplayType}\" ");
            _xmlBuilder.Append($"closingType=\"{elementNode.ClosingType}\" ");
            _xmlBuilder.Append($"state=\"{elementNode.GetCurrentStateDescription()}\"");

            if (elementNode.CssClasses.Count > 0)
            {
                _xmlBuilder.Append($" classes=\"{string.Join(" ", elementNode.CssClasses)}\"");
            }

            if (elementNode.Children.Count > 0)
            {
                _xmlBuilder.AppendLine(">");

                _indentLevel++;
                foreach (var child in elementNode.Children)
                {
                    child.Accept(this);
                }
                _indentLevel--;

                _xmlBuilder.AppendLine($"{indent}</element>");
            }
            else
            {
                _xmlBuilder.AppendLine(" />");
            }
        }

        public void Visit(LightTextNode textNode)
        {
            string indent = GetIndent();
            string escapedText = EscapeXml(textNode.Text);
            _xmlBuilder.AppendLine($"{indent}<text>{escapedText}</text>");
        }

        private string GetIndent()
        {
            return new string(' ', _indentLevel * INDENT.Length);
        }

        private string EscapeXml(string text)
        {
            return text
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&apos;");
        }

        public void Reset()
        {
            _xmlBuilder.Clear();
            _indentLevel = 0;
        }

        public void SaveToFile(string filePath)
        {
            System.IO.File.WriteAllText(filePath, XmlResult);
        }
    }
}
