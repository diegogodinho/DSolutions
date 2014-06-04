using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


using System.Linq.Expressions;

using WebMVC.Views.Shared;
using System.Reflection;
using Dados;
using WebMVC.Validators;

namespace WebMVC.Models
{
    public class FuncionalidadeModel : BaseModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Nome")]
        public string NomeFuncionalidade { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Código")]
        public string CodFuncionalidade { get; set; }      
    }

    public class FuncionalidadeRepository : IDados<FuncionalidadeModel>
    {
        public List<FuncionalidadeModel> BuscarTodos()
        {
            List<FuncionalidadeModel> funcionalidade = new List<FuncionalidadeModel>();
            SingletonDBContext.Current.dbContext.FUNCIONALIDADE.ToList().ForEach(r =>
            {
                funcionalidade.Add(new FuncionalidadeModel()
                {
                    ID = r.IDFUNCIONALIDADE,
                    CodFuncionalidade = r.CODFUNCIONALIDADE,
                    NomeFuncionalidade = r.NOMEFUNCIONALIDADE
                });
            });
            return funcionalidade;
        }

        public FuncionalidadeModel BuscarPorID(int ID)
        {
            FuncionalidadeModel retorno = (from a in SingletonDBContext.Current.dbContext.FUNCIONALIDADE
                                           where a.IDFUNCIONALIDADE == ID
                                           select new FuncionalidadeModel
                                           {
                                               ID = a.IDFUNCIONALIDADE,
                                               NomeFuncionalidade = a.NOMEFUNCIONALIDADE,
                                               CodFuncionalidade = a.CODFUNCIONALIDADE
                                           }).FirstOrDefault();
            return retorno;
        }

        public void AdicionarItem(FuncionalidadeModel item)
        {
            FUNCIONALIDADE funcionalidade = new FUNCIONALIDADE();
            funcionalidade.CODFUNCIONALIDADE = item.CodFuncionalidade;
            funcionalidade.NOMEFUNCIONALIDADE = item.NomeFuncionalidade;
            SingletonDBContext.Current.dbContext.AddToFUNCIONALIDADE(funcionalidade);
            SingletonDBContext.Current.dbContext.SaveChanges();
        }

        public void ExcluirItem(FuncionalidadeModel item)
        {
            FUNCIONALIDADE funcionalidade = (from a in SingletonDBContext.Current.dbContext.FUNCIONALIDADE
                                             where a.IDFUNCIONALIDADE == item.ID
                                             select a).FirstOrDefault();
            if (funcionalidade != null)
            {
                SingletonDBContext.Current.dbContext.FUNCIONALIDADE.DeleteObject(funcionalidade);
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }


        public void EditarItem(FuncionalidadeModel item)
        {
            FUNCIONALIDADE funcionalidade = (from a in SingletonDBContext.Current.dbContext.FUNCIONALIDADE
                                             where a.IDFUNCIONALIDADE == item.ID
                                             select a).FirstOrDefault();
            if (funcionalidade != null)
            {
                funcionalidade.NOMEFUNCIONALIDADE = item.NomeFuncionalidade;
                funcionalidade.CODFUNCIONALIDADE = item.CodFuncionalidade;
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }
    }
}