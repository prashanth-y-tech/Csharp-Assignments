// Decompiled with JetBrains decompiler
// Type: BubbleSort.Extensions.Extensions
// Assembly: BubbleSort, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2CBBD041-0300-4480-B061-2DEA08BEDB98
// Assembly location: C:\Users\prashanth yarram\OneDrive\Desktop\Technovert\C#-Training\C#-Assignments\Session-4\BubbleSort\bin\Debug\BubbleSort.exe

using System.Collections.Generic;
using System.Linq;

namespace BubbleSort.Extensions
{
  internal static class Extensions
  {
    public static int[] BubbleSort(this int[] array)
    {
      bool flag = false;
      if (array.Length == 0)
        return (int[]) null;
      if (array.Length == 1)
        return array;
      int num1 = ((IEnumerable<int>) array).Count<int>() - 1;
      while (!flag)
      {
        flag = true;
        for (int index = 0; index < num1; ++index)
        {
          if (array[index] > array[index + 1])
          {
            int num2 = array[index];
            array[index] = array[index + 1];
            array[index + 1] = num2;
            flag = false;
          }
        }
        --num1;
      }
      return array;
    }
  }
}
