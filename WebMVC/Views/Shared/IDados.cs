using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace WebMVC.Views.Shared
{
    public interface IDados<T> where T : class
    {
        List<T> BuscarTodos();
        T BuscarPorID(int ID);
        //List<T> BuscarPorFiltro(Expression<Func<T, bool>> filtro);
        void AdicionarItem(T item);
        void ExcluirItem(T item);
        void EditarItem(T item);
    }
}