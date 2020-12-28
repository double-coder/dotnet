using System;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            //lets start with collection
            //arrays
            string[] daysOfWeek = new string[7];
            //indexing start with zero
            daysOfWeek[1]= "assign val"; //[indexing] for accessing elements

            ArrayCollection collection = new ArrayCollection(daysOfWeek);
            var storeVal = collection.getArray("second ele");
            Console.WriteLine($"this val is: {storeVal[0]}");
            Console.WriteLine($"this val is: {storeVal[1]}");
        }
    }
}
