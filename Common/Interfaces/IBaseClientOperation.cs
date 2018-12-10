using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IBaseClientOperation
    {
        Client AddClient(Client newClient);

        Client DeleteClient(int id);

        Client UpdateClientDetails(Client editClient);
    }
}
