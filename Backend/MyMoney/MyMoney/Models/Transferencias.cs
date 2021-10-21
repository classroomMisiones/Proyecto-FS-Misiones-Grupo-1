using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Models
{
    public class Transferencias
    {
        public int idTranferencia { get; set; }
        public int idCarteraOrigen { get; set; }
        public int idCarteraDestino { get; set; }
        public int monto { get; set; }
        public string usuarioDestino { get; set; }
    }
}
