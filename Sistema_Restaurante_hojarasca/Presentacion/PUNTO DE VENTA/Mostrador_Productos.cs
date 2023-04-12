using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Sistema_Restaurante_hojarasca.Datos;

namespace Sistema_Restaurante_hojarasca.Presentacion.PUNTO_DE_VENTA
{
    public partial class Mostrador_Productos : Form
    {
        public Mostrador_Productos()
        {
            InitializeComponent();
        }

        int PaginaIncio = 1;
        int PaginaMaxima = 10;
        public static int id_grupo;
        int cantidad_grupos;

        private Button paginadorSiguiente = new Button();
        private Button paginadorAtras = new Button();

        private void Mostrador_Productos_Load(object sender, EventArgs e)
        {

            dibujarProductos();
        }

        public void dibujarProductos()
        {
            try
            {
                PanelProductos.Controls.Clear();
                CONEXIONMAESTRA.abrir();
                SqlCommand CMD = new SqlCommand("paginar_Productos_por_Grupo", CONEXIONMAESTRA.conectar);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@Desde", PaginaIncio);
                CMD.Parameters.AddWithValue("@Hasta", PaginaMaxima);
                SqlDataReader rdr = CMD.ExecuteReader();


                while (rdr.Read())
                {
                    Label lbl = new Label();
                    Panel p1 = new Panel();
                    PictureBox img1 = new PictureBox();

                    lbl.Text = rdr["Nombre"].ToString();
                    lbl.Name = rdr["id_Producto"].ToString();
                    lbl.Tag = rdr["Precio_Venta"].ToString();
                    lbl.Font = new Font("Montserrat", 7, FontStyle.Regular | FontStyle.Bold);
                    lbl.BackColor = Color.Transparent;
                    lbl.ForeColor = Color.White;
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(147, 75);
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.Transparent;
                    p1.BackgroundImage = Properties.Resources.azul;
                    p1.BackgroundImageLayout = ImageLayout.Stretch;

                    img1.Dock = DockStyle.Top;
                    byte[] bi = (byte[])rdr["Imagen"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bi);
                    img1.Image = Image.FromStream(ms);
                    img1.SizeMode = PictureBoxSizeMode.Zoom;
                    img1.Cursor = Cursors.Hand;
                    img1.Tag = rdr["Precio_Venta"].ToString();
                    img1.Name = rdr["id_producto"].ToString();
                    img1.BackColor = Color.Transparent;
                    p1.Controls.Add(lbl);

                    if (rdr["Estado_de_icono"].ToString() != "VACIO")
                    {
                        //se añade imagen a panel
                        p1.Controls.Add(img1);
                    }

                    lbl.BringToFront();
                    PanelProductos.Controls.Add(p1);
                }
                CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CONEXIONMAESTRA.Cerrar();
            }
        }
    }
}
