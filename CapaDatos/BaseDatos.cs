using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;


namespace SistemaRecursosHumanos.CapaDatos
{
    public class BaseDatos
    {
        private DbConnection Conexion = null;
        private DbTransaction Transaccion = null;
        private DbCommand Comando = null;
        private string CadenaConexion;
        private static DbProviderFactory Factory = null;

        public BaseDatos()
        {           
            Configurar();
        }

        private void Configurar()
        {
            try
            {
                string Proveedor = ConfigurationManager.AppSettings.Get("PROVEEDOR");
                this.CadenaConexion = ConfigurationManager.AppSettings.Get("CADENA");
                BaseDatos.Factory = DbProviderFactories.GetFactory(Proveedor);
            }
            catch (ConfigurationException ex)
            {
                throw new Exception("Error al cargar la configuracion de base de datos.", ex);
            }           
        }

        public void Conectar()
        {
            if(this.Conexion!=null && this.Conexion.State.Equals(ConnectionState.Open))
            {
                throw new Exception("La conexión se encuentra abierta");
            }
            try
            {
                if (this.Conexion == null)
                {
                    this.Conexion = Factory.CreateConnection();
                    this.Conexion.ConnectionString = CadenaConexion;
                }
                this.Conexion.Open();
            }
            catch (DataException ex)
            {
                throw new Exception("Error al conectarse a la Base de Datos", ex);
            }
        }

        public void Desconectar()
        {
            if(this.Conexion.State.Equals(ConnectionState.Open))
            {
                this.Conexion.Close();
            }
        }

        public void CrearComando(string SentenciasSQL)
        {
            this.Comando=Factory.CreateCommand();
            this.Comando.Connection=this.Conexion;
            this.Comando.CommandType=CommandType.Text;
            this.Comando.CommandText=SentenciasSQL;
        }

        public DbDataReader EjecutarConsulta()
        {
            return this.Comando.ExecuteReader();
        }

        public int EjecutarEscalar()
        {
            int Escalar=0;
            try 
	        {	  
                Escalar=int.Parse(this.Comando.ExecuteScalar().ToString());		
	        }
	        catch (Exception ex)
	        {		
		        throw new Exception("Error al ejecutar escalar", ex) ;
	        }
            return Escalar;
        }

        public DbDataReader EjecutarComando()
        {            
            return this.Comando.ExecuteReader();
        }

        public void AsignarParametro(string Nombre, string Separador, string Valor)
        {
            int Indice = this.Comando.CommandText.IndexOf(Nombre);
            string Prefijo = this.Comando.CommandText.Substring(0, Indice);
            string Sufijo = this.Comando.CommandText.Substring(Indice + Nombre.Length);
            this.Comando.CommandText = Prefijo + Separador + Valor + Separador + Sufijo;
        }
        
        public void AsignarParametroEntero(string Nombre, int Valor)
        {
            AsignarParametro(Nombre,"",Valor.ToString());                
        }

        public void AsignarParametroCadena(string Nombre, string Valor)
        {
            AsignarParametro(Nombre,"'",Valor);
        }
        
        public void AsignarParametroDecimal(string Nombre, decimal Valor)
        {
            AsignarParametro(Nombre,"",Valor.ToString());
        }

        public void AsignarParametroDateTime(string Nombre, DateTime Valor)
        {
            AsignarParametro(Nombre, "'", Valor.ToString());
        } 
        
    }
}
