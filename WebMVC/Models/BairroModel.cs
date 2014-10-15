using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Dados;
using System.Web.Mvc;

namespace WebMVC.Models
{
    public class BairroModel : BaseModel
    {
        [Required]
        [DisplayName("Nome")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Cidade")]
        public CidadeModel Cidade { get; set; }

        [Required]
        [DisplayName("Sigla")]
        [DataType(DataType.Text)]
        public string Sigla { get; set; }

        [DisplayName("Selecione a cidade")]
        public List<SelectListItem> CidadesDisponiveis { get; set; }
    }

    //public class BairroRepository:BaseRepository<BAIRRO,BairroModel>
    //{
    //    //public List<BairroModel> BuscarTodos()
    //    //{
    //    //    return (from a in SingletonDBContext.Current.dbContext.BAIRRO
    //    //            select new BairroModel
    //    //            {
    //    //                ID = a.ID,
    //    //                Nome = a.NOME,
    //    //                Sigla = a.SIGLA,
    //    //                Cidade = new CidadeModel
    //    //                {
    //    //                    ID = a.CIDADE.ID,
    //    //                    Nome = a.CIDADE.NOME,
    //    //                    Sigla = a.CIDADE.SIGLA
    //    //                }
    //    //            }).ToList();
    //    //}
       

    //    public List<BairroModel> BuscarTodosDaCidade(int idCidade)
    //    {
    //        return (from a in SingletonDBContext.Current.dbContext.BAIRRO
    //                where a.IDCIDADE == idCidade
    //                select new BairroModel
    //                {
    //                    ID = a.ID,
    //                    Nome = a.NOME,
    //                    Sigla = a.SIGLA,
    //                    Cidade = new CidadeModel
    //                    {
    //                        ID = a.CIDADE.ID,
    //                        Nome = a.CIDADE.NOME,
    //                        Sigla = a.CIDADE.SIGLA
    //                    }
    //                }).ToList();
    //    }

    //    //public BairroModel BuscarPorID(int id)
    //    //{
    //    //    return (from a in SingletonDBContext.Current.dbContext.BAIRRO
    //    //            where a.ID == id
    //    //            select new BairroModel
    //    //            {
    //    //                ID = a.ID,
    //    //                Nome = a.NOME,
    //    //                Sigla = a.SIGLA,
    //    //                Cidade = new CidadeModel
    //    //                {
    //    //                    ID = a.CIDADE.ID,
    //    //                    Nome = a.CIDADE.NOME,
    //    //                    Sigla = a.CIDADE.SIGLA
    //    //                }
    //    //            }).FirstOrDefault();

    //    //}

    //    //public void AdicionarItem(BairroModel item)
    //    //{
    //    //    BAIRRO bairro = new BAIRRO();
    //    //    bairro.NOME = item.Nome;
    //    //    bairro.SIGLA = item.Sigla;
    //    //    bairro.IDCIDADE = item.Cidade.ID;
    //    //    SingletonDBContext.Current.dbContext.AddToBAIRRO(bairro);
    //    //    SingletonDBContext.Current.dbContext.SaveChanges();
    //    //}

    //    //public void ExcluirItem(BairroModel item)
    //    //{
    //    //    BAIRRO bairro = (from a in SingletonDBContext.Current.dbContext.BAIRRO
    //    //                     where a.ID == item.ID
    //    //                     select a).FirstOrDefault();
    //    //    if (bairro != null)
    //    //    {
    //    //        SingletonDBContext.Current.dbContext.BAIRRO.DeleteObject(bairro);
    //    //        SingletonDBContext.Current.dbContext.SaveChanges();
    //    //    }
    //    //}
        
    //    //public void EditarItem(BairroModel item)
    //    //{
    //    //    BAIRRO bairro = (from a in SingletonDBContext.Current.dbContext.BAIRRO
    //    //                     where a.ID == item.ID
    //    //                     select a).FirstOrDefault();
    //    //    if (bairro != null)
    //    //    {
    //    //        bairro.NOME = item.Nome;
    //    //        bairro.SIGLA = item.Sigla;
    //    //        bairro.IDCIDADE = item.Cidade.ID;
    //    //        SingletonDBContext.Current.dbContext.SaveChanges();
    //    //    }
    //    //}

    //    public override BAIRRO entity
    //    {
    //        get { return new BAIRRO(); }
    //    }
    //}
}