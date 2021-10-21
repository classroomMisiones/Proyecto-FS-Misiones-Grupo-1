using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Models
{
    public class Clientes
    {
        public int idCliente { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }
    }
}
