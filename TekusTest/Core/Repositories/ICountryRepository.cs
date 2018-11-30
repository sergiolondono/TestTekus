using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekusTest.Models;

namespace TekusTest.Core.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Paises> getCountries();
        Paises getCountryById(int id);
        void Create(Paises pais);
    }
}
