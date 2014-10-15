using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Script.Serialization;
using Dados;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Reflection;
using Web.Comum.Validators;

namespace WebMVC.Models
{
    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Current password")]
        public string OldPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm new password")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [DisplayName("Usuário")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }

    

    

    //public abstract class BaseRepository<TBancoDeDados, TModel>
    //    where TBancoDeDados : EntityObject, ITableBase
    //    where TModel : BaseModel, new()
    //{
    //    public virtual List<TModel> BuscarTodos()
    //    {
    //        List<TModel> retorno = new List<TModel>();
    //        List<TBancoDeDados> listaDoBanco = SingletonDBContext.Current.dbContext.CreateObjectSet<TBancoDeDados>().ToList();
    //        foreach (TBancoDeDados item in listaDoBanco)
    //        {
    //            retorno.Add(AdaptarTipos<TBancoDeDados, TModel>(item));
    //        }
    //        return retorno;
    //    }

    //    public virtual TModel BuscarPorID(int ID)
    //    {
    //        TBancoDeDados objBanco = ContextDBHelp.FindByID<TBancoDeDados>(ID);
    //        return AdaptarTipos<TBancoDeDados, TModel>(objBanco);
    //    }

    //    public virtual void AdicionarItem(TModel item)
    //    {
    //        TBancoDeDados objConvertido = BaseModel.PreencherValores<TModel, TBancoDeDados>(item, entity);
    //        objConvertido.Save();
    //    }

    //    public virtual void ExcluirItem(TModel item)
    //    {
    //        TBancoDeDados objConvertido = BaseModel.PreencherValores<TModel, TBancoDeDados>(item, entity);
    //        objConvertido.Delete();
    //    }

    //    public virtual void ExcluirItem(int ID)
    //    {
    //        TBancoDeDados objBanco = ContextDBHelp.FindByID<TBancoDeDados>(ID);
    //        objBanco.Delete();
    //    }

    //    public virtual void EditarItem(TModel item)
    //    {
    //        TBancoDeDados objConvertido = BaseModel.PreencherValores<TModel, TBancoDeDados>(item, entity);
    //        objConvertido.Save();
    //    }

    //    public abstract TBancoDeDados entity { get; }

    //    private static object EncontrarMapeamento(object model)
    //    {
    //        string nameModel = model.GetType().Name;
    //        Mapeamento mapeamento = new Mapeamento();
    //        object retorno = null;

    //        foreach (PropertyInfo property in typeof(Mapeamento).GetProperties())
    //        {
    //            if (property.Name.ToUpper() == nameModel.ToUpper())
    //            {
    //                retorno = property.GetValue(mapeamento, null);
    //                break;
    //            }
    //        }
    //        return retorno;
    //    }

    //    private static void MapearObjetoDeAcordoComOMapeamento(object model)
    //    {
    //        object objdoMapeamento = EncontrarMapeamento(model);
    //        MethodInfo metodoAdaptadorDeTipos = typeof(BaseModel).GetMethod("AdaptarTipos");
    //        MethodInfo copiarObjetoGeneric = metodoAdaptadorDeTipos.MakeGenericMethod(typeof(TModel), objdoMapeamento.GetType());
    //        object retorno = copiarObjetoGeneric.Invoke(null, new object[] { model });
    //    }
    //    public static TDestino AdaptarTipos<TOrigem, TDestino>(TOrigem objetoOrigem)
    //      where TDestino : class,new()
    //    {
    //        TDestino objetoDeDestino = new TDestino();
    //        PropertyInfo[] propriedadesDeOrigem = objetoOrigem.GetType().GetProperties();
    //        PropertyInfo[] propriedadesDeDestino = objetoDeDestino.GetType().GetProperties();
    //        foreach (PropertyInfo propriedadeDeOrigem in propriedadesDeOrigem)
    //        {
    //            foreach (PropertyInfo propriedadeDeDestino in propriedadesDeDestino)
    //            {
    //                if (propriedadeDeOrigem.Name.ToUpper() == propriedadeDeDestino.Name.ToUpper())
    //                {
    //                    if (propriedadeDeDestino.CanWrite && propriedadeDeOrigem.PropertyType == propriedadeDeDestino.PropertyType)
    //                    {
    //                        propriedadeDeDestino.SetValue(objetoDeDestino, propriedadeDeOrigem.GetValue(objetoOrigem, null), null);
    //                    }
    //                    //else
    //                    //{
    //                    //    MapearObjetoDeAcordoComOMapeamento(propriedadeDeDestino);
    //                    //}
    //                    break;
    //                }
                    
    //            }
    //        }
    //        return objetoDeDestino;
    //    }

    //}

   
}

