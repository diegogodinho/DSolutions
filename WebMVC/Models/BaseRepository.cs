using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dados;
using System.Data.Objects;
namespace WebMVC.Models
{
    public abstract class BaseRepository<T> where T : class
    {
        protected void AdicionarItem(T entity)
        {
            ObjectSet<T> objectSet = SingletonDBContext.Current.dbContext.CreateObjectSet<T>();
            objectSet.AddObject(entity);
            SingletonDBContext.Current.dbContext.SaveChanges();
        }

        protected void RemoverItem(T entity)
        {
            ObjectSet<T> objectSet = SingletonDBContext.Current.dbContext.CreateObjectSet<T>();            
            objectSet.DeleteObject(entity);
            SingletonDBContext.Current.dbContext.SaveChanges();
        }
    }
}