using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaRecursosHumanos.CapaNegocios;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            Empleado objetoIngreso = new Empleado().BuscarRegistroEmpleado(txtIdEmpleado.Text);
            txtIdEmpleado.Text = objetoIngreso.IdEmpleado.ToString();
            txtNombres.Text = objetoIngreso.Nombres;
            txtApellidos.Text = objetoIngreso.Apellidos;
            txtPuesto.Text = objetoIngreso.Puesto;
            txtIdDepartamento.Text = objetoIngreso.IdDepartamento.ToString();
            txtSalario.Text = objetoIngreso.Salario.ToString();
            txtEmail.Text = objetoIngreso.Email;
            
                //Empleado objetoIngreso = new Empleado();
                //MessageBox.Show(objetoIngreso.IngresoMaximo().ToString());
            
        }

        //private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        //{
        //    if (txtIdEmpleado.Text == "")
        //    {
        //        Empleado objetoIngreso = new Empleado();
        //        int idGenerado = objetoIngreso.AgregarRegistroEmpleado(txtNombres.Text, txtApellidos.Text, txtPuesto.Text, int.Parse(txtIdDepartamento.Text), decimal.Parse(txtSalario.Text), txtEmail.Text);
        //        txtIdEmpleado.Text = idGenerado.ToString();
        //        MessageBox.Show("Usted Inserto Correctamente el Registro con ID :" + idGenerado.ToString());
        //    }
        //}
    }
}
