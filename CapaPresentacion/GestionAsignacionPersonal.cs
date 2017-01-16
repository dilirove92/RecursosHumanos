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
    public partial class GestionAsignacionPersonal : Form
    {
        public GestionAsignacionPersonal()
        {
            InitializeComponent();
        }

        public void MetodoLimpiarTodosLosText()
        {
            txtIdEmpleado.Text = "";
            txtIdDepartamento.Text = "";
            txtCargo.Text = "";
            txtSueldo.Text = "";
            txtFechaPosesion.Text = "";
        }

        private void btnBuscarAsignacionPersonal_Click(object sender, EventArgs e)
        {
            if (txtIdEmpleado.Text != "")
            {
                try
                {
                    AsignacionPersonal ObjetoAsignacionPersonal = new AsignacionPersonal().BuscarAsignacionPersonal(txtIdEmpleado.Text);
                    txtIdEmpleado.Text = ObjetoAsignacionPersonal.IdEmpleado;
                    txtIdDepartamento.Text = ObjetoAsignacionPersonal.IdDepartamento.ToString();
                    txtCargo.Text = ObjetoAsignacionPersonal.Cargo;
                    txtSueldo.Text = ObjetoAsignacionPersonal.Sueldo.ToString();
                    txtFechaPosesion.Text = ObjetoAsignacionPersonal.FechaPosesion.ToString();
                }
                catch (Exception)
                {
                    if (txtIdEmpleado.Text != "")
                    {
                        try
                        {
                            Empleado ObjetoEmpleado = new Empleado().BuscarRegistroEmpleado(txtIdEmpleado.Text);
                            txtIdEmpleado.Text = ObjetoEmpleado.IdEmpleado;
                            MessageBox.Show("El Empleado con Id " + txtIdEmpleado.Text.ToString() + " no ha sido asignado a un Departamento");
                            MetodoLimpiarTodosLosText();
                            txtIdEmpleado.Focus();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ese registro de Empleado no existe....!!! ");
                            MetodoLimpiarTodosLosText();
                            txtIdEmpleado.Focus();
                        }
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Ingrese el Id de Empleado a buscar...!!! ");
                MetodoLimpiarTodosLosText();
                txtIdEmpleado.Focus();
            }
        }
        
        private void btnAgregarAsignacionPersonal_Click(object sender, EventArgs e)
        {
            if ((txtIdEmpleado.Text!="")&&(txtIdDepartamento.Text!="")&&(txtCargo.Text!="")&&(txtSueldo.Text!="")&&(txtFechaPosesion.Text!=""))
            {
                try
                {
                    AsignacionPersonal ObjetoAsignacionPersonal = new AsignacionPersonal();
                    ObjetoAsignacionPersonal.AgregarAsignacionPersonal(txtIdEmpleado.Text, int.Parse(txtIdDepartamento.Text), txtCargo.Text, decimal.Parse(txtSueldo.Text), DateTime.Parse(txtFechaPosesion.Text));
                    MessageBox.Show("Registro insertado correctamente con el IdEmpleado: " + txtIdEmpleado.Text.ToString());
                }
                catch (Exception)
                {
                    if (txtIdEmpleado.Text != "")
                    {
                        try
                        {
                            AsignacionPersonal ObjetoAsignacionPersonal = new AsignacionPersonal().BuscarAsignacionPersonal(txtIdEmpleado.Text);
                            txtIdEmpleado.Text = ObjetoAsignacionPersonal.IdEmpleado;
                            MessageBox.Show("El Empleado con Id " + txtIdEmpleado.Text.ToString() + " ya ha sido asignado a un Departamento");                            
                        }
                        catch (Exception)
                        {                
                            if (txtIdDepartamento.Text != "")
                            {
                                try
                                {                                    
                                    Departamento ObjetoDepartamento = new Departamento().BuscarRegistroDepartamento(txtIdDepartamento.Text);
                                    txtIdDepartamento.Text = ObjetoDepartamento.IdDepartamento.ToString();
                                    MessageBox.Show("Ese Id de Empleado no existe....!!! ");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Ese Id de Departamento no existe....!!! ");
                                }
                            }                        
                        }                        
                    }
                    MetodoLimpiarTodosLosText();
                    txtIdEmpleado.Focus(); 
                }
            }
            else
            {
                MessageBox.Show("Por favor....Llenar todos los datos para la Asignación del Empleado que desea agregar!!! ");
                MetodoLimpiarTodosLosText();
                txtIdEmpleado.Focus();
            }
        }

        private void btnModificarAsignacionPersonal_Click(object sender, EventArgs e)
        {
            if ((txtIdEmpleado.Text != "") && (txtIdDepartamento.Text != "") && (txtCargo.Text != "") && (txtSueldo.Text != "") && (txtFechaPosesion.Text != ""))
            {
                try
                {
                    AsignacionPersonal ObjetoAsignacionPersonal2 = new AsignacionPersonal().BuscarAsignacionPersonal(txtIdEmpleado.Text);
                    txtIdEmpleado.Text = ObjetoAsignacionPersonal2.IdEmpleado;
                    AsignacionPersonal ObjetoAsignacionPersonal = new AsignacionPersonal();
                    ObjetoAsignacionPersonal.ModificarAsignacionPersonal(txtIdEmpleado.Text, int.Parse(txtIdDepartamento.Text), txtCargo.Text, decimal.Parse(txtSueldo.Text), DateTime.Parse(txtFechaPosesion.Text));
                    MessageBox.Show("Registro modificado correctamente con el IdEmpleado: " + txtIdEmpleado.Text.ToString());
                }
                catch (Exception)
                {
                    if (txtIdEmpleado.Text != "")
                    {
                        try
                        {
                            AsignacionPersonal ObjetoAsignacionPersonal = new AsignacionPersonal().BuscarAsignacionPersonal(txtIdEmpleado.Text);
                            txtIdEmpleado.Text = ObjetoAsignacionPersonal.IdEmpleado;
                            MessageBox.Show("Ese Id de Departamento no existe....!!! ");
                        }
                        catch (Exception)
                        {
                            if (txtIdDepartamento.Text != "")
                            {
                                try
                                {
                                    Departamento ObjetoDepartamento = new Departamento().BuscarRegistroDepartamento(txtIdDepartamento.Text);
                                    txtIdDepartamento.Text = ObjetoDepartamento.IdDepartamento.ToString();
                                    MessageBox.Show("Ese Id de Empleado no existe....!!! ");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Ese Id de Empleado e Id de Departamento no existe....!!! ");
                                }
                            }
                        }
                    }
                    MetodoLimpiarTodosLosText();
                    txtIdEmpleado.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor....Llenar todos los datos para la Asignación del Empleado que desea agregar!!! ");
                MetodoLimpiarTodosLosText();
                txtIdEmpleado.Focus();
            }
        }

        private void btnEliminarAsignacionPersonal_Click(object sender, EventArgs e)
        {            
            if (txtIdEmpleado.Text != "")
            {
                try
                {
                    AsignacionPersonal ObjetoAsignacionPersonal2 = new AsignacionPersonal().BuscarAsignacionPersonal(txtIdEmpleado.Text);
                    txtIdEmpleado.Text = ObjetoAsignacionPersonal2.IdEmpleado;
                    AsignacionPersonal ObjetoAsignacionPersonal = new AsignacionPersonal();
                    ObjetoAsignacionPersonal.EliminarAsignacionPersonal(txtIdEmpleado.Text);
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
