using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1_CodeAlong_180419.Vehicles;

namespace Garage1_CodeAlong_180419
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] internalCollection;
        private int count, capacity;

        public Garage(int capacity, out int createdCapacity)
        {
            //Cap the cap to values between 1 and 1000
            this.capacity = capacity < 1 ? 1 : capacity > 1000 ? 1000 : capacity;
            internalCollection = new T[this.capacity];
            createdCapacity = this.capacity;
            count = 0;
        }

        public bool Park(T vehicle)
        {
            if (count >= capacity)
                return false;
            internalCollection[count++] = vehicle;
            return true;
        }

        public T UnPark(string regNr)
        {
            T output = null;
            for (int i = 0; i < count; i++)
            {
                if (internalCollection[i].RegNr == regNr)
                {
                    output = internalCollection[i];
                    //---unsorted
                    //internalCollection[i] = internalCollection[count - 1];
                    //count--;
                    //break;
                    //---
                }
                if (output != null)
                {
                    if (i < count)
                    {
                        internalCollection[i] = internalCollection[i + 1];
                    }
                    else
                    {
                        internalCollection[i] = null;
                        count--;
                        break;
                    }
                }
            }
            return output;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                if (internalCollection[i] != null) // not null just to make sure, hiding misstakes
                    yield return internalCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
