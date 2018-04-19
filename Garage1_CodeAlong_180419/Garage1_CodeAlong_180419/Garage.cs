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
        private T[] internalCollection;                                     //this array is collection of Vehcils  or "where is the vehicles saved" 
        private int _count, _capacity;                                      //we used private here to deny to access to these fields from out of the class .


        public Garage(int capacity , out string message)                    //Constructor
        {
            message = "The Garage has been set to size "+ capacity;
            if (capacity < 1)                                               //to ensure that the array have at least 1 place 
            {
                capacity=1;
                message = " The Garage has to be at least size 1 " + "\nThe Garage has been set to size 1";//to ensure that the array have at least 1 place 
            }

            internalCollection = new T[capacity];                           //here is instanction of internal Collection

            _capacity = capacity;
            _count = 0;
        }

        public void Park(T vehicle , out string message) //no mattar what subclasses it will be vehicle 
        {
            message = "Sadly the Garage is Currently full ";
            if(_count < _capacity)
            {
                message = "The vehicle has been parked";
                internalCollection[_count++] = vehicle; // each time we add vehicle we will add with ++ new vehcile without empty spaces.
            }
            
        }

        public T UnPark(string regNr) //regNr we want to remove to know whic can is parked in the car 
        {
            T  output=null;
            int slotToRemove = -1; // coz there is no -1 in the array
            for (int i = 0; i < _count; i++) //loook through the array 
            {
                if(internalCollection[i].RegNr == regNr)
                {
                    output = internalCollection[i];
                    slotToRemove = i;
                    break;

                }

            }


            if(slotToRemove <0) // if there is no slott to remove 
            {
                return null;
            }

            for (int i =slotToRemove; i< _capacity; i++)
            {
                if (internalCollection[i] == null)
                {
                    break;
                }
               
                if (i + 1 != _capacity)  //we ae looking that we are curruntly not in the last capacity of the array
                {
                    internalCollection[i] = internalCollection[i + 1]; //we donät want to crush here
                }

                else 
                {
                    internalCollection[i] = null;
                    break;
                }

            }

            _count--;
            return output;

            
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <_count; i++)
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
