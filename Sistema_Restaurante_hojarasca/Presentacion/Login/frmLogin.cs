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
        private string rol;
        private string UsuarioInicioCaja;
        private string Estado_AperturaCaja;
        private int idSesion;
        int idMovCaja;

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
                p.Margin = new Padding(15, 15, 15, 15);
                

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
            panel_IngresarContraseña.Location = new Point((panel6.Width - panel_IngresarContraseña.Width) / 2, (panel6.Height - panel_IngresarContraseña.Height) / 2);
            //MessageBox.Show(Login);
        }

        private void ValidarUsuarios()
        {
            LUsuarios parametros = new LUsuarios();
            DUsuarios funcion = new DUsuarios();
            parametros.Password = Bases.Encriptar(txtContraseña.Text);
            parametros.Login = Login;
            funcion.validarUsuarios(parametros, ref idUsuario);

            if (idUsuario != 0)
            {
                mostrarRoles();
                if (rol == "Cajero" || rol == "Administrador")
                {
                    Dispose();
                    PUNTO_DE_VENTA.Visor_De_Mesas frm = new PUNTO_DE_VENTA.Visor_De_Mesas();
                    frm.ShowDialog();
                }
            }
        }
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            ValidarUsuarios();
        }

        private void ValidarAperturaCajas()
        {
            //Se muestran las cajas abiertas por Serial de PC
            MostrarMovimientosDeCaja();
            if(UsuarioInicioCaja == "Nulo")
            {
                Insertar_MovimientosCaja();
                Estado_AperturaCaja = "Nuevo";
                ValidarRol();
            }
            else
            {
                //Mostramos las cajas abiertas por Serial de PC y Usuario
                MostrarMovimientosCaja_Usuario();
            }
        }

        private void MostrarMovimientosCaja_Usuario()
        {
            LMovimientosCaja parametros = new LMovimientosCaja();
            DMovimientosCaja funcion = new DMovimientosCaja();
            parametros.Idusuario = idUsuario;
            funcion.MostrarMovCajaUsuario(ref idMovCaja, parametros);

            if (idMovCaja == 0)
            {
                if (rol == "Administrador")
                {
                    Estado_AperturaCaja = "Abierta";
                    MessageBox.Show("Todos los registros se harán con el Usuario: " + UsuarioInicioCaja + 
                        "*, Inicia Sesión con el Usuario " + UsuarioInicioCaja + "-ó- el Usuario *Admin*", 
                        "Caja Iniciada", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    ValidarRol();
                }
                else
                {
                    MessageBox.Show("Para poder continuar con el Turno de " + UsuarioInicioCaja +
                        "*, Inicia Sesión con el Usuario " + UsuarioInicioCaja + "-ó- el Usuario *Admin*",
                        "Caja Iniciada", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                Estado_AperturaCaja = "Abierta";
                ValidarRol();
            }

        }
        
        private void Insertar_MovimientosCaja()
        {
            LMovimientosCaja parametros = new LMovimientosCaja();
            DMovimientosCaja funcion = new DMovimientosCaja();
            parametros.Idusuario = idUsuario;
            funcion.insertar_MovimientoCaja(parametros);

        }

        private void MostrarMovimientosDeCaja()
        {
            DataTable dt = new DataTable();
            DMovimientosCaja funcion = new DMovimientosCaja();
            funcion.MostrarMovimientosCaja(ref dt);
            if (dt.Rows.Count > 0)
            {
                UsuarioInicioCaja = dt.Rows[0]["Nombre"].ToString();

            }
            else
            {
                UsuarioInicioCaja = "Nulo";
            }
        }

        private void ValidarRol()
        {
            if (rol == "Cajero" || rol== "Administrador")
            {
                if (Estado_AperturaCaja == "Nuevo")
                {
                    MostrarInicioSesion();
                    Dispose();
                    Caja.AperturaCaja frm = new Caja.AperturaCaja();
                    frm.ShowDialog();
                }
                else
                {
                    PasarVisorMesas();
                }
            }
            else
            {
                PasarVisorMesas();
            }
        }

        private void PasarVisorMesas()
        {
            MostrarInicioSesion();
            Dispose();
            PUNTO_DE_VENTA.Visor_De_Mesas frm = new PUNTO_DE_VENTA.Visor_De_Mesas();
            frm.ShowDialog();
        }

        private void MostrarInicioSesion()
        {
            DIniciosSesion funcion = new DIniciosSesion();
            funcion.MostrarInicioSesion(ref idSesion);
            if (idSesion > 0)
            {
                EditarInicioSesion();
            }
            else
            {
                InsertarInicioSesion();
            }
        }

        private void InsertarInicioSesion()
        {
            LIniciosSesion parametros = new LIniciosSesion();
            DIniciosSesion funcion = new DIniciosSesion();
            parametros.idUsuario = idUsuario;
            funcion.insertarInicioSesion(parametros);
        }

        private void EditarInicioSesion()
        {
            LIniciosSesion parametros = new LIniciosSesion();
            DIniciosSesion funcion = new DIniciosSesion();
            parametros.idUsuario = idUsuario;
            parametros.idSesion = idSesion;
            funcion.editarInicioSesion(parametros);
        }
        private void mostrarRoles()
        {
            LUsuarios parametros = new LUsuarios();
            DUsuarios funcion = new DUsuarios();
            parametros.IdUsuario = idUsuario;
            funcion.MostrarRoles(parametros, ref rol);
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña erronea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "0";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtContraseña.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int contador;
            contador = txtContraseña.Text.Count();

            if (contador != 0)
            {
                txtContraseña.Text = txtContraseña.Text.Substring(0, txtContraseña.Text.Count() - 1);
            }
        }

        private void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            PanelContraseña.Visible = true;
        }
    }
}
