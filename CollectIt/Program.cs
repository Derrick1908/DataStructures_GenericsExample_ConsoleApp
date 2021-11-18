using System;
using System.Collections.Generic;

namespace CollectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Employee> queue = new Queue<Employee>();
            queue.Enqueue(new Employee { Name = "Alex" });
            queue.Enqueue(new Employee { Name = "Dani" });
            queue.Enqueue(new Employee { Name = "Chris" });

            while(queue.Count > 0)
            {
                var employee = queue.Dequeue();
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine("----------------");

            Stack<Employee> stack = new Stack<Employee>();
            stack.Push(new Employee { Name = "Alex" });
            stack.Push(new Employee { Name = "Dani" });
            stack.Push(new Employee { Name = "Chris" });

            while (stack.Count > 0)
            {
                var employee = stack.Pop();
                Console.WriteLine(employee.Name);
            }

            Console.ReadKey();
        }
    }
}
