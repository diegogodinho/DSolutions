using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data;
using System.Data.Objects;
using System.Data.Metadata.Edm;

namespace Dados
{
    public static class ContextDBHelp
    {
        /// <summary>
        /// Save the reocrd to related table, if the primary key passed update it else add it.
        /// </summary>
        /// <param name="objEntity">Entity Object</param>
        public static void Save(this EntityObject objEntity)
        {
            try                                       // Update record.
            {
                SingletonDBContext.Current.dbContext.DetachObject(objEntity);
                SingletonDBContext.Current.dbContext.AttachTo(SingletonDBContext.Current.dbContext.GetEntitySetName(objEntity), objEntity);
                SingletonDBContext.Current.dbContext.ObjectStateManager.ChangeObjectState(objEntity, EntityState.Modified);
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
            catch (OptimisticConcurrencyException)   // Insert if found the record is already exists.
            {
                SingletonDBContext.Current.dbContext.DetachObject(objEntity);
                SingletonDBContext.Current.dbContext.AddObject(SingletonDBContext.Current.dbContext.GetEntitySetName(objEntity), objEntity);
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
            catch (Exception)
            { 

            }
        }

        /// <summary>
        /// Delete the record from related table. The primary key value must be filled.
        /// </summary>
        /// <param name="objEntity">Entity Object</param>
        public static void Delete(this EntityObject objEntity)
        {
            if (objEntity != null)
            {
                SingletonDBContext.Current.dbContext.DetachObject(objEntity);
                SingletonDBContext.Current.dbContext.Attach(objEntity);
                SingletonDBContext.Current.dbContext.ObjectStateManager.ChangeObjectState(objEntity, EntityState.Deleted);
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }

        public static string GetEntitySetName(this ObjectContext Context, EntityObject entity)
        {
            string entityTypeName = entity.GetType().Name;
            var container = Context.MetadataWorkspace.GetEntityContainer(Context.DefaultContainerName, DataSpace.CSpace);
            return container.BaseEntitySets.FirstOrDefault(meta => meta.ElementType.Name == entityTypeName).Name;
        }

        public static void DetachObject(this ObjectContext Context, EntityObject entity)
        {
            if (entity.EntityKey != null)
            {
                object objentity = null;
                var exist = Context.TryGetObjectByKey(entity.EntityKey, out objentity);
                if (exist) { Context.Detach(entity); }
            }
        }

        public static T FindByID<T>(int ID) where T : EntityObject, ITableBase
        {
            return SingletonDBContext.Current.dbContext.CreateObjectSet<T>().SingleOrDefault(r => r.ID == ID);
        }
    }
}
