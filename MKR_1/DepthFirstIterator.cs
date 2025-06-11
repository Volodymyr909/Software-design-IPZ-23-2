using Composer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class DepthFirstIterator : ILightNodeIterator
    {
        private readonly LightElementNode _root;
        private Stack<LightNode> _stack;
        private LightNode _current;

        public DepthFirstIterator(LightElementNode root)
        {
            _root = root;
            Reset();
        }

        public LightNode Current => _current;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_stack.Count == 0)
                return false;

            _current = _stack.Pop();

            if (_current is LightElementNode element)
            {
                for (int i = element.Children.Count - 1; i >= 0; i--)
                {
                    _stack.Push(element.Children[i]);
                }
            }

            return true;
        }

        public void Reset()
        {
            _stack = new Stack<LightNode>();
            _stack.Push(_root);
            _current = null;
        }

        public void Dispose()
        {
            _stack?.Clear();
        }
    }
}
