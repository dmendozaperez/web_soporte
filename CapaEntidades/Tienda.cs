using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Tienda
    {
        public string COD_ENT { get; set; }
        public string DES_ENT { get; set; }
    }
    public class Tienda_Config
    {
        public string CODIGO_ERROR { get; set; }
        public string CODIGO_INTERNO { get; set; }
        public string BOLETA { get; set; }
        public string FACTURA { get; set; }
        public string NCBOLETA { get; set; }
        public string NCFACTURA { get; set; }
    }
}
