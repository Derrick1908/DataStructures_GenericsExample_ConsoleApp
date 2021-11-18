using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public interface IBuffer<T> :IEnumerable<T>
    {
        bool IsEmpty { get; }
        void Write(T Value);
        T Read();
    }

    public class Buffer<T> : IBuffer<T>
    {
        protected Queue<T> _queue = new Queue<T>();

        public virtual bool IsEmpty => _queue.Count == 0;

        /* The Above is a shorthand notation for the Below Function (called Expression bodied functions)
        public virtual bool IsEmpty
        {
            get { return _queue.Count == 0; }
        }*/

        public virtual void Write(T Value)
        {
            _queue.Enqueue(Value);
        }
        public virtual T Read()
        {
            return _queue.Dequeue();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return _queue.GetEnumerator();
            foreach (var item in _queue)
            {
                //...
                yield return item;
            }
        }
          
        IEnumerator IEnumerable.GetEnumerator()          //Through this we are explicitly stating that we are Implementing the GetEnumerator Method of the IEnumerable Interface and not of IEnumerable<T>.
        {                                                //This is needed as we have two Methods with the same name and same number of Arguments(0); so resulting in an error.
            return GetEnumerator();                      //This calls the above Method through the 'this' reference implicitly i.e. this.GetEnumerator and since the 'this' does not reference IEnumerable it will call the above method.
        }
        
    }

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
