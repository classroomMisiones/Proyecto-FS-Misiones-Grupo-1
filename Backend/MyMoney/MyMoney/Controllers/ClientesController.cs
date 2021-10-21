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
                int idClienteNuevo = 0;
                SqlCommand comando = new SqlCommand();
                SqlCommand comando2 = new SqlCommand();
                SqlCommand comando3 = new SqlCommand();
                comando.CommandText = "INSERT INTO Clientes (usuario,contrasena,nombres,apellidos,email) VALUES ('"
                                              + oCliente.Usuario + "','"
                                              + oCliente.Contrasena + "','"
                                              + oCliente.Nombre + "','"
                                              + oCliente.Apellido + "','"
                                              + oCliente.Email + "')";
                comando.Connection = conector;
                comando2.Connection = conector;
                comando3.Connection = conector;
                comando.ExecuteNonQuery(); //Agregamos el Cliente nuevo

                comando3.CommandText = "SELECT TOP 1 idCliente FROM Clientes ORDER BY idCliente DESC"; //Agarramos su ID que se generó automáticamente
                SqlDataReader reader = comando3.ExecuteReader();
                if (reader.Read())
                {
                  idClienteNuevo = (int)reader["idCliente"]; //La volcamos en esta variable
                }
                reader.Close(); //Re importante cerrar
                comando2.CommandText = "INSERT INTO Carteras(idCliente, cvu) VALUES(" //Generamos la cartera de este cliente
                                                     + idClienteNuevo + ", '"     //Lo vinculamos al mismo.
                                                     + "12463256')";             
                comando2.ExecuteNonQuery();
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
                                                      + "',contraseña = '" + oCliente.Contrasena
                                                      + "',nombres = '" + oCliente.Nombre
                                                      + "',apellidos = '" + oCliente.Apellido
                                                      + "',email = '" + oCliente.Email
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
