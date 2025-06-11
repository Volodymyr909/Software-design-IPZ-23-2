using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class AddCssClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _cssClass;

        public AddCssClassCommand(LightElementNode element, string cssClass)
        {
            _element = element;
            _cssClass = cssClass;
        }

        public string Description => $"Add CSS class '{_cssClass}' to {_element.TagName}";

        public void Execute()
        {
            if (!_element.CssClasses.Contains(_cssClass))
            {
                _element.CssClasses.Add(_cssClass);
            }
        }

        public void Undo()
        {
            _element.CssClasses.Remove(_cssClass);
        }
    }
}
