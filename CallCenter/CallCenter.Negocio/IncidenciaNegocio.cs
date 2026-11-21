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

        public void Agregar(Incidencia nueva)
        {

            ValidarDatos(nueva);

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.ValidarConsulta(@"INSERT INTO dbo.Incidencias( Numero, Descripcion, IdCliente, IdTipoIncidencia, IdPrioridad, IdUsuarioCreador, IdUsuarioAsignado)
                                      VALUES (NEXT VALUE FOR dbo.SecuenciaNumeroIncidencia, @Descripcion, @IdCliente, @IdTipoIncidencia, @IdPrioridad, @IdUsuarioCreador, @IdUsuarioAsignado );");


                datos.SetearParametro("@Descripcion", nueva.Descripcion.Trim());
                datos.SetearParametro("@IdCliente", nueva.cliente.Id);
                datos.SetearParametro("@IdTipoIncidencia", nueva.Tipo.Id);
                datos.SetearParametro("@IdPrioridad", nueva.prioridad.Id);
                datos.SetearParametro("@IdUsuarioCreador", nueva.UsuarioCreador.Id);
                datos.SetearParametro("@IdUsuarioAsignado", nueva.UsuarioCreador.Id);

                datos.ejecutarAccion();
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


    }
}
