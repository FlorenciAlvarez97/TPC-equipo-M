using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Datos;
using CallCenter.Dominio;


namespace CallCenter.Negocio
{
    public class IncidenciaNegocio
    {

        public int Agregar(Incidencia nueva)

        {

            ValidarDatos(nueva);

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.ValidarConsulta(@"INSERT INTO dbo.Incidencias( Numero, Descripcion, IdCliente, IdTipoIncidencia, IdPrioridad, IdUsuarioCreador, IdUsuarioAsignado)  OUTPUT INSERTED.Numero
                                      VALUES (NEXT VALUE FOR dbo.SecuenciaNumeroIncidencia, @Descripcion, @IdCliente, @IdTipoIncidencia, @IdPrioridad, @IdUsuarioCreador, @IdUsuarioAsignado );");


                datos.SetearParametro("@Descripcion", nueva.Descripcion.Trim());
                datos.SetearParametro("@IdCliente", nueva.cliente.Id);
                datos.SetearParametro("@IdTipoIncidencia", nueva.Tipo.Id);
                datos.SetearParametro("@IdPrioridad", nueva.prioridad.Id);
                datos.SetearParametro("@IdUsuarioCreador", nueva.UsuarioCreador.Id);
                datos.SetearParametro("@IdUsuarioAsignado", nueva.UsuarioCreador.Id);


                int numeroGenerado = Convert.ToInt32(datos.EjecutarEscalar());

                return numeroGenerado;

            }
            finally
            {
                datos.CerrarConexion();
            }

        }
        private void ValidarDatos(Incidencia nueva)
        {
            if (nueva == null)
            {
                throw new ArgumentNullException(nameof(nueva));
            }

            if (string.IsNullOrWhiteSpace(nueva.Descripcion))
            {
                throw new ArgumentException("La descripción es obligatoria");
            }

            if (nueva.Descripcion.Trim().Length > 1000)
            {
                throw new ArgumentException("La descripción no puede superar los 1000 caracteres");
            }

            if (nueva.cliente == null || nueva.cliente.Id <= 0)
            {
                throw new ArgumentException("Debés seleccionar un cliente");
            }

            if (nueva.Tipo == null || nueva.Tipo.Id <= 0)
            {
                throw new ArgumentException("Debés seleccionar un tipo de incidencia");
            }

            if (nueva.prioridad == null || nueva.prioridad.Id <= 0)
            {
                throw new ArgumentException("Debés seleccionar una prioridad");
            }

            if (nueva.UsuarioCreador == null || nueva.UsuarioCreador.Id <= 0)
            {
                throw new ArgumentException("No se pudo identificar al usuario creador");
            }

        }


        public List<Incidencia> Listar()


        {
            List<Incidencia> lista = new List<Incidencia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta(@"SELECT i.Id, i.Numero, i.FechaAlta, i.FechaUltimaModificacion, i.Descripcion, i.IdCliente, c.Nombre AS NombreCliente,
                              c.Apellido AS ApellidoCliente, i.IdTipoIncidencia, t.Nombre AS NombreTipo, i.IdPrioridad, p.Nombre AS NombrePrioridad, i.IdEstado, e.Nombre AS NombreEstado,
                              i.IdUsuarioCreador, uc.Nombre AS NombreUsuarioCreador, i.IdUsuarioAsignado, ua.Nombre AS NombreUsuarioAsignado, i.IdUsuarioUltimaModificacion,
                              um.Nombre AS NombreUsuarioUltimaModificacion, (SELECT TOP 1 h.Comentario FROM dbo.HistorialIncidencia h WHERE h.IdIncidencia = i.Id ORDER BY h.Fecha DESC, h.Id DESC)
                              AS UltimoSeguimiento FROM dbo.Incidencias i INNER JOIN dbo.Clientes c ON i.IdCliente = c.Id  INNER JOIN dbo.TiposIncidencia t ON i.IdTipoIncidencia = t.Id
                              INNER JOIN dbo.Prioridades p ON i.IdPrioridad = p.Id INNER JOIN dbo.EstadosIncidencia e ON i.IdEstado = e.Id INNER JOIN dbo.Usuarios uc ON i.IdUsuarioCreador = uc.Id
                              INNER JOIN dbo.Usuarios ua ON i.IdUsuarioAsignado = ua.Id LEFT JOIN dbo.Usuarios um ON i.IdUsuarioUltimaModificacion = um.Id ORDER BY i.FechaAlta DESC, i.Id DESC;");

                datos.Leer();

                while (datos.Lector.Read())
                {
                    Incidencia incidencia = new Incidencia();

                    incidencia.Id = (int)datos.Lector["Id"];
                    incidencia.Numero = (int)datos.Lector["Numero"];
                    incidencia.FechaAlta = (DateTime)datos.Lector["FechaAlta"];
                    incidencia.FechaUltimaModificacion = datos.Lector["FechaUltimaModificacion"] == DBNull.Value ? (DateTime?)null : (DateTime)datos.Lector["FechaUltimaModificacion"];
                    incidencia.Descripcion = (string)datos.Lector["Descripcion"];
                    incidencia.UltimoSeguimiento = datos.Lector["UltimoSeguimiento"] == DBNull.Value ? null : (string)datos.Lector["UltimoSeguimiento"];

                    incidencia.cliente = new Cliente();
                    incidencia.cliente.Id = (int)datos.Lector["IdCliente"];
                    incidencia.cliente.Nombre = (string)datos.Lector["NombreCliente"];
                    incidencia.cliente.Apellido = (string)datos.Lector["ApellidoCliente"];

                    incidencia.Tipo = new TipoIncidencia();
                    incidencia.Tipo.Id = (int)datos.Lector["IdTipoIncidencia"];
                    incidencia.Tipo.Nombre = (string)datos.Lector["NombreTipo"];

                    incidencia.prioridad = new Prioridad();
                    incidencia.prioridad.Id = (int)datos.Lector["IdPrioridad"];
                    incidencia.prioridad.Nombre = (string)datos.Lector["NombrePrioridad"];

                    incidencia.Estado = new EstadoIncidencia();
                    incidencia.Estado.Id = (int)datos.Lector["IdEstado"];
                    incidencia.Estado.Nombre = (string)datos.Lector["NombreEstado"];

                    incidencia.UsuarioCreador = new Usuario();
                    incidencia.UsuarioCreador.Id = (int)datos.Lector["IdUsuarioCreador"];
                    incidencia.UsuarioCreador.Nombre = (string)datos.Lector["NombreUsuarioCreador"];

                    incidencia.UsuarioAsignado = new Usuario();
                    incidencia.UsuarioAsignado.Id = (int)datos.Lector["IdUsuarioAsignado"];
                    incidencia.UsuarioAsignado.Nombre = (string)datos.Lector["NombreUsuarioAsignado"];

                    if (datos.Lector["IdUsuarioUltimaModificacion"] != DBNull.Value)
                    {
                        incidencia.UsuarioUltimaModificacion = new Usuario();
                        incidencia.UsuarioUltimaModificacion.Id = (int)datos.Lector["IdUsuarioUltimaModificacion"];
                        incidencia.UsuarioUltimaModificacion.Nombre = (string)datos.Lector["NombreUsuarioUltimaModificacion"];
                    }

                    lista.Add(incidencia);
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
