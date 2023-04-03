using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Sistema_Restaurante_hojarasca.Logica;
using System.Windows.Forms;

namespace Sistema_Restaurante_hojarasca.Datos
{
    public class DModulos
    {
        public bool Insertar_Modulos(LModulos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Modulos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Modulo", parametros.Modulo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.Cerrar();
            }
        }
        public bool Editar_Modulos(LModulos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Modulos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdModulo", parametros.IdModulo);
                cmd.Parameters.AddWithValue("@Modulo", parametros.Modulo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.Cerrar();
            }
        }
        public bool Eliminar_Modulos(LModulos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Modulos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdModulo", parametros.IdModulo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.Cerrar();
            }
        }
        public void mostrar_Modulos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_Modulos", CONEXIONMAESTRA.conectar);
                da.Fill(dt);

                CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
