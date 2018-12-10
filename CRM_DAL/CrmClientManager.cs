using Common;
using Common.Enum;
using Common.Exceptiones;
using Common.Interfaces;
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm_Dal
{
    public class CrmClientManager : IClientOperation, IBaseClientOperation
    {
        CellularModelDB _context = new CellularModelDB();


        public Client AddClient(Client newClient)
        {
            try
            {
                using (_context)
                {
                    Client tmp = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == newClient.ClientID);

                    if (tmp != null)
                    {
                        throw new EntityExistsException("Client with same client id exists!");
                    }
                    _context.ClientsTable.Add(newClient);
                    _context.SaveChanges();
                    SetUserNameAndPass(newClient);

                    Client eddedClient = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == newClient.ClientID);

                    return eddedClient;
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        public Client DeleteClient(int id)
        {
            try
            {
                using (var contex = new CellularModelDB())
                {
                    Client tmp = contex.ClientsTable.FirstOrDefault((c) => c.ClientID == id);
                    foreach (var line in tmp.Lines)
                    {
                        line.IsActive = false;
                    }
                    return tmp;
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        public Client UpdateClientDetails(Client editClient)
        {
            try
            {
                using (_context)
                {
                    Client tmp = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == editClient.ClientID);

                    if (tmp == null)
                    {
                        return tmp;
                    }
                    _context.Entry(tmp).CurrentValues.SetValues(editClient);
                    _context.SaveChanges();
                    tmp = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == editClient.ClientID);
                    return tmp;
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
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
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        public string ChangeClientType(int clientId, ClientTypeName newType)
        {
            try
            {
                using (_context)
                {
                    Client tmp = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == clientId);
                    if (tmp != null)
                    {
                        tmp.ClientType = newType;
                        _context.SaveChanges();
                        return "Client type has changed!";
                    }
                    return "Error, client id worng!";
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        public ICollection<Client> GetAllClients()
        {
            try
            {
                using (_context)
                {
                    List<Client> clients = _context.ClientsTable.ToList();
                    return clients;
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }



        private void Log(Exception e)
        {
            Logger.Log.WriteToLog("" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
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
    }
}
