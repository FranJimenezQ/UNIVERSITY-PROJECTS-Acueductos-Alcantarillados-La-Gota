using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AcueductosAlcantarillados
{
    public partial class FormPrincipal : Form
    {
        private Cliente[] arregloClientes;
        private List<Cliente> listaCliente;
        private int cantCliente;
        public FormPrincipal()
        {
            InitializeComponent();
            arregloClientes = new Cliente[10];
            listaCliente = new List<Cliente>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cantCliente<10)
            {
                FormAgregarClientes forCliente = new FormAgregarClientes();
                if (forCliente.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    arregloClientes[cantCliente] = forCliente.Cliente;
                    listaCliente.Add(arregloClientes[cantCliente]);

                }
            }
            else
            {
                MessageBox.Show("Ya exedió el límite de Registros","Registro de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            FormRegistroClientes registro = new FormRegistroClientes(listaCliente);
            registro.ShowDialog();
        }
    
    }
}
