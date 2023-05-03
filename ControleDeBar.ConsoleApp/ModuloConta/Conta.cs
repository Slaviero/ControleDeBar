using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {

        public string nomeCliente;
        public Mesa mesaSelecionada;
        public Garcom garcomSelecionado;
        public bool status;
        public Conta(Mesa mesaSelecionada, Garcom garcomSelecionado, string nomeCliente, bool status)
        {
            this.nomeCliente = nomeCliente;
            this.mesaSelecionada = mesaSelecionada;
            this.garcomSelecionado = garcomSelecionado;
            this.status = status;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizado = (Conta)registroAtualizado;
            
            this.nomeCliente = contaAtualizado.nomeCliente;
            this.mesaSelecionada = contaAtualizado.mesaSelecionada;
            this.garcomSelecionado = contaAtualizado.garcomSelecionado;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nomeCliente.Trim()))
                erros.Add("O campo \"nome do cliente\" é obrigatório");

            if (nomeCliente.Length <= 3)
                erros.Add("O campo \"nome do cliente\" precisa ter mais que 3 letras");

            return erros;
        }
    }
}
