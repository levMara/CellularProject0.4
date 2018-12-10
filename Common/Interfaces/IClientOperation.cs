using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IClientOperation 
    {

        Client GetClient(int clientId);

        ICollection<Client> GetAllClients();

        string ChangeClientType(int clientId, ClientTypeName newType);

    }
}
