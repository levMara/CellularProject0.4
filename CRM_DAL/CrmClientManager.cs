using Common;
using Common.Enum;
using Common.Interfaces;
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm_Dal
{
    public class CrmClientManager : IClientOperation
    {
        CellularModelDB _context = new CellularModelDB();

        public void AddClient(Client newClient)
        {
            try
            {
                if (newClient != null)
                {
                    using (var context = new CellularModelDB())
                    {
                        context.ClientsTable.Add(newClient);
                        context.SaveChanges();
                        SetUserNameAndPass(newClient);                        
                    }
                }
            }
            catch (Exception e)
            {
                Log(e);            
                throw new Exception();
            }
        }      

        private void SetUserNameAndPass(Client newClient)
        {
            try
            {
                using (_context)
                {
                    if (newClient != null)
                    {
                        UserLogin user = new UserLogin
                        {
                            UserName = newClient.FirstName,
                            Password = newClient.LastName,
                            UserType = UserType.client
                        };
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new Exception();
            }
        }

        public Client GetClient(int clientId)
        {
            try
            {
                using (_context)
                {
                    Client tmp = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == clientId);
                    return tmp;
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new Exception();
            }
        }

        public void UpdateClientDetails(int clientId, Client editClient)
        {
            try
            {
                using (_context)
                {
                    if (editClient != null)
                    {
                        Client tmp = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == clientId);
                        editClient.ClientID = clientId;
                        _context.Entry(tmp).CurrentValues.SetValues(editClient); 
                    }

                }

                // client.ClientID;

            }
            catch (Exception e)
            {
                Log(e);
                throw new Exception();
            }
        }

        public void DeleteClient(int id)
        {
            try
            {
                Client tmp = new Client();
                using (var contex = new CellularModelDB())
                {
                    tmp = contex.ClientsTable.FirstOrDefault((c) => c.ClientID == id);
                    foreach (var line in tmp.Lines)
                    {
                        line.IsActive = false;
                    }
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new Exception();
            }
        }

        private void Log(Exception e)
        {
            Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());

        }
    }
}
