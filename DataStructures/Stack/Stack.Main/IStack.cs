
namespace Stack.Main
{
    public interface IStack<T>
    {
        void Push(T entry);
        T Pop();
        int Size();
        T Peek();
        bool IsEmpty();
        void Clear();
    }
}
