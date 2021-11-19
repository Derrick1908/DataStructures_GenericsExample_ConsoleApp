using System;
using System.Collections.Generic;

namespace CollectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeesByName = new Dictionary<string, Employee>();
            var employeesByDepartment = new Dictionary<string, List<Employee>>();

            employeesByName.Add("Scott", new Employee { Name = "Scott" });
            employeesByName.Add("Alex", new Employee { Name = "Alex" });
            employeesByName.Add("Joy", new Employee { Name = "Joy" });
            //employeesByName.Add("Scott", new Employee { Name = "Scott" });        //Cannot Add Duplicate Keys in a Dictionary

            var scott = employeesByName["Scott"];       //Indexing using the Key Values as they are Unique. Indexing Value depends on the Type of the Key which is string in this case.

            employeesByDepartment.Add("Engineering", 
                new List<Employee> { new Employee { Name = "Scott" } });
            //...
            employeesByDepartment["Engineering"].Add(new Employee { Name = "Scott" });

            foreach (var item in employeesByName)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value.Name);
            }

            Console.WriteLine("----------");
            foreach (var item in employeesByDepartment)
            {
                Console.WriteLine("{0} Department Employees:: ", item.Key);
                foreach (var employee in item.Value)
                {
                    Console.WriteLine(employee.Name);
                }
            }
            Console.ReadKey();
        }
    }
}
