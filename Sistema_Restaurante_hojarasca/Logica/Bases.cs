using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sistema_Restaurante_hojarasca.Logica
{
    public class Bases
    {
        public void DisenioDataGridView(ref DataGridView Listado)
        {
            Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Listado.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle cabecera = new DataGridViewCellStyle();
            cabecera.BackColor = Color.White;
            cabecera.ForeColor = Color.Black;
            cabecera.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            Listado.ColumnHeadersDefaultCellStyle = cabecera;
        }
    }
}
