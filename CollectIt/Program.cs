using System;
using System.Collections.Generic;

namespace CollectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Employee[] employees = new Employee[]{
                new Employee { Name = "Scott" },
                new Employee { Name = "Alex" }
            };*/

            List<Employee> employees = new List<Employee>       //Lists work in the Same way as an Array and we can Add New Employees and Remove them Efficiently
            {
                new Employee { Name = "Scott" },
                new Employee { Name = "Alex" }
            };

            employees.Add(new Employee { Name = "Dani" });

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].Name);
            }

            //Array.Resize(ref employees, 10);        //Limitations with Arrays Cannot Add New Elements or Remove Old Elements Efficiently.
            Console.ReadKey();
        }
    }
}
