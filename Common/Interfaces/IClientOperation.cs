using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IClientOperation 
    {
        void AddClient(Client newClient);

        Client GetClient(int clientId);

        void UpdateClientDetails(int clientId, Client editClient);

        void DeleteClient(int id);

    }
}
