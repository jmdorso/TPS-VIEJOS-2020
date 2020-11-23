using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class TalleInvalidoException : Exception
    {
        public TalleInvalidoException()
            : base("Talle invalido")
        {

        }

        public TalleInvalidoException(Exception e)
            : base("Talle invalido",e)
        {

        }

        public TalleInvalidoException(string message)
            : base(message)
        {

        }

        public TalleInvalidoException(string message, Exception e)
            : base(message,e)
        {

        }
    }
}
