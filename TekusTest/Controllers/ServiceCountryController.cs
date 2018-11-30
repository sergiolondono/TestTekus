using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TekusTest.Core;

namespace TekusTest.Controllers
{
    public class ServiceCountryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceCountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: ServiceCountry
        public ActionResult Index()
        {
            fillListViews();
            return View();
        }

        private void fillListViews()
        {
            #region Clientes
            var cliente = _unitOfWork.Clients.getClients();
            List<SelectListItem> clientList = new List<SelectListItem>();
            clientList.Clear();

            clientList.Add(new SelectListItem { Text = "-- Seleccionar Cliente --", Value = "" });
            foreach (var row in cliente)
                clientList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            ViewBag.cliente = clientList;
            #endregion


            #region Servicios
            var servicio = _unitOfWork.Services.getServices();
            List<SelectListItem> serviceList = new List<SelectListItem>();
            serviceList.Clear();

            serviceList.Add(new SelectListItem { Text = "-- Seleccionar Servicio --", Value = "" });
            foreach (var row in servicio)
                serviceList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            ViewBag.servicio = serviceList; 
            #endregion


            #region Paises
            var countries = _unitOfWork.Countries.getCountries();
            List<SelectListItem> countriesList = new List<SelectListItem>();
            countriesList.Clear();

            countriesList.Add(new SelectListItem { Text = "-- Seleccionar Pais --", Value = "" });
            foreach (var row in countries)
                countriesList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            ViewBag.paises = countriesList;
            #endregion

        }
    }
}