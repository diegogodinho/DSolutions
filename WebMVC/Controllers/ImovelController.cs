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
    public class ImovelController : Controller
    {
        //
        // GET: /Imovel/

        private ImovelRepository imovelRepository;
        public ImovelController()
        {
            imovelRepository = new ImovelRepository();
        }

        public ActionResult Index(int? page)
        {
            return View(new PaginatedData<ImovelModel>(imovelRepository.BuscarTodos().AsQueryable(), page ?? 0, Int32.Parse(ConfigurationManager.AppSettings["QuantidadeRegistroPorPagina"])));
        }

        //
        // GET: /Imovel/Details/5

        public ActionResult Details(int id)
        {
            return View(imovelRepository.BuscarPorID(id));
        }

        //
        // GET: /Imovel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Imovel/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Imovel/Edit/5

        public ActionResult Edit(int id)
        {
            return View(imovelRepository.BuscarPorID(id));
        }

        //
        // POST: /Imovel/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Imovel/Delete/5

        public ActionResult Delete(int id)
        {
            return View(imovelRepository.BuscarPorID(id));
        }

        //
        // POST: /Imovel/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
