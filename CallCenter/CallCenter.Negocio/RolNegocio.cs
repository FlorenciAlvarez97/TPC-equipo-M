using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    public class RolNegocio
    {
        public List<RolUsuario> Listar()
        {
            List<RolUsuario> lista = new List<RolUsuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta("SELECT Id, Nombre FROM dbo.Roles ORDER BY Id;");
                datos.Leer();
                while (datos.Lector.Read())
                {
                    RolUsuario rol = new RolUsuario();
                    rol.Id = (int)datos.Lector["Id"];
                    rol.Nombre = (string)datos.Lector["Nombre"];
                    lista.Add(rol);
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
