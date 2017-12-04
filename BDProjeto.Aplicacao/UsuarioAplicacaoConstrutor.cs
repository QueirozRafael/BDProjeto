using BDProjeto.RepositorioADO;
using BDProjeto.RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacaoConstrutor
    {
        public static UsuarioAplicacao UsuarioAplicacaoADO()
        {
            return new UsuarioAplicacao(new UsuarioAplicacaoADO());
        }

        public static UsuarioAplicacao UsuarioAplicacaoEF()
        {
            return new UsuarioAplicacao(new UsuarioRepositorioEF());
        }
    }
}
