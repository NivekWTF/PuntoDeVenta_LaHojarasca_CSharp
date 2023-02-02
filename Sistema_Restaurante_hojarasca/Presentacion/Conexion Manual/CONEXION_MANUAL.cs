using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace Sistema_Restaurante_hojarasca.CONEXION
{
    public partial class CONEXION_MANUAL : Form
    {
        private LIBRERIAS.AES aes = new LIBRERIAS.AES();
        int idTabla;


        public CONEXION_MANUAL()
        {
            InitializeComponent();
        }

        public void SaveToXML(Object dbCNString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbCNString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        string dbcnString;

        public void ReadFromXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcnString, LIBRERIAS.Desencryptacion.appPwdUnique, int.Parse("256")));
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {

            }
        }

        private void CONEXION_MANUAL_Load(object sender, EventArgs e)
        {
            ReadFromXML();
        }

        private void btnGenerarCadena_Click(object sender, EventArgs e)
        {
            comprobar_conexion();
        }

        private void comprobar_conexion()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = txtCnString.Text;
                SqlCommand com = new SqlCommand("select * from Mesas", con);
                con.Open();
                idTabla = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
                SaveToXML(aes.Encrypt(txtCnString.Text, LIBRERIAS.Desencryptacion.appPwdUnique, int.Parse("256")));
                MessageBox.Show("Conexion realizada con exito.", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show("Sin conexion", "Conexion fallida",MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
