using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace practica_pp2._0
{
    [Serializable]
    class Cliente
    {
        private string nombre;
        private string razonSocial;
        private int codigo;
        private double saldo;
        private double tope;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        public Cliente(string nombre, int codigo, double tope,double saldo)
        {
            this.nombre = nombre;
            this.codigo = codigo;
            this.tope = tope;
            this.saldo = saldo;
        }

        public void AgregarCompra(double monto)
        {
            saldo += monto;
        }

        public void AgregarPago(double monto)
        {
            saldo -= monto;
        }

        public double LeerSaldo()
        {
            return saldo;
        }
    }
}
