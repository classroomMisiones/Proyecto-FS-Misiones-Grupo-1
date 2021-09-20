using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Models
{
    public class Operaciones
    {
        public int idOperacion { get; set; }
        public int idMoneda { get; set; }
        public int idCartera { get; set; }
        public int egreso { get; set; }
        public int ingreso { get; set; }
    }
}