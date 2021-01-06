using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        
        async Task WriteEmailsAsync()
        {
            var emailRegex = new Regex(@"(?i)[a-z0-9_.+-]+@[a-z0-9-]+\.[a-z0-9-.]+");
            IEnumerable<string> emails1 = await getEmailsFromFileAsync("input1.txt");
            IEnumerable<string> emails2 = await getEmailsFromFileAsync("input2.txt");
            await writeLinesToFileAsync(emails1.Concat(emails2), "output.txt");

            async Task<IEnumerable<string>> getEmailsFromFileAsync(string fileName)
            {
                string text;

                using (StreamReader reader = File.OpenText(fileName))
                {
                    text = await reader.ReadToEndAsync();
                }

                return from Match emailMatch in emailRegex.Matches(text) select emailMatch.Value;
            }

            async Task writeLinesToFileAsync(IEnumerable<string> lines, string fileName)
            {
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    foreach (string line in lines)
                    {
                        await writer.WriteLineAsync(line);
                    }
                }
            }
        }
    }
}