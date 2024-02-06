using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSystem.Exception
{
    internal class PatientNumberNotFoundException : IOException
    {
        public PatientNumberNotFoundException()
        {

        }
        public PatientNumberNotFoundException(string message) : base(message)
        {

        }
    }
}
