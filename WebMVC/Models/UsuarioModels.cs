using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC.Authentication;
using System.Web.Script.Serialization;
using WebMVC.Validators;
using Dados;
using System.Web.UI.WebControls;
using System.Data;

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

    [PropertiesMustMatch("Senha", "ConfirmacaoSenha", ErrorMessage = "A senha e a confirmação da senha não conferem.")]
    public class UsuarioModel : BaseModel
    {
        [Required]
        [DisplayName("Login")]
        public virtual string Login { get; set; }

        [Required]
        [DisplayName("Nome")]
        public virtual string Nome { get; set; }

        [Required]
        [DisplayName("Sobrenome")]
        public virtual string SobreNome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public virtual string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public virtual string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirmação de senha")]
        public virtual string ConfirmacaoSenha { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Data de Nascimento")]
        public virtual DateTime DataNascimento { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("CPF")]
        public virtual string Cpf { get; set; }


        [DisplayName("Foto")]
        public Byte[] Foto { get; set; }

        [DisplayName("Grupo")]
        public int idGrupo { get; set; }

        public GrupoModel Grupo { get; set; }

        public List<SelectListItem> GruposDisponiveis { get; set; }


        public string FotoString { get; set; }
    }


    public class UsuarioEdicaoModel : UsuarioModel
    {
        [DataType(DataType.Password)]
        [DisplayName("Confirmação de senha")]
        public override string ConfirmacaoSenha
        {
            get
            {
                return base.ConfirmacaoSenha;
            }
            set
            {
                base.ConfirmacaoSenha = value;
            }
        }

        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public override string Senha
        {
            get
            {
                return base.Senha;
            }
            set
            {
                base.Senha = value;
            }
        }

        [DisplayName("Login")]
        public override string Login
        {
            get
            {
                return base.Login;
            }
            set
            {
                base.Login = value;
            }
        }
    }

    public class UsuarioRepository
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

        public List<UsuarioModel> BuscarTodos()
        {
            return SingletonDBContext.Current.dbContext.USUARIO.ToList().Select(r =>
                new UsuarioModel()
                {
                    Login = r.LOGIN,
                    ID = r.ID,
                    Nome = r.NOME,
                    Cpf = r.CPF,
                    DataNascimento = r.DATANASCIMENTO,
                    Email = r.EMAIL,
                    Foto = r.FOTO,
                    idGrupo = r.IDGRUPO.HasValue ? r.IDGRUPO.Value : 0,
                    SobreNome = r.SOBRENOME,
                    Grupo = r.IDGRUPO.HasValue ? new GrupoModel() { ID = r.GRUPO.IDGRUPO, NomeGrupo = r.GRUPO.NOMEGRUPO } : null
                }).ToList();
        }

        public UsuarioModel BuscarPorID(int ID)
        {
            UsuarioModel retorno = (from r in SingletonDBContext.Current.dbContext.USUARIO
                                    where r.ID == ID
                                    select new UsuarioModel
                                    {
                                        Login = r.LOGIN,
                                        ID = r.ID,
                                        Nome = r.NOME,
                                        Cpf = r.CPF,
                                        DataNascimento = r.DATANASCIMENTO,
                                        Email = r.EMAIL,
                                        Foto = r.FOTO,
                                        idGrupo = r.IDGRUPO.Value,
                                        SobreNome = r.SOBRENOME,
                                        Grupo = new GrupoModel() { ID = r.GRUPO.IDGRUPO, NomeGrupo = r.GRUPO.NOMEGRUPO }
                                    }).FirstOrDefault();
            return retorno;
        }

        public void AdicionarItem(UsuarioModel item)
        {
            USUARIO a = WebMVC.Models.BaseModel.AdaptarTipos<UsuarioModel, USUARIO>(item);
            SingletonDBContext.Current.dbContext.AddToUSUARIO(a);
            SingletonDBContext.Current.dbContext.SaveChanges();
        }

        public void ExcluirItem(UsuarioModel item)
        {
            try
            {
                USUARIO usuario = (from a in SingletonDBContext.Current.dbContext.USUARIO
                                   where a.ID == item.ID
                                   select a).FirstOrDefault();
                if (usuario != null)
                {
                    SingletonDBContext.Current.dbContext.USUARIO.DeleteObject(usuario);
                    SingletonDBContext.Current.dbContext.SaveChanges();
                }
            }
            catch (UpdateException)
            {
                throw new Exception("Exclusão não permitida, existe dependência para registro corrente!");
            }

        }

        public void EditarItem(UsuarioModel item)
        {
            USUARIO usuario = (from a in SingletonDBContext.Current.dbContext.USUARIO
                               where a.ID == item.ID
                               select a).FirstOrDefault();
            if (usuario != null)
            {
                usuario.NOME = item.Nome;
                usuario.CPF = item.Cpf;
                usuario.SOBRENOME = item.SobreNome;
                usuario.EMAIL = item.Email;
                usuario.DATANASCIMENTO = item.DataNascimento;
                usuario.IDGRUPO = item.idGrupo;
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }
    }
}
