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
    public class MonedasController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Monedas
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Monedas", conector);
                adaptador.Fill(dt);


            }
            return Ok(dt);
        }

        // GET: api/Monedas/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string nombre = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT nombre FROM Monedas Where idMoneda = " + id, conector);
                nombre = comando.ExecuteScalar().ToString();
            }
            return nombre;
        }

        // POST: api/Monedas
        public void Post([FromBody] Models.Monedas oMoneda)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Monedas (imagen,nombre) VALUES ('"
                                                                      + oMoneda.Imagen + "','"                                                                  
                                                                      + oMoneda.Nombre + "')";
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // PUT: api/Monedas/5
        public void Put(int id, [FromBody] Models.Monedas oMoneda)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Monedas SET imagen = '" + oMoneda.Imagen
                                                      + "',nombre = '" + oMoneda.Nombre
                                                      + "' WHERE idMoneda =" + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/Monedas/5
        public void Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Monedas WHERE idMoneda = " + id, conector);
                comando.ExecuteNonQuery();

            }
        }
    }
}
