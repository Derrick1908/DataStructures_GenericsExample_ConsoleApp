using System;
using System.Collections.Generic;

namespace CollectIt
{
    public class EmployeeComparer : IEqualityComparer<Employee>, 
                                    IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name);
        }

        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();      //Returns the HashCode of the Empployers Name (string) so that it can be used by the HashSet for the case when Two Employees with the Same Name will have the Same Hash Code and thus prevent Duplicates from being Inserted.
        }
    }

    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));       //This is Used for the First Time to Compare 
            }
            this[departmentName].Add(employee);
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new DepartmentCollection();       //Used a SortedSet to Store both Unique Employees per Department as well as Alphabetically Sorted. Note that a SortedSet is just a HashSet but sorts the Entries.

            
            #region SortedSet
             departments.Add("Sales", new Employee { Name = "Joy" })
                        .Add("Sales", new Employee { Name = "Dani" })
                        .Add("Sales", new Employee { Name = "Dani" });

            departments.Add("Engineering", new Employee { Name = "Scott" })
                       .Add("Engineering", new Employee { Name = "Alex" })
                       .Add("Engineering", new Employee { Name = "Dani" });
            #endregion

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }
            Console.ReadKey();
        }
    }
}
