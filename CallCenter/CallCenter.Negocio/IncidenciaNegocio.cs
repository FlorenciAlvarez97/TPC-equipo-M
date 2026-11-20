using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Datos;
using CallCenter.Dominio;


namespace CallCenter.Negocio
{
    internal class IncidenciaNegocio
    {

        public void Agregar(Incidencia nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.ValidarConsulta(@"INSERT INTO dbo.Incidencias( Numero, Descripcion, IdCliente, IdTipoIncidencia, IdPrioridad, IdUsuarioCreador, IdUsuarioAsignado)
                                      VALUES ( @Numero, @Descripcion, @IdCliente, @IdTipoIncidencia, @IdPrioridad, @IdUsuarioCreador, @IdUsuarioAsignado );" );

                datos.SetearParametro("@Numero", nueva.Numero);
                datos.SetearParametro("@Descripcion", nueva.Descripcion);
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

    }
}
