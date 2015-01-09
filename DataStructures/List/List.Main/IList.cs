
namespace List.Main
{
    public interface IList<T>
    {
        void Add(T entry);
        T Remove(int index);
        T Get(int index);
        int Length();
    }
}
