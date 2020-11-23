using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class PrecioInvalidoException : Exception
    {
            public PrecioInvalidoException()
            : base("Precio invalido")
            {

            }

            public PrecioInvalidoException(Exception e)
                : base("Precio invalido", e)
            {

            }

            public PrecioInvalidoException(string message)
                : base(message)
            {

            }

            public PrecioInvalidoException(string message, Exception e)
                : base(message, e)
            {

            }
        
    }
}
