using BDProjeto.Dominio;
using BDProjeto.Repositorio;
using DBProjeto.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BDProjeto.RepositorioADO
{
    public class UsuarioAplicacaoADO : IRepositorio<Usuario>
    {
        private BD bd;

        public IEnumerable<Usuario> ListaUsuarios()
        {
            var strQuery = "SELECT * FROM USUARIO";

            using (bd = new BD())
            {
                var retorno = bd.ExecutaSelect(strQuery);

                return ReaderEmLista(retorno);
            }
        }

        public Usuario ListaUsuarioPorId(string id)
        {
            var strQuery = "";
            strQuery = string.Concat(" SELECT * FROM USUARIO");
            strQuery = string.Concat(strQuery, string.Format(" WHERE ID = {0}", id));

            using (bd = new BD())
            {
                var retorno = bd.ExecutaSelect(strQuery);

                return ReaderEmLista(retorno).FirstOrDefault();
            }
        }

        private List<Usuario> ReaderEmLista(SqlDataReader reader)
        {
            var usuarios = new List<Usuario>();

            while (reader.Read())
            {
                var tempoObjeto = new Usuario()
                {                     
                    Id = int.Parse(reader["ID"].ToString()),
                    nome = reader["NOME"].ToString(),
                    cargo = reader["CARGO"].ToString(),
                    data = DateTime.Parse(reader["DATA"].ToString())
                };

                usuarios.Add(tempoObjeto);
            }

            reader.Close();
            return usuarios;
        }

        private void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery = string.Concat(strQuery, " INSERT INTO");
            strQuery = string.Concat(strQuery, " USUARIO (NOME, CARGO, DATA)");
            strQuery = string.Concat(strQuery, string.Format(" VALUES('{0}', '{1}', '{2}');", usuario.nome, usuario.cargo, usuario.data.ToString("yyyy/MM/dd")));

            using(bd = new BD())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        private void Update(Usuario usuario)
        {
            var strQuery = "";
            strQuery = string.Concat(strQuery, " UPDATE USUARIO SET");
            strQuery = string.Concat(strQuery, String.Format(" NOME = '{0}',", usuario.nome));
            strQuery = string.Concat(strQuery, String.Format(" CARGO = '{0}'", usuario.cargo));
            strQuery = string.Concat(strQuery, String.Format(" WHERE ID = {0}", usuario.Id));

            using (bd = new BD())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public void Delete(Usuario usuario)
        {
            var strQuery = "";
            strQuery = string.Concat(strQuery, " DELETE FROM USUARIO");
            strQuery = string.Concat(strQuery, string.Format(" WHERE ID = {0}", usuario.Id));

            using (bd = new BD())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Usuario usuario)
        {
            if(usuario.Id > 0)
            {
                Update(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }
    }
}
