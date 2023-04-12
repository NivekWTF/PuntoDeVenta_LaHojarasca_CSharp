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
    public partial class Visor_De_Mesas : Form
    {
        public Visor_De_Mesas()
        {
            InitializeComponent();
        }
        int id_salon;
        string estado;
        string Union_de_mesas;
        int Paso = 0;
        int idmesa_Origen;
        int idmesa_Destino;
        int idmesa;
        string nombre_mesa;
        string estado_de_mesa;
        int id_venta_mesa_origen;
        int id_venta_mesa_destino;
        int Estado_de_Herramientas = 0;

        
        void dibujarSalones()
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                 CONEXIONMAESTRA.abrir();
                string query = "Select * from SALON Where Estado='ACTIVO'";
                SqlCommand cmd = new SqlCommand(query,  CONEXIONMAESTRA.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    Panel panelLATERAL = new Panel();
                    b.Text = rdr["Salon"].ToString();
                    b.Name = rdr["Id_salon"].ToString();
                    b.Tag = rdr["Estado"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.ForeColor = Color.White;

                    panelC1.Size = new System.Drawing.Size(244, 58);
                    panelC1.Name = rdr["Id_salon"].ToString();

                    panelLATERAL.Size = new System.Drawing.Size(3, 58);
                    panelLATERAL.Dock = DockStyle.Left;
                    panelLATERAL.BackColor = Color.Transparent;
                    panelLATERAL.Name = rdr["Id_salon"].ToString();

                    panelC1.Controls.Add(b);
                    panelC1.Controls.Add(panelLATERAL);
                    flowLayoutPanel1.Controls.Add(panelC1);
                    b.BringToFront();
                    panelLATERAL.SendToBack();

                    b.Click += new EventHandler(miEvento_salon_button);
                }
                 CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                 CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento_salon_button(System.Object sender, EventArgs e)
        {
            try
            {
                Panel_Mesas.Visible = true;
                Panel_Mesas.Dock = DockStyle.Fill;
                id_salon = Convert.ToInt32(((Button)sender).Name);
                btnParaLlevar.Visible = true;
                PanelFondo.Visible = false;
                PanelFondo.Dock = DockStyle.None;
                dibujarMESAS();
            }
            catch (Exception ex)
            {

            }
        }
        void dibujarMESAS()
        {
            Panel_Mesas.Controls.Clear();
            try
            {
                 CONEXIONMAESTRA.abrir();
                string query = "mostrar_Mesas_PorSalon";
                SqlCommand cmd = new SqlCommand(query,  CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_salon", id_salon);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panel = new Panel();

                    int alto = Convert.ToInt32(rdr["y"].ToString());
                    int ancho = Convert.ToInt32(rdr["x"].ToString());
                    int tamanio_letra = Convert.ToInt32(rdr["Tamanio_letra"].ToString());
                    Point tamanio = new Point(ancho, alto);

                    panel.Tag = rdr["Id_mesa"].ToString();

                    b.Text = rdr["Mesa"].ToString();
                    b.Name = rdr["Id_mesa"].ToString();
                    b.Tag = rdr["Estado_Disponibilidad"].ToString();

                    panel.Size = new System.Drawing.Size(tamanio);

                    if (b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamanio);
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", tamanio_letra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        Panel_Mesas.Controls.Add(b);
                        b.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        Panel_Mesas.Controls.Add(panel);
                    }

                    if (Convert.ToString(b.Tag) == "LIBRE")
                    {
                        b.BackColor = Color.FromArgb(5, 179, 90);
                    }
                    else
                    {
                        b.BackColor = Color.Firebrick;
                    }

                    b.Click += new EventHandler(miEvento_buton_mesa);
                }
                 CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                 CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }


        private void miEvento_buton_mesa(System.Object sender, EventArgs e)
        {
            try
            {
                idmesa = Convert.ToInt32(((Button)sender).Name);
                nombre_mesa = ((Button)sender).Text;
                Dispose();
                Punto_de_Venta frmPDV = new Punto_de_Venta();
                frmPDV.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Visor_De_Mesas_Load_1(object sender, EventArgs e)
        {
            dibujarSalones();
            Union_de_mesas = "INACTIVO";
            PanelFondo.Visible = true;
            PanelFondo.Dock = DockStyle.Fill;
            Panel_Mesas.Visible = false;
            Panel_Mesas.Dock = DockStyle.None;
        }

        

        private void btnHerramientas_Click_1(object sender, EventArgs e)
        {
            if (Estado_de_Herramientas == 1)
            {
                PanelHerramientas.Visible = false;

                Estado_de_Herramientas = 0;
            }
            else if (Estado_de_Herramientas == 0)
            {
                PanelHerramientas.Location = new Point(PanelFondo.Location.X, panel3.Location.Y + btnHerramientas.Location.Y);
                PanelHerramientas.Visible = true;
                PanelHerramientas.BringToFront();
                Estado_de_Herramientas = 1;
            }
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            Dispose();
            Configuraciones.Menu_Configuraciones frmMenuConfiguraciones = new Configuraciones.Menu_Configuraciones();
            frmMenuConfiguraciones.ShowDialog();
        }
    }
}
