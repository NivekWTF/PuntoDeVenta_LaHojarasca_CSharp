using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Restaurante_hojarasca
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MODULOS.PUNTO_DE_VENTA.Visor_De_Mesas frm_visor_de_mesas = new MODULOS.PUNTO_DE_VENTA.Visor_De_Mesas();
            frm_visor_de_mesas.FormClosed += frm_closed;
            frm_visor_de_mesas.ShowDialog();
            Application.Run();
        }

        private static void frm_closed(object sender, FormClosedEventArgs e)
        { 
                Application.ExitThread();
                Application.Exit();
        }
    }
}
