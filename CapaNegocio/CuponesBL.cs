using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{    
    public class CuponesBL
    {
        private CuponesDA cupones = new CuponesDA();

        public List<Cupones> Listar(ref int currentPage, ref int pageSize, ref int _TotalRowCount, string _Buscar)
        {
            return cupones.Listar(currentPage,pageSize, ref _TotalRowCount, _Buscar);
        }
    }
}
