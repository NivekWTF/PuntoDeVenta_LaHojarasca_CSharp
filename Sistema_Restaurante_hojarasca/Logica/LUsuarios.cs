using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Restaurante_hojarasca.Logica
{
    public class LUsuarios
    {
        private int _IdUsuario;
        private string _Nombre;
        private string _Login;
        private string _Password;
        private byte[] _Icono;
        private string _Correo;
        private string _Rol;
        private string _Estado_Icono;
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public byte[] Icono
        {
            get { return _Icono; }
            set { _Icono = value; }
        }
        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        public string Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }
        public string Estado_Icono
        {
            get { return _Estado_Icono; }
            set { _Estado_Icono = value; }
        }
    }
}
