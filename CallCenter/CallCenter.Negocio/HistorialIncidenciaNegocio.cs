using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    public class HistorialIncidenciaNegocio
    {
        public void Agregar(HistorialIncidencia nuevo)
        {
            if (nuevo == null)
            {
                throw new ArgumentNullException(nameof(nuevo));
            }

            if (nuevo.Incidencia == null || nuevo.Incidencia.Id <= 0)
            {
                throw new ArgumentException("La incidencia no es válida");
            }

            if (nuevo.Usuario == null || nuevo.Usuario.Id <= 0)
            {
                throw new ArgumentException("Debés identificar al usuario");
            }

            if (string.IsNullOrWhiteSpace(nuevo.Comentario))
            {
                throw new ArgumentException("El comentario es obligatorio");
            }

            if (nuevo.Comentario.Trim().Length > 1000)
            {
                throw new ArgumentException("El comentario no puede superar los 1000 caracteres.");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta( @"INSERT INTO dbo.HistorialIncidencia (IdIncidencia, IdUsuario, Comentario, IdEstadoResultante)
                                      SELECT Id, @IdUsuario, @Comentario, IdEstado FROM dbo.Incidencias WHERE Id = @IdIncidencia;");

                datos.SetearParametro("@IdIncidencia", nuevo.Incidencia.Id);
                datos.SetearParametro("@IdUsuario", nuevo.Usuario.Id);
                datos.SetearParametro("@Comentario", nuevo.Comentario.Trim());

                datos.ejecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public List<HistorialIncidencia> ListarPorIncidencia(int idIncidencia)
        {
            List<HistorialIncidencia> lista = new List<HistorialIncidencia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta( @"SELECT h.Id, h.IdIncidencia, h.Fecha, h.IdUsuario, u.Nombre AS NombreUsuario, h.Comentario, h.IdEstadoResultante,
                                      e.Nombre AS NombreEstado FROM dbo.HistorialIncidencia h INNER JOIN dbo.Usuarios u ON h.IdUsuario = u.Id INNER JOIN dbo.EstadosIncidencia e
                                      ON h.IdEstadoResultante = e.Id WHERE h.IdIncidencia = @IdIncidencia ORDER BY h.Fecha DESC, h.Id DESC;");

                datos.SetearParametro("@IdIncidencia", idIncidencia);

                datos.Leer();

                while (datos.Lector.Read())
                {
                    HistorialIncidencia historial = new HistorialIncidencia();

                    historial.Id = (int)datos.Lector["Id"];
                    historial.Fecha = (DateTime)datos.Lector["Fecha"];
                    historial.Comentario = (string)datos.Lector["Comentario"];

                    historial.Incidencia = new Incidencia();
                    historial.Incidencia.Id = (int)datos.Lector["IdIncidencia"];

                    historial.Usuario = new Usuario();
                    historial.Usuario.Id = (int)datos.Lector["IdUsuario"];
                    historial.Usuario.Nombre = (string)datos.Lector["NombreUsuario"];

                    historial.EstadoResultante = new EstadoIncidencia();
                    historial.EstadoResultante.Id = (int)datos.Lector["IdEstadoResultante"];
                    historial.EstadoResultante.Nombre = (string)datos.Lector["NombreEstado"];

                    lista.Add(historial);
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}
