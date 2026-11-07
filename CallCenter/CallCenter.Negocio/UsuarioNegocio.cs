using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
                    lista.Add(ArmarUsuario(datos));
                }
                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        private Usuario ArmarUsuario(AccesoDatos datos)
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

        public Usuario ObtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("SELECT u.Id, u.Nombre, u.NombreUsuario, u.IdRol, r.Nombre AS NombreRol, u.Activo FROM dbo.Usuarios u INNER JOIN dbo.Roles r ON r.Id = u.IdRol WHERE u.Id = @Id;");
                datos.SetearParametro("@Id", id);
                datos.Leer();
                if (datos.Lector.Read())
                {
                    return ArmarUsuario(datos);
                }
                return null;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool ExisteNombreUsuario(string nombreUsuario, int idExcluido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("SELECT COUNT(*) FROM dbo.Usuarios WHERE NombreUsuario = @NombreUsuario AND Id <> @Id;");
                datos.SetearParametro("@NombreUsuario", nombreUsuario);
                datos.SetearParametro("@Id", idExcluido);
                return (int)datos.EjecutarEscalar() > 0;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public static string HashearContrasena(string contrasena)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                StringBuilder texto = new StringBuilder();
                foreach (byte b in bytes)
                {
                    texto.Append(b.ToString("x2"));
                }
                return texto.ToString();
            }
        }

        public void Agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("INSERT INTO dbo.Usuarios (Nombre, NombreUsuario, Contrasena, IdRol, Activo) VALUES (@Nombre, @NombreUsuario, @Contrasena, @IdRol, @Activo);");
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@NombreUsuario", nuevo.NombreUsuario);
                datos.SetearParametro("@Contrasena", HashearContrasena(nuevo.Contraseña));
                datos.SetearParametro("@IdRol", nuevo.Rol.Id);
                datos.SetearParametro("@Activo", nuevo.Activo);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                bool cambiaContrasena = !string.IsNullOrWhiteSpace(usuario.Contraseña);
                string consulta = "UPDATE dbo.Usuarios SET Nombre = @Nombre, NombreUsuario = @NombreUsuario, IdRol = @IdRol, Activo = @Activo";
                if (cambiaContrasena)
                {
                    consulta += ", Contrasena = @Contrasena";
                }
                consulta += " WHERE Id = @Id;";
                datos.ValidarConsulta(consulta);
                datos.SetearParametro("@Nombre", usuario.Nombre);
                datos.SetearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.SetearParametro("@IdRol", usuario.Rol.Id);
                datos.SetearParametro("@Activo", usuario.Activo);
                datos.SetearParametro("@Id", usuario.Id);
                if (cambiaContrasena)
                {
                    datos.SetearParametro("@Contrasena", HashearContrasena(usuario.Contraseña));
                }
                datos.ejecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
