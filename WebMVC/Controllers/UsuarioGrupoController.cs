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
    public class UsuarioGrupoController : Controller
    {
        private UsuarioGrupoRepository _grupoRepository;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            _grupoRepository = new UsuarioGrupoRepository();
            base.Initialize(requestContext);
        }
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View(_grupoRepository.BuscarTodos());
        }

        [CustomAuthorize]
        public ActionResult GrupoSelecionado(int? grupo)
        {
            return PartialView("SelecaoUsuarioGrupo", _grupoRepository.BuscarUsuariosDoGrupoEForaDele(grupo.Value));
        }

        [CustomAuthorize]
        public ActionResult AdicionarRemoverUsuarioGrupo(int? grupo, int? opcao, int? UsuariosGrupo, int? UsuarioNoPresentesNoGrupo)
        {
            if (opcao.HasValue)
            {
                if (opcao.Value == 1)
                {
                    _grupoRepository.IncluirUsuarioGrupo(grupo.Value, UsuarioNoPresentesNoGrupo.Value);
                }
                else
                {
                    _grupoRepository.RemoverUsuarioGrupo(grupo.Value, UsuariosGrupo.Value);
                }
                return PartialView("SelecaoUsuarioGrupo", _grupoRepository.BuscarUsuariosDoGrupoEForaDele(grupo.Value));
            }
            return View();
        }
    }
}
