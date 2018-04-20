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
        private int _count, _capacity;
        public Garage(int capacity, out string message)
        {
            message = $"The garage has been set to size {capacity}";
            if (capacity < 1)
            {
                capacity = 1;
                message = "The garage gas to be at least size 1" + "\n The garage has been set to size 1";
            }
            internalCollection = new T[capacity];
            _capacity = capacity;
            _count = 0;
        }

        public void Park(T vehicle, out string message)
        {
            message = "Sorry the garage is full";
           if (_count < _capacity)
            {
                internalCollection[_count++] = vehicle;
                message = "The vehicle has been parked";
            }
          
        }

        public T UnPark(string regNr)
        {
            T output=null;
            int slotToRemove = -1;
            for (int i = 0; i < _count; i++)
            {
                if (internalCollection[i].RegNr == regNr)
                {
                    output = internalCollection[i];
                    slotToRemove = i;
                    break;
                }
            }
            if (slotToRemove < 0)
            {
                return null;
            }

            for (int i = slotToRemove; i < _capacity; i++)
            {

                if (internalCollection[i] == null)
                {
                    break;
                }
                if (i+1!= _capacity)
                {
                     internalCollection[i] = internalCollection[i + 1];
                }
                else
                {
                    internalCollection[i] = null;
                }

            }
            _count--;
            return output;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return internalCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
