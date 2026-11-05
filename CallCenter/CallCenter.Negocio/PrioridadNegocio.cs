using System;
using System.Collections.Generic;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    public class PrioridadNegocio
    {
        private bool ExisteNombre(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta( "SELECT COUNT(*) FROM dbo.Prioridades WHERE UPPER(LTRIM(RTRIM(Nombre))) = UPPER(@Nombre);");

                datos.SetearParametro("@Nombre", nombre.Trim());

                int cantidad = Convert.ToInt32(datos.EjecutarEscalar());

                return cantidad > 0;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Prioridad> Listar()
        {
            List<Prioridad> lista = new List<Prioridad>();
            AccesoDatos datos = new AccesoDatos();

            // Valida y ejecuta la consulta

            try
            {
                datos.ValidarConsulta("SELECT Id, Nombre, Nivel, Activo FROM dbo.Prioridades ORDER BY Nivel, Id; ");
                datos.Leer();

                // Crear un objeto por cada registro recibido

                while (datos.Lector.Read())
                {
                    Prioridad prioridad = new Prioridad();

                    prioridad.Id = (int)datos.Lector["Id"];
                    prioridad.Nombre = (string)datos.Lector["Nombre"];
                    prioridad.Nivel = (int)datos.Lector["Nivel"];
                    prioridad.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(prioridad);
                }

                return lista;
            }

            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Agregar(Prioridad prioridad)
        {
            if (prioridad == null)
            {
                throw new ArgumentNullException(nameof(prioridad));
            }

            if (string.IsNullOrWhiteSpace(prioridad.Nombre))
            {
                throw new ArgumentException("Ingresá un nombre para la prioridad");
            }
            string nombre = prioridad.Nombre.Trim();

            if(nombre.Length > 15)
            {
                throw new InvalidOperationException("El nombre no puede superar los 15 caracteres");
            }

            if(prioridad.Nivel <=0)
            {
                throw new ArgumentException("El nivel debe ser mayor a cero");
            }

            if (ExisteNombre(nombre))
            {
                throw new ArgumentException("Ya existe una prioridad con ese nombre.");
            }



            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta("INSERT INTO dbo.Prioridades (Nombre, Nivel, Activo) VALUES (@Nombre, @Nivel, @Activo)");

                datos.SetearParametro("@Nombre", nombre);
                datos.SetearParametro("@Nivel", prioridad.Nivel);
                datos.SetearParametro("@Activo", true);

                datos.ejecutarAccion();
            }
            finally
            {  
                datos.CerrarConexion();
            }
        }

    }
}
