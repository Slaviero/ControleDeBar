using System.Collections;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class TelaGarcom : TelaBase
    {

        public TelaGarcom(RepositorioGarcom repositorioGarcom) 
        {
            repositorioBase = repositorioGarcom;
            nomeEntidade = "Garçon";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Cpf");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Garcom garcom in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", garcom.id, garcom.nome, garcom.cpf);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {

            Console.Write("\nInsira o nome: ");
            string nome = Console.ReadLine();
            Console.Write("\nInsira o CPF: ");
            string cpf = Console.ReadLine();

            return new Garcom(nome, cpf);

        }
    }

}
