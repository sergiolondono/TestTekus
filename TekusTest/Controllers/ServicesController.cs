using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TekusTest.Core;

namespace TekusTest.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Services
        public ActionResult Index()
        {
            fillClientsServices();
            return View();
        }

        private void fillClientsServices()
        {
            var cliente = _unitOfWork.Clients.getClients();
            var servicio = _unitOfWork.Services.getServices();
            List<SelectListItem> clientList = new List<SelectListItem>();
            List<SelectListItem> serviceList = new List<SelectListItem>();
            clientList.Clear();
            serviceList.Clear();

            clientList.Add(new SelectListItem { Text = "-- Seleccionar Cliente --", Value = "" });
            foreach (var row in cliente)
                clientList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            serviceList.Add(new SelectListItem { Text = "-- Seleccionar Servicio --", Value = "" });
            foreach (var row in servicio)
                serviceList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            ViewBag.cliente = clientList;
            ViewBag.servicio = serviceList;
        }
    }
}