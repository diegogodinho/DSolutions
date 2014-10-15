using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using System.Configuration;
using WebMVC.Views.Shared;
using Web.Comum.Attributes;
using Dominio.Entidades;
using Dados.Repositorio;


namespace WebMVC.Controllers
{
    public class CaracteristicaController : Controller
    {   
        private CaracteristicaRepositorio caracteristicaRepository;
        public CaracteristicaController()
        {
            caracteristicaRepository = new CaracteristicaRepositorio();
        }

        [CustomAuthorize]
        public ActionResult Index(int? page)
        {
            return View(new PaginatedData<CaracteristicaModel>(caracteristicaRepository.BuscarTodos().AsQueryable(), page ?? 0, Int32.Parse(ConfigurationManager.AppSettings["QuantidadeRegistroPorPagina"])));
        }


        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }


        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }        

        [HttpPost]

        [CustomAuthorize]
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


        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }        

        [HttpPost]

        [CustomAuthorize]
        public ActionResult Edit(CaracteristicaModel model)
        {

            if (ModelState.IsValid)
            {
                caracteristicaRepository.EditarItem(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            return View(caracteristicaRepository.BuscarPorID(id));
        }        

        [HttpPost]

        [CustomAuthorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                caracteristicaRepository.ExcluirItem(id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        
    }
}
