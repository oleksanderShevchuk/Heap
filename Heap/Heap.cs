using System;
using System.Collections;
using System.Collections.Generic;

namespace Heap
{
    internal class Heap : IEnumerable
    {
        private List<int> items = new List<int>();
        public int Count => items.Count;
        public Heap() { }
        public Heap(List<int> items)
        {
            this.items.AddRange(items);
            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }
        public int? Peek()
        {
            if (Count > 0)
            {
                return items[0];
            }
            else
            {
                return null;
            }
        }
        public void Add(int item)
        {
            items.Add(item);
            var currentIndex = Count - 1;
            var parentIndex = GetPerentIndex(currentIndex);

            while (currentIndex > 0 && items[parentIndex] < items[currentIndex])
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetPerentIndex(currentIndex);
            }
        }
        public int GetMax()
        {
            var result = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }

        private void Sort(int currentIndex)
        {
            int maxIndex, leftIndex, rightIndex;
            maxIndex = currentIndex;

            while (currentIndex < Count)
            {
                leftIndex = currentIndex*2 + 1;
                rightIndex = currentIndex*2 + 2;

                if (leftIndex < Count && items[leftIndex] > items[maxIndex])
                {
                    maxIndex = leftIndex;
                }
                if (rightIndex < Count && items[rightIndex] > items[maxIndex])
                {
                    maxIndex = rightIndex;
                }
                if (maxIndex == currentIndex)
                {
                    break;
                }
                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            var temp = items[currentIndex];
            items[currentIndex] = items[parentIndex];
            items[parentIndex] = temp;
        }

        private static int GetPerentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
            {
                yield return GetMax();
            }
        }
    }
}
