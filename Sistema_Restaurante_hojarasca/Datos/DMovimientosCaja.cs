using Sistema_Restaurante_hojarasca.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Restaurante_hojarasca.Datos
{
    public class DMovimientosCaja
    {
        private string SerialPC;
        private int idCaja;
        public void MostrarMovimientosCaja(ref DataTable dt)
        {
            try
            {
                Bases.Obtener_SerialPC(ref SerialPC);
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarMovimientosCaja", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", SerialPC);
                da.Fill(dt);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {

            }
        }

        public bool insertar_MovimientoCaja(LMovimientosCaja parametros)
        {
            try
            {
                DCaja funcion = new DCaja();
                funcion.MostrarCajaSerial(ref idCaja);
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_MovimientosCaja", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.Idusuario);
                cmd.Parameters.AddWithValue("@IdCaja", idCaja);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.Cerrar();
            }
        }

        public void MostrarMovCajaUsuario(ref int idMov, LMovimientosCaja parametros)
        {
            try
            {
                Bases.Obtener_SerialPC(ref SerialPC);
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("MostrarMovCajaUser", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@serial", SerialPC);
                da.Parameters.AddWithValue("@idusuario", parametros.Idusuario);
                idMov = Convert.ToInt32(da.ExecuteScalar());
            }
            catch(Exception ex)
            {
                idMov = 0;
            }
            finally
            {
                CONEXIONMAESTRA.Cerrar()M
            }
    
        }

    }
}
