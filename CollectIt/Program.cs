using System;
using System.Collections.Generic;

namespace CollectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //var employeesByName = new Dictionary<string, List<Employee>>();
            //var employeesByName = new SortedDictionary<string, List<Employee>>();       //Same as Dictionary but only Sorts the Values based on their Key Values. Note that if Keys are of Value Types it knows how to Sort. But if Keys are of Reference Types, then it has to be specified how to sort.
            var employeesByName = new SortedList<string, List<Employee>>();       //A Sorted List is more efficient when only Iteration of the List is Involved. Sorted Dicitonary should be used when Inserting or Deleting Entries or Indexing is involved as it is more efficient for those operations.

            employeesByName.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            employeesByName.Add("Engineering", new List<Employee> { new Employee(), new Employee() });

            foreach (var item in employeesByName)
            {
                Console.WriteLine("The Count of Employees for {0} is {1}",
                    item.Key, item.Value.Count);
            }
            Console.ReadKey();
        }
    }
}
