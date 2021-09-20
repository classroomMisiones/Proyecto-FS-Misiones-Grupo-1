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
    public class OperacionesController : ApiController
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
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Operaciones", conector);
                adaptador.Fill(dt);


            }
            return Ok(dt);
        }

        // GET: api/Operaciones/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Operaciones
        public void Post([FromBody] Models.Operaciones oOperaciones)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Operaciones (idMoneda,idCartera,egreso,ingreso) VALUES ("
                                                                      + oOperaciones.idMoneda + ","
                                                                      + oOperaciones.idCartera + ","
                                                                      + oOperaciones.egreso + ","
                                                                      + oOperaciones.ingreso + ")";
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // PUT: api/Operaciones/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Operaciones/5
        public void Delete(int id)
        {
        }
    }
}
