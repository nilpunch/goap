using System;
using System.Collections.Generic;

namespace GOAP.GoapPathfind.AStar
{
    internal sealed class MinHeap<T> where T : IComparable<T>
    {
        private readonly List<T> _items;

        public MinHeap()
        {
            _items = new List<T>();
        }

        public int Count => _items.Count;

        public T Peek() => _items[0];

        public void Insert(T item)
        {
            _items.Add(item);
            SortItem(item);
        }

        public T Extract()
        {
            var node = _items[0];

            ReplaceFirstItemWithLastItem();
            Heapify(0);

            return node;
        }

        public void Remove(T item)
        {
            if (Count < 2)
            {
                Clear();
            }
            else
            {
                var index = _items.IndexOf(item);
                if (index >= 0)
                {
                    _items[index] = _items[_items.Count - 1];
                    _items.RemoveAt(_items.Count - 1);

                    Heapify(0);
                }
            }
        }

        public void Clear() => _items.Clear();

        private void ReplaceFirstItemWithLastItem()
        {
            _items[0] = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);
        }

        private void SortItem(T item)
        {
            var index = _items.Count - 1;

            while (HasParent(index))
            {
                var parentIndex = GetParentIndex(index);
                if (ItemAIsSmallerThanItemB(item, _items[parentIndex]))
                {
                    _items[index] = _items[parentIndex];
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }

            _items[index] = item;
        }

        private void Heapify(int startIndex)
        {
            var bestIndex = startIndex;

            if (HasLeftChild(startIndex))
            {
                var leftChildIndex = GetLeftChildIndex(startIndex);
                if (ItemAIsSmallerThanItemB(_items[leftChildIndex], _items[bestIndex]))
                {
                    bestIndex = leftChildIndex;
                }
            }

            if (HasRightChild(startIndex))
            {
                var rightChildIndex = GetRightChildIndex(startIndex);
                if (ItemAIsSmallerThanItemB(_items[rightChildIndex], _items[bestIndex]))
                {
                    bestIndex = rightChildIndex;
                }
            }

            if (bestIndex != startIndex)
            {
                var temp = _items[bestIndex];
                _items[bestIndex] = _items[startIndex];
                _items[startIndex] = temp;
                Heapify(bestIndex);
            }
        }

        private static bool ItemAIsSmallerThanItemB(T a, T b) => a.CompareTo(b) < 0;

        private static bool HasParent(int index) => index > 0;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _items.Count;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < _items.Count;

        private static int GetParentIndex(int i) => (i - 1) / 2;
        private static int GetLeftChildIndex(int i) => (2 * i) + 1;
        private static int GetRightChildIndex(int i) => (2 * i) + 2;
    }
}