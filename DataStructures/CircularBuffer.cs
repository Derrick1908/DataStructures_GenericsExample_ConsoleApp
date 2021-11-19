using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T Value)
        {
            base.Write(Value);
            if(_queue.Count > _capacity)
            { 
                _queue.Dequeue();
            }
        }

        public bool IsFull => _queue.Count == _capacity;
        /* In Place of 
         * public bool IsFull { get { return _queue.Count == _capacity; } } 
         */
    }
}
