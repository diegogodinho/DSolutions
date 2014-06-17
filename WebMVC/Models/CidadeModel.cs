using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dados;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebMVC.Models
{
    public class CidadeModel : BaseModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Sigla")]
        public string Sigla { get; set; }
    }


    public class CidadeRepository
    {
        public List<CidadeModel> BuscarTodos()
        {
            return (from a in SingletonDBContext.Current.dbContext.CIDADE
                    select new CidadeModel { ID = a.ID, Nome = a.NOME, Sigla = a.SIGLA }).ToList();
        }
        public CidadeModel BuscarPorID(int id)
        {
            return (from a in SingletonDBContext.Current.dbContext.CIDADE
                    where a.ID == id
                    select new CidadeModel { ID = a.ID, Nome = a.NOME, Sigla = a.SIGLA }).FirstOrDefault();

        }
        public void AdicionarItem(CidadeModel item)
        {
            CIDADE cidade = new CIDADE();
            cidade.NOME = item.Nome;
            cidade.SIGLA = item.Sigla;
            SingletonDBContext.Current.dbContext.AddToCIDADE(cidade);
            SingletonDBContext.Current.dbContext.SaveChanges();
        }

        public void ExcluirItem(CidadeModel item)
        {
            CIDADE cidade = (from a in SingletonDBContext.Current.dbContext.CIDADE
                             where a.ID == item.ID
                             select a).FirstOrDefault();
            if (cidade != null)
            {
                SingletonDBContext.Current.dbContext.CIDADE.DeleteObject(cidade);
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }

        public void EditarItem(CidadeModel item)
        {
            CIDADE cidade = (from a in SingletonDBContext.Current.dbContext.CIDADE
                             where a.ID == item.ID
                             select a).FirstOrDefault();
            if (cidade != null)
            {
                cidade.NOME = item.Nome;
                cidade.SIGLA = item.Sigla;
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }
    }
}