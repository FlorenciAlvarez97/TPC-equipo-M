using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("SELECT u.Id, u.Nombre, u.NombreUsuario, u.IdRol, r.Nombre AS NombreRol, u.Activo FROM dbo.Usuarios u INNER JOIN dbo.Roles r ON r.Id = u.IdRol ORDER BY u.Nombre;");
                datos.Leer();
                while (datos.Lector.Read())
                {
                    lista.Add(Armarusuario(datos));
                }

                return lista;


            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        private Usuario Armarusuario(AccesoDatos datos)
        {
            Usuario usuario = new Usuario();
            usuario.Id = (int)datos.Lector["Id"];
            usuario.Nombre = (string)datos.Lector["Nombre"];
            usuario.NombreUsuario = (string)datos.Lector["NombreUsuario"];
            usuario.Rol = new RolUsuario();
            usuario.Rol.Id = (int)datos.Lector["IdRol"];
            usuario.Rol.Nombre = (string)datos.Lector["NombreRol"];
            usuario.Activo = (bool)datos.Lector["Activo"];
            return usuario;
        }


    }
}
