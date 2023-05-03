using System.Collections;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Pedido
    {
        public Conta conta;
        public Produto produto;
        public int quantidade;
        public decimal valorTotalPedido;
        public Pedido(Conta conta, Produto produto, int quantidade)
        {
            this.conta = conta;
            this.produto = produto;
            this.quantidade = quantidade;
            this.valorTotalPedido = produto.preco * quantidade;
        }
    }
}
