using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using SistemaRecursosHumanos.CapaDatos;

namespace SistemaRecursosHumanos.CapaNegocios
{
    public class IngresoSistema
    {
        public string Usuario {get; set;}
        public string Contrasena {get; set;}
        BaseDatos ObjetoBD=new BaseDatos();

        public IngresoSistema VerificarUsuario(string usuario, string contrasena)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"SELECT Usuario, Contrasena FROM IngresoAlSistema WHERE Usuario=@Usuario and Contrasena=@Contrasena ");            
            int Busqueda = 0;
            if (int.TryParse(usuario, out Busqueda))
            {
                ObjetoBD.AsignarParametroCadena("@Usuario", "");
                ObjetoBD.AsignarParametroCadena("@Contrasena", "");                
            }
            else
            {
                ObjetoBD.AsignarParametroCadena("@Usuario", usuario);
                ObjetoBD.AsignarParametroCadena("@Contrasena", contrasena);
            }
            DbDataReader reader = ObjetoBD.EjecutarConsulta();
            if (reader.Read())
            {
                IngresoSistema ObjetoIngresoSistema= new IngresoSistema();
                ObjetoIngresoSistema.Usuario=reader.GetString(0);
                ObjetoIngresoSistema.Contrasena=reader.GetString(1);
                return ObjetoIngresoSistema;
            }
            return null;           
        }

    }
}
