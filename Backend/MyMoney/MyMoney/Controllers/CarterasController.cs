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
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Carteras", conector);
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
