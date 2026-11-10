using System;
using System.Collections.Generic;
using System.Globalization;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    public class PrioridadNegocio
    {
        private string ValidarDatos(Prioridad prioridad)
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

            if (nombre.Length > 50)
            {
                throw new ArgumentException("El nombre no puede superar los 15 caracteres");
            }

            if (prioridad.Nivel <= 0)
            {
                throw new ArgumentException("El nivel dene ser mayor a cero");
            }
            return nombre;
        }

        private bool ExisteNombre(string nombre, int idExcluir = 0)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta( "SELECT COUNT(*) FROM dbo.Prioridades WHERE UPPER(LTRIM(RTRIM(Nombre))) = UPPER(@Nombre) AND Id <> @IdExcluir;");

                datos.SetearParametro("@Nombre", nombre.Trim());
                datos.SetearParametro("@IdExcluir", idExcluir);

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

        public Prioridad ObtenerPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID de la prioridad no es válido");
            }

            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.ValidarConsulta(@"SELECT Id, Nombre, Nivel, Activo FROM dbo.Prioridades WHERE Id = @Id;");
            

            datos.SetearParametro("@Id", id);
            datos.Leer();

                if (datos.Lector.Read())
                {
                    Prioridad prioridad= new Prioridad();

                    prioridad.Id = (int) datos.Lector["Id"];
                    prioridad.Nombre = (string)datos.Lector["Nombre"];
                    prioridad.Nivel = (int)datos.Lector["Nivel"];
                    prioridad.Activo = (bool)datos.Lector["Activo"];

                    return prioridad;
                }
              return null;
            }
            finally
            {  
                datos.CerrarConexion();
            }
        }
        public void Agregar(Prioridad prioridad)
        {
            string nombre = ValidarDatos(prioridad);

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
               ; datos.CerrarConexion();
            }
        }

        public void Modificar(Prioridad prioridad)
        {
            string nombre = ValidarDatos(prioridad);

            if(prioridad.Id <= 0)
            {
                throw new ArgumentException("El ID de la prioridad no es válido");
            }

            Prioridad existente = ObtenerPorId(prioridad.Id);

            if(existente == null)
            {
                throw new ArgumentException("No se encontró la prioridad que querés modificar");
            }

            if (ExisteNombre(nombre,prioridad.Id))
            {
                throw new ArgumentException("Ya existe otra prioridad con ese nombre");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta(@"UPDATE dbo.Prioridades SET Nombre = @Nombre, Nivel = @Nivel WHERE Id = @Id;");

                datos.SetearParametro("@Nombre", nombre);
                datos.SetearParametro("@Nivel", prioridad.Nivel);
                datos.SetearParametro("@Id", prioridad.Id);

                datos.ejecutarAccion();

            }
            finally
            {
                datos.CerrarConexion();
            }
        }
         public void CambiarEstado(int id, bool activo)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID no es válido");
            }

            Prioridad existente = ObtenerPorId(id);

            if (existente == null)
            {
                throw new ArgumentException("No se encontró la prridad que querés actualizar");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta("UPDATE dbo.Prioridades SET Activo = @Activo WHERW Id = @Id;");

                datos.SetearParametro("@Activo", activo);
                datos.SetearParametro("@Id", id);

                datos.ejecutarAccion();
            }

            finally
            {
                datos.CerrarConexion();
            }

        }

    }
}
