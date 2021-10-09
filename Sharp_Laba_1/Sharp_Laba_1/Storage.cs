using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharp_Laba_1
{
    /// <summary>
    /// Класс контейнер склада
    /// </summary>
    public class Storage
    {
        private int _storageSize;

        private Product[] _container;

        public int NumCode { get; set; } = 0;

        private Storage(int size)
        {
            _storageSize = size;
            _container = new Product[_storageSize];
            NumCode++;
        }

        public static implicit operator Storage(int n) => new Storage(n);

        public Product this[int index]
        {
            get => Pop(index);
            set => Put(value, index);
        }

        public override string ToString()
        {
            string str = null;
            foreach (var product in _container)
            {
                str += $"\n\t{product}";
            }
            return $"Номер склада: {NumCode} {str}";
        }

        public void Put(Product product)
        {
            for (int i = 0; i < _container.Length; i++)
            {
                if (_container[i] == null)
                {
                    _container[i] = product;
                    ReBar(product);
                    return;
                }
            }
            Console.WriteLine("Склад заполнен!");
        }

        public void Put(Product product,int i)
        {
            if (_container[i] != null)
            {
                Console.WriteLine("Место уже занято!");
            }
            else
            {
                _container[i] = product;
                ReBar(product);
            }
        }

        public Product Pop(int i)
        {
            var tmp = _container[i];
            _container[i] = null;
            return tmp;
        }

        public void Swap(int i, int j) => (this[i], this[j]) = (this[j], this[i]);

        public int Search(int code) => Array.IndexOf(_container, _container.First(p => p?.NumericCode == code));


        public List<int> Search(string name) => _container.Where(p =>p?.Name == name).Select(p => Array.IndexOf(_container, p)).ToList();

        public void SortByCode()
        {
            _container = _container.OrderBy(p => p?.NumericCode).ToArray();
            ReBar();
        }

        public void SortByName()
        {
            _container = _container.OrderBy(p => p?.Name).ToArray();
            ReBar();
        }

        private void ReBar(Product p) 
        {

        }

        private void ReBar() 
        {
            foreach (var item in _container.Where(p =>p != null))
            {
                ReBar(item);
            }
        }
    }
}