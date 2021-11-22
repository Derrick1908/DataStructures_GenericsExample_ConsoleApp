using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var buffer = new Buffer<double>();                  //Using the New Buffer that wraps the Queue Internally along with its Operations

            ProcessInput(buffer);

            //Converter<double, DateTime> converter = d => new DateTime(2010, 1, 1).AddDays(d);
            //var asDates = buffer.Map(converter);        //Here there is no need to send the Input and Output type as the Compiler infers it from the COnverter Variable.

            var asDates = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d));         //Inplace of declaring a variable converter we can directly send the expression body of function and the compiler will initialize the converter delegate pointing to it.
            
            foreach (var date in asDates)
            {
                Console.WriteLine(date);
            }
            
            Console.WriteLine("-------------Contents of Buffer-------------");
            buffer.Dump(d => Console.WriteLine(d));  

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
