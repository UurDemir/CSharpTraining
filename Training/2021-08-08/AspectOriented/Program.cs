using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOriented
{
    class Program
    {
        static void Main(string[] args)
        {
            NormalCall();
            Console.WriteLine(new string('-',10));
            ProxyCall();
            Console.ReadKey();
        }

        private static void NormalCall()
        {
            Mathematic math = new Mathematic();

            Console.WriteLine("Sum Result : " + math.Sum(10, 5));

            Console.WriteLine("Substract : " + math.Substract(16, 4));

            Console.WriteLine("Divide Result : " + math.Divide(28, 4));

            Console.WriteLine("Multiple Result : " + math.Multiple(33, 33));

        }



        private static void ProxyCall()
        {
            Mathematic math = Mathematic.Create();

            Console.WriteLine("Sum Result : " + math.Sum(10, 5));

            Console.WriteLine("Substract : " + math.Substract(16, 4));

            Console.WriteLine("Divide Result : " + math.Divide(28, 4));

            Console.WriteLine("Multiple Result : " + math.Multiple(33, 33));

        }
    }
}
