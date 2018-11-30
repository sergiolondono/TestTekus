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
    public class ServicesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Servicios> getServices()
        {
            return _unitOfWork.Services.getServices();
        }

        public Servicios getServiceById(int id)
        {
            return _unitOfWork.Services.getServiceById(id);
        }

        public IEnumerable<Servicios> getServiceByIdClient(int idClient)
        {
            return _unitOfWork.Services.getServiceByClient(idClient);
        }

        [HttpPost]
        public Servicios createService(Servicios servicio)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _unitOfWork.Services.Create(servicio);
            _unitOfWork.Complete();

            return servicio;
        }

        [HttpPut]
        public IHttpActionResult updateService(int id, Servicios servicio)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var serviceInDb = _unitOfWork.Services.getServiceById(id);
            if (serviceInDb != null)
            {
                serviceInDb.Nombre = servicio.Nombre;
                serviceInDb.ValorHora = servicio.ValorHora;                
                serviceInDb.IdCliente = servicio.IdCliente;                

                _unitOfWork.Complete();

                return Ok(serviceInDb);
            }
            else
                return BadRequest();
        }
    }
}
