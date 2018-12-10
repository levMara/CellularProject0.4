using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptiones
{
    [Serializable]
    public class EntityNotExistsException : Exception
    {
        public EntityNotExistsException()
        {

        }

        public EntityNotExistsException(string msg)
                : base(msg)
        {

        }
    }
}
