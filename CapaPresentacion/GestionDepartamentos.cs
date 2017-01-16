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
    public partial class GestionDepartamentos : Form
    {
        public GestionDepartamentos()
        {
            InitializeComponent();
        }

        public void MetodoLimpiarTodosLosText()
        {
            txtIdDepartamento.Text = "";
            txtNombreDepartamento.Text = ""; 
        }

        private void btnBuscarDepartamento_Click(object sender, EventArgs e)
        {
            if (txtIdDepartamento.Text != "")
            {
                try
                {
                    Departamento ObjetoDepartamento = new Departamento().BuscarRegistroDepartamento(txtIdDepartamento.Text);
                    txtIdDepartamento.Text = ObjetoDepartamento.IdDepartamento.ToString();
                    txtNombreDepartamento.Text = ObjetoDepartamento.NombreDepartamento;
                }
                catch (Exception)
                {
                    MessageBox.Show("No existe ese Departamento...!!! ");
                    MetodoLimpiarTodosLosText();
                    txtIdDepartamento.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ingrese el Id de Departamento a buscar...!!! ");
                MetodoLimpiarTodosLosText();
                txtIdDepartamento.Focus();
            }
        }

        private void btnModificarDepartamento_Click(object sender, EventArgs e)
        {
            if ((txtIdDepartamento.Text != "") && (txtNombreDepartamento.Text != ""))
            {
                try
                {
                    Departamento ObjetoDepartamento = new Departamento();
                    ObjetoDepartamento.ModificarRegistroDepartamento(int.Parse(txtIdDepartamento.Text), txtNombreDepartamento.Text);
                    MessageBox.Show("Registro de Departamento ha sido modificado exitosamente. ");
                }
                catch (Exception)
                {
                    MessageBox.Show("No existe ese Departamento...!!! ");
                    MetodoLimpiarTodosLosText();
                    txtIdDepartamento.Focus();
                }
            }
            else
            {
                if ((txtIdDepartamento.Text == "") || (txtNombreDepartamento.Text != ""))
                {
                    MessageBox.Show("Ingrese el Id de Departamento a modificar...!!! ");                    		
	            }
	            else
                {
                    MessageBox.Show("Por favor llenar todos los campos...!!! ");
	            }
                MetodoLimpiarTodosLosText();
                txtIdDepartamento.Focus();                 
            }            
        }

        private void btnEliminarDepartamento_Click(object sender, EventArgs e)
        {
            if (txtIdDepartamento.Text != "")
            {
                try
                {
                    Departamento ObjetoDepartamento = new Departamento();
                    ObjetoDepartamento.EliminarRegistroDepartamento(int.Parse(txtIdDepartamento.Text));
                    MessageBox.Show("Registro de Departamento eliminado con éxito. ");
                }
                catch (Exception)
                {
                    MessageBox.Show("No existe ese Departamento...!!! ");
                    MetodoLimpiarTodosLosText();
                    txtIdDepartamento.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ingrese el Id de Departamento a eliminar...!!! ");
                MetodoLimpiarTodosLosText();
                txtIdDepartamento.Focus();
            }
        }

        private void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {
            if ((txtIdDepartamento.Text == "") && (txtNombreDepartamento.Text != ""))
            {                
                Departamento ObjetoDepartamento = new Departamento();
                int IdGenerado = ObjetoDepartamento.InsertarRegistroDepartamento(txtNombreDepartamento.Text);
                txtIdDepartamento.Text = IdGenerado.ToString();
                MessageBox.Show("Registro insertado correctamente con el IdDepartamento: " + IdGenerado.ToString());
            }
            else
            {
                MessageBox.Show("Por favor ingrese solamente el Nombre del Departamento que desea agregar...!!! ");
                MetodoLimpiarTodosLosText();
                txtNombreDepartamento.Focus();
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MetodoLimpiarTodosLosText();
            txtIdDepartamento.Focus();
        }

    }
}
