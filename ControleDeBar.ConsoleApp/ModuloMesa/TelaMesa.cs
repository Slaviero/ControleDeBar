using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {

        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            repositorioBase = repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -30}", "Id", "Mesa", "Status");

            Console.WriteLine("--------------------------------------------------------------------");
            
            string statusOcupacao = "";

            foreach (Mesa mesa in registros)
            {
                if (mesa.status == true)
                    statusOcupacao = "Ocupado";
                else
                    statusOcupacao = "Livre";
                Console.WriteLine("{0, -10} | {1, -20} | {2, -30}", mesa.id, mesa.numero, statusOcupacao);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Insira o numero da mesa: ");
            string numero = Console.ReadLine();

            bool status = false;
            return new Mesa(numero, status);

        }
    }
}
