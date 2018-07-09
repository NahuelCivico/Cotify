using BusinessServices.Services;
using Model;
using Model.UnitOfWork;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class QuoteController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Quote
        public ActionResult Index()
        {
            List<Cotizaciones> quotes = new QuoteServices(unitOfWork).GetAll("");
            return View(convertToVM(quotes));
        }

        [HttpGet]
        public PartialViewResult Search(String filter)
        {
            List<Cotizaciones> quotes = new QuoteServices(unitOfWork).GetAll(filter);
            return PartialView("List", convertToVM(quotes));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new QuoteVM()
            {
                FechaVencimiento = DateTime.Now.AddYears(1),
                FechaCotizacion = DateTime.Now,
                NumeroPoliza = Guid.NewGuid().ToString().Substring(0, 6)
            });
        }

        [HttpPost]
        public ActionResult Create(QuoteVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                vm.FechaCotizacion = DateTime.Now;
                Int64 quote = new QuoteServices(unitOfWork).Create(convertToEntity(vm));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        #region Converts
        public List<QuoteVM> convertToVM(List<Cotizaciones> entity)
        {
            List<QuoteVM> quotesVM = new List<QuoteVM>();
            foreach (var item in entity)
            {
                quotesVM.Add(new QuoteVM()
                {
                    Cliente = item.Cliente,
                    TipoSeguro = item.TipoSeguro,
                    FormaPago = item.FormaPago,
                    FechaVencimiento = item.FechaVencimiento,
                    FechaCotizacion = item.FechaCotizacion,
                    Activa = item.Activa,
                    NumeroPoliza = item.NumeroPoliza
                });
            }
            return quotesVM;
        }

        public Cotizaciones convertToEntity(QuoteVM vm)
        {
            return new Cotizaciones()
            {
                Cliente = vm.Cliente,
                TipoSeguro = vm.TipoSeguro,
                FormaPago = vm.FormaPago,
                FechaVencimiento = vm.FechaVencimiento,
                FechaCotizacion = vm.FechaCotizacion,
                Activa = vm.Activa,
                NumeroPoliza = vm.NumeroPoliza
            };
        }
        #endregion
    }
}