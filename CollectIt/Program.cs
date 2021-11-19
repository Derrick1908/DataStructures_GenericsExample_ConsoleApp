using System;
using System.Collections.Generic;

namespace CollectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(3);

            var first = list.First;
            list.AddAfter(first, 5);
            list.AddBefore(first, 10);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------");
            //Another Way of Printing the Elements in the List
            var node = list.First;
            while (node != null )
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
            Console.ReadKey();
        }
    }
}
