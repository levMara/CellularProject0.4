using Common;
using Common.Interfaces;
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.UserRepository
{
    public class UserRepository : IUserLoginOperation
    {
        public UserLogin Login(string userName, string password)
        {
            try
            {
                using (var context = new CellularModelDB())
                {
                    UserLogin tmp = context.UserLoginsTable.SingleOrDefault((u) => u.UserName == userName && u.Password == password);
                    return tmp;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}