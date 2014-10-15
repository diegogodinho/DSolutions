using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class Mapeamento
    {
        public USUARIO UsuarioModel
        {
            get
            {
                return new USUARIO();
            }
        }
        public BAIRRO BairroModel
        {
            get
            {
                return new BAIRRO();
            }
        }

        public GRUPO GrupoModel
        {
            get
            {
                return new GRUPO();
            }
        }
    }
}
