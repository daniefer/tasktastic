using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Common
{
    public class EventStore<T, TKey> where T: struct, IKey<TKey>
                                     where TKey: struct
    {
        public event EventHandler<EventStoreEventArgs<Transform<T>>> Added;
        public event EventHandler<EventStoreEventArgs<Transform<T>>> Updated;
        public event EventHandler<EventStoreEventArgs<Transform<T>>> Deleted;

        private readonly LinkedList<Transform<T>> _events;

        public EventStore()
        {
            this._events = new LinkedList<Transform<T>>();
        }

        public virtual void Add(Transform<T> transform)
        {
            this._events.AddLast(transform);
            if (!transform.InitialValue.HasValue)
                this.OnAdded(transform);
            else if (!transform.FinalValue.HasValue)
                this.OnDelete(transform);
            else
                this.OnUpdate(transform);
        }

        public virtual T? Get(TKey key)
        {
            T? returnValue = null;
            TKey currentKey = key;
            LinkedListNode<Transform<T>> transform = _events.First;
            while (transform != null)
            {
                if (transform.Value.InitialValue != null && transform.Value.InitialValue.Value.Key.Equals(currentKey))
                {
                    // This is for when we find an update
                    returnValue = transform.Value.FinalValue;
                    if (!returnValue.HasValue) break;
                    currentKey = returnValue.Value.Key;
                }
                else if (transform.Value.FinalValue != null && transform.Value.FinalValue.Value.Key.Equals(currentKey))
                {
                    // This is when we find the first insert.
                    returnValue = transform.Value.FinalValue;
                    currentKey = returnValue.Value.Key;
                }
                transform = transform.Next;
            }
            return returnValue;
        }

        private void OnAdded(Transform<T> transform)
        {
            EventHandler<EventStoreEventArgs<Transform<T>>> onAdded = this.Added;
            onAdded?.Invoke(this, new EventStoreEventArgs<Transform<T>>(transform));
        }

        private void OnDelete(Transform<T> transform)
        {
            EventHandler<EventStoreEventArgs<Transform<T>>> onDeleted = this.Deleted;
            onDeleted?.Invoke(this, new EventStoreEventArgs<Transform<T>>(transform));
        }

        private void OnUpdate(Transform<T> transform)
        {
            EventHandler<EventStoreEventArgs<Transform<T>>> onUpdated = this.Updated;
            onUpdated?.Invoke(this, new EventStoreEventArgs<Transform<T>>(transform));
        }
    }
}
