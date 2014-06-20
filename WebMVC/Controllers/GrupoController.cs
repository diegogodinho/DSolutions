using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Views.Shared;
using WebMVC.Attributes;
using System.Configuration;

namespace WebMVC.Controllers
{
    public class GrupoController : Controller
    {
        private GrupoRepository _grupoRepository;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            _grupoRepository = new GrupoRepository();

            base.Initialize(requestContext);
        }

        [CustomAuthorize]
        public ActionResult Index(int? page)
        {
            return View(new PaginatedData<GrupoModel>(_grupoRepository.BuscarTodos().AsQueryable(), page ?? 0, Int32.Parse(ConfigurationManager.AppSettings["QuantidadeRegistroPorPagina"])));
        }

        #region Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(GrupoModel model)
        {
            if (ModelState.IsValid)
            {
                _grupoRepository.AdicionarItem(model);
                return RedirectToAction("Index");
            }            
            return View(model);
        }

        #endregion

        #region Edit
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            GrupoModel grupoModel = _grupoRepository.BuscarPorID(id);
            if (grupoModel != null)
                return View(grupoModel);
            return RedirectToAction("Index", "Grupo");
        }



        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(GrupoModel model)
        {
            _grupoRepository.EditarItem(model);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            GrupoModel grupoModel = _grupoRepository.BuscarPorID(id);
            if (grupoModel != null)
                return View(grupoModel);
            return RedirectToAction("Index", "Grupo");
        }



        [HttpPost]
        [CustomAuthorize]
        public ActionResult Delete(GrupoModel model)
        {
            try
            {
                _grupoRepository.ExcluirItem(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { message = e.Message });
            }

            return RedirectToAction("Index", "Grupo");
        }
        #endregion

        #region Details
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            GrupoModel grupoModel = _grupoRepository.BuscarPorID(id);
            if (grupoModel != null)
                return View(grupoModel);
            return RedirectToAction("Index", "Grupo");
        }
        #endregion
    }
}
