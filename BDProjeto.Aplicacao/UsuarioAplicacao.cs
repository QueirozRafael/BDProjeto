using BDProjeto.Dominio;
using BDProjeto.RepositorioADO;
using DBProjeto.Dominio.Contrato;
using System.Collections.Generic;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly IRepositorio<Usuario> repositorio;

        public UsuarioAplicacao(IRepositorio<Usuario> iRepositorio)
        {
            repositorio = iRepositorio;
        }
        
        public IEnumerable<Usuario> ListaUsuarios()
        {
            return repositorio.ListaUsuarios();
        }

        public Usuario ListaUsuarioPorId(string id)
        {
            return repositorio.ListaUsuarioPorId(id);
        }

        public void Delete(Usuario usuario)
        {
            repositorio.Delete(usuario);
        }

        public void Salvar(Usuario usuario)
        {
            repositorio.Salvar(usuario);
        }
    }
}
