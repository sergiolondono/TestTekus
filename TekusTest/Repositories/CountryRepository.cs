using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TekusTest.Core.Repositories;
using TekusTest.Models;

namespace TekusTest.Repositories
{
    public class CountryRepository: ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Paises> getCountries()
        {
            return _context.Paises.ToList();
        }

        public Paises getCountryById(int id)
        {
            return _context.Paises.SingleOrDefault(u => u.Id == id);
        }
        public void Create(Paises pais)
        {
            _context.Paises.Add(pais);
        }
    }
}