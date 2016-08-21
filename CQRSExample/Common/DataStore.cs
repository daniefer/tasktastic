using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DataStore<T> where T: struct, IEquatable<T>
    {
        private readonly List<T> _data;

        public DataStore()
        {
            _data = new List<T>();
        }

        public void Update(Transform<T> transform)
        {
            if (transform.InitialValue.HasValue) // Update or delete
            {
                T? oldItem = _data
                .Where(item => transform.InitialValue.Equals(item))
                .Cast<T?>()
                .FirstOrDefault();

                if (oldItem.HasValue)
                {
                    var index = _data.IndexOf(oldItem.Value);
                    if (transform.FinalValue.HasValue) // This was an update
                        _data[index] = transform.FinalValue.Value;
                    else // This was a delete
                        _data.Remove(oldItem.Value);
                }
                else { /* nothing */ } // The item was already deleted or has been updated already.
            }
            else if (transform.FinalValue.HasValue)
            {
                
            }
            else { /* Cannot happen. Transform object does not allow this state. */ }
            
        }
    }
}
