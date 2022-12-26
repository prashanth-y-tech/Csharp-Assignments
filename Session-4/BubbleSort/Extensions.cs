using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSort.Extensions
{
    internal static class Extensions
    {
        public static void BubbleSort<T>(this T[] array) where T : struct,IComparable
        {
            {
                bool flag = false;
                if (array.Length == 0)
                {
                    Console.WriteLine("Empty array passed");
                    flag = true;
                }
                int num1 = ((IEnumerable<T>)array).Count() - 1;
                while (!flag)
                {
                    flag = true;
                    for (int index = 0; index < num1; ++index)
                    {

                        if (array[index].CompareTo(array[index + 1]) > 0)
                        {
                            T num2 = array[index];
                            array[index] = array[index + 1];
                            array[index + 1] = num2;
                            flag = false;
                        }
                    }
                    --num1;
                }

            }
        }
    }
}
