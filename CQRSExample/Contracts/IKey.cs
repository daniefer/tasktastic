using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IKey<T> where T: struct
    {
        T Key { get; set; }
    }
}
