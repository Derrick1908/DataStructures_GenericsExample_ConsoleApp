using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    public interface IEntity
    {
        bool IsValid();
    }
    public class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person, IEntity
    {
        public int Id { get; set; }
        public bool IsValid()
        {
            return true;
        }
        public virtual void DoWork()
        {
            Console.WriteLine("Doing Real Work");
        }       
    }

    public class Manager : Employee
    {
        public override void DoWork()
        {
            Console.WriteLine("Create a Meeting");
        }
    }
}
