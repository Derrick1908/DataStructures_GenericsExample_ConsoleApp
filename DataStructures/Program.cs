using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //var buffer = new CircularBuffer<double>(capacity: 3);
            var buffer = new Buffer<double>();                  //Using the New Buffer that wraps the Queue Internally along with its Operations

            ProcessInput(buffer);
            Console.WriteLine("-------------Contents of Buffer-------------");
            buffer.Dump();          //Here we dont have to specify buffer.Dump<double>() becoz the compiler inferes the Type from byffer i.e. t-> Double.
         //buffer.Dump<int>();      //We will get an Error here becoz this means that buffer is also of type int i.e. of IBuffer<int> whereas it is double

            var asInts = buffer.AsEnumerableOf<double, int>();
            var asStrings = buffer.AsEnumerableOf<double, string>();

            Console.WriteLine("-------------Int Enumerable-------------");
            foreach (var item in asInts)
            {
                Console.WriteLine(item);            //Prints each Value in the Buffer; Done only after Implementing the IEnumerable Interface;
            }
            
            Console.WriteLine("-------------String Enumerable-------------");
            foreach (var item in asStrings)
            {
                Console.WriteLine(item);            //Prints each Value in the Buffer; Done only after Implementing the IEnumerable Interface;
            }

            ProcessBuffer(buffer);
            Console.ReadKey();
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer Sum: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
