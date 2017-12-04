using BDProjeto.Dominio;
using System;

namespace BDProjeto.Aplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = string.Empty;
            var usuario = new Usuario();
            var usuarioApp = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();

            //BUSCA REGISTRO
            var lstUsuarios = usuarioApp.ListaUsuarios();

            foreach(var item in lstUsuarios)
            {
                Console.WriteLine("ID: " + item.Id);
                Console.WriteLine("Nome: " + item.nome);
                Console.WriteLine("Cargo: " + item.cargo);
                Console.WriteLine("Data de admissão: " + item.data.ToShortDateString());
                Console.WriteLine("");
                Console.WriteLine("==========================================");
                Console.WriteLine("");
            }

            Console.WriteLine("Escolha a opção desejada:");
            Console.WriteLine("1 - Inserir registro");
            Console.WriteLine("2 - Alterar registro");
            Console.WriteLine("3 - Excluir registro");
            Console.WriteLine("4 - Sair");
            string opcao = Console.ReadLine();
            
            switch(opcao)
            {
                //INSERE REGISTRO
                case "1" :
                    Console.WriteLine("Digite o nome do funcionário:");
                    usuario.nome = Console.ReadLine();
                    Console.WriteLine("Digite o cargo do funcionário:");
                    usuario.cargo = Console.ReadLine();
                    Console.WriteLine("Digite a data de admissão do funcionário:");
                    usuario.data = Convert.ToDateTime(Console.ReadLine());
                    usuarioApp.Salvar(usuario);
                    Console.WriteLine("Funcionário inserido com sucesso");
                    break;
                //ALTERA REGISTRO
                case "2":
                    Console.WriteLine("Escolha o ID do funcionário a ser alterado:");
                    usuario.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o nome do funcionário:");
                    usuario.nome = Console.ReadLine();
                    Console.WriteLine("Digite o cargo do funcionário:");
                    usuario.cargo = Console.ReadLine();
                    usuarioApp.Salvar(usuario);
                    Console.WriteLine("Funcionário alterado com sucesso");
                    break;
                //DELETA REGISTRO
                case "3":
                    Console.WriteLine("Escolha o ID do funcionário a ser excluido:");
                    usuario.Id = Convert.ToInt32(Console.ReadLine());
                    usuarioApp.Delete(usuario);
                    Console.WriteLine("Funcionário excluido com sucesso");
                    break;
                case "4":
                    break;
            }
        }
    }
}
