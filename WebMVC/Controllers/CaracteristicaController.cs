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
        //
        // GET: /Caracteristica/
        private CaracteristicaRepository caracteristicaRepository;
        public CaracteristicaController()
        {
            caracteristicaRepository = new CaracteristicaRepository();
        }

        public ActionResult Index(int? page)
        {
            return View(new PaginatedData<CaracteristicaModel>(caracteristicaRepository.BuscarTodos().AsQueryable(), page ?? 0, Int32.Parse(ConfigurationManager.AppSettings["QuantidadeRegistroPorPagina"])));
        }

        //
        // GET: /Caracteristica/Details/5

        public ActionResult Details(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }

        //
        // GET: /Caracteristica/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Caracteristica/Create

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

        //
        // GET: /Caracteristica/Edit/5

        public ActionResult Edit(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }

        //
        // POST: /Caracteristica/Edit/5

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

        //
        // GET: /Caracteristica/Delete/5

        public ActionResult Delete(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }

        //
        // POST: /Caracteristica/Delete/5

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
