using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using Web.Comum.Authentication;

namespace Dados.Repositorio
{
    public class UsuarioRepositorio : BaseRepository<UsuarioModel>
    {
        public bool ValidarUsuario(string userName, string password, out CustomPrincipal principal)
        {
            principal = null;
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            var usuario = (from usuarioDB in SingletonDBContext.Current.dbContext.USUARIO
                           where usuarioDB.SENHA == password && usuarioDB.LOGIN == userName
                           select new
                           {
                               usuarioDB.NOME,
                               usuarioGrupo = new { Nome = usuarioDB.GRUPO.NOMEGRUPO, IDGrupo = usuarioDB.GRUPO.IDGRUPO }
                           }).FirstOrDefault();

            if (usuario != null)
            {
                Grupo grupo = new Grupo();
                grupo.Nome = usuario.usuarioGrupo.Nome;
                grupo.ID = usuario.usuarioGrupo.IDGrupo;
                principal = new CustomPrincipal(userName, grupo);
                return true;
            }
            return false;
        }

        //public List<UsuarioModel> BuscarTodos()
        //{
        //    return SingletonDBContext.Current.dbContext.USUARIO.ToList().Select(r =>
        //        new UsuarioModel()
        //        {
        //            Login = r.LOGIN,
        //            ID = r.ID,
        //            Nome = r.NOME,
        //            Cpf = r.CPF,
        //            DataNascimento = r.DATANASCIMENTO,
        //            Email = r.EMAIL,
        //            Foto = r.FOTO,
        //            idGrupo = r.IDGRUPO.HasValue ? r.IDGRUPO.Value : 0,
        //            SobreNome = r.SOBRENOME,
        //            Grupo = r.IDGRUPO.HasValue ? new GrupoModel() { ID = r.GRUPO.IDGRUPO, NomeGrupo = r.GRUPO.NOMEGRUPO } : null
        //        }).ToList();
        //}

        //public UsuarioModel BuscarPorID(int ID)
        //{
        //    USUARIO usuario = ContextDBHelp.FindByID<USUARIO>(ID);
        //    if (usuario != null)
        //    {
        //        UsuarioModel usuarioModel = BaseModel.AdaptarTipos<USUARIO, UsuarioModel>(usuario);
        //        if (usuario.GRUPO != null)
        //            usuarioModel.Grupo = BaseModel.AdaptarTipos<GRUPO, GrupoModel>(usuario.GRUPO);

        //        return usuarioModel;
        //    }
        //    else return null;

        //    //UsuarioModel retorno = (from r in SingletonDBContext.Current.dbContext.USUARIO
        //    //                        where r.ID == ID
        //    //                        select new UsuarioModel
        //    //                        {
        //    //                            Login = r.LOGIN,
        //    //                            ID = r.ID,
        //    //                            Nome = r.NOME,
        //    //                            Cpf = r.CPF,
        //    //                            DataNascimento = r.DATANASCIMENTO,
        //    //                            Email = r.EMAIL,
        //    //                            Foto = r.FOTO,
        //    //                            idGrupo = r.IDGRUPO.Value,
        //    //                            SobreNome = r.SOBRENOME,
        //    //                            Grupo = new GrupoModel() { ID = r.GRUPO.IDGRUPO, NomeGrupo = r.GRUPO.NOMEGRUPO }
        //    //                        }).FirstOrDefault();
        //    //return retorno;
        //}

        //public void AdicionarItem(UsuarioModel item)
        //{
        //    USUARIO a = WebMVC.Models.BaseModel.AdaptarTipos<UsuarioModel, USUARIO>(item);
        //    SingletonDBContext.Current.dbContext.AddToUSUARIO(a);
        //    SingletonDBContext.Current.dbContext.SaveChanges();
        //}

        //public void ExcluirItem(UsuarioModel item)
        //{
        //    try
        //    {
        //        USUARIO usuario = (from a in SingletonDBContext.Current.dbContext.USUARIO
        //                           where a.ID == item.ID
        //                           select a).FirstOrDefault();
        //        if (usuario != null)
        //        {
        //            SingletonDBContext.Current.dbContext.USUARIO.DeleteObject(usuario);
        //            SingletonDBContext.Current.dbContext.SaveChanges();
        //        }
        //    }
        //    catch (UpdateException)
        //    {
        //        throw new Exception("Exclusão não permitida, existe dependência para registro corrente!");
        //    }

        //}

        //public void EditarItem(UsuarioModel item)
        //{
        //    USUARIO usuario = (from a in SingletonDBContext.Current.dbContext.USUARIO
        //                       where a.ID == item.ID
        //                       select a).FirstOrDefault();
        //    if (usuario != null)
        //    {
        //        usuario.NOME = item.Nome;
        //        usuario.CPF = item.Cpf;
        //        usuario.SOBRENOME = item.SobreNome;
        //        usuario.EMAIL = item.Email;
        //        usuario.DATANASCIMENTO = item.DataNascimento;
        //        usuario.IDGRUPO = item.idGrupo;
        //        SingletonDBContext.Current.dbContext.SaveChanges();
        //    }
        //}

        //public override USUARIO entity
        //{
        //    get { return new USUARIO(); }
        //}
    }
}
