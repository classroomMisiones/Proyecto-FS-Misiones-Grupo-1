using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyMoney.Controllers
{
    public class TranferenciasController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Tranferencias
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Tranferencias", conector);
                adaptador.Fill(dt);


            }
            return Ok(dt);
        }

        // GET: api/Tranferencias/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string nombre = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT idCuentaDestino FROM Monedas Where idTranferencia = " + id, conector);
                nombre = comando.ExecuteScalar().ToString();
            }
            return nombre;
        }

        // POST: api/Tranferencias
        public void Post([FromBody] Models.Transferencias oTranferencia)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Tranferencias (idCarteraOrigen,idCarteraDestino,monto) VALUES ("
                                                                      + oTranferencia.idCarteraOrigen + ","
                                                                      + oTranferencia.idClienteDestino + ","
                                                                      + oTranferencia.monto + ")";
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // PUT: api/Tranferencias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tranferencias/5
        public void Delete(int id)
        {
        }
    }
}
