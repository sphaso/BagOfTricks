
namespace List.Main
{
    public class ArrayList<T> : IList<T>
    {
        private T[] _array;
        private int _addIndex = -1;

        public ArrayList(int initialSize = 10)
        {
            _array = new T[initialSize];
        }

        public void Add(T entry)
        {
            if (_addIndex == _array.Length - 1)
            {
                var newArray = new T[_array.Length + 10];
                _array.CopyTo(newArray, 0);
                _array = newArray;
            }

            _addIndex++;
            _array[_addIndex] = entry;
        }

        public T Remove(int index)
        {
            var temp = _array[index];
            var i = index;
            while (i < _array.Length - 2)
            {
                _array[i] = _array[i + 1];
                i++;
            }

            _addIndex--;
            return temp;
        }

        public T Get(int index)
        {
            return _array[index];
        }

        public int Length()
        {
            return _array.Length;
        }
    }
}
