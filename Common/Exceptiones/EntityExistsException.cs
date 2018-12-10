using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptiones
{
    [Serializable]
    public class EntityExistsException : Exception
    {
       
        public EntityExistsException()
        {

        }

        public EntityExistsException(string msg)
                : base(msg)
        {

        }
    }
}
