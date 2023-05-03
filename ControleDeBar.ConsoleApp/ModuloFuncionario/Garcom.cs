﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class Garcom : EntidadeBase
    {
        public string nome;
        public string cpf;

        public Garcom(string nome, string cfp)
        {
            this.nome = nome;
            this.cpf = cfp;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcomAtualizado = (Garcom)registroAtualizado;

            this.nome = garcomAtualizado.nome;
            this.cpf = garcomAtualizado.cpf;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (nome.Length <= 3)
                erros.Add("O campo \"nome\" precisa ter mais que 3 letras");

            if (string.IsNullOrEmpty(cpf.Trim()))
                erros.Add("O campo \"cpf\" é obrigatório");

            return erros;
        }
    }

}
