using System;

namespace GenericStack
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Stack<string> stack = new Stack<string>();
      stack.PushElement("a");
      stack.PushElement("b");
      stack.PushElement("c");
      stack.PushElement("d");
      stack.PushElement("e");
      stack.PopElement();
      stack.PopElement();
      stack.PushElement("f");
      Console.WriteLine(stack.GetData());
    
    }
  }
}
