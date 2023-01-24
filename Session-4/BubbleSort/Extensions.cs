using System;

namespace BubbleSort.Extensions
{
    internal static class Extensions
    {
        public static void BubbleSort<T>(this T[] array) where T : struct, IComparable
        {
            bool flag;
            if (array.Length.Equals(0))
            {
                return;
            }
            for (int temp = 0; temp < array.Length - 1; temp++)
            {
                flag = true;
                for (int index = 0; index < array.Length - 1; index++)
                {
                    if (array[index].CompareTo(array[index + 1]) > 0)
                    {
                        T num2 = array[index];
                        array[index] = array[index + 1];
                        array[index + 1] = num2;
                        flag = false;
                    }
                }
                if (flag.Equals(true))
                {
                    break;
                }
            }
        }
    }
}
