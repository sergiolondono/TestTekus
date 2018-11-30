using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TekusTest.Core.Repositories;
using TekusTest.Models;

namespace TekusTest.Repositories
{
    public class ServiceCountryRepository : IServiceCountryRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceCountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<PaisesPorServicio> getCountriesServices()
        {
            return _context.PaisesPorServicio.ToList();
        }

        public PaisesPorServicio getCountryServcieById(int id)
        {
            return _context.PaisesPorServicio.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<PaisesPorServicio> getCountryServiceExist(int? idServicio, int? idPais)
        {
            return _context.PaisesPorServicio.Where(cs => cs.IdServicio == idServicio && cs.IdPais == idPais).ToList();
        }

        public void Create(PaisesPorServicio paisServicio)
        {
            _context.PaisesPorServicio.Add(paisServicio);
        }
    }
}