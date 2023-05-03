using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp
{
    internal class TelaPrincipal
    {
        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine(" _________________________________________");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|             Controle de Bar             |");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|                                         |");
            Console.WriteLine("| Digite 1 para Cadastrar Garçom:         |");
            Console.WriteLine("| Digite 2 para Cadastrar Produto:        |");
            Console.WriteLine("| Digite 3 para Cadastrar Mesas:          |");
            Console.WriteLine("| Digite 4 para acessar o Menu de Contas: |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|        -- Digite s para Sair --         |");
            Console.WriteLine("|_________________________________________|");

            Console.Write("\n\nInsira um comando: ");
            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
