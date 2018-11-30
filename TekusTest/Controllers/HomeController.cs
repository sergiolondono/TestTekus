using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TekusTest.Core;

namespace TekusTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var cliente = _unitOfWork.Clients.getClients();
            List<SelectListItem> clientList = new List<SelectListItem>();
            clientList.Clear();
            clientList.Add(new SelectListItem { Text = "-- Seleccionar Cliente --", Value = "" });
            foreach (var row in cliente)
                clientList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            ViewBag.cliente = clientList;
            return View();
        }
    }
}