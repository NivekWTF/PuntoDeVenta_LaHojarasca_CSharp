using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Restaurante_hojarasca.MODULOS.Configuraciones
{
    public partial class Menu_Configuraciones : Form
    {
        public Menu_Configuraciones()
        {
            InitializeComponent();
        }

        private void Menu_Configuraciones_Load(object sender, EventArgs e)
        {
            centrar_Panel_Contenedor();
        }

        private void centrar_Panel_Contenedor()
        {
            panelContenedor.Location = new Point((panel1.Width - panelContenedor.Width)/2, (panel1.Height - panelContenedor.Height) / 2);
        }

        private void Menu_Configuraciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            PUNTO_DE_VENTA.Visor_De_Mesas Frmvisor_De_Mesas = new PUNTO_DE_VENTA.Visor_De_Mesas();
            Frmvisor_De_Mesas.ShowDialog();
        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            Mesas.Salones frm_configura_Mesas = new Mesas.Salones();
            frm_configura_Mesas.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos.Productos_Rest frm_Productos = new Productos.Productos_Rest();
            frm_Productos.ShowDialog();
        }
    }
}
