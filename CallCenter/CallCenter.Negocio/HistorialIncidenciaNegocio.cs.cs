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
                                      SELECT Id, @IdUsuario, @Comentario, Id Estado FROM dbo.Incidencias WHERE Id = @IdIncidencia;");

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
    }
}
