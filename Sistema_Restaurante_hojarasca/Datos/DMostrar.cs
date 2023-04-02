﻿using System;
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
    public class DMostrar
    {
        public void MostrarUsuarios(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_usuario", CONEXIONMAESTRA.conectar);
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

        public void buscarUsuarios(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Buscar_Usuarios", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
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
