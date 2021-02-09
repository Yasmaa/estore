using StoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSample.Database
{
    public class ClientsManager : BaseDataManager<Client>
    {
        public Client GetCliente()
        {
            return Database.Clients.FirstOrDefault();
        }

    }
}
