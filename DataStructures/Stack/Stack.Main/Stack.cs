
using System.Collections.Generic;
using System.Linq;

namespace Stack.Main
{
    public class Stack<V> : IStack<V>
    {
        private List<V> _storage = new List<V>();

        public void Push(V entry)
        {
            _storage.Add(entry);
        }

        public V Pop()
        {
            var temp = Peek();
            _storage.Remove(temp);

            return temp;
        }

        public int Size()
        {
            return _storage.Count;
        }

        public V Peek()
        {
            return _storage.Last();
        }

        public bool IsEmpty()
        {
            return _storage.Count == 0;
        }

        public void Clear()
        {
            _storage.Clear();
        }
    }
}
