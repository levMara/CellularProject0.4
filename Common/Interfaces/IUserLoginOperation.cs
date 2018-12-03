using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IUserLoginOperation
    {
        UserLogin Login(string userName, string password/*, out UserLoginMessage msg*/);
    }
}
