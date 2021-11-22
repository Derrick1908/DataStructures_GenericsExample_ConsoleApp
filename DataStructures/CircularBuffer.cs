using System;
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
                var discard = _queue.Dequeue();
                OnItemDiscarded(discard, Value);
            }
        }

        private void OnItemDiscarded(T discard, T value)
        {
            if (ItemDiscarded != null)      //This means that the Delegate has been assigned to a Function
            {
                var args = new ItemDiscardedEventArgs<T>(discard, value);       //Constructs the Arguments to be given to the Function
                ItemDiscarded(this, args);              //Calls the Other Function through the delegate
            }
        }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;   //Here we are declaring a delegate Variable using an Inbuilt Delegate Type Event Handler
        public bool IsFull => _queue.Count == _capacity;        
    }

    public class ItemDiscardedEventArgs<T> : EventArgs      //Class that extends Event Args and has been defined so that we can include two properties of Discard and New Value not available with the current Event Args
    {
        public ItemDiscardedEventArgs(T discard, T newitem)
        {
            ItemDiscarded = discard;
            NewItem = newitem;
        }

        public T ItemDiscarded { get; set; }
        public T NewItem { get; set; }
    }
}
