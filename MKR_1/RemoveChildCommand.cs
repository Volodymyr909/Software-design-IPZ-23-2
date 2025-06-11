using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class RemoveChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;
        private int _originalIndex;

        public RemoveChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public string Description => $"Remove {(_child is LightElementNode el ? el.TagName : "text")} from {_parent.TagName}";

        public void Execute()
        {
            _originalIndex = _parent.Children.IndexOf(_child);
            _parent.Children.Remove(_child);
        }

        public void Undo()
        {
            _parent.Children.Insert(_originalIndex, _child);
        }
    }
}
