using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Sistema_Restaurante_hojarasca.MODULOS.Productos
{
    public partial class Productos_Rest : Form
    {
        public Productos_Rest()
        {
            InitializeComponent();
        }

        public static int idGrupo;

        private void Productos_Rest_Load(object sender, EventArgs e)
        {
                dibujarGrupos();
        }

        private void dibujarGrupos()
        {
            try
            {
                Panel_Grupos.Controls.Clear();
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("select * from Grupo_Productos", CONEXION.CONEXIONMAESTRA.conectar);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Creacion de objetos
                    Label lbl = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox img1 = new PictureBox();

                    //Configuraciones para Label con Nombre del grupo
                    lbl.Text = reader["Grupo"].ToString();
                    lbl.Name = reader["IdGrupo"].ToString();
                    lbl.Size = new System.Drawing.Size(119, 25);
                    lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
                    lbl.BackColor = Color.Transparent;
                    lbl.ForeColor = Color.White;
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Cursor = Cursors.Hand;

                    //Configuraciones para panel1
                    p1.Size = new Size(140, 133);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Dock = DockStyle.Bottom;
                    p1.BackColor = Color.FromArgb(43, 43, 43);
                    p1.Name = reader["IdGrupo"].ToString();

                    //Configuraciones para panel2
                    p2.Size = new Size(140, 25);
                    p2.Dock = DockStyle.Top;
                    p2.BackColor = Color.Transparent;
                    p2.BorderStyle = BorderStyle.None;

                    //Configuraciones para Imagen del Grupo de productos
                    img1.Size = new Size(140, 76);
                    img1.Dock = DockStyle.Top;
                    img1.BackgroundImage = null;
                    //Ajuste para guardar en memoria
                    byte[] bi = (byte[])reader["Icono"];
                    MemoryStream ms = new MemoryStream(bi);
                    img1.Image = Image.FromStream(ms);
                    img1.SizeMode = PictureBoxSizeMode.Zoom;
                    img1.Cursor = Cursors.Hand;
                    img1.Tag = reader["idGrupo"].ToString();

                    //Configuraciones para Menu de ajustes de grupo
                    MenuStrip menustp = new MenuStrip();
                    menustp.BackColor = Color.Transparent;
                    menustp.AutoSize = false;
                    menustp.Size = new Size(28, 24);
                    menustp.Dock = DockStyle.Right;
                    menustp.Name = reader["idGrupo"].ToString();

                    //Añadir menus strip al grupo principal
                    ToolStripMenuItem toolStpPRINCIPAL = new ToolStripMenuItem();
                    ToolStripMenuItem toolStpEDITAR = new ToolStripMenuItem();
                    ToolStripMenuItem toolStpELIMINAR = new ToolStripMenuItem();
                    ToolStripMenuItem toolStpRESTAURAR = new ToolStripMenuItem();

                    //Añadir imagen de 3 puntos a ajustes de grupo
                    toolStpPRINCIPAL.Image = Properties.Resources.dots;
                    toolStpPRINCIPAL.BackColor = Color.Transparent;

                    //Propiedades de menu editar
                    toolStpEDITAR.Text = "Editar";
                    toolStpEDITAR.Name = reader["Grupo"].ToString();
                    toolStpEDITAR.Tag = reader["idGrupo"].ToString();

                    //Propiedades de menu eliminar
                    toolStpELIMINAR.Text = "Eliminar";
                    toolStpELIMINAR.Tag = reader["idGrupo"].ToString();

                    //Propiedades de menu Restaurar
                    toolStpRESTAURAR.Text = "Restaurar";
                    toolStpRESTAURAR.Tag = reader["idGrupo"].ToString();

                    //Añadir subgrupos a grupo principal
                    menustp.Items.Add(toolStpPRINCIPAL);
                    toolStpPRINCIPAL.DropDownItems.Add(toolStpEDITAR);
                    toolStpPRINCIPAL.DropDownItems.Add(toolStpELIMINAR);
                    toolStpPRINCIPAL.DropDownItems.Add(toolStpRESTAURAR);

                    p2.Controls.Add(menustp);
                    p1.Controls.Add(lbl);
                    //if el estado no está vacio
                    if (reader["Estado_de_icono"].ToString() != "VACIO")
                    {
                        //se añade imagen a panel
                        p1.Controls.Add(img1);
                    }
                    
                    //se añade panel2 con subgrupo a panel 1
                    p1.Controls.Add(p2);
                    //se envia el label con nombre al frente
                    lbl.BringToFront();
                    //se envia el panel hacia atrás
                    p2.SendToBack();
                    //se añade todo al panel principal
                    Panel_Grupos.Controls.Add(p1);
                    lbl.Click += new EventHandler(eventoLabel);
                    img1.Click += new EventHandler(eventoImagen);
                }
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void eventoLabel(Object sender, EventArgs e)
        {
            idGrupo = Convert.ToInt32(((Label)sender).Name);
            Selec_Deselec_Grupos();
            verProductos_Grupos();
            
        }

        private void Selec_Deselec_Grupos()
        {
            foreach (Panel panelP1 in Panel_Grupos.Controls)
            {
                if(panelP1 is Panel)
                {
                    foreach (Label PanlLateral2 in panelP1.Controls)
                    {
                        if(PanlLateral2 is Label)
                        {
                            panelP1.BackColor = Color.FromArgb(43, 43, 43);
                            break;
                        }
                    }
                }
            }

            //Seleccionado
            foreach (Panel panelP2 in Panel_Grupos.Controls)
            {
                if(panelP2 is Panel)
                {
                    if(panelP2.Name == Convert.ToString(idGrupo))
                    {
                        panelP2.BackColor = Color.Black;
                    }
                }
            }
        }

        private void verProductos_Grupos()
        {
            PanelFondo.Visible = false;
            Panel7.Visible = true;
            Panel7.Dock = DockStyle.Fill;
            dibujarProductos();
        }

        private void eventoImagen(Object sender, EventArgs e)
        {
            idGrupo = Convert.ToInt32(((PictureBox)sender).Tag);
            verProductos_Grupos();
            Selec_Deselec_Grupos();
        }

        private void dibujarProductos()
        {
            try
            {
                PanelProductos_Cont.Controls.Clear();
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostraer_productos_por_grupo", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_grupo", idGrupo);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label lbl = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox img1 = new PictureBox();
                    lbl.Text = rdr["Nombre"].ToString();
                    lbl.Name = rdr["idProducto"].ToString();
                    lbl.Size = new Size(119, 25);
                    lbl.Font = new Font("Microsoft Sans Serif", 13);
                    lbl.BackColor = Color.Transparent;
                    lbl.ForeColor = Color.White;
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Cursor = Cursors.Hand;

                    p1.Size = new Size(140, 133);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Dock = DockStyle.Bottom;
                    p1.BackColor = Color.FromArgb(43,43,43);

                    p2.Size = new Size(140,25);
                    p2.Dock = DockStyle.Top;
                    p2.BackColor = Color.Transparent;
                    p2.BorderStyle = BorderStyle.None;

                    img1.Size = new Size(140, 76);
                    img1.Dock = DockStyle.Top;
                    img1.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Imagen"];
                    MemoryStream ms = new MemoryStream(bi);
                    img1.Image = Image.FromStream(ms);
                    img1.SizeMode = PictureBoxSizeMode.Zoom;
                    img1.Cursor = Cursors.Hand;
                    img1.Tag = rdr["idProducto"].ToString();

                    //Configuraciones para Menu de ajustes de grupo
                    MenuStrip menustp = new MenuStrip();
                    menustp.BackColor = Color.Transparent;
                    menustp.AutoSize = false;
                    menustp.Size = new Size(28, 24);
                    menustp.Dock = DockStyle.Right;
                    menustp.Name = rdr["idProducto"].ToString();

                    //Añadir menus strip al grupo principal
                    ToolStripMenuItem toolStpPRINCIPAL = new ToolStripMenuItem();
                    ToolStripMenuItem toolStpEDITAR = new ToolStripMenuItem();
                    ToolStripMenuItem toolStpELIMINAR = new ToolStripMenuItem();
                    ToolStripMenuItem toolStpRESTAURAR = new ToolStripMenuItem();

                    //Añadir imagen de 3 puntos a ajustes de grupo
                    toolStpPRINCIPAL.Image = Properties.Resources.dots;
                    toolStpPRINCIPAL.BackColor = Color.Transparent;

                    //Propiedades de menu editar
                    toolStpEDITAR.Text = "Editar";
                    toolStpEDITAR.Name = rdr["Nombre"].ToString();
                    toolStpEDITAR.Tag = rdr["idProducto"].ToString();
                    
                    //Propiedades de menu eliminar
                    toolStpELIMINAR.Text = "Eliminar";
                    toolStpELIMINAR.Tag = rdr["idProducto"].ToString();

                    //Propiedades de menu Restaurar
                    toolStpRESTAURAR.Text = "Restaurar";
                    toolStpRESTAURAR.Tag = rdr["idProducto"].ToString();

                    //Añadir subgrupos a grupo principal
                    menustp.Items.Add(toolStpPRINCIPAL);
                    toolStpPRINCIPAL.DropDownItems.Add(toolStpEDITAR);
                    toolStpPRINCIPAL.DropDownItems.Add(toolStpELIMINAR);
                    toolStpPRINCIPAL.DropDownItems.Add(toolStpRESTAURAR);

                    p2.Controls.Add(menustp);
                    p1.Controls.Add(lbl);
                    //if el estado no está vacio
                    if (rdr["Estado_Imagen"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(img1);
                    }
                        
                    
                    
                    //se añade panel2 con subgrupo a panel 1
                    p1.Controls.Add(p2);
                    //se envia el label con nombre al frente
                    lbl.BringToFront();
                    //se envia el panel hacia atrás
                    p2.SendToBack();
                    //se añade todo al panel principal de PRODUCTOS
                    PanelProductos_Cont.Controls.Add(p1);
                }
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnAgregarSalon_Click(object sender, EventArgs e)
        {
            Grupos_Prods frm = new Grupos_Prods();
            frm.FormClosed += new FormClosedEventHandler(frmGrupos_FormClosed);
            frm.ShowDialog();
        }

        public void frmGrupos_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarGrupos();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Productos.Registro_Prods frm = new Registro_Prods();
            frm.FormClosed += new FormClosedEventHandler(frmRegistroProductos_FormClosed);
            frm.ShowDialog();
        }

        public void frmRegistroProductos_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarProductos();
        }
    }
}
