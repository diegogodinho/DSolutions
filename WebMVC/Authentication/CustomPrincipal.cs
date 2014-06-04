﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace WebMVC.Authentication
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public string Nome { get; private set; }
        public List<Grupo> Grupos { get; private set; }

        public CustomPrincipal(string nome,List<Grupo> grupos)
        {
            Nome = nome;
            Identity = new GenericIdentity(nome);
            Grupos = grupos;
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return Grupos.Any(r => r.Nome == role);
        }

        public bool PermiteAcessoAFuncionalidade(string funcionalidade)
        {
            return Grupos.Any(delegate(Grupo grupo)
            {
                if (grupo.Funcionalidades != null)
                {
                    return grupo.Funcionalidades.Any(f => f.NomeFuncionalidade == funcionalidade);
                }
                else
                    return false;
            });
        }

        public bool PermiteAcessoAAcao(string funcionalidade, Acao acao)
        {
            return Grupos.Any(delegate(Grupo grupo)
            {
                if (grupo.Funcionalidades != null)
                {
                    return grupo.Funcionalidades.Any(f => f.NomeFuncionalidade == funcionalidade && f.Acao == acao);
                }
                else
                    return false;
            });
        }
    }
}