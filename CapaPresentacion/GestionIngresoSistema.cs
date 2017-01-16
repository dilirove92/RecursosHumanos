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
    public partial class GestionIngresoSistema : Form
    {
        public GestionIngresoSistema()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text!="" && txtContrasena.Text!="")
            {               
                try
                {
                    IngresoSistema ObjetoIngresoSistema = new IngresoSistema().VerificarUsuario(txtUsuario.Text, txtContrasena.Text);
                    txtUsuario.Text = ObjetoIngresoSistema.Usuario;
                    txtContrasena.Text = ObjetoIngresoSistema.Contrasena;
                    //GestionIngresoSistema ObjetoGestionIngresoSistema = new GestionIngresoSistema();
                    //ObjetoGestionIngresoSistema.Close();    
                    txtUsuario.Text = "";
                    txtContrasena.Text = "";
                    GestionOpciones ObjetoGestionOpciones= new GestionOpciones();
                    ObjetoGestionOpciones.Show();
                    MessageBox.Show("Bienvenido al Sistema de Recursos Humanos. ");                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Usuario o contraseña no válida. Inténtalo de nuevo. ");
                    txtUsuario.Text = "";
                    txtContrasena.Text = "";
                    txtUsuario.Focus();
                }
            }
        }
       
    }
}
