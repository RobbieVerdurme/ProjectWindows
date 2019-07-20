using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model.Exceptions
{
    class InvalidCredentialsException: Exception
    {

        public InvalidCredentialsException() : base()
        {
        }

        public InvalidCredentialsException(string message): base(message)
        {  
        }

    }
}
