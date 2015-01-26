using System.Collections.Generic;

namespace Queue.Main
{
    //Not thread-safe
    public class FifoQueue<V> : IQueue<V>
    {
        private List<V> _storage = new List<V>();

        public void Enqueue(V entry)
        {
            _storage.Add(entry);
        }

        public V Dequeue()
        {
            var temp = _storage[0];
            _storage.RemoveAt(0);

            return temp;
        }

        public void Clear()
        {
            _storage.Clear();
        }

        public int Size()
        {
            return _storage.Count;
        }

        public bool IsEmpty()
        {
            return _storage.Count == 0;
        }
    }
}
