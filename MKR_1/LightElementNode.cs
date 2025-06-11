using MKR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer
{
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

        public void ExecuteCommand(ICommand command, CommandInvoker invoker = null)
        {
            if (invoker != null)
            {
                invoker.ExecuteCommand(command);
            }
            else
            {
                command.Execute();
            }
        }

        public void AddChildWithCommand(LightNode child, CommandInvoker invoker)
        {
            var command = new AddChildCommand(this, child);
            invoker.ExecuteCommand(command);
        }

        public void RemoveChildWithCommand(LightNode child, CommandInvoker invoker)
        {
            var command = new RemoveChildCommand(this, child);
            invoker.ExecuteCommand(command);
        }

        public void AddCssClassWithCommand(string cssClass, CommandInvoker invoker)
        {
            var command = new AddCssClassCommand(this, cssClass);
            invoker.ExecuteCommand(command);
        }

        public void RemoveCssClassWithCommand(string cssClass, CommandInvoker invoker)
        {
            var command = new RemoveCssClassCommand(this, cssClass);
            invoker.ExecuteCommand(command);
        }

        public IEnumerable<LightNode> TraverseDepthFirst()
        {
            using (var iterator = new DepthFirstIterator(this))
            {
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public IEnumerable<LightNode> TraverseBreadthFirst()
        {
            using (var iterator = new BreadthFirstIterator(this))
            {
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public IEnumerable<LightElementNode> FindByClass(string className)
        {
            return TraverseDepthFirst()
                  .OfType<LightElementNode>()
                  .Where(e => e.CssClasses.Contains(className));
        }

        public IEnumerable<LightElementNode> FindByTag(string tagName)
        {
            return TraverseDepthFirst()
                  .OfType<LightElementNode>()
                  .Where(e => e.TagName.Equals(tagName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<LightTextNode> GetAllTextNodes()
        {
            return TraverseDepthFirst()
                  .OfType<LightTextNode>();
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
