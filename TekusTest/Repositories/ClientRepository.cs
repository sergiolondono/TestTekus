using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TekusTest.Core.Repositories;
using TekusTest.Models;

namespace TekusTest.Repositories
{
    public class ClientRepository: IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Clientes> getClients()
        {
            return _context.Clientes.ToList();
        }

        public Clientes getClientByNit(string id)
        {
            return _context.Clientes.SingleOrDefault(u => u.Nit == id);
        }

        public void Create(Clientes user)
        {
            _context.Clientes.Add(user);
        }
    }
}