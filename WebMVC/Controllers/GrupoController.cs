using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Views.Shared;

namespace WebMVC.Controllers
{
    public class GrupoController : Controller
    {
        private IDados<GrupoModel> _grupoRepository;
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            _grupoRepository = new GrupoRepository();
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            return View(_grupoRepository.BuscarTodos());
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(GrupoModel model)
        {
            if (ModelState.IsValid)
            {
                _grupoRepository.AdicionarItem(model);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Teste mensagem de erro");
            return View(model);
        }

        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            GrupoModel grupoModel = _grupoRepository.BuscarPorID(id);
            if (grupoModel != null)
                return View(grupoModel);
            return RedirectToAction("Index", "Grupo");
        }



        [HttpPost]
        public ActionResult Edit(GrupoModel model)
        {
            _grupoRepository.EditarItem(model);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            GrupoModel grupoModel = _grupoRepository.BuscarPorID(id);
            if (grupoModel != null)
                return View(grupoModel);
            return RedirectToAction("Index", "Grupo");
        }



        [HttpPost]
        public ActionResult Delete(GrupoModel model)
        {
            _grupoRepository.ExcluirItem(model);
            return RedirectToAction("Index", "Grupo");
        }
        #endregion

        #region Details
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
