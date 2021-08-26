using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcueductosAlcantarillados.Clases
{
    class ValidarDatos
    {
        public static void ValidarDatosVacios(Control.ControlCollection controles, ErrorProvider error)
        {
            bool exito = true;//NullReferenceException 
            int ncontroles = controles.Count;
            Control control;
            for (int i = 0; i < ncontroles; i++)
            {
                control = controles[i];
                if (control is TextBox)
                {
                    if (control.Tag.ToString().Equals("0"))
                    {
                        if (((TextBox)control).Text.Equals(""))
                        {
                            error.SetError(control, "INGRESE DATOS");
                            exito = false;
                        }
                        else
                        {
                            error.SetError(control, "");
                        }
                    }
                }
            }
            if (!exito) throw new ArgumentNullException();

        }
        public static void ValidarLetras(KeyPressEventArgs e, TextBox Txtvalidar, ErrorProvider EPValidarDatos)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                {
                    throw new FormatException();
                }
                EPValidarDatos.Clear();
            }
            catch (FormatException error)
            {
                EPValidarDatos.SetError(Txtvalidar, "INGRESE SOLO\n Letras");
                e.Handled = true;
                Txtvalidar.Focus();
            }
        }
        public static void ValidarNumeros(KeyPressEventArgs e, TextBox Txtvalidar, ErrorProvider EPValidarDatos)
        {
            try
            {
                if (!Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    throw new FormatException();
                }
                EPValidarDatos.Clear();
            }
            catch (FormatException error)
            {
                EPValidarDatos.SetError(Txtvalidar, "INGRESE SOLO\n NÚMEROS");
                e.Handled = true;
                Txtvalidar.Focus();
            }
        }
        
    }
}
