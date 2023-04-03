using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Restaurante_hojarasca.Logica
{
    public class LPermisos
    {
        private int _IDPermiso;
        private int _Id_Modulo;
        private int _Id_Usuario;
        public int IDPermiso
        {
            get { return _IDPermiso; }
            set { _IDPermiso = value; }
        }
        public int Id_Modulo
        {
            get { return _Id_Modulo; }
            set { _Id_Modulo = value; }
        }
        public int Id_Usuario
        {
            get { return _Id_Usuario; }
            set { _Id_Usuario = value; }
        }
    }
}
