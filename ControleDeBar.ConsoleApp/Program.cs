using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RepositorioGarcom repositorioGarcom = new RepositorioGarcom(new ArrayList());
            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());

            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaConta telaConta = new TelaConta(repositorioConta,repositorioMesa, repositorioGarcom, telaMesa, telaGarcom, telaProduto,repositorioProduto);

            TelaPrincipal telaPrincipal = new TelaPrincipal();

            repositorioGarcom.Inserir(new Garcom("Francisco", "156622612616312"));
            repositorioMesa.Inserir(new Mesa("6B", false));
            repositorioMesa.Inserir(new Mesa("8Y", true));
            repositorioProduto.Inserir(new Produto("Batata", "Porção de Batatas", 30));
            repositorioProduto.Inserir(new Produto("Pepsi", "refrigerante generico", 5));


            while (true)
            {
                string opcao = telaPrincipal.ApresentarMenu();

                if (opcao == "s" || opcao == "S")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaGarcom.ApresentarMenu();

                    switch (subMenu)
                    {
                        case "1":
                            telaGarcom.InserirNovoRegistro();
                            break;
                        case "2":
                            telaGarcom.VisualizarRegistros(true);
                            Console.ReadLine();
                            break;
                        case "3":
                            telaGarcom.EditarRegistro();
                            break;
                        case "4":
                            telaGarcom.ExcluirRegistro();
                            break;
                        case "s":
                            break;
                        case "S":
                            break;
                    }
                }
                else if (opcao == "2")
                {
                    string subMenu = telaProduto.ApresentarMenu();

                    switch (subMenu)
                    {
                        case "1":
                            telaProduto.InserirNovoRegistro();
                            break;
                        case "2":
                            telaProduto.VisualizarRegistros(true);
                            Console.ReadLine();
                            break;
                        case "3":
                            telaProduto.EditarRegistro();
                            break;
                        case "4":
                            telaProduto.ExcluirRegistro();
                            break;
                        case "s":
                            break;
                        case "S":
                            break;
                    }
                }
                else if (opcao == "3")
                {
                    string subMenu = telaMesa.ApresentarMenu();

                    switch (subMenu)
                    {
                        case "1":
                            telaMesa.InserirNovoRegistro();
                            break;
                        case "2":
                            telaMesa.VisualizarRegistros(true);
                            Console.ReadLine();
                            break;
                        case "3":
                            telaMesa.EditarRegistro();
                            break;
                        case "4":
                            telaMesa.ExcluirRegistro();
                            break;
                        case "s":
                            break;
                        case "S":
                            break;
                    }
                }
                else if (opcao == "4")
                {
                    string subMenu = telaConta.ApresentarMenu();

                    switch (subMenu)
                    {
                        case "1":
                            telaConta.InserirNovoRegistro();
                            break;
                        case "2":
                            telaConta.VisualizarRegistros(true);
                            Console.ReadLine();
                            break;
                        case "3":
                            telaConta.SolicitarFechamento();
                            break;
                        case "4":
                            telaConta.ObterPedido();
                            break;
                        case "5":
                            telaConta.MostrarFaturamento();
                            break;
                        case "s":
                            break;
                        case "S":
                            break;
                    }
                }
            }
        }
    }
}