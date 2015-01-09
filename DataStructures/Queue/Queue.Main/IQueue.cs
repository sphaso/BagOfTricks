
namespace Queue.Main
{
    public interface IQueue<T>
    {
        void Enqueue(T entry);

        T Dequeue();

        void Clear();

        int Size();

        bool IsEmpty();
    }
}
