using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace www.it.bataperu.com.Models.CuponesViewModels
{
    public class CuponesSearchViewModel
    {
        public Int32 rownumber { get; set; }
        public string code128 { get; set; }
        public Decimal correlativo { get; set; }
        public string barra { get; set; }
        public string nomape { get; set; }
        public string email { get; set; }
        public string dni { get; set; }
        public string estado { get; set; }
        public decimal porc_desc { get; set; }
        public DateTime fec_emi { get; set; }
        public DateTime fec_fin { get; set; }
        public int pares_max { get; set; }
        public string grupo { get; set; }
        public string empresa_razon { get; set; }
        public Decimal monto_vale { get; set; }
    }
}