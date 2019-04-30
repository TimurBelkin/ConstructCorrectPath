using ConstructPathDelivery;
using ConstructPathNoExceptionMessage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConstructPath
{
    

    class Program
    {
        


        static void printPath(List<Tuple<string, string>> input)
        {
            Console.WriteLine("Begin");
            if (input == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                foreach (var it in input)
                {
                    Console.WriteLine("{0} -> {1}", it.Item1, it.Item2);
                }
            }
            Console.WriteLine("End");
            Console.WriteLine();
        }


        static void Test(List<Tuple<string, string>> list)
        {
            List<Tuple<string, string>> new_list = new List<Tuple<string, string>>();
            printPath(list);
            PathConstructorNoException pathConstructorNoException = new PathConstructorNoException();
            new_list = pathConstructorNoException.ConstructPath(list);
            printPath(new_list);
            Console.WriteLine("--------------------------------------");
        }

        static void GlobalTest()
        {
            // Input null
            Console.WriteLine("Input null:");
            Test(null);

            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            Test(list);

            // one element
            Console.WriteLine("one element:");
            list.Add(new Tuple<string, string>("two", "three"));
            Test(list);

            // Correct data
            Console.WriteLine("Correct data:");
            list.Add(new Tuple<string, string>("four", "five"));
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("three", "four"));
            Test(list);

            // circle
            Console.WriteLine("Circle:"); 
            list.Add(new Tuple<string, string>("four", "one"));
            Test(list);
        }

        static void Main(string[] args)
        {
            /*
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            PathConstructor pathConstructor = new PathConstructor();
            List<Tuple<string, string>> result = pathConstructor.ConstructPath(list);
            Console.WriteLine(list ==  result);*/
             GlobalTest();
            while (true) ;
        }
    }
}
