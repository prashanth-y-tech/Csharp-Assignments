using System;

namespace GenericStack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            try
            {
                stack.Push("a");
                stack.Push("b");
                stack.Push("c");
                stack.Push("d");
                stack.Push("e");
                stack.Pop();
                stack.Pop();
                stack.Push("f");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(stack.GetData());
        }
    }
}
