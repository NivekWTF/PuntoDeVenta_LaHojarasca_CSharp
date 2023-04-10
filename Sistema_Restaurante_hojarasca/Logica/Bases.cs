using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using Sistema_Restaurante_hojarasca.LIBRERIAS;

namespace Sistema_Restaurante_hojarasca.Logica
{
    public class Bases
    {
        public static TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        public static MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

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

        public void DisenioEliminados(ref DataGridView Listado)
        {
            foreach (DataGridViewRow row in Listado.Rows)
            {
                string estado;
                estado = row.Cells["Estado_Icono"].Value.ToString();
                if (estado == "Eliminado")
                {
                    row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        public static string Encriptar(string texto)
        {
            string tempEncriptar = null;
            if (string.IsNullOrEmpty(texto.Trim(' ')))
            {
                tempEncriptar = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(Desencryptacion.appPwdUnique));
                des.Mode = CipherMode.ECB;
                ICryptoTransform encrypt = des.CreateEncryptor();
                byte[] buff = UnicodeEncoding.ASCII.GetBytes(texto);
                tempEncriptar = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            return tempEncriptar;
        }
        public static string Desencriptar(string texto)
        {
            string tempDesencriptar = null;
            if (string.IsNullOrEmpty(texto.Trim(' ')))
            {
                tempDesencriptar = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(Desencryptacion.appPwdUnique));
                des.Mode = CipherMode.ECB;
                ICryptoTransform desencrypta = des.CreateDecryptor();
                byte[] buff = Convert.FromBase64String(texto);
                tempDesencriptar = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length));
            }
            return tempDesencriptar;
        }
    }
}
