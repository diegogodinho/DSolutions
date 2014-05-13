using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dados;

namespace WebApiAngularPrjWeb.Models
{
    public class Usuario
    {
        public int ID { get; set; }

        public String Nome { get; set; }

        public List<Usuario> BuscarTodos()
        {
            List<Usuario> retorno = new List<Usuario>();
            (from a in SingletonDBContext.Current.dbContext.USUARIOUNIVERSUS
             select a).ToList().ForEach(r =>
             {
                 retorno.Add(new Usuario()
                 {
                     ID = r.IDUSUARIOUNIVERSUS,
                     Nome = r.NOME
                 });
             });
            return retorno;
        }

        public Usuario BuscarPorId(int id)
        {
            USUARIOUNIVERSUS usuario = (from a in SingletonDBContext.Current.dbContext.USUARIOUNIVERSUS
                                        where a.IDUSUARIOUNIVERSUS == id
                                        select a).FirstOrDefault();
            if (usuario != null)
            {
                return new Usuario()
                {
                    ID = usuario.IDUSUARIOUNIVERSUS,
                    Nome = usuario.NOME
                };
            }
            return null;
        }
    }
}