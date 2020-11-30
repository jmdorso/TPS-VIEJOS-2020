using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class LeerBDException : Exception
    {
        public LeerBDException()
            : base("BD invalida")
        {

        }

        public LeerBDException(Exception e)
            : base("BD invalida", e)
        {

        }

        public LeerBDException(string message)
            : base(message)
        {

        }

        public LeerBDException(string message, Exception e)
            : base(message, e)
        {

        }
    }
}
