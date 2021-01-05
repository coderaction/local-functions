using System;

namespace FunctionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            ExampleOne();

            ExampleTwo();
        }
        
        private static void ExampleOne()
        {
            var k = 10;
            
            var j = 99.9;
            
            void Scope(string x, int y) 
            {
                Console.WriteLine($"The value of {nameof(x)} is {x}");
                Console.WriteLine($"The value of {nameof(y)} is {y}");
                Console.WriteLine($"The value of {nameof(k)} is {j}");
                Console.WriteLine($"The value of {nameof(j)} is {j}");
            }
            
            Scope("twelve", 666);
            
            Console.ReadKey();
        }

        private static void ExampleTwo()
        {
            
            MyGeneric<string>("twelve");
            
            MyGeneric<int>(2012);
            
            void MyGeneric<Value>(Value x)
            {
                Console.WriteLine($"Value from generic message: {x}");
            }
            
            Console.ReadKey();
        }
        
        public void TotalCount(int numberOne, int numberTwo)
        {
            double Total()
            {
                return numberOne + numberTwo;
            }
            
            Console.WriteLine($"Total: {Total()}");
        }
    }
}