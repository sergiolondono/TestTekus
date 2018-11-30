using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekusTest.Models;

namespace TekusTest.Core.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Clientes> getClients();
        Clientes getClientByNit(string id);
        void Create(Clientes user);
    }
}
