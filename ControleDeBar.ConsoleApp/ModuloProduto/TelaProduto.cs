using System.Collections;
using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase
    {

        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            repositorioBase = repositorioProduto;
            nomeEntidade = "Produto";
            sufixo = "s ";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Preço");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Produto produto in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", produto.id, produto.nome, $"R${produto.preco}");
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("\nInsira o nome: ");
            string nome = Console.ReadLine();
            Console.Write("\nInsira a descricao: ");
            string descricao = Console.ReadLine();
            Console.Write("\nInsira o preço: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            return new Produto(nome, descricao, preco);

        }
    }

}
