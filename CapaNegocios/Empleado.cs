using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using SistemaRecursosHumanos.CapaDatos;

namespace SistemaRecursosHumanos.CapaNegocios
{
    public class Empleado
    {
        public string IdEmpleado { get; set; }
        public string Nombres{get; set;}
        public string Apellidos { get; set; }
        public int Edad { get; set; }        
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        BaseDatos ObjetoBD = new BaseDatos();

        public void AgregarRegistroEmpleado(string idempleado, string nombres, string apellidos, int edad, string domicilio, string telefono, string email)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"INSERT INTO Empleados (IdEmpleado, Nombres, Apellidos, Edad, Domicilio, Telefono, Email) VALUES (@IdEmpleado, @Nombres, @Apellidos, @Edad, @Domicilio, @Telefono, @Email);");
            ObjetoBD.AsignarParametroCadena("@IdEmpleado", idempleado);
            ObjetoBD.AsignarParametroCadena("@Nombres", nombres);
            ObjetoBD.AsignarParametroCadena("@Apellidos", apellidos);
            ObjetoBD.AsignarParametroEntero("@Edad", edad);
            ObjetoBD.AsignarParametroCadena("@Domicilio", domicilio);
            ObjetoBD.AsignarParametroCadena("@Telefono", telefono);
            ObjetoBD.AsignarParametroCadena("@Email", email);
            ObjetoBD.EjecutarComando();
        }

        public Empleado BuscarRegistroEmpleado(string _id)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"SELECT IdEmpleado, Nombres, Apellidos, Edad, Domicilio, Telefono, Email FROM Empleados 
                                    WHERE IdEmpleado=@IdEmpleado or Nombres=@Nombres or Apellidos=@Apellidos or Email=@Email");
            int outId=0;
            if (int.TryParse(_id, out outId))
            {
                ObjetoBD.AsignarParametroCadena("@IdEmpleado", "");
                ObjetoBD.AsignarParametroCadena("@Nombres", "");
                ObjetoBD.AsignarParametroCadena("@Apellidos", "");
                ObjetoBD.AsignarParametroCadena("@Email", "");
            }
            else
            {
                ObjetoBD.AsignarParametroCadena("@IdEmpleado", _id);
                ObjetoBD.AsignarParametroCadena("@Nombres", _id);
                ObjetoBD.AsignarParametroCadena("@Apellidos", _id);
                ObjetoBD.AsignarParametroCadena("@Email", _id);
            }
            DbDataReader reader = ObjetoBD.EjecutarConsulta();
            if(reader.Read())
            {
                Empleado ObjetoEmpleado = new Empleado();
                ObjetoEmpleado.IdEmpleado = reader.GetString(0);
                ObjetoEmpleado.Nombres = reader.GetString(1);
                ObjetoEmpleado.Apellidos = reader.GetString(2);
                ObjetoEmpleado.Edad = reader.GetInt32(3);
                ObjetoEmpleado.Domicilio = reader.GetString(4);
                ObjetoEmpleado.Telefono = reader.GetString(5);
                ObjetoEmpleado.Email = reader.GetString(6);
                return ObjetoEmpleado;
            }
            return null;
        }

        public void EliminarRegistroEmpleado(string id)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando("DELETE FROM Empleados WHERE IdEmpleado=@IdEmpleado");
            ObjetoBD.AsignarParametroCadena("@IdEmpleado", id);
            ObjetoBD.EjecutarComando();
        }

        public void ModificarRegistroEmpleado(string id, string nombres, string apellidos, int edad, string domicilio, string telefono, string email)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"UPDATE Empleados SET Nombres=@Nombres, Apellidos=@Apellidos, Edad=@Edad, Domicilio=@Domicilio, Telefono=@Telefono, Email=@Email WHERE IdEmpleado=@IdEmpleado");
            ObjetoBD.AsignarParametroCadena("@Nombres", nombres);
            ObjetoBD.AsignarParametroCadena("@Apellidos", apellidos);
            ObjetoBD.AsignarParametroEntero("@Edad", edad);
            ObjetoBD.AsignarParametroCadena("@Domicilio", domicilio);
            ObjetoBD.AsignarParametroCadena("@Telefono", telefono);
            ObjetoBD.AsignarParametroCadena("@Email", email);
            ObjetoBD.AsignarParametroCadena("@IdEmpleado", id);
            ObjetoBD.EjecutarComando();
        }

        public override string ToString()
        {
            return string.Format("IdEmpleado: {0}  Nombres: {1} Apellidos: {2} Edad: {3}  Domicilio: {4} Telefono: {5} Email: {6}",
                this.IdEmpleado, this.Nombres, this.Apellidos, this.Edad.ToString(), this.Domicilio, this.Telefono, this.Email);
        } 
        
    }
}
