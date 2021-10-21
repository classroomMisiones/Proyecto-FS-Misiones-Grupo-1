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
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class LoginController : ApiController
    {
    string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

    // GET: api/Default
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/Default/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Login
    public int Post([FromBody] Models.Clientes oCliente)
        {
      using (SqlConnection conector = new SqlConnection(cadena))
      {
        int idClienteLogin = 0;
        conector.Open();
        {
          string contrasenaDB = "";
          string usuarioDB = "";
          string emailDB = "";
          
          SqlCommand comando = new SqlCommand();
          SqlCommand comando2 = new SqlCommand();
          comando.Connection = conector;
          comando2.Connection = conector;
          comando.CommandText = "SELECT * FROM Clientes WHERE contrasena = '" + oCliente.Contrasena + "' AND ("
                                  + "email = '" + oCliente.Email + "' OR usuario = '" + oCliente.Usuario + "')";
          SqlDataReader reader = comando.ExecuteReader();
          if (reader.Read())
          {
            contrasenaDB = reader["contrasena"].ToString();
            usuarioDB = reader["usuario"].ToString();
            emailDB = reader["email"].ToString();
            idClienteLogin = (int)reader["idCliente"];
          } else
          {
            reader.Close();
            return idClienteLogin;
          }
         
         //Controlar si vino un email
            if (emailDB.Equals(""))
            {
            //Si no vino ninguno, es porque algún dato estaba mal. Login fail.
            return idClienteLogin;
          } else if (emailDB.Equals(oCliente.Email)) { //Si vino un correo, login exitoso también
              //idClienteLogin = (int)reader["idCliente"]; //Ponemos en esta variable el id del cliente que hizo login.
              reader.Close(); //Cerramos el lector.
              return idClienteLogin;
            }
        }
        return idClienteLogin;
      }
      }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
