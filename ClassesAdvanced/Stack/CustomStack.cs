using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;
        private T?[] _buffer;
        private int _count;
        public int Count => this._count;

        public CustomStack() : this(DefaultCapacity)
        {
        }
        public CustomStack(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException("Capacity cannot be zero or negative.");
            this._buffer = new T?[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this._buffer[index]!;
            }

        }

        public void Push(T value)
        {
            this.GrowIfNecessary();
            this._buffer[this._count++]= value;
        }
        public T Pop()
        {
            this.EnsureNotEmpty();
            T lastElement = this._buffer[this._count-1]!;
            this._buffer[this._count - 1] = default;
            this._count--;
            return lastElement;
        }
        public T Peek()
        {
            this.EnsureNotEmpty();
            return this._buffer[this._count - 1]!;

        }
        public void ForEach (Action<T> action)
        {
            foreach (T element in this)
                action(element);
        }
        private void ValidateIndex(int index)
        {
            if (index < 0||index>=this._count)
                throw new IndexOutOfRangeException("Index is out of range");
        }
        private void EnsureNotEmpty()
        {
            if (this._count == 0) throw new InvalidOperationException("Stack is empty");
        }
        private void GrowIfNecessary()
        {
            if (this._count == this._buffer.Length)
                this.Grow();
        }
        private void Grow()
        {
            T[] newBuffer = new T[2*this._buffer.Length];
            Array.Copy(this._buffer, newBuffer, this._buffer.Length);
            this._buffer = newBuffer;
        }
    

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this._count - 1; i >= 0; i--)
                yield return this._buffer[i]!;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
