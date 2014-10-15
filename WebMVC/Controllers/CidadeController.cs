using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Views.Shared;
using System.Configuration;
using Web.Comum.Attributes;

namespace WebMVC.Controllers
{
    public class CidadeController : Controller
    {
        //
        // GET: /Cidade/
        private CidadeRepository cidadeRepository;
        public CidadeController()
        {
            cidadeRepository = new CidadeRepository();
        }


        [CustomAuthorize]
        public ActionResult Index(int? page)
        {
            return View(new PaginatedData<CidadeModel>(cidadeRepository.BuscarTodos().AsQueryable(), page ?? 0, Int32.Parse(ConfigurationManager.AppSettings["QuantidadeRegistroPorPagina"])));
        }

        //
        // GET: /Cidade/Details/5


        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            return View(cidadeRepository.BuscarPorID(id));
        }

        //
        // GET: /Cidade/Create

        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cidade/Create

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(CidadeModel model)
        {
            if (ModelState.IsValid)
            {
                cidadeRepository.AdicionarItem(model);
                return RedirectToAction("Index");
            }
            return View();

        }

        //
        // GET: /Cidade/Edit/5


        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            CidadeModel cidade = cidadeRepository.BuscarPorID(id);
            if (cidade != null)
                return View(cidade);
            return RedirectToAction("Index", "Cidade");
        }

        //
        // POST: /Cidade/Edit/5

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(CidadeModel model)
        {
            cidadeRepository.EditarItem(model);
            return RedirectToAction("Index");
        }

        //
        // GET: /Cidade/Delete/5

        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            CidadeModel cidade = cidadeRepository.BuscarPorID(id);
            if (cidade != null)
                return View(cidade);
            return RedirectToAction("Index", "Cidade");
        }

        //
        // POST: /Cidade/Delete/5

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Delete(CidadeModel model)
        {
            cidadeRepository.ExcluirItem(model);
            return RedirectToAction("Index");
        }
    }
}
