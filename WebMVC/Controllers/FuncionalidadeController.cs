using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Views.Shared;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    public class FuncionalidadeController : Controller
    {
        private IDados<FuncionalidadeModel> _funcionalidadeRepository;
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            _funcionalidadeRepository = new FuncionalidadeRepository();
            base.Initialize(requestContext);
        }

        [CustomAuthorize]
        public ActionResult Index(int? page, string sorter)
        {
            List<FuncionalidadeModel> funcinalidades = _funcionalidadeRepository.BuscarTodos();
            if (sorter != null && sorter != string.Empty)
            {
                if (sorter == "ID")
                    funcinalidades = funcinalidades.OrderBy(r => { return r.ID; }).ToList();
                else if (sorter == "NomeFuncionalidade")
                    funcinalidades = funcinalidades.OrderBy(r => { return r.NomeFuncionalidade; }).ToList();
                else
                    funcinalidades = funcinalidades.OrderBy(r => { return r.CodFuncionalidade; }).ToList();
            }

            PaginatedData<FuncionalidadeModel> exemploPaginacao = new PaginatedData<FuncionalidadeModel>(funcinalidades.AsQueryable(), page ?? 0, 30);

            return View(exemploPaginacao);
        }

        #region Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        [CustomAuthorize]
        [HttpPost]
        public ActionResult Create(FuncionalidadeModel model)
        {
            if (ModelState.IsValid)
            {
                _funcionalidadeRepository.AdicionarItem(model);
                return RedirectToAction("Index", "Funcionalidade");
            }
            ModelState.AddModelError("", "Teste mensagem de erro");
            return View(model);
        }
        #endregion

        #region Edit
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            FuncionalidadeModel funcionalidadeModel = _funcionalidadeRepository.BuscarPorID(id);
            if (funcionalidadeModel != null)
                return View(funcionalidadeModel);
            return RedirectToAction("Index", "Funcionalidade");
        }

        [CustomAuthorize]
        [HttpPost]
        public ActionResult Edit(FuncionalidadeModel model)
        {
            if (ModelState.IsValid)
            {
                _funcionalidadeRepository.EditarItem(model);
                return RedirectToAction("Index", "Funcionalidade");
            }
            ModelState.AddModelError("", "Teste mensagem de erro");
            return View(model);
        }
        #endregion

        #region Delete
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            FuncionalidadeModel funcionalidadeModel = _funcionalidadeRepository.BuscarPorID(id);
            if (funcionalidadeModel != null)
                return View(funcionalidadeModel);
            return RedirectToAction("Index", "Funcionalidade");
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Delete(FuncionalidadeModel funcionalidade)
        {
            _funcionalidadeRepository.ExcluirItem(funcionalidade);
            return RedirectToAction("Index", "Funcionalidade");
        }
        #endregion

        #region Details
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            FuncionalidadeModel funcionalidadeModel = _funcionalidadeRepository.BuscarPorID(id);
            if (funcionalidadeModel != null)
                return View(funcionalidadeModel);
            return RedirectToAction("Index", "Funcionalidade");
        }

        #endregion       
    }
}
