using CallCenter.Datos;
using CallCenter.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Negocio
{
    public class IncidenciaGestionNegocio
    {
        private Incidencia ArmarIncidencia(AccesoDatos datos)
        {
            Incidencia inc = new Incidencia();
            inc.Id = (int)datos.Lector["Id"];
            inc.Numero = (int)datos.Lector["Numero"];
            inc.FechaAlta = (DateTime)datos.Lector["FechaAlta"];
            inc.FechaUltimaModificacion = datos.Lector["FechaUltimaModificacion"] is DBNull ? (DateTime?)null : (DateTime)datos.Lector["FechaUltimaModificacion"];
            inc.Descripcion = (string)datos.Lector["Descripcion"];
            inc.Resolucion = datos.Lector["Resolucion"] is DBNull ? null : (string)datos.Lector["Resolucion"];
            inc.ComentarioCierre = datos.Lector["ComentarioCierre"] is DBNull ? null : (string)datos.Lector["ComentarioCierre"];
            inc.cliente = new Cliente();
            inc.cliente.Id = (int)datos.Lector["IdCliente"];
            inc.cliente.Nombre = (string)datos.Lector["NombreCliente"];
            inc.cliente.Apellido = (string)datos.Lector["ApellidoCliente"];
            inc.Tipo = new TipoIncidencia();
            inc.Tipo.Id = (int)datos.Lector["IdTipoIncidencia"];
            inc.Tipo.Nombre = (string)datos.Lector["NombreTipo"];
            inc.prioridad = new Prioridad();
            inc.prioridad.Id = (int)datos.Lector["IdPrioridad"];
            inc.prioridad.Nombre = (string)datos.Lector["NombrePrioridad"];
            inc.Estado = new EstadoIncidencia();
            inc.Estado.Id = (int)datos.Lector["IdEstado"];
            inc.Estado.Nombre = (string)datos.Lector["NombreEstado"];
            inc.UsuarioAsignado = new Usuario();
            inc.UsuarioAsignado.Id = (int)datos.Lector["IdUsuarioAsignado"];
            inc.UsuarioAsignado.Nombre = (string)datos.Lector["NombreAsignado"];
            return inc;
        }

        public Incidencia obtenerporid(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta(@"SELECT i.Id, i.Numero, i.FechaAlta, i.FechaUltimaModificacion, i.Descripcion, i.Resolucion, i.ComentarioCierre, i.IdCliente, c.Nombre AS NombreCliente, c.Apellido AS ApellidoCliente, i.IdTipoIncidencia, t.Nombre AS NombreTipo, i.IdPrioridad, p.Nombre AS NombrePrioridad, i.IdEstado, e.Nombre AS NombreEstado, i.IdUsuarioAsignado, ua.Nombre AS NombreAsignado FROM dbo.Incidencias i INNER JOIN dbo.Clientes c ON c.Id = i.IdCliente INNER JOIN dbo.TiposIncidencia t ON t.Id = i.IdTipoIncidencia INNER JOIN dbo.Prioridades p ON p.Id = i.IdPrioridad INNER JOIN dbo.EstadosIncidencia e ON e.Id = i.IdEstado INNER JOIN dbo.Usuarios ua ON ua.Id = i.IdUsuarioAsignado WHERE i.Id = @Id;");
                datos.SetearParametro("@Id", id);
                datos.Leer();
                if (datos.Lector.Read())
                {
                    return ArmarIncidencia(datos);
                }
                return null;


            }
            finally
            {
                datos.CerrarConexion();
            }
            
        }


    }
}
