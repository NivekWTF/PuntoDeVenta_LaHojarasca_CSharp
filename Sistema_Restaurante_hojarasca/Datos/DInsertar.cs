using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Restaurante_hojarasca.Logica;
using Sistema_Restaurante_hojarasca.Datos;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_Restaurante_hojarasca.Datos
{
    public class DInsertar
    {
        public bool insertarUsuarios(LUsuarios parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Usuario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                cmd.Parameters.AddWithValue("@Password", parametros.Password);
                cmd.Parameters.AddWithValue("@Icono", parametros.Icono);
                cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                cmd.Parameters.AddWithValue("@Rol", parametros.Rol);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.Cerrar();
            }
        }
    }
}
