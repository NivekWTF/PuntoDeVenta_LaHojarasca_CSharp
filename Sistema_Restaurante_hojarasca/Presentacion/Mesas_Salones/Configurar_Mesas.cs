using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_Restaurante_hojarasca.MODULOS.Mesas
{
    public partial class Configurar_Mesas : Form
    {
        private int idsalon;

        public Configurar_Mesas()
        {
            InitializeComponent();
        }

        private void Configurar_Mesas_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            txtSalonEdicion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarSalon();
        }

        private void InsertarMesasVacias()
        {
            for (int i = 1; i <= 80; i++)
            {
                try
                {
                    CONEXION.CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("Insertar_mesa",CONEXION.CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mesa", "NULO");
                    cmd.Parameters.AddWithValue("@idsalon", idsalon);
                    cmd.ExecuteNonQuery();
                    CONEXION.CONEXIONMAESTRA.Cerrar();
                }
                catch (Exception ex)
                {
                    CONEXION.CONEXIONMAESTRA.Cerrar();
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void mostrarIdSalonRI()
        {
            SqlCommand com = new SqlCommand("MostrarIDSalonRI", CONEXION.CONEXIONMAESTRA.conectar);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Salon", txtSalonEdicion.Text);

            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                idsalon = Convert.ToInt32(com.ExecuteScalar());
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
        }

        private void InsertarSalon()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_salon", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Salon", txtSalonEdicion.Text);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.Cerrar();
                mostrarIdSalonRI();
                InsertarMesasVacias();
                Close();
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.conectar.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
