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
    public class ClientesController : ApiController
    {

        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Clientes
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Clientes", conector);
                adaptador.Fill(dt);


            }
            return Ok(dt);
        }


        // GET: api/Clientes/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string nombre = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Nombre FROM Clientes Where idCliente = " + id, conector);
                nombre = comando.ExecuteScalar().ToString();
            }
            return nombre;
        }

        // POST: api/Clientes
        public void Post([FromBody] Models.Clientes oCliente)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Clientes (usuario,contraseña,nombres,apellidos,dni,email,telefono) VALUES ('"
                                                                      + oCliente.Usuario + "','"
                                                                      + oCliente.Contraseña + "','"
                                                                      + oCliente.Nombre + "','"
                                                                      + oCliente.Apellido + "','"
                                                                      + oCliente.Dni + "','"
                                                                      + oCliente.Email + "','"
                                                                      + oCliente.Telefono +"')";
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody] Models.Clientes oCliente)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Clientes SET usuario = '" + oCliente.Usuario
                                                      + "',contraseña = '" + oCliente.Contraseña
                                                      + "',nombres = '" + oCliente.Nombre
                                                      + "',apellidos = '" + oCliente.Apellido
                                                      + "',dni = '" + oCliente.Dni
                                                      + "',email = '" + oCliente.Email
                                                      + "',telefono = '" + oCliente.Telefono
                                                      + "' WHERE idCliente =" + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Clientes WHERE idCliente = " + id, conector);
                comando.ExecuteNonQuery();

            }
        }
    }
}
