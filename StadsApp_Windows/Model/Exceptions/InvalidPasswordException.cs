using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model.Exceptions
{
    class InvalidPasswordException : Exception
    {

        public InvalidPasswordException() : base()
        {
        }

        public InvalidPasswordException(string message) : base(message)
        {
        }

    }
}
