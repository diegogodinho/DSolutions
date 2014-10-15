using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Web.Comum.Validators;
using System.Web.Mvc;

namespace Dominio.Entidades
{
    //[PropertiesMustMatch("Senha", "ConfirmacaoSenha", ErrorMessage = "A senha e a confirmação da senha não conferem.")]
    public class UsuarioModel : BaseModel
    {
        //[Required]
        //[DisplayName("Login")]
        public virtual string Login { get; set; }

        //[Required]
        //[DisplayName("Nome")]
        public virtual string Nome { get; set; }

        //[Required]
        //[DisplayName("Sobrenome")]
        public virtual string SobreNome { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //[DisplayName("Email")]
        public virtual string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[DisplayName("Senha")]
        public virtual string Senha { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[DisplayName("Confirmação de senha")]
        public virtual string ConfirmacaoSenha { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        //[DisplayName("Data de Nascimento")]
        public virtual DateTime DataNascimento { get; set; }

        //[Required]
        //[DataType(DataType.Text)]
        //[DisplayName("CPF")]
        public virtual string Cpf { get; set; }


        //[DisplayName("Foto")]
        public Byte[] Foto { get; set; }

        //[DisplayName("Grupo")]
        public Int32? idGrupo { get; set; }

        public GrupoModel Grupo { get; set; }

        public List<SelectListItem> GruposDisponiveis { get; set; }


        public string FotoString { get; set; }
    }
}
