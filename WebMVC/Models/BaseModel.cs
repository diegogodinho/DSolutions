using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace WebMVC.Models
{
    public class BaseModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("ID")]
        public int ID { get; set; }



        public static TDestino AdaptarTipos<TOrigem, TDestino>(TOrigem objetoOrigem)
           where TDestino : class,new()
        {
            TDestino objetoDeDestino = new TDestino();
            PropertyInfo[] propriedadesDeOrigem = objetoOrigem.GetType().GetProperties();
            PropertyInfo[] propriedadesDeDestino = objetoDeDestino.GetType().GetProperties();
            foreach (PropertyInfo propriedadeDeOrigem in propriedadesDeOrigem)
            {
                foreach (PropertyInfo propriedadeDeDestino in propriedadesDeDestino)
                {
                    if (propriedadeDeOrigem.Name.ToUpper() == propriedadeDeDestino.Name.ToUpper())
                    {
                        if (propriedadeDeDestino.CanWrite)
                        {
                            propriedadeDeDestino.SetValue(objetoDeDestino, propriedadeDeOrigem.GetValue(objetoOrigem, null), null);
                        }
                        break;
                    }
                }
            }
            return objetoDeDestino;
        }
    }
}