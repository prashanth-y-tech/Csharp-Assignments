// Decompiled with JetBrains decompiler
// Type: BubbleSort.Program
// Assembly: BubbleSort, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2CBBD041-0300-4480-B061-2DEA08BEDB98
// Assembly location: C:\Users\prashanth yarram\OneDrive\Desktop\Technovert\C#-Training\C#-Assignments\Session-4\BubbleSort\bin\Debug\BubbleSort.exe

using System;

namespace BubbleSort
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      int[] array = new int[6]{ 3, 2, 4, 7, 9, 1 };
      Console.WriteLine((object) array);
      array.BubbleSort();
      foreach (int num in array)
        Console.WriteLine(num);
    }
  }
}
