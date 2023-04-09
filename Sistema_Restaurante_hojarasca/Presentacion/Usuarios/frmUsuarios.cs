﻿using System;
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
using System.IO;

namespace Sistema_Restaurante_hojarasca.Presentacion.Usuarios
{
    public partial class frmUsuarios : Form
    {
        int idusuario;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            panel_Registro.Visible = true;
            lblMensajeIcono.Visible = true;
            CargaModulos();
            panel_Registro.BringToFront();
            panel_Registro.Dock = DockStyle.Fill;
            
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtContrasena.Clear();
            txtCorreo.Clear();
            txtUsuario.Clear();
            
        }

        private void CargaModulos()
        {
            DModulos funcion = new DModulos();
            DataTable dt = new DataTable();
            funcion.mostrar_Modulos(ref dt);
            dtgListadoPermisos.DataSource = dt;

        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbRoles.SelectedIndex;

            foreach (DataGridViewRow row in dtgListadoPermisos.Rows)
            {
                bool marcar = Convert.ToBoolean(row.Cells["Marcar"].Value);
                string modulo = row.Cells["Modulo"].Value.ToString();

                if (index == 0)
                {
                    if (modulo == "Ventas")
                        row.Cells[0].Value = true;

                    if (modulo == "Compras")
                        row.Cells[0].Value = false;

                    if (modulo == "Caja")
                        row.Cells[0].Value = false;
                }
                if (index == 1)
                {
                    if (modulo == "Ventas")
                        row.Cells[0].Value = true;

                    if (modulo == "Compras")
                        row.Cells[0].Value = false;

                    if (modulo == "Caja")
                        row.Cells[0].Value = true;
                }
                if (index == 2)
                {
                    row.Cells[0].Value = true;
                }





            }
            
            
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if(ValidaCampos(txtNombre.Text) && ValidaCampos(txtUsuario.Text)
                && ValidaCampos(txtCorreo.Text) && ValidaCampos(txtContrasena.Text))
            {
                InsertarUsuarios();
                LimpiarCampos();
                lblMensajeIcono.Visible = true;
                cmbRoles.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No puedes dejar en blanco los campos.", "Mensaje",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            
        }

        private bool ValidaCampos(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena) || string.IsNullOrEmpty(cadena))
                return false;

            return true;
        }

       

        private void InsertarUsuarios()
        {
            LUsuarios parametros = new LUsuarios();
            DUsuarios funcion = new DUsuarios();
            parametros.Nombre = txtNombre.Text;
            parametros.Login = txtUsuario.Text;
            parametros.Password = txtContrasena.Text;
            MemoryStream ms = new MemoryStream();
            PicIcono.Image.Save(ms, PicIcono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();
            parametros.Correo = txtCorreo.Text;
            parametros.Rol = cmbRoles.Text;
            
            

            if(funcion.insertarUsuarios(parametros) == true)
            {
                obtenerIdUsuario();
                InsertarPermisos();
            }

            
        }

        private void InsertarPermisos()
        {
            foreach (DataGridViewRow row in dtgListadoPermisos.Rows)
            {
                int idModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                bool marcado = Convert.ToBoolean(row.Cells["Marcar"].Value);

                if (marcado == true)
                {
                    LPermisos parametros = new LPermisos();
                    DPermisos funcion = new DPermisos();

                    parametros.Id_Modulo = idModulo;
                    parametros.Id_Usuario = idusuario;

                    if (funcion.Insertar_Permisos(parametros) == true)
                    {
                        MessageBox.Show("Registrado con éxito!");
                    }
                }
            }
        }

        private void obtenerIdUsuario()
        {
            DUsuarios funcion = new DUsuarios();
            funcion.ObtenerIDUsuarios(ref idusuario,txtUsuario.Text);
        }

        private void AgregaNuevoIcono_Click(object sender, EventArgs e)
        {
            OpenFileDialog.InitialDirectory = "";
            OpenFileDialog.Filter = "Imágenes|*.PNG;*.JPG)";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.Title = "Agrega un nuevo ícono...";

            if(OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                PicIcono.BackgroundImage = null;
                PicIcono.Image = new Bitmap(OpenFileDialog.FileName);
                OcultaIconos();
            }
        }

        private void OcultaIconos()
        {
            panelIconos.Visible = false;
            lblMensajeIcono.Visible = false;
            PicIcono.Visible = true;
        }

        private void lblMensajeIcono_Click(object sender, EventArgs e)
        {
            panelIconos.Visible = true;
            panelIconos.Dock = DockStyle.Fill;
            panelIconos.BringToFront();
        }


        private void btnVolverRegistro_Click(object sender, EventArgs e)
        {
            panelIconos.Visible = false;
        }

        private void p1_Click(object sender, EventArgs e)
        {
            PicIcono.Image = p1.Image;
            OcultaIconos();
        }

        
        private void p2_Click(object sender, EventArgs e)
        {
            PicIcono.Image = p2.Image;
            OcultaIconos();
        }

        private void p3_Click(object sender, EventArgs e)
        {
            PicIcono.Image = p3.Image;
            OcultaIconos();
        }

        private void p4_Click(object sender, EventArgs e)
        {
            PicIcono.Image = p4.Image;
            OcultaIconos();
        }

        private void p5_Click(object sender, EventArgs e)
        {
            PicIcono.Image = p5.Image;
            OcultaIconos();
        }

        private void p6_Click(object sender, EventArgs e)
        {
            PicIcono.Image = p6.Image;
            OcultaIconos();
        }

        private void p8_Click(object sender, EventArgs e)
        {
            PicIcono.Image = p8.Image;
            OcultaIconos();
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            string dato = txtNombre.Text;

            if (ValidaCampos(dato))
            {
                errorProvider1.SetError(txtNombre, "");
            }
            else
            {
                errorProvider1.SetError(txtNombre, "No puedes dejar este campo vacío");
                txtNombre.Focus();
            }
        }

        private void txtUsuario_Validated(object sender, EventArgs e)
        {
            string dato = txtUsuario.Text;

            if (ValidaCampos(dato))
            {
                errorProvider1.SetError(txtUsuario, "");
            }
            else
            {
                errorProvider1.SetError(txtUsuario, "No puedes dejar este campo vacío");
                txtUsuario.Focus();
            }
        }

        private void txtCorreo_Validated(object sender, EventArgs e)
        {
            string dato = txtCorreo.Text;

            if (ValidaCampos(dato))
            {
                errorProvider1.SetError(txtCorreo, "");
            }
            else
            {
                errorProvider1.SetError(txtCorreo, "No puedes dejar este campo vacío");
                txtCorreo.Focus();
            }
        }

        private void txtContrasena_Validated(object sender, EventArgs e)
        {
            string dato = txtContrasena.Text;

            if (ValidaCampos(dato))
            {
                errorProvider1.SetError(txtContrasena, "");
            }
            else
            {
                errorProvider1.SetError(txtContrasena, "No puedes dejar este campo vacío");
                txtContrasena.Focus();
            }
        }
    }
}
