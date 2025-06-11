using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class ChangeTextCommand : ICommand
    {
        private readonly LightTextNode _textNode;
        private readonly string _newText;
        private readonly string _oldText;

        public ChangeTextCommand(LightTextNode textNode, string newText)
        {
            _textNode = textNode;
            _newText = newText;
            _oldText = textNode.Text;
        }

        public string Description => $"Change text from '{_oldText}' to '{_newText}'";

        public void Execute()
        {

        }

        public void Undo()
        {

        }
    }
}
