using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SistemaRecursosHumanos.CapaPresentacion.GestionIngresoSistema());
            //Application.Run(new SistemaRecursosHumanos.CapaPresentacion.GestionEmpleados());
            //Application.Run(new SistemaRecursosHumanos.CapaPresentacion.GestionDepartamentos());
            //Application.Run(new SistemaRecursosHumanos.CapaPresentacion.GestionAsignacionPersonal());
        }
    }
}
