using BDProjeto.Dominio;
using DBProjeto.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.RepositorioEF
{
    public class UsuarioRepositorioEF : IRepositorio<Usuario>
    {
        private readonly BD bd;

        public UsuarioRepositorioEF()
        {
            bd = new BD();
        }

        public void Delete(Usuario entidade)
        {
            var usuarioExcluir = bd.usuario.First(x => x.Id == entidade.Id);
            bd.usuario.Remove(usuarioExcluir);
            bd.SaveChanges();
        }

        public Usuario ListaUsuarioPorId(string valor)
        {   
            return bd.usuario.First(x => x.Id.ToString() == valor);
        }

        public IEnumerable<Usuario> ListaUsuarios()
        {
            var usuarios = bd.usuario;
            return usuarios;
        }

        public void Salvar(Usuario entidade)
        {
            if(entidade.Id > 0)
            {
                var usuarioAlterar = bd.usuario.First(x => x.Id == entidade.Id);
                usuarioAlterar.nome = entidade.nome;
                usuarioAlterar.cargo = entidade.cargo;
                usuarioAlterar.data = entidade.data;
            }
            else
            {
                bd.usuario.Add(entidade);
            }

            bd.SaveChanges();
        }
    }
}
