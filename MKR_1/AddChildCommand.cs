using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class AddChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public string Description => $"Add {(_child is LightElementNode el ? el.TagName : "text")} to {_parent.TagName}";

        public void Execute()
        {
            _parent.Children.Add(_child);
        }

        public void Undo()
        {
            _parent.Children.Remove(_child);
        }
    }
}
