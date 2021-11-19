using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataStructures
{
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
}
