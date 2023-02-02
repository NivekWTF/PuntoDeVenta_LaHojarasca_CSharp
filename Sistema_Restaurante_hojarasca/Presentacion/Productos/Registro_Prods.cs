using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace Sistema_Restaurante_hojarasca.MODULOS.Productos
{
    public partial class Registro_Prods : Form
    {
        public Registro_Prods()
        {
            InitializeComponent();
        }
        string ESTADO_IMAGEN;

        private void Registro_Prods_Load(object sender, EventArgs e)
        {
            ESTADO_IMAGEN = "VACIO";
        }

        private void Insertar_Productos()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Productos", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", txtNombreProducto.Text);
                cmd.Parameters.AddWithValue("@id_Grupo", Productos_Rest.idGrupo);
                cmd.Parameters.AddWithValue("@PrecioVenta", txtPrecioVenta.Text);
                cmd.Parameters.AddWithValue("@Estado_Imagen", ESTADO_IMAGEN);
                
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenGrupo.Image.Save(ms, ImagenGrupo.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Imagen", ms.GetBuffer());
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombreProducto.Text != "" && txtPrecioVenta.Text != "")
            {
                Insertar_Productos();
            }
            Close();
        }

        private void agregar_Imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imágenes";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenGrupo.BackgroundImage = null;
                ImagenGrupo.Image = new Bitmap(dlg.FileName);
                panel3.Visible = false;
                ESTADO_IMAGEN = "LLENO";
            }
        }

        private void lblAgregarIcono_Click(object sender, EventArgs e)
        {
            agregar_Imagen();
        }

        private void pcbAgregarIcono_Click(object sender, EventArgs e)
        {
            agregar_Imagen();
        }
    }
}
