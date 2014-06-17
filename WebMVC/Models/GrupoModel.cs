using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebMVC.Views.Shared;
using Dados;

namespace WebMVC.Models
{
    public class GrupoModel : BaseModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Nome")]
        public string NomeGrupo { get; set; }        
    }

    public class GrupoRepository : IDados<GrupoModel>
    {
        public List<GrupoModel> BuscarTodos()
        {
            List<GrupoModel> retorno = new List<GrupoModel>();
            SingletonDBContext.Current.dbContext.GRUPO.ToList().ForEach(r =>
            {
                retorno.Add(new GrupoModel()
                {
                    ID = r.IDGRUPO,
                    NomeGrupo = r.NOMEGRUPO
                });
            });
            return retorno;
        }
       
        public GrupoModel BuscarPorID(int ID)
        {
            GrupoModel retorno = (from a in SingletonDBContext.Current.dbContext.GRUPO
                                  where a.IDGRUPO == ID
                                  select new GrupoModel { ID = a.IDGRUPO, NomeGrupo = a.NOMEGRUPO }).FirstOrDefault();
            return retorno;
        }

        public void AdicionarItem(GrupoModel item)
        {
            GRUPO grupo = new GRUPO();
            grupo.NOMEGRUPO = item.NomeGrupo;
            SingletonDBContext.Current.dbContext.AddToGRUPO(grupo);
            SingletonDBContext.Current.dbContext.SaveChanges();
        }

        public void ExcluirItem(GrupoModel item)
        {
            GRUPO grupos = (from a in SingletonDBContext.Current.dbContext.GRUPO
                                             where a.IDGRUPO == item.ID
                                             select a).FirstOrDefault();
            if (grupos != null)
            {
                SingletonDBContext.Current.dbContext.GRUPO.DeleteObject(grupos);
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }

        public void EditarItem(GrupoModel item)
        {
            GRUPO grupos = (from a in SingletonDBContext.Current.dbContext.GRUPO
                             where a.IDGRUPO == item.ID
                             select a).FirstOrDefault();
            if (grupos != null)
            {
                grupos.NOMEGRUPO = item.NomeGrupo;                
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }
    }

}