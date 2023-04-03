using System;

using System.Data;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;
using Sistema_Restaurante_hojarasca.Datos;

namespace Sistema_Restaurante_hojarasca.MODULOS.PUNTO_DE_VENTA
{
    public partial class MostradorProductos : UserControl
    {
        public MostradorProductos()
        {
            InitializeComponent();
        }

        int PaginaInicio = 1;
        int PaginaMaxima = 50;
        
        int cantidad_productos = 0;

        private Button paginadorSiguiente = new Button();
        private Button paginadorAtras = new Button();

        private void MostradorProductos_Load(object sender, EventArgs e)
        {
            dibujarProductos();
            contar_Productos();
        }

        public void contar_Productos()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("contar_Productos_Por_grupo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idgrupo", Punto_de_Venta.idGrupo);
                cantidad_productos = Convert.ToInt32(cmd.ExecuteScalar());

                CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                cantidad_productos = 0;
                MessageBox.Show(ex.Message);
            }
        }

        public void dibujarProductos()
        {
            try
            {
                PanelProductos.Controls.Clear();
                CONEXIONMAESTRA.abrir();
                SqlCommand CMD = new SqlCommand("paginar_Productos_por_Grupo", CONEXIONMAESTRA.conectar);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@id_grupo", Punto_de_Venta.idGrupo);
                CMD.Parameters.AddWithValue("@Desde", PaginaInicio);
                CMD.Parameters.AddWithValue("@Hasta", PaginaMaxima);
                SqlDataReader rdr = CMD.ExecuteReader();


                while (rdr.Read())
                {
                    Label lbl = new Label();
                    Panel p1 = new Panel();
                    PictureBox img1 = new PictureBox();

                    lbl.Text = rdr["Nombre"].ToString();
                    lbl.Name = rdr["idProducto"].ToString();
                    lbl.Tag = rdr["PrecioVenta"].ToString();
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
                    img1.Tag = rdr["PrecioVenta"].ToString();
                    img1.Name = rdr["idProducto"].ToString();
                    img1.BackColor = Color.Transparent;
                    p1.Controls.Add(lbl);

                    if (rdr["Estado_Imagen"].ToString() != "VACIO")
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
                MessageBox.Show(ex.StackTrace);
                CONEXIONMAESTRA.Cerrar();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if(PaginaInicio > 1)
            {
                PaginaInicio -= 15;
                PaginaMaxima -= 15;
                dibujarProductos();
            }
        }

        private void btnDelante_Click(object sender, EventArgs e)
        {
            if (PaginaInicio > 1)
            {
                PaginaInicio += 15;
                PaginaMaxima += 15;
                dibujarProductos();
            }
        }
    }
}
