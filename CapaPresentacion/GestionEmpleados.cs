using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaRecursosHumanos.CapaNegocios;

namespace SistemaRecursosHumanos.CapaPresentacion
{
    public partial class GestionEmpleados : Form
    {
        public GestionEmpleados()
        {
            InitializeComponent();
        }

        public void MetodoLimpiarTodosLosText()
        {
            txtIdEmpleado.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtDomicilio.Text = "";
            txtTelefono.Text = "";
            txtEdad.Text = "";
            txtEmail.Text = "";
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            if (txtIdEmpleado.Text != "")
            {
                try
                {
                    Empleado ObjetoEmpleado = new Empleado().BuscarRegistroEmpleado(txtIdEmpleado.Text);
                    txtIdEmpleado.Text = ObjetoEmpleado.IdEmpleado;
                    txtNombres.Text = ObjetoEmpleado.Nombres;
                    txtApellidos.Text = ObjetoEmpleado.Apellidos;
                    txtEdad.Text = ObjetoEmpleado.Edad.ToString();
                    txtDomicilio.Text = ObjetoEmpleado.Domicilio;
                    txtTelefono.Text = ObjetoEmpleado.Telefono;
                    txtEmail.Text = ObjetoEmpleado.Email;
                }
                catch (Exception)
                {
                    MessageBox.Show("No existe ese Empleado...!!! ");
                    MetodoLimpiarTodosLosText();
                    txtIdEmpleado.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ingrese el Id de Empleado a buscar...!!! ");
                MetodoLimpiarTodosLosText();
                txtIdEmpleado.Focus();
            }            
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            if ((txtIdEmpleado.Text!="")&&(txtNombres.Text!="")&&(txtApellidos.Text!="")&&(txtEdad.Text!="")&&(txtDomicilio.Text!="")&&(txtTelefono.Text!="")&&(txtEmail.Text!=""))
            {
                try
                {                    
                    Empleado ObjetoEmpleado = new Empleado();
                    ObjetoEmpleado.AgregarRegistroEmpleado(txtIdEmpleado.Text, txtNombres.Text, txtApellidos.Text, int.Parse(txtEdad.Text), txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
                    MessageBox.Show("Registro insertado correctamente con el IdEmpleado: " + txtIdEmpleado.Text.ToString());
                }
                catch (Exception)
                {
                    //Empleado ObjetoEmpleado = new Empleado().BuscarRegistroEmpleado(txtIdEmpleado.Text);
                    //txtIdEmpleado.Text = ObjetoEmpleado.IdEmpleado;
                    MessageBox.Show("El Empleado con Id: " + txtIdEmpleado.Text + " ya existe...!!! ");
                    MetodoLimpiarTodosLosText();
                    txtIdEmpleado.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor....Llenar todos los datos del Empleado que desea agregar!!! ");
                MetodoLimpiarTodosLosText();
                txtIdEmpleado.Focus();                                                
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            if ((txtIdEmpleado.Text != "") && (txtNombres.Text != "") && (txtApellidos.Text != "") && (txtEdad.Text != "") && (txtDomicilio.Text != "") && (txtTelefono.Text != "") && (txtEmail.Text != ""))
            {
                try
                {
                    Empleado ObjetoEmpleado2 = new Empleado().BuscarRegistroEmpleado(txtIdEmpleado.Text);
                    txtIdEmpleado.Text = ObjetoEmpleado2.IdEmpleado;
                    Empleado ObjetoEmpleado = new Empleado();
                    ObjetoEmpleado.ModificarRegistroEmpleado(txtIdEmpleado.Text, txtNombres.Text, txtApellidos.Text, int.Parse(txtEdad.Text), txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
                    MessageBox.Show("Registro de Empleado ha sido modificado exitosamente. ");
                }
                catch (Exception)
                {
                    MessageBox.Show("No existe ese Empleado...!!! ");
                    MetodoLimpiarTodosLosText();
                    txtIdEmpleado.Focus();
                }
            }
            else
            {
                if (txtIdEmpleado.Text == "")
                {
                    MessageBox.Show("Ingrese el Id de Empleado a modificar...!!! ");                    
                }
                else
                {
                    MessageBox.Show("Por favor llenar todos los campos...!!! ");                    
                }
                MetodoLimpiarTodosLosText();
                txtIdEmpleado.Focus();
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (txtIdEmpleado.Text != "")
            {
                try
                {
                    Empleado ObjetoEmpleado2 = new Empleado().BuscarRegistroEmpleado(txtIdEmpleado.Text);
                    txtIdEmpleado.Text = ObjetoEmpleado2.IdEmpleado;
                    Empleado ObjetoEmpleado = new Empleado();                    
                    ObjetoEmpleado.EliminarRegistroEmpleado(txtIdEmpleado.Text);
                    MessageBox.Show("Registro de Empleado eliminado con éxito. ");
                }
                catch (Exception)
                {
                    MessageBox.Show("No existe ese Empleado...!!! ");
                    MetodoLimpiarTodosLosText();
                    txtIdEmpleado.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ingrese el Id de Empleado a eliminar...!!! ");
                MetodoLimpiarTodosLosText();
                txtIdEmpleado.Focus();
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MetodoLimpiarTodosLosText();
            txtIdEmpleado.Focus();
        }
    }
}
