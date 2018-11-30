using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekusTest.Core.Repositories;

namespace TekusTest.Core
{
    public interface IUnitOfWork
    {
        IClientRepository Clients { get; }
        ICountryRepository Countries { get; }
        IServiceRepository Services { get; }
        IServiceCountryRepository CountriesServices { get;}
        void Complete();
    }
}
