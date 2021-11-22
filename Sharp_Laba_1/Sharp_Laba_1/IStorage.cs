using System.Collections.Generic;

namespace Sharp_Laba_1
{
    public interface IStorage<T> where T : class, IProduct
    {
        int StorageNumCode { get; set; }
        T this[int index] { get; set; }
        void Put(T product);
        void Put(T product,int i);
        T Pop(int i);
        void Swap(int i, int j);
        int Search(int code);
        List<int> Search(string name);
        void SortByCode();
        void SortByName();
    }
}