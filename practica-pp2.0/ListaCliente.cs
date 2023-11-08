using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace practica_pp2._0
{
    class ListaCliente
    {
        public List<Cliente> listado = new List<Cliente>();
        public int UltimoCodigo { get; set; }
        public int TotalDeClientes
        {
            get { return listado.Count; }
        }

        public bool AgregarCliente(Cliente nuevoC)
        {
            bool existe=false;

            if (!existe)
            {
                listado.Add(nuevoC);
            }
            return existe;
        }

        public bool BorrarCliente(int codigo)
        {
            Cliente nuevoC = VerCliente(codigo);
            bool existe = false;
            if (nuevoC != null)
            {
                existe = true;
                listado.Remove(nuevoC);
            }
            else
            {
                throw new Exception("no encontrado");
            }
            return existe;
        }

        public Cliente VerCliente(int codigo)       //famosa busqueda binaria
        {
            Cliente nuevoC = new Cliente("", codigo, 200000, 0);
            listado.Sort();
            int orden = listado.BinarySearch(nuevoC);
            if (orden >=0)
            {
                nuevoC = listado[orden];
            }
            else
            {
                nuevoC = null;
            }
            return nuevoC;
        }

        public Cliente[] ListaCompleta()
        {
            Cliente[] client = new Cliente[listado.Count];
            int indice = 0;
            foreach(Cliente c in listado)
            {
                client[indice++] = c;
            }
            return client;
        }

    }
}
