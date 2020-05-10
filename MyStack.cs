namespace Workshop
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyStack<T> : IEnumerable<T>
    {
        private int capacity;
        private T[] data;
        public MyStack()
            : this(4)
        {
        }
        public MyStack(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];

        }
        public int Count { get; private set; }
        public void Push(T item)
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
            this.data[this.Count] = item;
            this.Count++;
        }
        public T Pop()
        {
            this.ValidateEmptyStack();
            var result = this.data[this.Count - 1];
            this.Count--;
            return result; 
        }
        public T Peek()
        {
            this.ValidateEmptyStack();
           return this.data[this.Count - 1];

        }
        public void Clear()
        {
            this.data = new T[this.capacity];
            this.Count = 0;
        }
        public void ForEach(Action<T> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.data[i]);
            }
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
        private void ValidateEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is empty.");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)data
                .Take(this.Count))
                .Reverse()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)data).GetEnumerator();
        }
    }
}
