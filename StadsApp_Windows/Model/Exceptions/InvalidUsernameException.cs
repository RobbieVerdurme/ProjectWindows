using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model.Exceptions
{
    class InvalidUsernameException : Exception
    {

        public InvalidUsernameException() : base()
        {
        }

        public InvalidUsernameException(string message) : base(message)
        {
        }

    }
}
