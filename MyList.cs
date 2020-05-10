namespace Workshop
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    public class MyList<T> : IEnumerable<T>
    {

        private int capacity;
        private T[] data;
        public MyList()
            : this(4)
        {

        }

        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
        }
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.data[index] = value;
            }
        }
        public void Add(T element)
        {
            this.CheckIfResizeIsNeeded();
            this.data[this.Count] = element;
            this.Count++;
        }
        public void InsertAt(int index, T element)
        {
            this.ValidateIndex(index);
            this.CheckIfResizeIsNeeded();
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.data[i + 1] = this.data[i];
            }
            this.data[index] = element;
            this.Count++;
        }
        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);
            var result = this.data[index];
            for (int i = index + 1; i < Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }
            this.Count--;
            return result;

        }
        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            var firstValue = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = firstValue;
        }
        public int RemoveAll(Func<T, bool> filter)
        {
            var removed = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (filter(this.data[i]))
                {
                    this.RemoveAt(i);
                    removed++;
                }
            }
            return removed;
        }
        public void Clear()
        {
            this.Count = 0;
            this.data = new T[capacity];
        }
        private void Resize()
        {
            var newCapacity = this.data.Length * 2;

            var newData = new T[newCapacity];
            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }
            this.data = newData;
        }
        private void ValidateIndex(int index)
        {

            if (index >= 0 && index < this.Count)
            {
                return;
            }
            var msg = this.Count == 0
                ? "The List is empty"
                : $"The list has {this.Count} elements and it is zero-based";

            throw new Exception($"Index of range. {msg}.");
        }
        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)data
                .Take(this.Count))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)data).GetEnumerator();
        }
    }
}
