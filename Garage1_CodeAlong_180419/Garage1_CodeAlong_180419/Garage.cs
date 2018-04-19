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
            message = "The Garage has been set to size " + capacity;

            if (capacity < 1)
            {
                capacity = 1;
                message = "The Garage has to be at least size 1"+
                    "\nThe Garage has been set to size 1";
            }

            internalCollection = new T[capacity];

            _capacity = capacity;
            _count = 0;
        }

        public void Park(T vehicle, out string message)
        {
            message = "Sadly the garage is currently full";
            if (_count < _capacity)
            {
                message = "The vehicle has been parked";
                internalCollection[_count++] = vehicle;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
