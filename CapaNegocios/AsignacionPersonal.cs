using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using SistemaRecursosHumanos.CapaDatos;

namespace SistemaRecursosHumanos.CapaNegocios
{
    public class AsignacionPersonal
    {
        public string IdEmpleado {get; set; }
        public int IdDepartamento {get; set; }
        public string Cargo {get; set; }
        public decimal Sueldo {get; set; }
        public DateTime FechaPosesion {get; set; }
        BaseDatos ObjetoBD = new BaseDatos();

        public void AgregarAsignacionPersonal(string idempleado, int iddepartamento, string cargo, decimal sueldo, DateTime fechaposesion)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"INSERT INTO AsignacionDePersonal (IdEmpleado, IdDepartamento, Cargo, Sueldo, FechaPosesion) VALUES (@IdEmpleado, @IdDepartamento, @Cargo, @Sueldo, @FechaPosesion);");
            ObjetoBD.AsignarParametroCadena("@IdEmpleado", idempleado);
            ObjetoBD.AsignarParametroEntero("@IdDepartamento", iddepartamento);
            ObjetoBD.AsignarParametroCadena("@Cargo", cargo);
            ObjetoBD.AsignarParametroDecimal("@Sueldo", sueldo);
            ObjetoBD.AsignarParametroDateTime("@FechaPosesion", fechaposesion);           
            ObjetoBD.EjecutarComando();
        }


        public AsignacionPersonal BuscarAsignacionPersonal(string _id)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"SELECT IdEmpleado, IdDepartamento, Cargo, Sueldo, FechaPosesion FROM AsignacionDePersonal 
                                    WHERE IdEmpleado=@IdEmpleado");
            int Busqueda = 0;
            if (int.TryParse(_id, out Busqueda))
            {
                ObjetoBD.AsignarParametroCadena("@IdEmpleado", "");
            }
            else
            {
                ObjetoBD.AsignarParametroCadena("@IdEmpleado", _id);
            }
            DbDataReader reader = ObjetoBD.EjecutarConsulta();
            if (reader.Read())
            {
                AsignacionPersonal ObjetoAsignacionPersonal = new AsignacionPersonal();
                ObjetoAsignacionPersonal.IdEmpleado = reader.GetString(0);
                ObjetoAsignacionPersonal.IdDepartamento = reader.GetInt32(1);
                ObjetoAsignacionPersonal.Cargo = reader.GetString(2);
                ObjetoAsignacionPersonal.Sueldo = reader.GetDecimal(3);
                ObjetoAsignacionPersonal.FechaPosesion = reader.GetDateTime(4);
                return ObjetoAsignacionPersonal;
            }
            return null;
        }

        public void EliminarAsignacionPersonal(string id)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando("DELETE FROM AsignacionDePersonal WHERE IdEmpleado=@IdEmpleado");
            ObjetoBD.AsignarParametroCadena("@IdEmpleado", id);
            ObjetoBD.EjecutarComando();
        }

        public void ModificarAsignacionPersonal(string idempleado, int iddepartamento, string cargo, decimal sueldo, DateTime fechaposesion)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"UPDATE AsignacionDePersonal SET IdDepartamento=@IdDepartamento, Cargo=@Cargo, Sueldo=@Sueldo, FechaPosesion=@FechaPosesion WHERE IdEmpleado=@IdEmpleado");
            ObjetoBD.AsignarParametroEntero("@IdDepartamento", iddepartamento);
            ObjetoBD.AsignarParametroCadena("@Cargo", cargo);
            ObjetoBD.AsignarParametroDecimal("@Sueldo", sueldo);
            ObjetoBD.AsignarParametroDateTime("@FechaPosesion", fechaposesion);
            ObjetoBD.AsignarParametroCadena("@IdEmpleado", idempleado);
            ObjetoBD.EjecutarComando();
        }

        public override string ToString()
        {
            return string.Format("IdEmpleado: {0}  IdDepartamento: {1} Cargo: {2} Sueldo: {3}  FechaPosesion: {4}",
                this.IdEmpleado, this.IdDepartamento.ToString(), this.Cargo, this.Sueldo.ToString(), this.FechaPosesion.ToString());
        }

    }
}
