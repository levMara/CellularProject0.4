using Common;
using Common.Interfaces;
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceEngine_Dal
{
    public class InvoiceManager : IEnvoiceEngineOperation
    {
        public ICollection<Call> IssuingInvoice(int clientId)
        {
            try
            {
                using (var context = new CellularModelDB())
                {
                    //get all client lines
                    List<Line> liens = context.LinesTable.Where((l) => l.Client.ClientID == clientId).ToList();
                    List<Call> calls = new List<Call>();
                             

                
                    return calls ;
                }
            }
            catch (Exception e)
            {
                Logger.Log.WriteToLog("Failed connect to data base" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
                
            }
        }
    }
}
