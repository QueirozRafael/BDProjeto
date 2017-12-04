using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BDProjeto.Repositorio
{
    public class BD : IDisposable
    {
        private readonly SqlConnection conexao;

        public BD()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conectionBD"].ToString());
            conexao.Open();
        }
        
        /// <summary>
        /// Método para Insert, Update, Delete
        /// </summary>
        /// <param name="strQuery"></param>
        public void ExecutaComando(string strQuery)
        {
            var command = new SqlCommand()
            {
                CommandText = strQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao,
            };

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Método para Select
        /// </summary>
        /// <param name="strQuery"></param>
        public SqlDataReader ExecutaSelect(string strQuery)
        {
            var commandSelect = new SqlCommand(strQuery, conexao);
            return commandSelect.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
