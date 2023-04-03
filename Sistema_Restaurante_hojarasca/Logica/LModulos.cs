using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Restaurante_hojarasca.Logica
{
    public class LModulos
    {
        private int _IdModulo;
        private string _Modulo;
        public int IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }
        public string Modulo
        {
            get { return _Modulo; }
            set { _Modulo = value; }
        }
    }
}
