using System;
using System.Collections.Generic;
using System.Linq;
using static Sharp_Laba_1.BarCode;

namespace Sharp_Laba_1
{
    /// <summary>
    /// Класс контейнер склада
    /// </summary>
    public class Storage<T> : IStorage<T> where T : class, IProduct
    {
        private T[] _container;
        private int _storageNumCode;

        private static int _count;

        public int StorageNumCode
        {
            get => _storageNumCode;
            set
            {
                _storageNumCode = value;
                ReBar();
            }
        }
        
        private Storage(int size)
        {
            _container = new T[size];
            _count++;
            StorageNumCode = _count;
        }

        public static implicit operator Storage<T>(int n) => new Storage<T>(n);

        public T this[int index]
        {
            get => Pop(index);
            set => Put(value, index);
        }

        public override string ToString()
        {
            string str = null;
            foreach (var product in _container.Where(product => product != null))
            {
                str += $"\n\t{product}";
            }
            return $"Номер склада: {StorageNumCode} {str}";
        }

        public void Put(T product)
        {
            for (int i = 0; i < _container.Length; i++)
            {
                if (_container[i] == null)
                {
                    Put(product, i);
                    return;
                }
            }
            Console.WriteLine("Склад заполнен!");
        }

        public void Put(T product,int i)
        {
            if (_container[i] != null)
            {
                Console.WriteLine("Место уже занято!");
            }
            else
            {
                _container[i] = product;
                GenerateFullBarcode(product, StorageNumCode, Array.IndexOf(_container,product));
            }
        }

        public T Pop(int i)
        {
            var tmp = _container[i];
            _container[i] = null;
            return tmp;
        }

        public void Swap(int i, int j)
        {
            (this[i], this[j]) = (this[j], this[i]);
        }

        public int Search(int code) => 
            Array.IndexOf(_container, _container.First(product => product?.NumericCode == code));


        public List<int> Search(string name) => 
            _container.Where(product =>product?.Name == name).Select(product => Array.IndexOf(_container, product)).ToList();
        
        public void SortByCode()
        {
            _container = _container.OrderBy(product => product?.NumericCode).ToArray();
            ReBar();
        }
        
        public void SortByName()
        {
            _container = _container.OrderBy(p => p?.Name).ToArray();
            ReBar();
        }
        
        private void ReBar() 
        {
            foreach (var item in _container.Where(product =>product != null))
            {
                GenerateFullBarcode(item, StorageNumCode, Array.IndexOf(_container,item));
            }
        }
    }
}