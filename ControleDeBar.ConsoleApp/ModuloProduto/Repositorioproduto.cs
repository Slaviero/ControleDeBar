using System.Collections;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase
    {
        public RepositorioProduto(ArrayList listaProdutos)
        {
            this.listaRegistros = listaProdutos;
        }

        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Produto)base.SelecionarPorId(id);
        }
    }

}
