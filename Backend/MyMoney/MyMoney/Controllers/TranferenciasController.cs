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
        public bool Post([FromBody] Models.Transferencias oTranferencia)
        {
      int saldoActualOrigen;
      int saldoActualDestino;
      int nuevoSaldoOrigen;
      int nuevoSaldoDestino;
      int idCarteraOrigen;
      int idCarteraDestino;
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
        //Conseguir el ID de la Cartera Destino usando el Usuario que me llegó.
        comando.Connection = conector;
        comando.CommandText = "SELECT * from Clientes WHERE usuario = '" + oTranferencia.usuarioDestino + "'";
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.Read())
        { //Si el usuario ingresado corresponde con un usuario en la base de datos.
          oTranferencia.idCarteraDestino = (int)reader["idCliente"];
          reader.Close();
        } else
        { //No corresponde a ningún usuario
          reader.Close();
          return false;
        }
        //Conseguir el Saldo Actual del usuario que hace la transferencia.
        comando.CommandText = "SELECT * from Carteras WHERE idCliente = " + oTranferencia.idCarteraOrigen;
        SqlDataReader reader2 = comando.ExecuteReader();
        reader2.Read();
        saldoActualOrigen = (int)reader2["saldoDisponible"]; //Guardar el saldo actual en mi variable
        idCarteraOrigen = (int)reader2["idCartera"];
        reader2.Close();
        if (saldoActualOrigen >= oTranferencia.monto)
        { //Si hay saldo suficiente, se hace la transferencia
          nuevoSaldoOrigen = saldoActualOrigen - oTranferencia.monto;
          //Necesito el saldo actual de la cartera destino.
          comando.CommandText = "SELECT * from Carteras WHERE idCliente = " + oTranferencia.idCarteraDestino;
          SqlDataReader reader3 = comando.ExecuteReader();
          reader3.Read();
          saldoActualDestino = (int)reader3["saldoDisponible"]; //Guardar el saldo actual en mi variable
          idCarteraDestino = (int)reader3["idCartera"];
          reader3.Close();
          //
          nuevoSaldoDestino = saldoActualDestino + oTranferencia.monto;
          comando.CommandText = "UPDATE Carteras SET saldoDisponible = " + nuevoSaldoOrigen + " WHERE idCliente = " + oTranferencia.idCarteraOrigen;
          comando.ExecuteNonQuery();
          comando.CommandText = "UPDATE Carteras SET saldoDisponible = " + nuevoSaldoDestino + " WHERE idCliente = " + oTranferencia.idCarteraDestino;
          comando.ExecuteNonQuery();
          //Ahora tengo que registrar esta transferencia en la tabla transferencias.
          comando.CommandText = "INSERT INTO Transferencias (idCarteraOrigen,idCarteraDestino,monto) VALUES ("
                                                                                + idCarteraOrigen + ","
                                                                                + idCarteraDestino + ","
                                                                                + oTranferencia.monto + ")";
          comando.ExecuteNonQuery();
          return true;
        } else
        { //Sino, no hay saldo suficiente.
          return false;
        }
       



                
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
