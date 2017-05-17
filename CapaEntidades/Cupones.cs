using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Cupones
    {
        public string CODE { get; set; }
        public string CORRELATIVO { get; set; }
        public string BARRA { get; set; }
        public string NOMAPE { get; set; }
        public string EMAIL { get; set; }
        public string DNI { get; set; }
        public string ESTADO { get; set; }
        public Decimal PORC_DESC { get; set; }
        public DateTime FEC_EMI { get; set; }
        public DateTime FEC_FIN { get; set; }
        public int PARES_MAX { get; set; }
        public string CAMPA { get; set; }
        public Decimal MONTO_VALE { get; set; }
        public string EST_ID { get; set; }


    }
}
