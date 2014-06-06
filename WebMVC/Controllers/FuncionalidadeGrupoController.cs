using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Attributes;
using WebMVC.Views.Shared;

namespace WebMVC.Controllers
{
    public class FuncionalidadeGrupoController : Controller
    {
        //
        // GET: /FuncionalidadeGrupo/
        private FuncionalidadeRepository _funcionalidadeRepository;
        private FuncionalidadeGrupoRepository _funcionalidadeGrupoRepository;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _funcionalidadeRepository = new FuncionalidadeRepository();
            _funcionalidadeGrupoRepository = new FuncionalidadeGrupoRepository();
        }


        [CustomAuthorize]
        public ActionResult Index()
        {
            return View(_funcionalidadeRepository.BuscarTodos());
        }

        [CustomAuthorize]
        public ActionResult FuncionalidadeSelecionada(int? funcionalidade, int? page, string sorter)
        {
            return PartialView("GridGruposPorFuncionalidade", _funcionalidadeGrupoRepository.BuscarTodos(funcionalidade.Value));
        }

        #region Create
        public ActionResult CriarFuncionalidadeGrupo(FormCollection form)
        {
            string funciondalidade = form["funcionalidadeID"];
            return View(_funcionalidadeGrupoRepository.BuscarGruposSemAModalidade(Convert.ToInt32(funciondalidade)));
        }
        #endregion
    }
}
