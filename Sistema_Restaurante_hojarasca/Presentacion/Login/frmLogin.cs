using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Restaurante_hojarasca.Datos;
using Sistema_Restaurante_hojarasca.Logica;
using UIDC;
using System.IO;

namespace Sistema_Restaurante_hojarasca.Presentacion.Login
{
    public partial class frmLogin : Form
    {
        private string Login;
        private int idUsuario;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DibujarUsuarios();
            CentrarPaneles();
        }

        private void CentrarPaneles()
        {
            panel_visor_Usuarios.Dock = DockStyle.Fill;
            panel_IngresarContraseña.Location = new Point(
                (panel6.Width - panel_IngresarContraseña.Width) / 2, (panel6.Height - panel_IngresarContraseña.Height) / 2);
        }

        private void DibujarUsuarios()
        {
            PanelMostradorUsuarios.Controls.Clear();

            DataTable dt = new DataTable();
            DUsuarios funcion = new DUsuarios();
            funcion.DibujarUsuarios(ref dt);

            foreach (DataRow dataRow in dt.Rows)
            {
                Label lbl1 = new Label();
                Panel p = new Panel();
                UI_CustomPictureBox pictureBox = new UI_CustomPictureBox();

                lbl1.Text = dataRow["Login"].ToString();
                lbl1.Name = dataRow["IdUsuario"].ToString();
                lbl1.Size = new Size(175, 25);
                lbl1.Font = new Font("Inter V Black", 16);
                lbl1.BackColor = Color.Transparent;
                lbl1.ForeColor = Color.White;
                lbl1.Dock = DockStyle.Top;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;
                lbl1.Cursor = Cursors.Hand;
                

                p.Size = new Size(194, 250);
                p.BorderStyle = BorderStyle.None;
                p.BackColor = Color.FromArgb(20, 20, 20);

                pictureBox.BackgroundImage = null;
                byte[] bi = (Byte[])dataRow["Icono"];
                MemoryStream ms = new MemoryStream(bi);
                pictureBox.Image = Image.FromStream(ms);
                
                pictureBox.Tag = dataRow["Login"].ToString();
                pictureBox.Cursor = Cursors.Hand;
                pictureBox.Size = new Size(194, 194);
                pictureBox.Filter = false;
                pictureBox.Elipse = true;
                pictureBox.Dock = DockStyle.Top;
                pictureBox.SendToBack();

                p.Controls.Add(lbl1);
                p.Controls.Add(pictureBox);
                PanelMostradorUsuarios.Controls.Add(p);

                lbl1.Click += Lbl1_Click;
                pictureBox.Click += PictureBox_Click;

            }

        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Login = ((UI_CustomPictureBox)sender).Tag.ToString(); ;
            MostrarPanelContraseña();
        }

        private void Lbl1_Click(object sender, EventArgs e)
        {
            Login = ((Label)sender).Text;
            MostrarPanelContraseña();
        }

        private void MostrarPanelContraseña()
        {
            panel_visor_Usuarios.Visible = false;
            PanelContraseña.Visible = true;
            PanelContraseña.Dock = DockStyle.Fill;
            //MessageBox.Show(Login);
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            LUsuarios parametros = new LUsuarios();
            DUsuarios funcion = new DUsuarios();
            parametros.Password = Bases.Encriptar(txtContraseña.Text);
            parametros.Login = Login;
            funcion.validarUsuarios(parametros, ref idUsuario);

            if (idUsuario != 0)
            {
                Dispose();
                PUNTO_DE_VENTA.Visor_De_Mesas frm = new PUNTO_DE_VENTA.Visor_De_Mesas();
                frm.ShowDialog();
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña erronea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
