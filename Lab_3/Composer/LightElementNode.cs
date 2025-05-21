using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public string DisplayType { get; }
        public string ClosingType { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }

        public LightElementNode(string tagName, string displayType, string closingType)
        {
            TagName = tagName;
            DisplayType = displayType;
            ClosingType = closingType;
            CssClasses = new List<string>();
            Children = new List<LightNode>();
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
        }

        public void AddCssClass(string cssClass)
        {
            CssClasses.Add(cssClass);
        }

        public override string OuterHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"<{TagName}");

                if (CssClasses.Count > 0)
                {
                    sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");
                }

                if (ClosingType == "self-closing")
                {
                    sb.Append(" />");
                }
                else
                {
                    sb.Append(">");
                    foreach (var child in Children)
                    {
                        sb.Append(child.OuterHTML);
                    }
                    sb.Append($"</{TagName}>");
                }

                return sb.ToString();
            }
        }

        public override string InnerHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var child in Children)
                {
                    sb.Append(child.InnerHTML);
                }
                return sb.ToString();
            }
        }
    }
}
