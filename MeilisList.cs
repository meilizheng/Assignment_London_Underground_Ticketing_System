using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
    public class MeilisList<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _count;
        private const int InitialCapacity = 100;

        public MeilisList()
        {
            _items = new T[InitialCapacity];
            _count = 0;
        }
        public int Count => _count;

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                ResizeArray();
            }

            _items[_count] = item;
            _count++;
        }

        private void ResizeArray()
        {
            int newCapacity = _items.Length * 2; // Double the capacity
            T[] newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
