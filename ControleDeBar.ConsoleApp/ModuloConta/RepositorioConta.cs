using System.Collections;
using ControleDeBar.ConsoleApp.Compartilhado;
using Microsoft.Win32;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {

        public ArrayList Pedidos = new ArrayList();

        public RepositorioConta(ArrayList listaContas)
        {
            this.listaRegistros = listaContas;
        }

        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Conta)base.SelecionarPorId(id);

        }
        public bool FecharConta(int idParametro)
        {
            foreach (Conta conta in listaRegistros)
            {
                if (idParametro == conta.id && conta.status != false)
                {
                    conta.status = false;
                    return true;
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Nenhuma conta aberta encontrada com essa identificação, verifique o Id correspondente e tente novamente.");
            Console.ResetColor();
            Console.ReadLine();
            return false;
        }

        public void ObterFaturamento()
        {

            Console.WriteLine("{0, -10} | {1, -30} | {2, -20}| {3, -20}", "Id", "Nome Cliente", "Número da mesa", "Valor total pedidos");

            Console.WriteLine("--------------------------------------------------------------------------------------------------------");

            decimal totalPedidoDaConta = 0;
            foreach (Conta conta in listaRegistros)
            {
                if (conta.status == false)
                {
                    
                    foreach (Pedido pedido in Pedidos)
                    {
                        if(pedido.conta.id == conta.id)
                        {
                            totalPedidoDaConta += pedido.valorTotalPedido;
                        }
                    }
                    Console.WriteLine("{0, -10} | {1, -30} | {2, -20}| {3, -20}", conta.id, conta.nomeCliente, conta.mesaSelecionada.numero, totalPedidoDaConta);

                }
            }
        }
    }
}
