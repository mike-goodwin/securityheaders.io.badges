using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityHeaders.io.badges
{
    class BlackListException : Exception
    {
        public BlackListException() : base("Warning! Infinite recursion detected. Spacetime collapse imminent.")
        {
        }
    }
}
