using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Restaurante_hojarasca.Datos;

namespace Sistema_Restaurante_hojarasca.MODULOS.Mesas
{
    public partial class Salones : Form
    {
        private int id_salon;
        private string estado;
        public static string nombre_mesa;
        public static int idMesa;

        public Salones()
        {
            InitializeComponent();
        }

        private void Salones_Load(object sender, EventArgs e)
        {
            PanelFondo.Dock = DockStyle.Fill;
            PanelFondo.BringToFront();
            DibujarSalones();

        }

        private void DibujarMesas()
        {
            try
            {
                Panel_Mesas.Controls.Clear();
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_Mesas_PorSalon", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_salon", id_salon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Button b = new Button();
                    Panel panel = new Panel();
                    int alto = Convert.ToInt32(reader["y"].ToString());
                    int ancho = Convert.ToInt32(reader["x"].ToString());
                    int tamanioLetra = Convert.ToInt32(reader["tamanio_letra"].ToString());
                    Point tamanio = new Point(ancho, alto);
                    
                    panel.BackgroundImage = Properties.Resources.mesa_vacia;
                    panel.BackgroundImageLayout = ImageLayout.Zoom;
                    panel.Cursor = Cursors.Hand;
                    panel.Tag = reader["id_mesa"].ToString();
                    panel.Size = new System.Drawing.Size(tamanio);

                    b.Text = reader["Mesa"].ToString();
                    b.Name = reader["id_mesa"].ToString();
                    
                    if(b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamanio);
                        b.BackColor = Color.FromArgb(5, 179, 90);
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", tamanioLetra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        Panel_Mesas.Controls.Add(b);
                    }
                    else
                    {
                        Panel_Mesas.Controls.Add(panel);
                    }
                    b.Click += new EventHandler(miEvento);
                    panel.Click += new EventHandler(miEventoPanel_click);
                }
                CONEXIONMAESTRA.Cerrar();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                CONEXIONMAESTRA.Cerrar();
            }
           

        }

        private void miEvento(Object sender, EventArgs e)
        {
            nombre_mesa = ((Button)sender).Text;
            idMesa =Convert.ToInt32(((Button)sender).Name);
            Agregar_Mesa_Ok frmAgregarMesa = new Agregar_Mesa_Ok();
            frmAgregarMesa.FormClosed += new FormClosedEventHandler(frm_AgregarMesa_ok_FormClosed);

            frmAgregarMesa.ShowDialog();
        }

        private void miEventoPanel_click(Object sender, EventArgs e)
        {
            idMesa =Convert.ToInt32(((Panel)sender).Tag);
            Agregar_Mesa_Ok frmAgregarMesa = new Agregar_Mesa_Ok();
            frmAgregarMesa.FormClosed += new FormClosedEventHandler(frm_AgregarMesa_ok_FormClosed);
            frmAgregarMesa.ShowDialog();
        }

        private void frm_AgregarMesa_ok_FormClosed(Object sender, FormClosedEventArgs e)
        {
            DibujarMesas();
        }

        private void DibujarSalones()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                CONEXIONMAESTRA.abrir();
                SqlCommand CMD = new SqlCommand("mostrar_SALON", CONEXIONMAESTRA.conectar);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@buscar", txtBuscarSalon.Text);
                SqlDataReader dataread = CMD.ExecuteReader();

                while (dataread.Read())
                {
                    Button btn = new Button();
                    Panel panelC1 = new Panel();
                    btn.Text = dataread["Salon"].ToString();
                    btn.Name = dataread["Id_salon"].ToString();
                    btn.Dock = DockStyle.Fill;
                    btn.BackColor = Color.Transparent;
                    btn.Font = new System.Drawing.Font("Montserrat", 12);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(39, 176, 71);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Tag = dataread["Estado"].ToString();

                    panelC1.Size = new System.Drawing.Size(290, 58);
                    panelC1.Name = dataread["Id_salon"].ToString();

                    string estado;
                    estado = dataread["Estado"].ToString();

                    if (estado.Equals("ELIMINADO"))
                    {
                        btn.Text = dataread["Salon"].ToString() + " - Eliminado";
                        btn.ForeColor = Color.FromArgb(231, 63, 67);
                    }
                    else
                    {
                        btn.ForeColor = Color.White;
                    }

                    panelC1.Controls.Add(btn);
                    flowLayoutPanel1.Controls.Add(panelC1);
                    btn.Click += new EventHandler(mievento_salon_btn);
                }
                CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }


        private void mievento_salon_btn(object sender, EventArgs e)
        {
            PanelFondo.Visible = false;
            PanelFondo.Dock = DockStyle.None;
            Panel_Mesas.Visible = true;
            Panel_Mesas.Dock = DockStyle.Fill;
            id_salon = Convert.ToInt32(((Button) sender).Name);
            estado = Convert.ToString(((Button)sender).Tag);
            DibujarMesas();

            foreach (Panel PanelC2 in flowLayoutPanel1.Controls)
            {
                if(PanelC2 is Panel)
                {
                    foreach (Button button in PanelC2.Controls)
                    {
                        if(button is Button)
                        {
                            button.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }
            string Nombre = Convert.ToString(((Button)sender).Name);
            foreach (Panel PanelC1 in flowLayoutPanel1.Controls)
            {
                if(PanelC1 is Panel)
                {
                    foreach (Button boton in PanelC1.Controls)
                    {
                        if(boton.Name == Nombre)
                        {
                            boton.BackColor = Color.OrangeRed;
                            break;
                        }
                    }
                }
            }
        }

        public void frm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            DibujarSalones();
        }

        private void btnAgregarSalon_Click_1(object sender, EventArgs e)
        {
            MODULOS.Mesas.Configurar_Mesas frm = new MODULOS.Mesas.Configurar_Mesas();
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.ShowDialog();
        }

        private void btnAumentarTamMesa_Click(object sender, EventArgs e)
        {
            aumentarTamanioMesa();
        }

        internal void aumentarTamanioMesa()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("aumentar_Tamanio_mesa", CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.Cerrar();
                DibujarMesas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }

        internal void disminuirTamanioMesa()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("disminuir_Tamanio_mesa", CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.Cerrar();
                DibujarMesas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        internal void disminuirTamanioLetra()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("disminuir_tamanio_Letra", CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.Cerrar();
                DibujarMesas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        internal void aumentarTamanioLetra()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("aumentar_tamanio_Letra", CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.Cerrar();
                DibujarMesas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisminuirTamMesa_Click(object sender, EventArgs e)
        {
            disminuirTamanioMesa();
        }

        private void btnAumentarTamLetra_Click(object sender, EventArgs e)
        {
            aumentarTamanioLetra();
        }

        private void btnDisminuirTamLetra_Click(object sender, EventArgs e)
        {
            disminuirTamanioLetra();
        }
    }
}
