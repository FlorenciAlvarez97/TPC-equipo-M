using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    public class TipoIncidenciaNegocio
    {

        private string ValidarDatos(TipoIncidencia tipo)
        {
            if (tipo == null)
            {
                throw new ArgumentNullException(nameof(tipo));
            }

            if (string.IsNullOrWhiteSpace(tipo.Nombre))
            {
                throw new ArgumentException("Ingresá un nombre para el tipo de incidencia");
            }

            string nombre = tipo.Nombre.Trim();

            if (nombre.Length > 50)
            {
                throw new ArgumentException("El nombre no puede superar los 50 caracteres");
            }
            return nombre;
        }

        private bool ExisteNombre(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta("SELECT COUNT(*) FROM dbo.TiposIncidencia WHERE UPPER(LTRIM(RTRIM(Nombre))) = UPPER(@Nombre)");

                datos.SetearParametro("@Nombre", nombre.Trim());


                int cantidad = Convert.ToInt32(datos.EjecutarEscalar());

                return cantidad > 0;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<TipoIncidencia> Listar()
        {
            List<TipoIncidencia> lista = new List<TipoIncidencia>();
            AccesoDatos datos = new AccesoDatos();

            // Valida y ejecuta la consulta

            try
            {
                datos.ValidarConsulta("SELECT Id, Nombre, Descripcion, Activo FROM dbo.TiposIncidencia ORDER BY Nombre; ");
                datos.Leer();

                // Crear un objeto por cada registro recibido

                while (datos.Lector.Read())
                {
                    TipoIncidencia tipo = new TipoIncidencia();

                    tipo.Id = (int)datos.Lector["Id"];
                    tipo.Nombre = (string)datos.Lector["Nombre"];
                    tipo.Descripcion= datos.Lector["Descripcion"] is DBNull ? null: (string)datos.Lector["Descripcion"];
                    tipo.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(tipo);
                }

                return lista;
            }

            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Agregar(TipoIncidencia nuevo)
        {
            string nombre = ValidarDatos(nuevo);

            if (ExisteNombre(nombre))
            {
                throw new ArgumentException("Ya existe un tipo de incidencia con ese nombre.");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta("INSERT INTO dbo.TiposIncidencia (Nombre, Descripcion, Activo) VALUES (@Nombre, @Descripcion, @Activo)");

                datos.SetearParametro("@Nombre", nombre);
                datos.SetearParametro("@Descripcion", string.IsNullOrWhiteSpace(nuevo.Descripcion) ? null: nuevo.Descripcion.Trim());
                datos.SetearParametro("@Activo", nuevo.Activo);

                datos.ejecutarAccion();
            }
            finally
            {
                ; datos.CerrarConexion();
            }
        }


    }
}
