using Common;
using Common.Enum;
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
        public UserLogin Login(string userName, string password/*, out UserLoginMessage msg*/)
        {           
            try
            {
                using (var context = new CellularModelDB())
                {
                    UserLogin tmp;
                    tmp = context.UserLoginsTable.SingleOrDefault((u) => u.UserName == userName && u.Password == password);
                    if (tmp != null)
                    {
                        //msg = UserLoginMessage.userExist;
                        return tmp;
                    }
                    else
                    {
                        tmp = context.UserLoginsTable.SingleOrDefault((u) => u.UserName == userName);
                        //if (tmp != null)
                        //   // msg = UserLoginMessage.worngPassword;
                        //else
                           // msg = UserLoginMessage.userNotExist;

                        return null;                  
                    }                 
                }
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                throw new Exception();
            }
        }
    }
}