using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using System.Configuration;
using WebMVC.Views.Shared;

namespace WebMVC.Controllers
{
    public class CaracteristicaController : Controller
    {   
        private CaracteristicaRepository caracteristicaRepository;
        public CaracteristicaController()
        {
            caracteristicaRepository = new CaracteristicaRepository();
        }

        public ActionResult Index(int? page)
        {
            return View(new PaginatedData<CaracteristicaModel>(caracteristicaRepository.BuscarTodos().AsQueryable(), page ?? 0, Int32.Parse(ConfigurationManager.AppSettings["QuantidadeRegistroPorPagina"])));
        }        

        public ActionResult Details(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }        

        public ActionResult Create()
        {
            return View();
        }        

        [HttpPost]
        public ActionResult Create(CaracteristicaModel model)
        {
            if (ModelState.IsValid)
            {
                caracteristicaRepository.AdicionarItem(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }        

        public ActionResult Edit(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }        

        [HttpPost]
        public ActionResult Edit(CaracteristicaModel model)
        {

            if (ModelState.IsValid)
            {
                caracteristicaRepository.AtualizarItem(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }        

        public ActionResult Delete(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }        

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                caracteristicaRepository.RemoverItem(id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        
    }
}
