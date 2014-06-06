using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dados;
using WebMVC.Views.Shared;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class FuncionalidadeGrupoGridModel : BaseModel
    {
        public int funcionalidadeID { get; set; }
        public List<GrupoModel> Grupos { get; set; }
    }

    public class FuncionalidadeGrupoCreateModel : BaseModel
    {
        [Required]
        public FuncionalidadeModel Funcionalidade { get; set; }
        [Required]
        public List<GrupoModel> Grupos { get; set; }
        [Required]
        public bool PermiteCriacao { get; set; }
        [Required]
        public bool PermiteLeitura { get; set; }
        [Required]
        public bool PermiteAlteracao { get; set; }
        [Required]
        public bool PermiteExclusao { get; set; }
    }


    public class FuncionalidadeGrupoRepository
    {
        public FuncionalidadeGrupoGridModel BuscarTodos(int funcionalidade)
        {
            FuncionalidadeGrupoGridModel retorno = new FuncionalidadeGrupoGridModel();
            retorno.Grupos = (from a in SingletonDBContext.Current.dbContext.FUNCIONALIDADEGRUPO
                              where a.IDFUNCIONALIDADE == funcionalidade
                              select new GrupoModel
                              {
                                  ID = a.GRUPO.IDGRUPO,
                                  NomeGrupo = a.GRUPO.NOMEGRUPO,
                              }).ToList();
            retorno.funcionalidadeID = funcionalidade;
            return retorno;
        }
        public FuncionalidadeGrupoCreateModel BuscarGruposSemAModalidade(int funcionalidade)
        {
            FuncionalidadeGrupoCreateModel retorno = new FuncionalidadeGrupoCreateModel();
            retorno.Grupos = (from a in SingletonDBContext.Current.dbContext.GRUPO
                              join b in SingletonDBContext.Current.dbContext.FUNCIONALIDADEGRUPO on a.IDGRUPO equals b.IDGRUPO into lfjoin
                              from b in lfjoin.DefaultIfEmpty()
                              where (b.IDFUNCIONALIDADE != funcionalidade || b == null)
                              select new GrupoModel
                              {
                                  ID = a.IDGRUPO,
                                  NomeGrupo = a.NOMEGRUPO,
                              }).ToList();
            FuncionalidadeRepository funcionalidadeRepository = new FuncionalidadeRepository();
            retorno.Funcionalidade = funcionalidadeRepository.BuscarPorID(funcionalidade);
            return retorno;
        }
    }
}