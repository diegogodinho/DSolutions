using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace Dados
{
    public abstract class BaseRepository<TModel> where TModel : new()
    {
        public object EntidadeMapeamento { get; private set; }

        private ContextDB _dbContext { get; set; }

        public BaseRepository()
        {
            _dbContext = SingletonDBContext.Current.dbContext;
        }

        public List<TModel> BucarTodos()
        {
            try
            {
                object objectSet = ObterObjectSet();
                return MontarObjetosDeModelo(((IEnumerable<EntityObject>)objectSet).ToList());

            }
            catch (Exception)
            {
                throw;
            }
        }

        public TModel BuscarPorID(int ID)
        {
            object objectSet = ObterObjectSet();
            MethodInfo metodo = this.GetType().GetMethod("GetObjectById");
            MethodInfo copiarObjetoGeneric = metodo.MakeGenericMethod(EntidadeMapeamento.GetType());
            object objct = copiarObjetoGeneric.Invoke(this, new object[] { objectSet, ID });
            return MontarObjetoDeModelo((EntityObject)objct);
        }

        public T GetObjectById<T>(ObjectSet<T> objectSet, int id) where T : class, ITableBase
        {
            return objectSet.SingleOrDefault(e => e.ID == id);
        }

        private object ObterObjectSet()
        {
            EncontrarMapeamento();

            if (EntidadeMapeamento is EntityObject)
            {
                MethodInfo metodo = typeof(ContextDB).GetMethod("CreateObjectSet", new Type[0]);
                MethodInfo copiarObjetoGeneric = metodo.MakeGenericMethod(EntidadeMapeamento.GetType());
                return copiarObjetoGeneric.Invoke(SingletonDBContext.Current.dbContext, null);
            }
            return null;
        }

        private List<TModel> MontarObjetosDeModelo(List<EntityObject> listaDadosBanco)
        {
            List<TModel> retorno = new List<TModel>();
            EncontrarMapeamento();

            MethodInfo metodoAdaptadorDeTipos = this.GetType().GetMethod("AdaptarTipos");

            foreach (EntityObject objMapeado in listaDadosBanco)
            {
                MethodInfo copiarObjetoGeneric = metodoAdaptadorDeTipos.MakeGenericMethod(objMapeado.GetType(), typeof(TModel));
                TModel objConvertido = (TModel)copiarObjetoGeneric.Invoke(this, new object[] { objMapeado });
                retorno.Add(objConvertido);
            }
            return retorno;
        }

        private TModel MontarObjetoDeModelo(EntityObject objetoBancoDeDados)
        {
            TModel retorno = new TModel();
            EncontrarMapeamento();

            MethodInfo metodoAdaptadorDeTipos = this.GetType().GetMethod("AdaptarTipos");

            MethodInfo copiarObjetoGeneric = metodoAdaptadorDeTipos.MakeGenericMethod(objetoBancoDeDados.GetType(), typeof(TModel));
            return (TModel)copiarObjetoGeneric.Invoke(this, new object[] { objetoBancoDeDados });
        }

        private void EncontrarMapeamento()
        {
            if (EntidadeMapeamento == null)
            {
                string nameModel = typeof(TModel).Name;
                Mapeamento mapeamento = new Mapeamento();

                foreach (PropertyInfo property in typeof(Mapeamento).GetProperties())
                {
                    if (property.Name.ToUpper() == nameModel.ToUpper())
                    {
                        EntidadeMapeamento = property.GetValue(mapeamento, null);
                        break;
                    }
                }
            }
        }

        public TDestino AdaptarTipos<TOrigem, TDestino>(TOrigem objetoOrigem)
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
                        if (propriedadeDeDestino.CanWrite && propriedadeDeOrigem.PropertyType == propriedadeDeDestino.PropertyType)
                        {
                            propriedadeDeDestino.SetValue(objetoDeDestino, propriedadeDeOrigem.GetValue(objetoOrigem, null), null);
                        }
                        break;
                    }
                }
            }
            return objetoDeDestino;
        }

        public void AdicionarItem(ref TModel model)
        {
            ObterObjectSet();
            EntityObject objConvertido = ConverterEntidadeModeloParaEntidadeDeBanco(model);
            _dbContext.AddObject(_dbContext.GetEntitySetName(objConvertido), objConvertido);
            _dbContext.SaveChanges();
            model = ConverterEntidadeDeBancoParaEntidadeModelo(objConvertido);
        }

        public void RemoverItem(TModel model)
        {
            ObterObjectSet();
            EntityObject objConvertido = ConverterEntidadeModeloParaEntidadeDeBanco(model);
            string teste = _dbContext.GetEntitySetName(objConvertido);
            _dbContext.AttachTo(teste, objConvertido);
            _dbContext.DeleteObject(objConvertido);
            _dbContext.SaveChanges();
        }

        private EntityObject ConverterEntidadeModeloParaEntidadeDeBanco(TModel instanciaEntidadeModelo)
        {
            MethodInfo metodoAdaptadorDeTipos = this.GetType().GetMethod("AdaptarTipos");
            MethodInfo copiarObjetoGeneric = metodoAdaptadorDeTipos.MakeGenericMethod(typeof(TModel), EntidadeMapeamento.GetType());
            return (EntityObject)copiarObjetoGeneric.Invoke(this, new object[] { instanciaEntidadeModelo });
        }

        private TModel ConverterEntidadeDeBancoParaEntidadeModelo(object instanciaEntidadeBanco)
        {
            MethodInfo metodoAdaptadorDeTipos = this.GetType().GetMethod("AdaptarTipos");
            MethodInfo copiarObjetoGeneric = metodoAdaptadorDeTipos.MakeGenericMethod(EntidadeMapeamento.GetType(), typeof(TModel));
            return (TModel)copiarObjetoGeneric.Invoke(this, new object[] { instanciaEntidadeBanco });
        }
    }
}
