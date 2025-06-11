using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class RemoveCssClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _cssClass;

        public RemoveCssClassCommand(LightElementNode element, string cssClass)
        {
            _element = element;
            _cssClass = cssClass;
        }

        public string Description => $"Remove CSS class '{_cssClass}' from {_element.TagName}";

        public void Execute()
        {
            _element.CssClasses.Remove(_cssClass);
        }

        public void Undo()
        {
            if (!_element.CssClasses.Contains(_cssClass))
            {
                _element.CssClasses.Add(_cssClass);
            }
        }
    }
}
