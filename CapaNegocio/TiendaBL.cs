using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaNegocio
{
    public class TiendaBL
    {
        private TiendaDA tienda = new TiendaDA();

        public List<Tienda> Listar()
        {
            return tienda.Listar();
        }
        public Tienda_Config Get(String codtda)
        {
            return tienda.Get(codtda);
        }

    }
}
