using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class RepositorioGarcom : RepositorioBase
    {

        public RepositorioGarcom(ArrayList listaGarcons) 
        {
            this.listaRegistros = listaGarcons;
        }

        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Garcom)base.SelecionarPorId(id);
        }
    }

}
