using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[]{
                new Employee { Name = "Scott" },
                new Employee { Name = "Alex" }
            };


            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i].Name);
            }

            Array.Resize(ref employees, 10);        //Limitations with Arrays Cannot Add New Elements or Remove Old Elements Efficiently.

        }
    }
}
