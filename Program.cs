namespace Workshop
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList<string>();

            list.Add("element");
            list.Count();
            list.InsertAt(1, "secondElement");
            list.RemoveAt(1);
            var isElement = list.Contains("element");
            Console.WriteLine(isElement);

            list.Swap(0, 1);
            list.RemoveAll(e => e == "element");
            list.Clear();

            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            var element = stack.Peek();
            Console.WriteLine(element);
            stack.ForEach(x => Console.WriteLine(x));
            stack.Clear();


            
        }
    }
}
