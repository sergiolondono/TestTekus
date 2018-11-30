using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekusTest.Models;

namespace TekusTest.Core.Repositories
{
    public interface IServiceCountryRepository
    {
        IEnumerable<PaisesPorServicio> getCountriesServices();
        PaisesPorServicio getCountryServcieById(int id);
        IEnumerable<PaisesPorServicio> getCountryServiceExist(int? idServicio, int? idPais);
        IEnumerable<ResumeServicesByCountry> getServicesByCountry();
        void Create(PaisesPorServicio paisServicio);
    }
}
