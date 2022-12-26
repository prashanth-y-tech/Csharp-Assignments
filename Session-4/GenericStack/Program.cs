// Decompiled with JetBrains decompiler
// Type: GenericStack.Program
// Assembly: GenericStack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A690CBD-D02B-4FA1-971F-BFDFF830492D
// Assembly location: C:\Users\prashanth yarram\OneDrive\Desktop\Technovert\C#-Training\C#-Assignments\Session-4\GenericStack\bin\Debug\GenericStack.exe

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
      stack.DisplayElements();
    }
  }
}
