using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapiScopeSample
{
    public class SomeException : Exception
    {
        public SomeException(string message) : base(message)
        {
        }
    }
}
