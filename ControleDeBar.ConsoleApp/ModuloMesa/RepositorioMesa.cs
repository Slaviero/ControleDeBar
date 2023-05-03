using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase
    {
        public RepositorioMesa(ArrayList listaMesas)
        {
            this.listaRegistros = listaMesas;
        }

        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Mesa)base.SelecionarPorId(id);
        }
        public void OcuparMesa(int idParametro)
        { 
            foreach(Mesa mesa in listaRegistros) 
            {
                if(idParametro == mesa.id)
                {
                    mesa.status = true;
                    break;
                }
            }
        }
        //public EntidadeBase SelecionarMesaPorId(int id)
        //{
        //    Mesa mesaSelecionada = null;

        //    foreach (Mesa mesa in listaRegistros)
        //    {
        //        if (mesa.id == id)
        //        {
        //            mesaSelecionada = mesa;
        //            break;
        //        }
        //    }

        //    return mesaSelecionada;
        //}
    }
}
