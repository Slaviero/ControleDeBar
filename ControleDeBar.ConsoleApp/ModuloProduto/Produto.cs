using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string nome;
        public string descricao;
        public decimal preco;

        public Produto(string nome, string descricao, decimal preco)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;

            this.nome = produtoAtualizado.nome;
            this.descricao = produtoAtualizado.descricao;
            this.preco = produtoAtualizado.preco;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (nome.Length <= 3)
                erros.Add("O campo \"nome\" precisa ter mais que 3 letras");

            if (string.IsNullOrEmpty(descricao.Trim()))
                erros.Add("O campo \"descrição\" é obrigatório");

            if (preco <= 0)
                erros.Add("O preço não pode ser inferior pu igual a 0");
            return erros;
        }
    }

}
