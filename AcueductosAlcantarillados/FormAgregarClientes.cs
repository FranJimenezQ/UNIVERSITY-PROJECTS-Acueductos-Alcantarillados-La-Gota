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
using AcueductosAlcantarillados.Clases;
using System.Text.RegularExpressions;

namespace AcueductosAlcantarillados
{
    public partial class FormAgregarClientes : Form
    {
        private Cliente cliente;

        

        public FormAgregarClientes()
        {
            InitializeComponent();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDatos.ValidarDatosVacios(this.Controls, errorProvider1);
                ValidarCorreo(txtCorreo.Text.Trim());
                agregarDatos();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentNullException)
            {
                this.DialogResult = DialogResult.None;
                return;
            }
            
        }
        public void agregarDatos()
        {
            cliente = new Cliente(); 
            cliente.Identificacion = int.Parse(TxtID.Text);
            cliente.Nombre = TxtNombre.Text;
            cliente.PrimerApellido = TxtPrimerApellido.Text;
            cliente.SegundoApellido = TxtSegundoApellido.Text;
            cliente.Celular = int.Parse(TxtCelular.Text);
            cliente.Correo = txtCorreo.Text;
        }
        public Cliente Cliente { get => cliente; }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.ValidarNumeros(e, TxtID, errorProvider1);
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.ValidarLetras(e, TxtNombre, errorProvider1);
        }

        private void TxtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.ValidarLetras(e, TxtPrimerApellido, errorProvider1);
        }

        private void TxtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.ValidarLetras(e, TxtSegundoApellido, errorProvider1);
        }

        private void TxtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.ValidarNumeros(e, TxtCelular, errorProvider1);
        }

        public  void ValidarCorreo(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    errorProvider1.Clear();
                }
                else
                {
                    
                    errorProvider1.SetError(txtCorreo, "Correo Incorrecto");
                    txtCorreo.Focus();
                    throw new ArgumentNullException();
                }
            }
            else
            {
                
                errorProvider1.SetError(txtCorreo, "Correo Incorrecto");
                txtCorreo.Focus();
                throw new ArgumentNullException();
            }
        }
    }
}
