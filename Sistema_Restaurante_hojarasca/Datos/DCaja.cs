using Sistema_Restaurante_hojarasca.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Sistema_Restaurante_hojarasca.Datos
{
    public class DCaja
    {
        private string SerialPC;
        public void MostrarCajaSerial(ref int idcaja)
        {
            try
            {
                Bases.Obtener_SerialPC(ref SerialPC);
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("MostrarCajaSerial", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Serial", SerialPC);
                idcaja = Convert.ToInt32(da.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                CONEXIONMAESTRA.Cerrar();
            }
        }
    }
}
