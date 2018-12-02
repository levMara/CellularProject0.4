using Common;
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
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
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
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                throw new Exception();
            }
        }

        public void UpdateClientDetails(int clientId, Client editClient)
        {
            try
            {

                using (_context)
                {
                    //packageToEdit.PackageId = EditedPackage.PackageId;
                    //context.Entry(EditedPackage).CurrentValues.SetValues(packageToEdit);
                    Client tmp = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == clientId);
                    editClient.ClientID = clientId;
                    _context.Entry(tmp).CurrentValues.SetValues(editClient);

                }

                // client.ClientID;

            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
      
    }
}
