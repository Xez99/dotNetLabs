using System.Collections.Generic;

namespace lab_1.utils
{
    //#nullable enable
    public interface List<T> : IEnumerable<T>
    {
        public void Add(T t);
        public void Add(int position, T t);
        public void AddFirst(T t);
        public void AddLast(T t);
        public bool Remove(T t);
        public void Remove(int position);
        public bool Contains(T t);
        public T Get(int position);
        public int  Size();
        public bool IsEmpty();
        public void Clean();
        public void Reverse();
    }
}