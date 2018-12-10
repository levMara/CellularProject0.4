using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptiones
{
    [Serializable]
    public class DbFaildConnncetException : Exception
    {
        public DbFaildConnncetException()
        {

        }

        public DbFaildConnncetException(string msg)
                : base(msg)
        {

        }

    }
}
