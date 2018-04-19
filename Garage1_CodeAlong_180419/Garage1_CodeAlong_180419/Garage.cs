using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1_CodeAlong_180419.Vehicles;

namespace Garage1_CodeAlong_180419
{ // Buisness logic layer?
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {

        private T[] internalCollection;
        private int _count, _capacity; // Fields

        public Garage(int capacity, out string message) // Make sure we dont have a garage with less than one space. 
        {
            //message = null;
            message = "The Garage has been set to size " + capacity;
            if (capacity < 1)
            {
                capacity = 1;
                message = "The Garage has to be at least size 1" +  // Replace the value and sends it back? to the out string message parameter in constructor. Dosent to anything until we call it from the UI. 
                    "\nThe Garage has been set to size 1";
            }

            internalCollection = new T[capacity];            // Create an instance of the collection. 
            _capacity = capacity;                   // Takes the int that will be sent in thru the constructor parameter.
            _count = 0;                                 // starts empty
        }

        public T UnPark(string regNr) // Take in a regnumer - bca they are unice.? // declare two varibles 
        {
            T output = null; // array output. a vecicle whatever! T Generic // initiate the output.  and at the end return output. 
            int slotToRemove = -1;              // 
            for (int i = 0; i < _count; i++) // we start at zero to the current count. We count trou it once serching for reg number..   // Null values have to be at the end, in list,? arrays? 
            {
                if (internalCollection[i].RegNr == regNr)
                {
                    output = internalCollection[i];
                    slotToRemove = i;
                    break;                                  // snap us put of the forlope  // The array contains pointer to the vechile 
                }
            }
            if (slotToRemove < 0)            // if ther is no slot to remove return ull.
            {
                return null;
            }
            for (int i = slotToRemove; i < _capacity; i++)                      // loop thru from -1 an increase until we are in capacity
            {
                if (internalCollection[i] == null)
                {
                    break;
                }
                if (i + 1 != _capacity) 
                {
                    internalCollection[i] = internalCollection[i + 1];          // Moving up the next value, loop again and againg until you hit null
                }
                else
                {
                    internalCollection[i] = null;
                }                                                      // Just moving everting up one step, until we hit null, or the final value. as soon as i+1 has moved and null or last value get caught
                               
            }
            _count--;                                                   // Remove the value in the array.
            return output;                                           // retun output 
        }


        public void Park(T vehicle, out string message) // T sets the type, so it can be a car not only a vechile, dosent matter with subclass. Not unyil the function is finished
        {
            message = "Sadly the garage is currently full";
            if (_count < _capacity)
            {
                message = "The Vehicle has been parked";
                internalCollection[_count++] = vehicle;
            }
        }


        public IEnumerator<T> GetEnumerator() // Implement interface. 
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
