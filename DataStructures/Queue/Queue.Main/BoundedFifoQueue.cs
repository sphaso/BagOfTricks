using System;
using System.Collections.Generic;

namespace Queue.Main
{
    //Not thread-safe
    public class BoundedFifoQueue<V> : IQueue<V>
    {
        private readonly int _threshold;
        private List<V> _storage = new List<V>();

        public BoundedFifoQueue(int threshold = 10)
        {
            _threshold = threshold;
        }

        public void Enqueue(V entry)
        {
            if (Size() >= _threshold)
            {
                throw new IndexOutOfRangeException("Queue threshold reached");
            }

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
