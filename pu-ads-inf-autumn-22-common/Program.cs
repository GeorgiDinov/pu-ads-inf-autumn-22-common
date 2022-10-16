namespace pu_ads_inf_autumn_22_common
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }// end of method Main

        //Common array stuff
        //***Please revise why array indicies start from '0'?
        //:) At least in modern programing languages.
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

        //Array rotation/ reversion
        private static void RotateSingleDimentionalArrayV1(int[] array)
        {
            int last = array.Length - 1;
            for (int first = 0; first < array.Length / 2; first++)
            {
                int temp = array[first];
                array[first] = array[last];
                array[last--] = temp;
            }
        }

        private static void RotateSingleDimentionalArrayV2(int[] array)
        {
            for (int first = 0, last = array.Length - 1; first < array.Length / 2; first++, last--)
            {
                int temp = array[first];
                array[first] = array[last];
                array[last] = temp;
            }
        }

        private static void RotateSingleDimentionalArrayV2_1(int[] array)
        {
            for (int first = 0, last = array.Length - 1; first < array.Length / 2; first++, last--)
            {
                Swap(array, first, last);
            }
        }

        private static void RotateSingleDimentionalArrayV3(int[] array)
        {
            int first = 0, last = array.Length - 1;
            while (first < array.Length / 2)
            {
                int temp = array[first];
                array[first++] = array[last];
                array[last--] = temp;
            }
        }

        private static void RotateSingleDimentionalArrayV3_1(int[] array)
        {
            int first = 0, last = array.Length - 1;
            while (first < array.Length / 2)
            {
                Swap(array, first, last);
                first++;
                last--;
            }
        }


        private static void Swap(int[] array, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            if (IsIndexOutOfBounds(array, left))
            {
                return;//process with custom exception or other logic
            }

            if (IsIndexOutOfBounds(array, right))
            {
                return;//process with custom exception or other logic
            }

            if (array[left] == array[right])
            {
                return;
            }

            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        private static bool IsIndexInBounds(int[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }

        private static bool IsIndexOutOfBounds(int[] array, int index)
        {
            return index < 0 && index >= array.Length;
        }

        //Min & Max
        private static int GetMinValueInSingleDimentionalArray(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        private static int GetMaxValueInSingleDimentionalArray(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        //Sum & Average
        private static int SumAllElementsInSingleDimentionalArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        private static double GetAverageOfSingleDimentionalArray(int[] array)
        {
            int sum = SumAllElementsInSingleDimentionalArray(array);
            return sum / array.Length;
        }

        //Copy and allocate more memory
        private static int[] CopyArrayAndIncrementLenght(int[] array)
        {
            int newLenght = array.Length + 1;
            int[] copy = new int[newLenght];
            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }

        private static int[] CopyArrayAndDoubleLenght(int[] array)
        {
            int[] copy = new int[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }

        //Internship interview live coding task example
        // Write a program that determines if there exists an element in the array
        // such that the sum of the elements on its left is equal to the sum of the elements on its right.
        // If there are no elements to the left/right, their sum is considered to be 0.
        // Print the index that satisfies the required condition or "no" if there is no such index.
        private static void EqualSumCheck(int[] array)
        {
            int index = GetIndexInArrayThatDividesItIntoTwoEqualSums(array);
            string result;
            if (index != -1)
            {
                result = "At position [" + index + "] equal sums to the left and right were found";
            }
            else
            {
                result = "Position dividing the array in two equal sums Not Found!";
            }

            Console.WriteLine(result);
        }

        private static int GetIndexInArrayThatDividesItIntoTwoEqualSums(int[] array)
        {
            //Some validations and also prepostitions to determine if you are on the right path,
            //ask questions, those validations/checks may not be required
            if (array == null)
            {
                return -1; // process with custom exception or other logic
            }

            if (array.Length == 0)
            {
                return -1; // process with custom exception or other logic
            }

            if (array.Length == 1) // If there are no elements to the left/right, their sum is considered to be 0.
            {
                return 0;
            }

            if (array.Length == 2)
            {
                if (array[0] == 0) // If there are no elements to the left/right, their sum is considered to be 0.
                {
                    return 1;
                }
                if (array[1] == 0) // If there are no elements to the left/right, their sum is considered to be 0.
                {
                    return 0;
                }
            }

            //mind that the idea behind is very like insertion/ shell sort - loop going in the opposite direction of another loop
            for (int i = 0; i < array.Length; i++)
            {
                int leftSum = 0;
                for (int left = i - 1; left >= 0; left--)
                {
                    leftSum += array[left];
                }

                int rightSum = 0;
                for (int right = i + 1; right < array.Length; right++)
                {
                    rightSum += array[right];
                }

                if (leftSum == rightSum)
                {
                    return i;
                }
            }

            return -1;
        }

        //variation to get all possible positions, note that may return null
        private static int[] GetAllIndicesInArrayThatDividesItIntoTwoEqualSums(int[] array)
        {
            int counter = 0;
            int[] indices = null;

            for (int i = 0; i < array.Length; i++)
            {
                int leftSum = 0;
                for (int left = i - 1; left >= 0; left--)
                {
                    leftSum += array[left];
                }

                int rightSum = 0;
                for (int right = i + 1; right < array.Length; right++)
                {
                    rightSum += array[right];
                }

                if (leftSum == rightSum)
                {
                    if (indices == null)
                    {
                        indices = new int[1];
                    }

                    if (counter == indices.Length)
                    {
                        indices = CopyArrayAndIncrementLenght(indices);
                    }

                    indices[counter++] = i;
                }
            }

            return indices;
        }

        //Note this implementation, because it is very close to merge sort algorithm
        private static int[] MergeTwoSortedArrays(int[] leftArray, int[] rightArray)
        {
            int resultArrayLength = leftArray.Length + rightArray.Length;
            int[] resultArray = new int[resultArrayLength];

            int leftCursor = 0;
            int rightCursor = 0;
            int resultCursor = 0;

            while (leftCursor < leftArray.Length && rightCursor < rightArray.Length)
            {
                if (leftArray[leftCursor] < rightArray[rightCursor])
                {
                    resultArray[resultCursor++] = leftArray[leftCursor++];
                }
                else
                {
                    resultArray[resultCursor++] = rightArray[rightCursor++];
                }
            }

            while (leftCursor < leftArray.Length)
            {
                resultArray[resultCursor++] = leftArray[leftCursor++];
            }

            while (rightCursor < rightArray.Length)
            {
                resultArray[resultCursor++] = rightArray[rightCursor++];
            }

            return resultArray;
        }

        //Two dimentional arrays
        static int[,] GetRandomMatrix(int height, int width)
        {
            int[,] matrix = new int[height, width];
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)// arr.GetLength(0) - gives the number of rows in a 2D array
            {
                for (int j = 0; j < matrix.GetLength(1); j++)// arr.GetLength(1) - gives the number of elements in the row
                {
                    matrix[i, j] = random.Next(0, 10);
                }
            }
            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            string line = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                line += "[";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += (j < matrix.GetLength(1) - 1) ? matrix[i, j] + ", " : matrix[i, j] + "";
                }
                line += "]\n";
            }
            Console.WriteLine(line);
        }

        //Other
        //Prime numbers
        static void EratostenSieve(int n)
        {
            bool[] sieve = new bool[n + 1];

            for (int i = 0; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }


            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i] == true)
                {
                    for (int j = i + i; j < sieve.Length; j += i)
                    {
                        sieve[j] = false;
                    }
                }

            }

            string primesString = "";
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    primesString += i + " ";
                }
            }
            Console.WriteLine("Primes = " + primesString);
        }

        private static void PrintAllPrimesUpTo(int primesBoundary)
        {
            string primesString = "";
            for (int i = 2; i < primesBoundary + 1; i++)
            {
                if (IsPrime(i))
                {
                    primesString += i + " ";
                }
            }
            Console.WriteLine("Primes = " + primesString);
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (int i = 2; i < number; i++)// spot for optimization either 'number/2' or Math.Sqrt(number)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //LargestPrimeFactor
        //        Write a method named getLargestPrime with one parameter of type int named number.
        //        If the number is negative or does not have any prime numbers,
        //        the method should return -1 to indicate an invalid value.
        //        The method should calculate the largest prime factor of a given number and return it.
        //
        //        EXAMPLE INPUT/OUTPUT:
        //        * getLargestPrime (21); should return 7 since 7 is the largest prime (3 * 7 = 21)
        //        * getLargestPrime (217); should return 31 since 31 is the largest prime (7 * 31 = 217)
        //        * getLargestPrime (0); should return -1 since 0 does not have any prime numbers
        //        * getLargestPrime (45); should return 5 since 5 is the largest prime (3 * 3 * 5 = 45)
        //        * getLargestPrime (-1); should return -1 since the parameter is negative

        //        HINT: Since the numbers 0 and 1 are not considered prime numbers, they cannot contain prime numbers.
        private static int GetLargestPrimeFactor(int number)
        {
            Console.WriteLine("number at start = " + number);
            if (number < 0)
            {
                return -1;
            }
            int i;
            for (i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    number /= i;
                    i--;
                }
            }
            return i;
        }

        //Fibonachi line
        private static int[] GetFibonachiNumbersUpToArrayImpl(int number)
        {
            int[] fibArray = new int[number + 1];
            fibArray[0] = 0;
            fibArray[1] = 1;
            for (int i = 2; i < fibArray.Length; i++)
            {
                fibArray[i] = fibArray[i - 1] + fibArray[i - 2];
            }

            return fibArray;
        }

        private static int GetFibonachiLineIter(int nthFib)
        {
            int left = 0;
            int right = 1;
            int result = 0;
            for (int i = 2; i < nthFib + 1; i++)
            {
                result = left + right;
                left = right;
                right = result;
                Console.Write(result + " ");// to output the line, mehtod only returns the nth Fib number
            }
            return result;
        }

        static int GetFibonachiRecursive(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            int result = GetFibonachiRecursive(n - 1) + GetFibonachiRecursive(n - 2);
            return result;
        }

        //GreatestCommonDividor
        private static int GreatestCommonDivModulus(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        private static int GreatestCommonDivSubtraction(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

        static int GreatestCommonDivRecursive(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if (a > b)
            {
                a %= b;
                return GreatestCommonDivRecursive(a, b);
            }
            else
            {
                b %= a;
                return GreatestCommonDivRecursive(a, b);
            }
        }

        //Searching
        //Linear search
        private static int LinearSearch(int[] arrayToSearchIn, int numberToSearchFor)
        {
            for (int i = 0; i < arrayToSearchIn.Length; i++)
            {
                Console.WriteLine("Linear search iteration");

                if (arrayToSearchIn[i] == numberToSearchFor)
                {
                    return i;
                }
            }
            return -1;
        }

        //Binary search
        //*** remeber, works only on sorted array/collection
        private static int BinarySearch(int[] arrayToSearchIn, int numberToSearchFor)
        {
            int first = 0;
            int last = arrayToSearchIn.Length - 1;
            while (first <= last)
            {
                int mid = (first + last) / 2;
                if (arrayToSearchIn[mid] == numberToSearchFor)
                {
                    return mid;
                }

                if (arrayToSearchIn[mid] < numberToSearchFor)
                {
                    first = mid + 1;
                }
                else
                {
                    last = mid - 1;
                }
            }
            return -1;
        }



    }// end of class Program

}//end of namespace pu_ads_inf_autumn_22_common