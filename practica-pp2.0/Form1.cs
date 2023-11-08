using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace practica_pp2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListaCliente nuevaLista = new ListaCliente();
        private void btnCarga_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fS = null;
                try
                {
                    fS = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sR = new StreamReader(fS);

                    string[] datos;
                    string renglon;
                    int linea = 0;
                    while (!sR.EndOfStream)
                    {
                        renglon = sR.ReadLine();
                        linea++;
                        datos = renglon.Split(';');
                        if (datos.Length <= 2) throw new Exception("Error!!!" + linea.ToString());

                        foreach(Cliente c in nuevaLista.listado)
                        {
                            c.AgregarCompra(2000);
                            c.AgregarPago(30000);
                        }
                    }
                    sR.Close();
                    fS.Close();
                }
                catch(IOException)
                {
                    MessageBox.Show("Error en el archivo");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("error desconocido!" + ex);
                }
            }

        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()== DialogResult.OK)
            {
                FileStream fS = null;
                try
                {
                    fS = new FileStream("Resumen.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sW = new StreamWriter(fS);

                    foreach(Cliente c in nuevaLista.listado)
                    {
                        sW.WriteLine(c.Nombre + ";" + c.Saldo);
                    }
                    sW.Close();
                    fS.Close();
                }
                catch (IOException)
                {
                    MessageBox.Show("Error en el archivo");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error desconocido" + ex);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fileS = null;
            try
            {
                fileS = new FileStream("Clientes.dat", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                nuevaLista = (ListaCliente)formatter.Deserialize(fileS);
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el archivo");
            }
            finally
            {
                if (fileS != null)
                {
                    fileS.Close();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileStream files = null;
            try
            {
                files = new FileStream("Clientes.dat", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(files, nuevaLista);
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el archivo");
            }
            finally
            {
                if (files != null)
                {
                    files.Close();
                }
            }
        }
    }
}
