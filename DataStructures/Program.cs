using System;

namespace DataStructures
{
    class Program
    {
        static void ConsoleWrite(double data)           //Signature Matches the Type of Delegate, so hence delegate can point to it.
        {
            Console.WriteLine(data);
        }

        static void Main(string[] args)
        {
            //var buffer = new CircularBuffer<double>(capacity: 3);
            var buffer = new Buffer<double>();                  //Using the New Buffer that wraps the Queue Internally along with its Operations

            ProcessInput(buffer);
            
            Console.WriteLine("-------------Contents of Buffer-------------");
            /*var consoleOut = new Printer<double>(ConsoleWrite);
            buffer.Dump(consoleOut);          //Here we passing the Function through the Delegate Variable         
            */

            buffer.Dump(ConsoleWrite);       //Rather than doing the above, we can also pass the Function Name directly and the Compiler in the Background will instantiate a delegate pointing to this Method

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
