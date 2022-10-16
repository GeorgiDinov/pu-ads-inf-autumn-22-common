using System;


namespace Sortings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GetRandomInitializedSingleDimentionArray(10);
            Console.WriteLine("Array = " + GetArrayAsString(array));
            BubbleSort(array);
            Console.WriteLine("BubbleSort applied = " + GetArrayAsString(array));
        }

        //Slightly optimized if happens that the array is already sorted we will stop iterating
        private static void BubbleSort(int[] array)
        {
            for (int last = array.Length - 1; last > 0; last--)
            {
                bool isSorted = true;
                for (int current = 0; current < last; current++)
                {
                    int next = current + 1;
                    if (array[current] > array[next])
                    {
                        isSorted = false;
                        Swap(array, current, next);
                    }
                }
                if (isSorted)
                {
                    break;
                }
            }
        }


        private static void Swap(int[] array, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            if (array[left] == array[right])
            {
                return;
            }

            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        private static int[] GetRandomInitializedSingleDimentionArray(int arrayLength)
        {
            Random random = new Random();
            int[] array = new int[arrayLength];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10, 100);
            }
            return array;
        }

        private static string GetArrayAsString(int[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += (i < array.Length - 1) ? array[i] + ", " : array[i] + "";
            }
            return "[" + result + "]";
        }
    }
}
