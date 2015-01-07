
using System;

namespace Iterator.Main
{
    interface IIterate<T>
    {
        T Next();

        bool Eof();

        T Current();
    }

    public class Iterator<T> : IIterate<T>
    {
        private readonly T[] _array;
        private int _index;

        public Iterator(T[] array)
        {
            _array = array;
        }


        public T Next()
        {
            if (!Eof())
            {
                _index += 1;
                return Current();    
            }

            throw new IndexOutOfRangeException();
        }

        public bool Eof()
        {
            return _index == _array.Length - 1;
        }

        public T Current()
        {
            return _array[_index];
        }
    }
}
