using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using SistemaRecursosHumanos.CapaDatos;

namespace SistemaRecursosHumanos.CapaNegocios
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        BaseDatos ObjetoBD = new BaseDatos();

        public int InsertarRegistroDepartamento(string nombredepartamento)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"INSERT INTO Departamentos (NombreDepartamento) VALUES (@NombreDepartamento); SELECT @@IDENTITY");
            ObjetoBD.AsignarParametroCadena("@NombreDepartamento", nombredepartamento);
            int iddepartamento = ObjetoBD.EjecutarEscalar();
            return iddepartamento;
        }

        public Departamento BuscarRegistroDepartamento(string _id)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"SELECT IdDepartamento, NombreDepartamento FROM Departamentos WHERE IdDepartamento=@IdDepartamento or NombreDepartamento=@NombreDepartamento");
            int Busqueda=0;
            if (int.TryParse(_id, out Busqueda))
            {
                ObjetoBD.AsignarParametroEntero("@IdDepartamento", int.Parse(_id));
                ObjetoBD.AsignarParametroCadena("@NombreDepartamento", "");
            }
            else
            {
                ObjetoBD.AsignarParametroEntero("@IdDepartamento", Busqueda);
                ObjetoBD.AsignarParametroCadena("@NombreDepartamento", _id);
            }
            DbDataReader reader = ObjetoBD.EjecutarConsulta();
            if(reader.Read())
            {
                Departamento ObjetoDepartamento= new Departamento();
                ObjetoDepartamento.IdDepartamento = reader.GetInt32(0);
                ObjetoDepartamento.NombreDepartamento = reader.GetString(1);
                return ObjetoDepartamento;
            }
            return null;
        }

        public void EliminarRegistroDepartamento(int iddepartamento)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"DELETE FROM Departamentos WHERE IdDepartamento=@IdDepartamento");
            ObjetoBD.AsignarParametroEntero("@IdDepartamento", iddepartamento);
            ObjetoBD.EjecutarComando();
        }

        public void ModificarRegistroDepartamento(int iddepartamento, string nombredepartamento)
        {
            ObjetoBD.Conectar();
            ObjetoBD.CrearComando(@"UPDATE Departamentos SET NombreDepartamento=@NombreDepartamento WHERE IdDepartamento=@IdDepartamento");
            ObjetoBD.AsignarParametroCadena("@NombreDepartamento", nombredepartamento);
            ObjetoBD.AsignarParametroEntero("@IdDepartamento", iddepartamento);
            ObjetoBD.EjecutarComando();
        }

        public override string ToString()
        {
            return string.Format("IdDepartamento: {0} NombreDepartamento: {1}", this.IdDepartamento.ToString(), this.NombreDepartamento);
        }


    }
}
