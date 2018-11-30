using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TekusTest.Core.Repositories;
using TekusTest.Models;

namespace TekusTest.Repositories
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Servicios> getServices()
        {
            return _context.Servicios.ToList();
        }

        public Servicios getServiceById(int id)
        {
            return _context.Servicios.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<Servicios> getServiceByClient(int idClient)
        {
            return _context.Servicios.Where(u => u.IdCliente == idClient).ToList();
        }

        public void Create(Servicios servicio)
        {
            _context.Servicios.Add(servicio);
        }
    }
}