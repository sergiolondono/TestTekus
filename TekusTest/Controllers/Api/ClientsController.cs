using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TekusTest.Core;
using TekusTest.Models;

namespace TekusTest.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Clientes> getClients()
        {
            return _unitOfWork.Clients.getClients();
        }

        [HttpPost]
        public Clientes createClients(Clientes client)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _unitOfWork.Clients.Create(client);
            _unitOfWork.Complete();

            return client;
        }

        [HttpPut]
        public IHttpActionResult updateClient(string id, Clientes client)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var clientInDb = _unitOfWork.Clients.getClientByNit(id);
            if (clientInDb != null)
            {
                clientInDb.Nit = client.Nit;
                clientInDb.Nombre = client.Nombre;
                clientInDb.Email = client.Email;

                _unitOfWork.Complete();

                return Ok(clientInDb);
            }
            else
                return BadRequest();
        }

    }
}
