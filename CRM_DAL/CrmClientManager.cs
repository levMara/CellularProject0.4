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
    public class CrmClientManager
    {
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
            catch (Exception)
            {
                throw;
            }

        }   

        internal void DeleteClient(int id)
        {
            try
            {
                Client tmp = new Client();
                using (var contex = new CellularModelDB())
                {
                    tmp = contex.ClientsTable.FirstOrDefault((c) => c.ClientID == id);
                    //line off

                   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
