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
    class Program
    {
        static void Main(string[] args)
        {
            //var departments = new Dictionary<string, List<Employee>>();
            //var departments = new SortedDictionary<string, List<Employee>>();       //Used a Sorted Dictionary to Sort the Departments
            //var departments = new SortedDictionary<string, HashSet<Employee>>();       //Used a HashSet to Store only Unique Employees per Department
            var departments = new SortedDictionary<string, SortedSet<Employee>>();       //Used a SortedSet to Store both Unique Employees per Department as well as Alphabetically Sorted. Note that a SortedSet is just a HashSet but sorts the Entries.

            #region HashSet
            /*
            departments.Add("Sales", new HashSet<Employee>(new EmployeeComparer()));        //One of the Overloaded Constructors of HashSet can receive a Class that Implements IEqualityComparer
            departments["Sales"].Add(new Employee { Name = "Joy" });
            departments["Sales"].Add(new Employee { Name = "Dani" });
            departments["Sales"].Add(new Employee { Name = "Dani" });

            departments.Add("Engineering", new HashSet<Employee>(new EmployeeComparer()));      //This means thta use the Object of EmployeeComparer to Compare the Two Objects of the Employee Class
            departments["Engineering"].Add(new Employee { Name = "Scott" });
            departments["Engineering"].Add(new Employee { Name = "Alex" });
            departments["Engineering"].Add(new Employee { Name = "Dani" }); */
            #endregion

            #region SortedSet
            departments.Add("Sales", new SortedSet<Employee>(new EmployeeComparer()));        //One of the Overloaded Constructors of SortedSet can receive a Class that Implements not IEqualityComparer but IComparer (becoz here it not only has to Compare both the Values whether they are equal or not but here it has to Sort them as well)
            departments["Sales"].Add(new Employee { Name = "Joy" });
            departments["Sales"].Add(new Employee { Name = "Dani" });
            departments["Sales"].Add(new Employee { Name = "Dani" });

            departments.Add("Engineering", new SortedSet<Employee>(new EmployeeComparer()));      //This means thta use the Object of EmployeeComparer to Compare the Two Objects of the Employee Class
            departments["Engineering"].Add(new Employee { Name = "Scott" });
            departments["Engineering"].Add(new Employee { Name = "Alex" });
            departments["Engineering"].Add(new Employee { Name = "Dani" });
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
