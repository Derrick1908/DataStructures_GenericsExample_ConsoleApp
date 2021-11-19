using System;

namespace DataStructures
{
    class Program
    {
        /*
        static void ConsoleWrite(double data)           //Signature Matches the Type of Delegate, so hence delegate can point to it.
        {
            Console.WriteLine(data);
        }
        */
        static void Main(string[] args)
        {
            //Action<double> print = ConsoleWrite;        //Action(type of Delegate) that can take 16 Generic Input Parameters but returns a Void. For this Example, print(2.0) is valid
            /*Action<double> print = delegate (double data)   //Can point the Delegate to a Named Method as above or through an Anonymous Method
            {
                Console.WriteLine(data);
            };*/
            Action<bool> print = d => Console.WriteLine(d);     //Rather than using that Anonymous Method abpve we have used a Lambda Expression  Method.
            Func<double, double> square = d => d * d;               //Same as Action but always returns a Type( last paramater sent is the return type -> means that atleast one parameter has to be defined)
            Func<double, double, double> add = (x, y) => x + y;
            Predicate<double> isLessThanTen = d => d < 10;          //Predicate always returns a Boolean Value

            print(isLessThanTen(square(add(3,5))));

            var buffer = new Buffer<double>();                  //Using the New Buffer that wraps the Queue Internally along with its Operations

            ProcessInput(buffer);
            
            Console.WriteLine("-------------Contents of Buffer-------------");

            //buffer.Dump(print);       //Rather than doing the above, we can also pass the Function Name directly and the Compiler in the Background will instantiate a delegate pointing to this Method
            buffer.Dump(d => Console.WriteLine(d));  //Can also pass the Lamda Expression directly to the Dump Function and a Delegate will get created for it in the background

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
