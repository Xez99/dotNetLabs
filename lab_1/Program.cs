using System;
using lab_1.utils;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            Console.WriteLine(list);
            
            list.Add("1");
            list.Add("2");
            list.AddFirst("0");
            list.AddLast("3");
            Console.WriteLine(list);
            list.Reverse();
            Console.WriteLine(list);
            foreach (string i in list)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();
            
            list.Clean();
            Console.WriteLine(list);
            
            list.AddFirst("2");
            list.Add("3");
            list.AddFirst("1");
            list.AddFirst("0");
            Console.WriteLine(list);
            
            list.Add(0,"sub0");
            list.Add(2, "sub0");
            list.Add(5, "2.5");
            list.Add(7, "3.9");
            list.Add("4");
            Console.WriteLine(list);

            list.Remove("sub0");
            Console.WriteLine(list);
            list.AddFirst("deadSub0");
            list.Add(8, "deadSub0");
            Console.WriteLine(list);
            list.Remove("deadSub0");
            Console.WriteLine(list);

            list.Remove(0);
            Console.WriteLine(list);
            list.Remove(2);
            Console.WriteLine(list);
            list.Remove(4);
            Console.WriteLine(list);
            
            Console.WriteLine(list.Get(0));
            Console.WriteLine(list.Get(1));
            Console.WriteLine(list.Get(2));
            Console.WriteLine(list.Get(3));
            
            Console.WriteLine(list.Contains("3.9"));
        }
    }
}