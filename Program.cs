using System;

namespace InPlaceMergeSort
{
    class Program
    {
        static void MergeSort<T>(T[] numberList, int start, int end, T[] tempArray) where T : IComparable
        {

            if (end - start <= 1) return;

            int start1 = start;
            int end1 = (start + end) / 2;
            int start2 = end1;
            int end2 = end;
            
            MergeSort(numberList, start1, end1, tempArray);
            MergeSort(numberList, start2, end2, tempArray);

            for (int i1 = start1, i2 = start2, count = 0; true; count++)
            {
                if (i1 >= end1)
                {
                    for (; i2 < end2; i2++, count++)
                    {
                        tempArray[count] = numberList[i2];
                    }

                    break;
                }

                if (i2 >= end2)
                {
                    for (; i1 < end1; i1++, count++)
                    {
                        tempArray[count] = numberList[i1];
                    }

                    break;
                }

                if (numberList[i1].CompareTo(numberList[i2]) < 0)
                {
                    tempArray[count] = numberList[i1];
                    i1++;
                }
                else
                {
                    tempArray[count] = numberList[i2];
                    i2++;
                }
            }

            for (int i = start, count = 0; i < end; i++, count++)
            {
                numberList[i] = tempArray[count];
            }
        }

        static void MergeSort<T> (T[] numberList) where T : IComparable
        {
            MergeSort(numberList, 0, numberList.Length, new T[numberList.Length]);
        }



        static void Main(string[] args)
        {
            int[] numberList = { 5, 82, 23, 52 };

            MergeSort(numberList);

            ;
        }
    }
}
