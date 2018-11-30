using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekusTest.Models;

namespace TekusTest.Core.Repositories
{
    public interface IServiceRepository
    {
        IEnumerable<Servicios> getServices();
        Servicios getServiceById(int id);
        IEnumerable<Servicios> getServiceByClient(int idClient);
        void Create(Servicios servicio);
    }
}
