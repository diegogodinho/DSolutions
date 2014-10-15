using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dados.Repositorio;
using Dominio.Entidades;

namespace TestDados
{
    [TestClass]
    public class UnitTest1
    {
        private UsuarioModel usuarioModel;
        private UsuarioRepositorio usuarioRepositorio;

        [TestInitialize]
        public void IncializarTestes()
        {
            usuarioRepositorio = new UsuarioRepositorio();
            usuarioModel = new UsuarioModel();
            usuarioModel.ConfirmacaoSenha = "123";
            usuarioModel.Cpf = "123";
            usuarioModel.DataNascimento = DateTime.Now;
            usuarioModel.Email = "diegogodinho.ferreira@yahoo.com.br";
            usuarioModel.idGrupo = 1;
            usuarioModel.Login = "thecs22cabuloso";
            usuarioModel.Nome = "Teste Inserção";
            usuarioModel.Senha = "123456";
            usuarioModel.SobreNome = "Godinho Ferreira Teste";            
        }

        [TestMethod]
        public void TestePersistenciaUsuario()
        {
            IncluirUsuario();
            TestarConsistenciainclusao();
            ExcluirUsuario();
            TestarNaoExistenciaUsuario();
        }
        private void TestarNaoExistenciaUsuario()
        {
            UsuarioModel usuarioInserido = usuarioRepositorio.BuscarPorID(usuarioModel.ID);
            Assert.IsTrue(usuarioInserido == null, "Usuário ainda existe na base de dados");
        }
        public void IncluirUsuario()
        {   
            usuarioRepositorio.AdicionarItem(ref usuarioModel);
        }
        public void ExcluirUsuario()
        {
            usuarioRepositorio.RemoverItem(usuarioModel);
        }
        public void TestarConsistenciainclusao()
        {
            UsuarioModel usuarioInserido = usuarioRepositorio.BuscarPorID(usuarioModel.ID);
            Assert.IsTrue(usuarioInserido.ConfirmacaoSenha == usuarioModel.ConfirmacaoSenha, "O campo confirmação de senha informado não foi ínserido como esperado");
            Assert.IsTrue(usuarioInserido.Cpf == usuarioModel.Cpf, "O campo cpf informado não foi ínserido como esperado");
            Assert.IsTrue(usuarioInserido.DataNascimento.ToShortDateString() == usuarioModel.DataNascimento.ToShortDateString(), "O campo data de nascimento informado não foi ínserido como esperado");
        }
    }
}

