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

namespace WebMVC.Models
{

    #region Models
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
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }

    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public class RegisterModel
    {
        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string Email { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }
    }
    #endregion

    #region Services


    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password, out CustomPrincipal principal);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password, out CustomPrincipal principal)
        {
            principal = null;
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            var usuariouniversus = (from usuarioUniversus in SingletonDBContext.Current.dbContext.USUARIOUNIVERSUS
                                    where usuarioUniversus.SENHAPADRAO == password && usuarioUniversus.LOGIN == userName
                                    select new
                                    {
                                        usuarioUniversus.NOME,
                                        usuarioGrupo = usuarioUniversus.USUARIOGRUPO.Select(r => new
                                        {
                                            nomeGrupo = r.GRUPO.NOMEGRUPO.TrimEnd(),
                                            funcionalidades = r.GRUPO.FUNCIONALIDADEGRUPO.Select(f => new
                                            {
                                                nome = f.FUNCIONALIDADE.NOMEFUNCIONALIDADE.TrimEnd(),
                                                codigoFuncionalidade = f.FUNCIONALIDADE.CODFUNCIONALIDADE.TrimEnd(),
                                                permiteCriacao = f.PERMITECRIACAO,
                                                permiteLeitura = f.PERMITELEITURA,
                                                permiteAlteracao = f.PERMITEALTERACAO,
                                                permiteExclusao = f.PERMITEEXCLUSAO
                                            })
                                        })
                                    }).FirstOrDefault();

            if (usuariouniversus != null)
            {
                List<Grupo> grupos = new List<Grupo>();

                usuariouniversus.usuarioGrupo.ToList().ForEach(usugrupo =>
                    {
                        Grupo grupo = new Grupo();
                        grupo.Nome = usugrupo.nomeGrupo;
                        grupo.Funcionalidades = new List<Funcionalidade>();
                        usugrupo.funcionalidades.ToList().ForEach(funcGrupo =>
                            {
                                Funcionalidade funcionalidade = new Funcionalidade();
                                funcionalidade.NomeFuncionalidade = funcGrupo.nome;
                                funcionalidade.CodigoFuncionalidade = funcGrupo.codigoFuncionalidade;
                                funcionalidade.PermiteCriacao = funcGrupo.permiteCriacao.HasValue ? funcGrupo.permiteCriacao.Value : 0;
                                funcionalidade.PermiteLeitura = funcGrupo.permiteLeitura.HasValue ? funcGrupo.permiteLeitura.Value : 0;
                                funcionalidade.PermiteAlteracao = funcGrupo.permiteAlteracao.HasValue ? funcGrupo.permiteAlteracao.Value : 0;
                                funcionalidade.PermiteExclusao = funcGrupo.permiteExclusao.HasValue ? funcGrupo.permiteExclusao.Value : 0;
                                grupo.Funcionalidades.Add(funcionalidade);
                            });
                        grupos.Add(grupo);

                    });
                principal = new CustomPrincipal(userName, grupos);
                return true;
            }
            return false;

            //return _provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }
    }
    #endregion



}
