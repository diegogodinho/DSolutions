using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Views.Shared;

namespace WebMVC.Controllers
{
    public class UsuarioGrupoController : Controller
    {
        private UsuarioGrupoRepository _grupoRepository;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            _grupoRepository = new UsuarioGrupoRepository();
            base.Initialize(requestContext);
        }
        public ActionResult Index()
        {
            return View(_grupoRepository.BuscarTodos());
        }

        public ActionResult GrupoSelecionado(int? grupos)
        {
            return PartialView("SelecaoUsuarioGrupo", _grupoRepository.BuscarUsuariosDoGrupoEForaDele(grupos.Value));
        }


        public ActionResult AdicionarRemoverUsuarioGrupo(int? idUsuarioGrupo)
        {
            return null;
        }
    }
}
