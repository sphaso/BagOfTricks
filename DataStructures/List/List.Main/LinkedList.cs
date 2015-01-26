

using System;

namespace List.Main
{
    public class LinkedList<T> : IList<T>
    {
        private class Node<V>
        {
            public Node()
            {
                
            }

            public Node(V entry)
            {
                Value = entry;
            }

            public V Value { get; set; }
            public Node<V> Next { get; set; }
        }

        private Node<T> _head = new Node<T>();

        public void Add(T entry)
        {
            var node = GetNode(Length() - 1);
            node.Value = entry;
            if (node.Next == null)
            {
                node.Next = new Node<T>();
            }
        }

        private Node<T> GetNode(int index)
        {
            Node<T> element = _head;
            for (var i = 0; i < index; i++)
            {
                if (element.Next == null)
                    throw new IndexOutOfRangeException();

                element = element.Next;
            }

            return element;
        }

        public T Remove(int index)
        {
            var element = GetNode(index);
            var temp = element.Value;

            var nav = _head;
            for (var i = 0; i < index - 1; i++)
            {
                nav = nav.Next;
            }

            var toRemove = GetNode(index + 1);
            nav.Value = toRemove.Value;
            nav.Next = toRemove.Next;
            
            return temp;
        }

        public T Get(int index)
        {
            var node = GetNode(index);

            return node.Value;
        }

        public int Length()
        {
            var i = 0;
            var current = _head;
            while (current != null)
            {
                current = current.Next;
                i++;
            }

            return i;
        }
    }
}
