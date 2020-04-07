using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_and_Bubble_Sorting
{
    class SortingHandler
    {
        private string convertArrayInTxt(int[] Array)
        {
            string txt = "";
            for (int i = 0; i < Array.Length; i++)
            {
                txt += Array[i] + " ";
            }

            return txt;
        }

        public string InsertionSort(int[] Array, int ArraySize)
        {
            for (int i = 1; i < ArraySize; i++)
            {
                int j = i;
                while (j > 0 && Array[j - 1] > Array[j])
                {
                    int temp = Array[j - 1];
                    Array[j - 1] = Array[j];
                    Array[j] = temp;
                    j--;
                }
            }

            return convertArrayInTxt(Array);
        }

        public string BubbleSort(int[] unsortedArray)
        {
            int[] array = unsortedArray;
            int start, end, auxiliaryVar;

            for (end = array.Length - 1; end > 1; end--)
            {
                for (start = 0; start < end; start++)
                {
                    if (array[start] > array[start + 1])
                    {
                        auxiliaryVar = array[start];
                        array[start] = array[start + 1];
                        array[start + 1] = auxiliaryVar;
                    }
                }
            }
            return convertArrayInTxt(array);
        }

        public string ShellSort(int[] array)
        {
            int auxiliaryVar;

            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        auxiliaryVar = array[j];
                        array[j] = array[j - d];
                        array[j - d] = auxiliaryVar;
                        j = j - d;
                    }
                }

                d = d / 2;
            }
            return convertArrayInTxt(array);
        }

        public string QuickSorting(int[] array, int first, int last)
        {
            int p = array[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (array[i] < p && i <= last) ++i;
                while (array[j] > p && j >= first) --j;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) QuickSorting(array, first, j);
            if (i < last) QuickSorting(array, i, last);

            if (first == 0 && last == array.Length - 1)
            {
                return convertArrayInTxt(array);
            }
            else
            {
                return "";
            }
        }

        public string MergeSort(int[] array)
        {
            return convertArrayInTxt(MergeSort(array, 0, array.Length - 1));
        }

        private int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        private void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
    }
}
