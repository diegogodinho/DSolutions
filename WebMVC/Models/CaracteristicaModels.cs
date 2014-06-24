using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Dados;

namespace WebMVC.Models
{
    public class CaracteristicaModel : BaseModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }

    public class CaracteristicaRepository : BaseRepository<CARACTERISTICA>
    {
        public List<CaracteristicaModel> BuscarTodos()
        {
            return (from a in SingletonDBContext.Current.dbContext.CARACTERISTICA
                    select new CaracteristicaModel()
                    {
                        Descricao = a.DESCRICAO,
                        ID = a.IDCARACTERISTICA
                    }).ToList();
        }

        public CaracteristicaModel BuscarPorID(int id)
        {
            return (from a in SingletonDBContext.Current.dbContext.CARACTERISTICA
                    where a.IDCARACTERISTICA == id
                    select new CaracteristicaModel()
                    {
                        Descricao = a.DESCRICAO,
                        ID = a.IDCARACTERISTICA
                    }).FirstOrDefault();
        }

        public void AdicionarItem(CaracteristicaModel item)
        {
            this.AdicionarItem(new CARACTERISTICA() { DESCRICAO = item.Descricao });
        }
        public void RemoverItem(int id)
        {
            CARACTERISTICA caracteristicaModel = (from a in SingletonDBContext.Current.dbContext.CARACTERISTICA
                                                  where a.IDCARACTERISTICA == id
                                                  select a).FirstOrDefault();
            if (caracteristicaModel != null)
            {
                this.RemoverItem(caracteristicaModel);
            }
        }

        public void AtualizarItem(CaracteristicaModel item)
        {
            CARACTERISTICA caracteristicaModel = (from a in SingletonDBContext.Current.dbContext.CARACTERISTICA
                                                  where a.IDCARACTERISTICA == item.ID
                                                  select a).FirstOrDefault();
            if (caracteristicaModel != null)
            {
                caracteristicaModel.DESCRICAO = item.Descricao;
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }
    }
}