using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteLibrary.Exceptions
{
    internal class RecordDeletedException : Exception
    {
        public RecordDeletedException() : base("Record no longer exists.")
        {
            
        }
    }
}
