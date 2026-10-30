using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CallCenter.Datos
{
    public class AccesoDatos
    {
        private readonly SqlConnection conexion;
        private readonly SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            ;
            ConnectionStringSettings configuracion =
                ConfigurationManager.ConnectionStrings["CallCenterDB"];

            if (configuracion == null || string.IsNullOrWhiteSpace(configuracion.ConnectionString))
            {
                throw new ConfigurationErrorsException("Falta configurar la conexion de la base de datos en web.config.");
            }
            conexion = new SqlConnection(configuracion.ConnectionString);
            comando = new SqlCommand();
            comando.Connection = conexion;
        } 

        public void ValidarConsulta(string consulta)
        {
            if (String.IsNullOrWhiteSpace(consulta))
            {
                throw new ArgumentException("La consulta no puede estar vacia", nameof(consulta));
            }

            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;

        }

        public void Leer()
        {
            conexion.Open();
            lector = comando.ExecuteReader();

        }

        public void CerrarConexion()
        {
            try
            {
                if (lector != null)
                {
                    lector.Close();
                    lector = null;
                }
            }

            finally
            { 
                conexion.Close(); 
            }
        }
            




    }
}
