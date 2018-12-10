using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptiones
{
    [Serializable]
    public class InternalServerException : Exception
    {
        
        public InternalServerException()
        {

        }

        public InternalServerException(string msg)
                : base(msg)
        {

        }
    }
}
