using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
    public class CustomList<T>
    {
        // Created the field. T[] is a generic array.
        private T[] customs;
        private int count;

        // Default constructor that initializes the CustomList with a default size of 100.
        public CustomList() : this(100) { }

        // Parameterized constructor that initializes the CustomList with a specified initial size.
        public CustomList(int InitialSize)
        {
            customs = new T[InitialSize];
        }

        //Count property
        public int Count => count;


        //CheckIntegrity Method, use to resize the generic array's size when necessary.
        private void CheckIntegrity()
        {
            // Check if the current count exceeds 80% of the array's length.
            if (count >= 0.8 * customs.Length)
            {
                // Create a new array with double the size of the current array.
                T[] newCustom = new T[customs.Length * 2];

                //Cope the elements from the current arry to new array.
                Array.Copy(customs, newCustom, count);

                // Update the reference to the generic array.
                customs = newCustom;
            }
        }

        //Created the Add metod
        public void Add(T custom)
        {
            CheckIntegrity();
            customs[count++] = custom;
        }

        public void AddAtIndex(T custom, int index)
        {
            CheckIntegrity();
            if (index < 0 || index > count) throw new IndexOutOfRangeException(nameof(index));
            for (int i = count; i > index; i--)
            {
                customs[i] = customs[i - 1];
            }
            customs[index] = custom;
            count++;
        }

        public void RemoveAtIndex(int index)
        {
            for (int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        customs[j] = customs[j + 1];
                    }
                    count--;
                }
            }
        }
    }
}
