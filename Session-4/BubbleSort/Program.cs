using System;
using BubbleSort.Extensions;

namespace BubbleSort
{
  internal class Program
  {
    
    private static void Main(string[] args)
    {

     int[] array = new int[3]{ 4,9,1};
     array.BubbleSort();
     foreach (int num in array)
        Console.WriteLine(num);
    }
  }
}
