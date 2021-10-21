using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyMoney.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CarterasController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Carteras
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT cli.idCliente as Cliente,trans.idCarteraOrigen as Origen,trans.idCarteraDestino as Destino, trans.monto as monto, car.idCartera as Cartera FROM Carteras as car  INNER JOIN Clientes as cli ON cli.idCliente = car.idCliente INNER JOIN Transferencias as trans ON car.idCartera = trans.idCarteraDestino WHERE trans.idCarteraOrigen = 3 OR trans.idCarteraDestino = 3 AND cli.idCliente = 3", conector);
                adaptador.Fill(dt);


            }
            return Ok(dt);
        }

        // GET: api/Carteras/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string cvu = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT cvu FROM Carteras Where idMoneda = " + id, conector);
                cvu = comando.ExecuteScalar().ToString();
            }
            return cvu;
        }

        // POST: api/Carteras
        public void Post([FromBody] Models.Carteras oCartera)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Carteras (idCliente,cvu) VALUES ('"
                                                                      + oCartera.idCliente + "','"
                                                                      + oCartera.Cvu + "')";
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // PUT: api/Carteras/5
        public void Put(int id, [FromBody] Models.Carteras oCartera)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE MCarteras SET idCliene = '" + oCartera.idCliente
                                                      + "',cvu = '" + oCartera.Cvu
                                                      + "' WHERE idMoneda =" + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/Carteras/5
        public void Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Carteras WHERE idCartera = " + id, conector);
                comando.ExecuteNonQuery();

            }
        }
    }
}
