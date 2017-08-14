using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace SearchSort
{
    class Program
    {
        #region Sort Constants
        private const int _BubbleSort = 0;
        private const int _BiDiBubbleSort = 1;
        private const int _CombSort = 2;
        private const int _GnomeSort = 3;
        private const int _InsertSort = 4;
        private const int _QuickSort = 5;
        private const int _ShellSort = 6;
        private const int _SelectionSort = 7;
        private const int _MergeSort = 8;
        private const int _BucketSort = 9;
        private const int _HeapSort = 10;
        private const int _CountSort = 11;
        private const int _OddEvenSort = 12;
        private const int _RadixSort = 13;

        #endregion

        #region Search Constants
        private const int _SequencialSearch = 0;
        private const int _BinarySearch = 1;
        private const int _InterpolationSearch = 2;
        private const int _NthLargest = 3;
        private const int _MthSmallest = 4;
        #endregion

        static void Main()
        {
            Random rng = new Random(100);
            int[] data = new int[100];

            MixData(ref data, rng);

            DisplayData(data);
            //SearchData(data, _SequencialSearch);

            SortData(data, _QuickSort);
            SearchData(data, _BinarySearch);

            Console.ReadKey();

        }

        #region Miscellaneous Utilities

        public static int FindMax(int[] x)
        {
            int max = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] > max) max = x[i];
            }
            return max;
        }

        public static int FindMin(int[] x)
        {
            int min = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] < min) min = x[i];
            }
            return min;
        }

        public static void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        // Determines if int array is sorted from 0 -> Max
        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if string array is sorted from A -> Z
        public static bool IsSorted(string[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].CompareTo(arr[i]) > 0) // If previous is bigger, return false
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if int array is sorted from Max -> 0
        public static bool IsSortedDescending(int[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] < arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if string array is sorted from Z -> A
        public static bool IsSortedDescending(string[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i].CompareTo(arr[i + 1]) < 0) // If previous is smaller, return false
                {
                    return false;
                }
            }
            return true;
        }

        private static void SearchData(int[] data, int SearchType)
        {
            Console.WriteLine("Type an valid data entry to search: ");
            int i = Convert.ToInt32(Console.ReadLine());
            int search = 0;
            switch (SearchType)
            {
                case _BinarySearch:
                    Console.Write("Binary Search: ");
                    search = Search.Binary(data, i);
                    break;

                case _SequencialSearch:
                    Console.Write("Linear Search: ");
                    search = Search.Sequencial(data, i);
                    break;

                case _InterpolationSearch:
                    Console.Write("Interpolation Search: ");
                    search = Search.InterpolationSearch(data, i);
                    break;

                case _NthLargest:
                    Console.Write("Nth Largest Search: ");
                    search = Search.NthLargest1(data, i);
                    break;

                case _MthSmallest:
                    Console.Write("Mth Smallest Search: ");
                    search = Search.MthSmallest1(data, i);
                    break;

            }

            if (search < 0)
            {
                Console.WriteLine("Data entry not found.");
            }
            else Console.WriteLine("Data entry found at: " + search);

        }

        private static void SortData(int[] data, int SortType)
        {
            Console.Write("Sorted Data\nUsing: ");
            int[] sortedData = new int[data.Length];
            data.CopyTo(sortedData, 0);

            switch (SortType)
            {
                case _BubbleSort:
                    Console.WriteLine("Bubble Sort");
                    Sort.BubbleSort(ref sortedData);
                    break;

                case _BiDiBubbleSort:
                    Console.WriteLine("BiDi Bubble Sort");
                    Sort.BiDiBubbleSort(ref sortedData);
                    break;

                case _CombSort:
                    Console.WriteLine("Comb Sort");
                    Sort.CombSort(ref sortedData);
                    break;

                case _GnomeSort:
                    Console.WriteLine("Gnome Sort");
                    Sort.GnomeSort(ref sortedData);
                    break;
                case _HeapSort:
                    Console.WriteLine("Heap Sort");
                    Sort.Heapsort(ref sortedData);
                    break;

                case _InsertSort:
                    Console.WriteLine("Insert Sort");
                    Sort.InsertionSort(ref sortedData);
                    break;

                case _MergeSort:
                    Console.WriteLine("Merge Sort");
                    Sort.MergeSort(ref sortedData, 0, sortedData.Length);
                    break;

                case _OddEvenSort:
                    Console.WriteLine("Odd Even Sort");
                    Sort.OddEvenSort(ref sortedData);
                    break;

                case _QuickSort:
                    Console.WriteLine("Quick Sort");
                    Sort.QuickSort(ref sortedData);
                    break;

                case _RadixSort:
                    Console.WriteLine("Radix Sort");
                    Sort.RadixSort(ref sortedData, 32);
                    break;

                case _ShellSort:
                    Console.WriteLine("Shell Sort");
                    Sort.ShellSort(ref sortedData);
                    break;

                case _CountSort:
                    Console.WriteLine("Count Sort");
                    Sort.Count_Sort(ref sortedData);
                    break;

                case _SelectionSort:
                    Console.WriteLine("Selection Sort");
                    Sort.SelectionSort(ref sortedData);
                    break;

                case _BucketSort:
                    Console.WriteLine("Bucket Sort");
                    Sort.BucketSort(ref sortedData);
                    break;
            }

            for (int i = 0; i < data.Length -1; i++)
            {
                if (i != 0 && i % 10 == 0)
                    Console.Write("\n");
                Console.Write(sortedData[i] + " ");
            }

            Console.Write("\n");
        }

        static void MixData(ref int[] data, Random rng)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                data[i] = (int)(rng.NextDouble() * data.Length);
            }

        }

        static void DisplayData(int[] data)
        {
            Console.WriteLine("Dataset: ");
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (i != 0 && i % 10 == 0) Console.Write("\n");
                Console.Write(data[i] + " ");
            }
            Console.Write("\n");
        }
        #endregion
    }
}
