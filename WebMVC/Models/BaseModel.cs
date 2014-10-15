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
        [Key]
        public int ID { get; set; }        
       
       

        //public static TDestino PreencherValores<TOrigem, TDestino>(TOrigem objetoOrigem, TDestino objetoDestino)          
        //{
        //    PropertyInfo[] propriedadesDeOrigem = objetoOrigem.GetType().GetProperties();
        //    PropertyInfo[] propriedadesDeDestino = objetoDestino.GetType().GetProperties();
        //    foreach (PropertyInfo propriedadeDeOrigem in propriedadesDeOrigem)
        //    {
        //        foreach (PropertyInfo propriedadeDeDestino in propriedadesDeDestino)
        //        {
        //            if (propriedadeDeOrigem.Name.ToUpper() == propriedadeDeDestino.Name.ToUpper())
        //            {
        //                if (propriedadeDeDestino.CanWrite)
        //                {
        //                    propriedadeDeDestino.SetValue(objetoDestino, propriedadeDeOrigem.GetValue(objetoOrigem, null), null);
        //                }
        //                break;
        //            }
        //        }
        //    }
        //    return objetoDestino;
        //}
    }
}