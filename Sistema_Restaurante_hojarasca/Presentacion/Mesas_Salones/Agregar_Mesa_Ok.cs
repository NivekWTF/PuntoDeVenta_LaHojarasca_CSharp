using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Sistema_Restaurante_hojarasca.Datos;

namespace Sistema_Restaurante_hojarasca.MODULOS
{
    public partial class Agregar_Mesa_Ok : Form
    {
        public Agregar_Mesa_Ok()
        {
            InitializeComponent();
        }

        private void Agregar_Mesa_Ok_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            txtMesaEdicion.Text = MODULOS.Mesas.Salones.nombre_mesa;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtMesaEdicion.Text != "")
            {
                editar_Mesa();
            }
        }

        private void editar_Mesa()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("EDITAR_MESA", CONEXIONMAESTRA.conectar);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mesa", txtMesaEdicion.Text);
                cmd.Parameters.AddWithValue("@id_mesa", MODULOS.Mesas.Salones.idMesa);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.Cerrar();
                Close();
                
            }
            catch (Exception ex)
            {
                CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.Message);
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
