using System;


namespace Sortings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Two identical arrays to test the difference in shifts between Insertion and Shell sort
            int[] array = new int[] { 10, 3, 5, 14, 21, 17, -5, 1 };
            int[] array2 = new int[] { 10, 3, 5, 14, 21, 17, -5, 1 };
            Console.WriteLine("Array1 = " + GetArrayAsString(array));
            InsertionSort(array);
            Console.WriteLine("Array1 = " + GetArrayAsString(array));
            Console.WriteLine();
            Console.WriteLine("Array2 = " + GetArrayAsString(array2));
            ShellSort(array2);
            Console.WriteLine("Array2 = " + GetArrayAsString(array2));
            Console.WriteLine();

            int[] array3 = new int[] { 10, 3, 5, 14, 21, 17, -5, 1 };
            Console.WriteLine("Array3 = " + GetArrayAsString(array3));
            MergeSort(array3, 0, array3.Length);
            Console.WriteLine("Merge Sort Applied");
            Console.WriteLine("Array3 = " + GetArrayAsString(array3));
            Console.WriteLine();

            int[] array4 = new int[] { 10, 3, 5, 14, 21, 17, -5, 1 };
            Console.WriteLine("Array4 = " + GetArrayAsString(array4));
            QuickSort(array4, 0, array4.Length);
            Console.WriteLine("Quick Sort Applied");
            Console.WriteLine("Array4 = " + GetArrayAsString(array4));
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

        private static void SelectionSort(int[] array)
        {
            for (int lastUnsortedIndex = array.Length - 1; lastUnsortedIndex > 0; lastUnsortedIndex--)
            {
                int indexWhereMaxValueIs = lastUnsortedIndex; // could be any index in range...
                                                              // to simplify it a bit, it as if you were constantly decreasing the array interval to search
                                                              // MAX value and then put it at place you've selected(last in our case)
                for (int i = 0; i < lastUnsortedIndex; i++)
                {
                    if (array[i] > array[indexWhereMaxValueIs])
                    {
                        indexWhereMaxValueIs = i;
                    }
                }
                Swap(array, indexWhereMaxValueIs, lastUnsortedIndex);
            }
        }

        private static void InsertionSort(int[] array)
        {
            int shiftsCounter = 0;
            for (int indexGoingRight = 1; indexGoingRight < array.Length; indexGoingRight++)
            {
                int candidateToInsert = array[indexGoingRight]; // note this is the actual value
                int indexGoingLeft; //we need this outside the loop to refer it later 
                for (indexGoingLeft = indexGoingRight; indexGoingLeft > 0 && array[indexGoingLeft - 1] > candidateToInsert; indexGoingLeft--)
                {
                    shiftsCounter++;
                    array[indexGoingLeft] = array[indexGoingLeft - 1]; // we shift elemets to the right until we either are at the begining of the array
                                                                       // or the neighbour to our left is smaller than the candidateToInsert
                }
                array[indexGoingLeft] = candidateToInsert; // here we are at place to insert
            }
            Console.WriteLine("Exiting InsertionSort with " + shiftsCounter + " shifts.");
        }

        // Main difference /imporovement when using the Shell method over InsertionSort is that we 
        // make a couple of rough sortings while our step/gap is closing(going smaller)
        // and our array is more or less sorted, this helps reducing the number of shifts we make to find the spot for our "candidate" 
        private static void ShellSort(int[] array)
        {
            int shiftsCounter = 0;
            for (int step = array.Length / 1; step > 0; step /= 2) // note that the step will eventually become '1' and from that point on it is 1:1 with InsertionSort
            {
                for (int indexGoingRight = step; indexGoingRight < array.Length; indexGoingRight++)
                {
                    int candidateToInsert = array[indexGoingRight];
                    int indexGoingLeft;
                    for (indexGoingLeft = indexGoingRight; indexGoingLeft >= step && array[indexGoingLeft - step] > candidateToInsert; indexGoingLeft -= step)
                    {
                        shiftsCounter++;
                        array[indexGoingLeft] = array[indexGoingLeft - step];
                    }
                    array[indexGoingLeft] = candidateToInsert;
                }
            }
            Console.WriteLine("Exiting ShellSort with " + shiftsCounter + " shifts.");
        }

        private static void MergeSort(int[] array, int start, int end)
        {
            if (end - start < 2)
            {
                return;
            }
            //logical partitioning part, until we go down to one element arrays(sorted by default)
            int mid = (start + end) / 2;
            MergeSort(array, start, mid);
            MergeSort(array, mid, end);
            //merge part
            Merge(array, start, mid, end);
        }

        private static void Merge(int[] array, int start, int mid, int end)
        {
            if (array[mid - 1] <= array[mid])
            {
                return;
            }
            int i = start;
            int j = mid;
            int tempIndex = 0;
            int[] tempArray = new int[end - start];
            while (i < mid && j < end)
            {
                tempArray[tempIndex++] = (array[i] <= array[j]) ? array[i++] : array[j++]; // note '<=' this makes it stable sorting algorithm
            }
            Array.Copy(array, start, array, start + tempIndex, mid - i);
            Array.Copy(tempArray, 0, array, start, tempIndex);
        }

        private static void QuickSort(int[] array, int start, int end)
        {
            if (end - start < 2)
            {
                return;
            }
            int pivotIndex = Partition(array, start, end);
            QuickSort(array, start, pivotIndex);
            QuickSort(array, pivotIndex + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            int pivot = array[start];
            int leftSide = start;
            int rightSide = end;
            while (leftSide < rightSide)
            {
                while (leftSide < rightSide && array[--rightSide] > pivot) ;
                if (leftSide < rightSide)
                {
                    array[leftSide] = array[rightSide];
                }
                while (leftSide < rightSide && array[++leftSide] < pivot) ;
                if (leftSide < rightSide)
                {
                    array[rightSide] = array[leftSide];
                }
            }
            array[rightSide] = pivot;
            return rightSide;
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
