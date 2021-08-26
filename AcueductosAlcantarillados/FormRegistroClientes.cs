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
    public partial class FormRegistroClientes : Form
    {
        
        private List<Cliente> listaCliente= new List<Cliente>();
        public FormRegistroClientes(List<Cliente> plistaCliente)
        {
            InitializeComponent();
            listaCliente = plistaCliente;
        }

        private void RegistroClientes_Load(object sender, EventArgs e)
        {
            AgregarDatosTable();
        }
        public void AgregarDatosTable()
        {

            dgvPeticiones.Rows.Clear();
            foreach (Cliente cliente in listaCliente)
            {
                dgvPeticiones.Rows.Add(cliente.Identificacion, cliente.Nombre, cliente.PrimerApellido, cliente.SegundoApellido, cliente.Celular,cliente.Correo);
            }
        }
    }
}
