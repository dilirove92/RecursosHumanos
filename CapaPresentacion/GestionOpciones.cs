using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaRecursosHumanos.CapaPresentacion
{
    public partial class GestionOpciones : Form
    {
        public GestionOpciones()
        {
            InitializeComponent();
        }
              
        private void DatosPersonalesDeEmpleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GestionEmpleados ObjetoGestionEmpleados = new GestionEmpleados();
            ObjetoGestionEmpleados.Show();
        }

        private void DatosDeDepartamentosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            GestionDepartamentos ObjetoGestionDepartamentos = new GestionDepartamentos();
            ObjetoGestionDepartamentos.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AsignacionDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionAsignacionPersonal ObjetoGestionAsignacionPersonal = new GestionAsignacionPersonal();
            ObjetoGestionAsignacionPersonal.Show();

        }
    }
}
