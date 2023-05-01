using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sistema_Restaurante_hojarasca.Logica;
using System.Windows.Forms;

namespace Sistema_Restaurante_hojarasca.Datos
{
    public class DIniciosSesion
    {
        private int idCaja;
        public void MostrarInicioSesion(ref int id)
        {
            try
            {
                DCaja funcion = new DCaja();
                funcion.MostrarCajaSerial(ref id);
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("mostrarInicioSesion", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idCaja);
                id = Convert.ToInt32(da.ExecuteScalar());
            }
            catch (Exception)
            {
                id = 0;
            }
            finally
            {
                CONEXIONMAESTRA.Cerrar();
            }
        }

        public bool insertarInicioSesion(LIniciosSesion parametros)
        {
            try 
            {
                DCaja funcion = new DCaja();
                funcion.MostrarCajaSerial(ref idCaja);
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertInicioSesion", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcaja", idCaja);
                cmd.Parameters.AddWithValue("@idusuario", parametros.idUsuario);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void editarInicioSesion(LIniciosSesion parametros)
        {

        }
    }
}
