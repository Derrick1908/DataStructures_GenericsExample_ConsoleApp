using System;
using System.Collections.Generic;

namespace CollectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(2);     //Won't Add this to the Set List as it is a Duplicate Value. Only Allows Unique Values.

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            HashSet<Employee> set2 = new HashSet<Employee>();
            set2.Add(new Employee { Name = "Scott" });
            set2.Add(new Employee { Name = "Scott" });  //This will add the Second Employee becoz for Reference Types it just check if the references are the same or not. It cannot check explicitly the Values
                                                        //In order to check the values of the objects explicitly it will have to be told.
            var employee = new Employee { Name = "Alex" };
            set2.Add(employee);
            set2.Add(employee);         //Here as it can see the same object reference is already added, it does not add it again to prevent duplication
            
            foreach (var item in set2)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}
