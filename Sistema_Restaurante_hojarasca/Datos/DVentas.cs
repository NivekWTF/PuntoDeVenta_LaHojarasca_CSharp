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
    public class DVentas
    {
        private void Insertar_Ventas(LVentas parametros)
        {
            try
            {              
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Ventas", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idClienteV", parametros.idClienteV);
                cmd.Parameters.AddWithValue("@fecha_venta", parametros.fecha_venta);
                cmd.Parameters.AddWithValue("@Id_Usuario", parametros.Id_Usuario);
                cmd.Parameters.AddWithValue("@Accion", parametros.Accion);
                cmd.Parameters.AddWithValue("@ID_caja", parametros.ID_caja);
                cmd.Parameters.AddWithValue("@Id_Mesa", parametros.Id_Mesa);
                cmd.Parameters.AddWithValue("@Numero_Personas", parametros.Numero_Personas);
                cmd.Parameters.AddWithValue("@Lugar_Consumo", parametros.Lugar_Consumo);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
