using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Restaurante_hojarasca.Logica
{
    public class LVentas
    {
        private int _idVenta;
        private int _idClienteV;
        private DateTime _fecha_venta;
        private string _Numero_Doc;
        private double _Monto_Total;
        private string _TipoPago;
        private string _Estado;
        private double _IVA;
        private string _Comprobante;
        private int _Id_Usuario;
        private string _Fecha_Pago;
        private string _Accion;
        private double _Saldo;
        private double _PagoCon;
        private double _Porcentaje_IVA;
        private int _ID_caja;
        private string _Referencia_Tarjeta;
        private double _Vuelto;
        private double _Efectivo;
        private double _Credito;
        private double _Tarjeta;
        private int _Id_Mesa;
        private int _Numero_Personas;
        private string _Lugar_Consumo;
        public int idVenta
        {
            get { return _idVenta; }
            set { _idVenta = value; }
        }
        public int idClienteV
        {
            get { return _idClienteV; }
            set { _idClienteV = value; }
        }
        public DateTime fecha_venta
        {
            get { return _fecha_venta; }
            set { _fecha_venta = value; }
        }
        public string Numero_Doc
        {
            get { return _Numero_Doc; }
            set { _Numero_Doc = value; }
        }
        public  double Monto_Total
        {
            get { return _Monto_Total; }
            set { _Monto_Total = value; }
        }
        public string TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public  double IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }
        public string Comprobante
        {
            get { return _Comprobante; }
            set { _Comprobante = value; }
        }
        public int Id_Usuario
        {
            get { return _Id_Usuario; }
            set { _Id_Usuario = value; }
        }
        public string Fecha_Pago
        {
            get { return _Fecha_Pago; }
            set { _Fecha_Pago = value; }
        }
        public string Accion
        {
            get { return _Accion; }
            set { _Accion = value; }
        }
        public  double Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }
        public  double PagoCon
        {
            get { return _PagoCon; }
            set { _PagoCon = value; }
        }
        public  double Porcentaje_IVA
        {
            get { return _Porcentaje_IVA; }
            set { _Porcentaje_IVA = value; }
        }
        public int ID_caja
        {
            get { return _ID_caja; }
            set { _ID_caja = value; }
        }
        public string Referencia_Tarjeta
        {
            get { return _Referencia_Tarjeta; }
            set { _Referencia_Tarjeta = value; }
        }
        public  double Vuelto
        {
            get { return _Vuelto; }
            set { _Vuelto = value; }
        }
        public  double Efectivo
        {
            get { return _Efectivo; }
            set { _Efectivo = value; }
        }
        public  double Credito
        {
            get { return _Credito; }
            set { _Credito = value; }
        }
        public  double Tarjeta
        {
            get { return _Tarjeta; }
            set { _Tarjeta = value; }
        }
        public int Id_Mesa
        {
            get { return _Id_Mesa; }
            set { _Id_Mesa = value; }
        }
        public int Numero_Personas
        {
            get { return _Numero_Personas; }
            set { _Numero_Personas = value; }
        }
        public string Lugar_Consumo
        {
            get { return _Lugar_Consumo; }
            set { _Lugar_Consumo = value; }
        }
    }
}
