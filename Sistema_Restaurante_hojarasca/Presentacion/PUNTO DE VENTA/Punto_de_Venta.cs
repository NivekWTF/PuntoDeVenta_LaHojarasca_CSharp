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
using System.IO;
using Sistema_Restaurante_hojarasca.Datos;

namespace Sistema_Restaurante_hojarasca.Presentacion.PUNTO_DE_VENTA
{
    public partial class Punto_de_Venta : Form
    {
        public Punto_de_Venta()
        {
            InitializeComponent();
        }

        int PaginaIncio=1;
        int PaginaMaxima=10;
        public static int idGrupo;
        int cantidad_Grupos;

        private Button btnPaginaSiguiente = new Button();
        private Button btnPaginaAtras = new Button();

        public static Punto_de_Venta _Puerta;


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uI_GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Punto_de_Venta_Load(object sender, EventArgs e)
        {
            dibujarGrupos();
            contar_Grupos();
        
        }

        public static Punto_de_Venta Puerta
        {
            get
            {
                if(_Puerta == null  || _Puerta.IsDisposed)
                    _Puerta = new Punto_de_Venta();
               return _Puerta;

            }
        }
        public void InsertarVenta()
        {

        }

        void contar_Grupos()
        {
            try
            {
                 CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("select count (IdGrupo) from Grupo_Productos",  CONEXIONMAESTRA.conectar);
                cantidad_Grupos = Convert.ToInt32(cmd.ExecuteScalar());
                 CONEXIONMAESTRA.Cerrar();

            }
            catch (Exception ex)
            {
                 CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.Message);
            }
        }

        public void dibujarGrupos()
        {
            flowLayoutPanelGrupos.Controls.Clear();
            try
            {
                 CONEXIONMAESTRA.abrir();
                SqlCommand CMD = new SqlCommand("Paginar_Grupos",  CONEXIONMAESTRA.conectar);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@Desde", PaginaIncio);
                CMD.Parameters.AddWithValue("@Hasta", PaginaMaxima);
                SqlDataReader rdr = CMD.ExecuteReader();

                while (rdr.Read())
                {
                    Label lbl1 = new Label();
                    Panel p1 = new Panel();
                    PictureBox Img1 = new PictureBox();
                    lbl1.Text = rdr["Grupo"].ToString();
                    lbl1.Name = rdr["IdGrupo"].ToString();
                    lbl1.Size = new Size(119, 25);
                    lbl1.Font = new Font("Segoe UI", 11);
                    lbl1.BackColor = Color.Transparent;
                    lbl1.ForeColor = Color.White;
                    lbl1.Dock = DockStyle.Fill;
                    lbl1.TextAlign = ContentAlignment.MiddleCenter;
                    lbl1.Cursor = Cursors.Hand;

                    p1.Size = new Size(200, 100);
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.Transparent;
                    p1.Name = rdr["idGrupo"].ToString();
                    p1.BackgroundImage = Properties.Resources.naranja;
                    p1.BackgroundImageLayout = ImageLayout.Stretch;

                    Img1.Size = new Size(140, 50);
                    Img1.Dock = DockStyle.Top;
                    Img1.BackgroundImage = null;
                    byte[] bi = (byte[])rdr["Icono"];
                    MemoryStream ms = new System.IO.MemoryStream(bi);
                    Img1.Image = Image.FromStream(ms);
                    Img1.SizeMode = PictureBoxSizeMode.Zoom;
                    Img1.Cursor = Cursors.Hand;
                    Img1.Tag = rdr["Idgrupo"].ToString();
                    Img1.BackColor = Color.Transparent;

                    p1.Controls.Add(lbl1);
                    if (rdr["Estado_de_icono"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(Img1);
                    }
                    lbl1.BringToFront();
                    flowLayoutPanelGrupos.Controls.Add(p1);
                    lbl1.Click += new EventHandler (miEventoLabel);
                    Img1.Click += new EventHandler(miEventoImagen);
                }
                 CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void miEventoLabel(object sender, EventArgs e)
        {
            try
            {
                idGrupo = Convert.ToInt32(((Label)sender).Name);
                Seleccionar_Deseleccionar_Grupos();
                panel_Productos.Controls.Clear();
                PUNTO_DE_VENTA.MostradorProductos frm_Productos = new MostradorProductos();
                frm_Productos.Dock = DockStyle.Fill;
                panel_Productos.Controls.Add(frm_Productos);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void miEventoImagen(object sender, EventArgs e)
        {
            try
            {
                idGrupo = Convert.ToInt32(((PictureBox)sender).Tag);
                Seleccionar_Deseleccionar_Grupos();
                panel_Productos.Controls.Clear();
                PUNTO_DE_VENTA.MostradorProductos frm_Productos = new MostradorProductos();
                frm_Productos.Dock = DockStyle.Fill;
                panel_Productos.Controls.Add(frm_Productos);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Seleccionar_Deseleccionar_Grupos()
        {
            try
            {
                foreach (Control panelP1 in flowLayoutPanelGrupos.Controls)
                {
                    if (panelP1 is Panel)
                    {
                        foreach (var PanelSecundario in panelP1.Controls)
                        {
                            panelP1.BackColor = Color.Transparent;
                            panelP1.BackgroundImage = Properties.Resources.naranja;
                            panelP1.BackgroundImageLayout = ImageLayout.Stretch;
                            break;
                        }
                    }
                }

                foreach (Control panelP2 in flowLayoutPanelGrupos.Controls)
                {
                    if (panelP2 is Panel)
                    {
                        if(panelP2.Name == idGrupo.ToString())
                        {
                            panelP2.BackColor = Color.Transparent;
                            panelP2.BackgroundImage = Properties.Resources.azul;
                            panelP2.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        
                    }
                }
             }
                

            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnVerMesas_Click(object sender, EventArgs e)
        {
            Dispose();
            Visor_De_Mesas frmVisorMesas = new Visor_De_Mesas();
            frmVisorMesas.ShowDialog();
        }

        private void btnGrupoIzquierda_Click(object sender, EventArgs e)
        {
            if (PaginaIncio > 1)
            {
                PaginaIncio -= 10;
                PaginaMaxima -= 10;
                dibujarGrupos();
            }

            
        }

        private void btnGrupoDerecha_Click(object sender, EventArgs e)
        {
            contar_Grupos();
            if (cantidad_Grupos > PaginaMaxima)
            {
                PaginaIncio += 10;
                PaginaMaxima += 10;
                dibujarGrupos();
            }
        }
    }
}
