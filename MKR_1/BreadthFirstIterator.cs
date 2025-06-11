using Composer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class BreadthFirstIterator : ILightNodeIterator
    {
        private readonly LightElementNode _root;
        private Queue<LightNode> _queue;
        private LightNode _current;

        public BreadthFirstIterator(LightElementNode root)
        {
            _root = root;
            Reset();
        }

        public LightNode Current => _current;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_queue.Count == 0)
                return false;

            _current = _queue.Dequeue();

            if (_current is LightElementNode element)
            {
                foreach (var child in element.Children)
                {
                    _queue.Enqueue(child);
                }
            }

            return true;
        }

        public void Reset()
        {
            _queue = new Queue<LightNode>();
            _queue.Enqueue(_root);
            _current = null;
        }

        public void Dispose()
        {
            _queue?.Clear();
        }
    }
}
