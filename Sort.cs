using System;
using System.Collections.Generic;

namespace SearchSort
{
    public class Sort
    {
        #region Bubble Sort
        public static void BubbleSort(ref int[] x)
        {
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < x.Length - 1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        // Exchange elements
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        exchanges = true;
                    }
                }
            } while (exchanges);
        }
        #endregion

        #region Bidirectional Bubble Sort
        public static void BiDiBubbleSort(ref int[] x)
        {
            for (int k = x.Length - 1; k > 0; k--)
            {
                bool swapped = false;
                for (int i = k; i > 0; i--)
                    if (x[i] < x[i - 1])
                    {
                        // swap
                        int temp = x[i];
                        x[i] = x[i - 1];
                        x[i - 1] = temp;
                        swapped = true;
                    }

                for (int i = 0; i < k; i++)
                    if (x[i] > x[i + 1])
                    {
                        // swap
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        swapped = true;
                    }

                if (!swapped)
                    break;
            }
        }
        #endregion

        #region Odd Even Sort
        public static void OddEvenSort(ref int[] x)
        {
            int temp;
            for (int i = 0; i < x.Length / 2; ++i)
            {
                for (int j = 0; j < x.Length - 1; j += 2)
                {
                    if (x[j] > x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }

                for (int j = 1; j < x.Length - 1; j += 2)
                {
                    if (x[j] > x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }
            }
        }
        #endregion

        #region Comb Sort
        public static int NewGap(int gap)
        {
            gap = gap * 10 / 13;
            if (gap == 9 || gap == 10)
                gap = 11;
            if (gap < 1)
                return 1;
            return gap;
        }

        public static void CombSort(ref int[] x)
        {
            int gap = x.Length;
            bool swapped;
            do
            {
                swapped = false;
                gap = NewGap(gap);
                for (int i = 0; i < (x.Length - gap); i++)
                {
                    if (x[i] > x[i + gap])
                    {
                        swapped = true;
                        int temp = x[i];
                        x[i] = x[i + gap];
                        x[i + gap] = temp;
                    }
                }
            } while (gap > 1 || swapped);
        }
        #endregion

        #region Gnome Sort
        public static void GnomeSort(ref int[] x)
        {
            int i = 0;
            while (i < x.Length)
            {
                if (i == 0 || x[i - 1] <= x[i]) i++;
                else
                {
                    int temp = x[i];
                    x[i] = x[i - 1];
                    x[--i] = temp;
                }
            }
        }
        #endregion

        #region Insertion Sort
        public static void InsertionSort(ref int[] x)
        {
            int n = x.Length - 1;
            int i, j, temp;

            for (i = 1; i <= n; ++i)
            {
                temp = x[i];
                for (j = i - 1; j >= 0; --j)
                {
                    if (temp < x[j]) x[j + 1] = x[j];
                    else break;
                }
                x[j + 1] = temp;
            }
        }
        #endregion

        #region Quick Sort

        public static void QuickSort(ref int[] x)
        {
            Qs(x, 0, x.Length - 1);
        }

        public static void Qs(int[] x, int left, int right)
        {
            int i, j;
            int pivot, temp;

            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i] < pivot) && (i < right)) i++;
                while ((pivot < x[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) Qs(x, left, j);
            if (i < right) Qs(x, i, right);
        }

        #endregion

        #region Shell Sort

        public static void ShellSort(ref int[] x)
        {
            int i, j, temp;
            int increment = 3;

            while (increment > 0)
            {
                for (i = 0; i < x.Length; i++)
                {
                    j = i;
                    temp = x[i];

                    while ((j >= increment) && (x[j - increment] > temp))
                    {
                        x[j] = x[j - increment];
                        j = j - increment;
                    }

                    x[j] = temp;
                }

                if (increment / 2 != 0)
                {
                    increment = increment / 2;
                }
                else if (increment == 1)
                {
                    increment = 0;
                }
                else
                {
                    increment = 1;
                }
            }
        }
        #endregion

        #region Selection Sort

        public static void SelectionSort(ref int[] x)
        {
            int i, j;
            int min, temp;

            for (i = 0; i < x.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < x.Length; j++)
                {
                    if (x[j] < x[min])
                    {
                        min = j;
                    }
                }
                temp = x[i];
                x[i] = x[min];
                x[min] = temp;
            }
        }
        #endregion

        #region Merge Sort

        public static void MergeSort(ref int[] x, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(ref x, left, middle);
                MergeSort(ref x, middle + 1, right);
                Merge(ref x, left, middle, middle + 1, right);
            }
        }

        public static void Merge(ref int[] x, int left, int middle, int middle1, int right)
        {
            int oldPosition = left;
            int size = right - left + 1;
            int[] temp = new int[size];
            int i = 0;

            while (left <= middle && middle1 <= right)
            {
                if (x[left] <= x[middle1])
                    temp[i++] = x[left++];
                else
                    temp[i++] = x[middle1++];
            }
            if (left > middle)
                for (int j = middle1; j <= right; j++)
                    temp[i++] = x[middle1++];
            else
                for (int j = left; j <= middle; j++)
                    temp[i++] = x[left++];
            Array.Copy(temp, 0, x, oldPosition, size);
        }
        #endregion

        #region Bucket Sort

        public static void BucketSort(ref int[] x)
        {
            //Verify input
            if (x == null || x.Length <= 1)
                return;

            //Find the maximum and minimum values in the array
            int maxValue = x[0];
            int minValue = x[0];

            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] > maxValue)
                    maxValue = x[i];

                if (x[i] < minValue)
                    minValue = x[i];
            }

            //Create a temporary "bucket" to store the values in order
            //each value will be stored in its corresponding index
            //scooting everything over to the left as much as possible (minValue)
            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            //Move items to bucket
            for (int i = 0; i < x.Length; i++)
            {
                if (bucket[x[i] - minValue] == null)
                    bucket[x[i] - minValue] = new LinkedList<int>();

                bucket[x[i] - minValue].AddLast(x[i]);
            }

            //Move items in the bucket back to the original array in order
            int k = 0; //index for original array
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First; //start add head of linked list

                    while (node != null)
                    {
                        x[k] = node.Value; //get value of current linked node
                        node = node.Next; //move to next linked node
                        k++;
                    }
                }
            }
        }
        #endregion

        #region Heap Sort

        public static void Heapsort(ref int[] x)
        {
            int i;
            int temp;
            int n = x.Length;

            for (i = (n / 2) - 1; i >= 0; i--)
            {
                SiftDown(ref x, i, n);
            }

            for (i = n - 1; i >= 1; i--)
            {
                temp = x[0];
                x[0] = x[i];
                x[i] = temp;
                SiftDown(ref x, 0, i - 1);
            }
        }

        public static void SiftDown(ref int[] x, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            int temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (x[root * 2] > x[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (x[root] < x[maxChild])
                {
                    temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
        #endregion

        #region Count Sort

        public static void Count_Sort(ref int[] x)
        {
            try
            {
                int i;
                int k = Program.FindMax(x); //Finds max value of input array

                // output array holds the sorted output
                int[] output = new int[x.Length];

                // provides temperarory storage 
                int[] temp = new int[k + 1];
                for (i = 0; i < k + 1; i++)
                {
                    temp[i] = 0;
                }

                for (i = 0; i < x.Length; i++)
                {
                    temp[x[i]] = temp[x[i]] + 1;
                }

                for (i = 1; i < k + 1; i++)
                {
                    temp[i] = temp[i] + temp[i - 1];
                }

                for (i = x.Length - 1; i >= 0; i--)
                {
                    output[temp[x[i]] - 1] = x[i];
                    temp[x[i]] = temp[x[i]] - 1;
                }

                for (i = 0; i < x.Length; i++)
                {
                    x[i] = output[i];
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        #endregion

        #region Radix Sort

        //RadixSort takes an array and the number of bits used as 
        //the key in each iteration.
        public static void RadixSort(ref int[] x, int bits)
        {
            //Use an array of the same size as the original array 
            //to store the result of each iteration.
            int[] b = new int[x.Length];
            // ReSharper disable once UnusedVariable
            int[] bOrig = b;

            //Mask is the bitmask used to extract the sort key. 
            //We start with the bits least significant bits and
            //left-shift it the same amount at each iteration. 
            //When all the bits are shifted out of the word, we are done.
            int rshift = 0;
            for (int mask = ~(-1 << bits); mask != 0; mask <<= bits, rshift += bits)
            {
                //An array is needed to store the count for each key value.
                int[] cntarray = new int[1 << bits];

                //Count each key value
                for (int p = 0; p < x.Length; ++p)
                {
                    int key = (x[p] & mask) >> rshift;
                    ++cntarray[key];
                }

                //Sum up how many elements there are with lower 
                //key values, for each key.
                for (int i = 1; i < cntarray.Length; ++i)
                    cntarray[i] += cntarray[i - 1];

                //The values in cntarray are used as indexes 
                //for storing the values in b. b will then be
                //completely sorted on this iteration's key. 
                //Elements with the same key value are stored 
                //in their original internal order.
                for (int p = x.Length - 1; p >= 0; --p)
                {
                    int key = (x[p] & mask) >> rshift;
                    --cntarray[key];
                    b[cntarray[key]] = x[p];
                }

                //Swap the a and b references, so that the 
                //next iteration works on the current b, 
                //which is now partially sorted.
                int[] temp = b; b = x; x = temp;
            }
        }

        #endregion
        
    }
}