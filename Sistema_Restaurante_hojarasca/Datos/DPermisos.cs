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
    public class DPermisos
    {
        private bool Insertar_Permisos(LPermisos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Permisos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Modulo", parametros.Id_Modulo);
                cmd.Parameters.AddWithValue("@Id_Usuario", parametros.Id_Usuario);
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

        private bool EditarPermisos(LPermisos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editar_Permisos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPermiso", parametros.IDPermiso);
                cmd.Parameters.AddWithValue("@Id_Modulo", parametros.Id_Modulo);
                cmd.Parameters.AddWithValue("@Id_Usuario", parametros.Id_Usuario);
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

        public bool ElimarUsuarios(LUsuarios parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminar_Permisos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
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

        public void MostrarUsuarios(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_Permisos", CONEXIONMAESTRA.conectar);
                da.Fill(dt);

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
