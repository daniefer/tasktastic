using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EventStoreEventArgs<T> : EventArgs where T: struct
    {
        private T _data;
        public EventStoreEventArgs(T data)
        {
            this._data = data;
        }

        public T Data
        {
            get { return this._data; }
        }
    }
}
