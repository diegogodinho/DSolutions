using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Dados;
using WebMVC.Views.Shared;

namespace WebMVC.Models
{
    public class UsuarioGrupoModel : BaseModel
    {
        [Required]
        public List<GrupoModel> Grupos { get; set; }
    }


    public class Usuario : BaseModel
    {
        public string Nome { get; set; }
    }

    public class UsuarioPorGrupo : BaseModel
    {
        public List<Usuario> UsuariosPertencentesAoGrupo { get; set; }
        public List<Usuario> UsuariosNaoPertencentesAoGrupo { get; set; }
    }

    public class UsuarioGrupoRepository
    {
        public UsuarioGrupoModel BuscarTodos()
        {
            UsuarioGrupoModel retorno = new UsuarioGrupoModel();
            retorno.Grupos = new List<GrupoModel>();
            SingletonDBContext.Current.dbContext.GRUPOS.ToList().ForEach(r =>
            {
                retorno.Grupos.Add(new GrupoModel()
                {
                    ID = r.IDGRUPO,
                    NomeGrupo = r.NOMEGRUPO
                });
            });
            return retorno;
        }

        public UsuarioPorGrupo BuscarUsuariosDoGrupoEForaDele(int grupoID)
        {
            UsuarioPorGrupo usuarioPorGrupo = new UsuarioPorGrupo();
            usuarioPorGrupo.UsuariosPertencentesAoGrupo = (from a in SingletonDBContext.Current.dbContext.USUARIOGRUPO
                                                           where a.IDGRUPO == grupoID
                                                           orderby a.USUARIOUNIVERSUS.NOME
                                                           select new Usuario { ID = a.IDUSUARIOUNIVERSUS, Nome = a.USUARIOUNIVERSUS.NOME }).ToList();
            List<int> ids = new List<int>();
            usuarioPorGrupo.UsuariosPertencentesAoGrupo.ForEach(r => { ids.Add(r.ID); });
            usuarioPorGrupo.UsuariosNaoPertencentesAoGrupo = (from a in SingletonDBContext.Current.dbContext.USUARIOUNIVERSUS
                                                              where !ids.Contains(a.IDUSUARIOUNIVERSUS)
                                                              orderby a.NOME
                                                              select new Usuario { ID = a.IDUSUARIOUNIVERSUS, Nome = a.NOME }).ToList();
            return usuarioPorGrupo;
        }
    }
}
