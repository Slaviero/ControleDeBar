using System.Collections;
using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using Microsoft.Win32;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        RepositorioMesa repositorioMesa;
        RepositorioGarcom repositorioGarcom;
        RepositorioConta repositorioConta;
        RepositorioProduto repositorioProduto;
        TelaProduto telaProduto;
        TelaMesa telaMesa;
        TelaGarcom telaGarcom;

        public TelaConta(RepositorioConta repositorioConta, RepositorioMesa repositorioMesa, RepositorioGarcom repositorioGarcom,
            TelaMesa telaMesa, TelaGarcom telaGarcom, TelaProduto telaProduto, RepositorioProduto repositorioProduto)
        {
            this.telaProduto = telaProduto;
            this.telaMesa = telaMesa;
            this.telaGarcom = telaGarcom;
            this.repositorioGarcom = repositorioGarcom;
            this.repositorioMesa = repositorioMesa;
            this.repositorioConta = repositorioConta;
            this.repositorioProduto = repositorioProduto;
            repositorioBase = repositorioConta;
            nomeEntidade = "Conta";
            sufixo = "s";
            this.repositorioGarcom = repositorioGarcom;
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -30}", "Id", "Nome Cliente", "Número da mesa", "Status da Conta");

            Console.WriteLine("---------------------------------------------------------------------------------");
            string statusConta = "";
            foreach (Conta conta in registros)
            {
                if (conta.status)
                    statusConta = "Conta Aberta";
                else
                    statusConta = "Conta fechada";
                Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -30}", conta.id, conta.nomeCliente, conta.mesaSelecionada.numero, statusConta);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Insira o nome do cliente responsável: ");
            string nome = Console.ReadLine();

            int idMesa;
            int idGarcom;
            Mesa mesaSelecionada = null;
            Garcom garcomSelecionado = null;
            do
            {
                telaMesa.VisualizarRegistros(false);

                Console.Write("\nInsira o Id da Mesa onde o cliente está: ");
                idMesa = Int16.Parse(Console.ReadLine());

                mesaSelecionada = (Mesa)repositorioMesa.SelecionarPorId(idMesa);

                if (mesaSelecionada == null)
                {
                    MostrarMensagem("Id invalido, por favor insira um Id válido.", ConsoleColor.DarkRed);
                    Console.Clear();
                }

            } while (mesaSelecionada == null);
            do
            {
                telaGarcom.VisualizarRegistros(false);

                Console.Write("\nInsira o Id do Garçom responsavém pela mesa: ");
                idGarcom = Int16.Parse(Console.ReadLine());

                garcomSelecionado = (Garcom)repositorioGarcom.SelecionarPorId(idGarcom);

                if (garcomSelecionado == null)
                {
                    MostrarMensagem("Id invalido, por favor insira um Id válido.", ConsoleColor.DarkRed);
                    Console.Clear();
                }


            } while (garcomSelecionado == null);


            repositorioMesa.OcuparMesa(idMesa);

            bool statusConta = true;

            return new Conta(mesaSelecionada, garcomSelecionado, nome, statusConta);

        }
        public Pedido ObterPedido()
        {
            MostrarCabecalho("Menu de Contas...", "Inserindo Pedido");

            Conta contaSelecionada = null;
            Produto produtoSelecionado = null;
            do
            {
                VisualizarRegistros(false);

                Console.WriteLine("\nInsira o Id da conta responsável pelo pedido: ");
                int idConta = Int16.Parse(Console.ReadLine());
                contaSelecionada = (Conta)repositorioConta.SelecionarPorId(idConta);

                if (contaSelecionada == null)
                {
                    MostrarMensagem("Id invalido, por favor insira um Id válido.", ConsoleColor.DarkRed);
                    Console.Clear();
                }

            } while (contaSelecionada == null);

            do
            {

                telaProduto.VisualizarRegistros(false);

                Console.WriteLine("\nInsira o Id do produto que gostaria de pedir: ");
                int idProduto = Int16.Parse(Console.ReadLine());

                produtoSelecionado = (Produto)repositorioProduto.SelecionarPorId(idProduto);

                if (produtoSelecionado == null)
                {
                    MostrarMensagem("Id invalido, por favor insira um Id válido.", ConsoleColor.DarkRed);
                    Console.Clear();
                }
            } while (produtoSelecionado == null);


            Console.WriteLine("\nInsira a quantidade a ser pedida: ");
            int quantidade = Int16.Parse(Console.ReadLine());

            MostrarMensagem("Pedido Efetuado Com Sucesso!", ConsoleColor.Green);

            Pedido pedido = new Pedido(contaSelecionada, produtoSelecionado, quantidade);
            repositorioConta.Pedidos.Add(pedido);

            return pedido;
        }


        public override string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine(" _________________________________________");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|              Menu de Contas             |");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|                                         |");
            Console.WriteLine("| Digite 1 para Abrir Conta:              |");
            Console.WriteLine("| Digite 2 para Visualizar Contas:        |");
            Console.WriteLine("| Digite 3 para Fechar Conta:             |");
            Console.WriteLine("| Digite 4 para Efetuar um pedido:        |");
            Console.WriteLine("| Digite 5 para exibir o faturameto:      |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|        -- Digite s para Sair --         |");
            Console.WriteLine("|_________________________________________|");

            Console.Write("\n\nInsira um comando: ");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public void SolicitarFechamento()
        {
            Console.Clear();

            bool contaFoiFechada = false;
            do
            {
                MostrarCabecalho("Cadastro de Contas..", "Fechando a Conta");

                VisualizarRegistros(false);

                Console.Write("Digite o Id da conta que deseja fechar: ");
                int idConta = Int16.Parse(Console.ReadLine());

                contaFoiFechada = repositorioConta.FecharConta(idConta);

                if (contaFoiFechada)
                    MostrarMensagem("Conta Fechada com sucesso!", ConsoleColor.Green);

            } while (contaFoiFechada == false);

        }

        public void MostrarFaturamento()
        {
            MostrarCabecalho("Cadastro de Contas..", "Exibição de faturamento");

            repositorioConta.ObterFaturamento();

            MostrarMensagem("Esse é o faturameto das contas fechadas!", ConsoleColor.Green);
        }
    }
}
