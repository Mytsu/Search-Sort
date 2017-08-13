namespace SearchSort
{
    public class Search
    {

        #region Linear Search
        public static int Sequencial(int[] data, int key)
        {
            for (int i = data.Length -1; i >= 0; i--)
            {
                if (data[i] == key)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region Binary Search
        public static int Binary(int[] data, int key)
        {
            int min = 1;
            int max = data.Length -1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == data[mid])
                {
                    return ++mid;
                }
                if (key < data[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        #endregion

        #region Interpolation Search

        public static int InterpolationSearch(ref int[] x, int searchValue)
        {
            // Returns index of searchValue in sorted input data
            // array x, or -1 if searchValue is not found
            int low = 0;
            int high = x.Length - 1;
            int mid;

            while (x[low] < searchValue && x[high] >= searchValue)
            {
                mid = low + ((searchValue - x[low]) * (high - low)) / (x[high] - x[low]);

                if (x[mid] < searchValue)
                    low = mid + 1;
                else if (x[mid] > searchValue)
                    high = mid - 1;
                else
                    return mid;
            }

            if (x[low] == searchValue)
                return low;
            else
                return -1; // Not found
        }
        #endregion

        #region Nth Largest

        public static int NthLargest1(int[] array, int n)
        {
            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            //Sort the array
            Sort.QuickSort(ref tempArray);
            //Return the n-th largest value in the sorted array
            return tempArray[tempArray.Length - n];
        }

        public static int NthLargest2(int[] array, int k)
        {
            int maxIndex;
            int maxValue;

            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);

            for (int i = 0; i < k; i++)
            {
                maxIndex = i;       // index of minimum element
                maxValue = tempArray[i];// assume minimum is the first array element
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    // if we've located a higher value
                    if (tempArray[j] > maxValue)
                    {   // capture it
                        maxIndex = j;
                        maxValue = tempArray[j];
                    }
                }
                Program.Swap(ref tempArray[i], ref tempArray[maxIndex]);
            }
            return tempArray[k - 1];
        }
        #endregion

        #region Mth Smallest

        public static int MthSmallest1(int[] array, int m)
        {
            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            //Sort the array
            Sort.QuickSort(ref tempArray);
            //Return the m-th smallest value in the sorted array
            return tempArray[m - 1];
        }

        public static int MthSmallest2(int[] array, int m)
        {
            int minIndex;
            int minValue;

            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);

            for (int i = 0; i < m; i++)
            {
                minIndex = i;      // index of minimum element
                minValue = tempArray[i];// assume minimum is the first array element
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (tempArray[j] < minValue)
                    {   // capture it
                        minIndex = j;
                        minValue = tempArray[j];
                    }
                }
                Program.Swap(ref tempArray[i], ref tempArray[minIndex]);
            }
            return tempArray[m - 1];
        }
        #endregion
    }
}