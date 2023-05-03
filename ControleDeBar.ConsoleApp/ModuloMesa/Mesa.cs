using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string numero;
        public bool status;

        public Mesa(string numero, bool status)
        {
            this.numero = numero;
            this.status = status;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizado = (Mesa)registroAtualizado;

            this.numero = mesaAtualizado.numero;
            this.status = mesaAtualizado.status;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(numero.Trim()))
                erros.Add("O campo \"numero\" é obrigatório");

            return erros;
        }
    }
}
