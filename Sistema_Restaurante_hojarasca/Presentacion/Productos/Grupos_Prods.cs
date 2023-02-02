using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace Sistema_Restaurante_hojarasca.MODULOS.Productos
{
    public partial class Grupos_Prods : Form
    {
        public Grupos_Prods()
        {
            InitializeComponent();
        }
        string ESTADO_IMAGEN;

        private void test()
        {

        }
        private void Grupos_Prods_Load(object sender, EventArgs e)
        {
            ESTADO_IMAGEN = "VACIO";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Insertar_Grupo_Productos();
            Close();
        }

        private void Insertar_Grupo_Productos()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Grupo_Productos", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grupo", txtGrupo.Text);
                cmd.Parameters.AddWithValue("@PorDefecto", "NO");
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Estado_de_icono", ESTADO_IMAGEN);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenGrupo.Image.Save(ms, ImagenGrupo.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());

                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void agregar_Imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes |*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imágenes";

            if(dlg.ShowDialog() == DialogResult.OK)
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
