using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    class IntArray
    {
        private List<int> array;

        public IntArray()
        {
            array = new List<int>();
        }

        public void FillArray()
        {
            array.Add(32);
            array.Add(15);
            array.Add(4);
            array.Add(66);
            array.Add(9);
            array.Add(83);
            array.Add(1);
            array.Add(47);
            array.Add(35);
            array.Add(73);
            array.Add(10);
            array.Add(91);
        }

        public void Print()
        {
            for (int i = 0; i < array.Count; i++)
            {
                Console.Write(array[i]+"\t");
            }
        }
        public void Add(int num)
        {
            array.Add(num);
        }

        public void Sort()
        {
            array.Sort();
        }

        public int BinarySearch(int num)
        {
            int result = -1, startIndex=0, endIndex=array.Count-1;
            while (result==-1)
            {
                int mid = (startIndex + endIndex) / 2;
                if (num == array[mid])
                    result = mid;
                else if (num < array[mid])
                    endIndex = mid - 1;
                else
                    startIndex = mid + 1;
            }

            return result;
        }
    }
}
