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


        private void ValidarDatos(Usuario usuario, bool esNuevo)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (usuario.Nombre.Trim().Length > 100)
            {
                throw new ArgumentException("El nombre no puede superar los 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
            {
                throw new ArgumentException("El usuario es obligatorio.");
            }

            if (usuario.NombreUsuario.Trim().Length > 50)
            {
                throw new ArgumentException("El usuario no puede superar los 50 caracteres.");
            }

            if (usuario.Rol == null || usuario.Rol.Id <= 0)
            {
                throw new ArgumentException("Debés seleccionar un rol.");
            }

            if (esNuevo && string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }

            if (ExisteNombreUsuario(usuario.NombreUsuario, usuario.Id))
            {
                throw new ArgumentException("Ya existe un usuario con ese nombre de usuario.");
            }
        }

        public void Agregar(Usuario nuevo)
        {
            ValidarDatos(nuevo, true);

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
            ValidarDatos(usuario, false);

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

       public List<Usuario> Buscar(string texto, int? idrol, bool? activo)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("SELECT u.Id, u.Nombre, u.NombreUsuario, u.IdRol, r.Nombre AS NombreRol, u.Activo FROM dbo.Usuarios u INNER JOIN dbo.Roles r ON r.Id = u.IdRol WHERE (@Texto = '' OR u.Nombre LIKE '%' + @Texto + '%' OR u.NombreUsuario LIKE '%' + @Texto + '%') AND (@IdRol IS NULL OR u.IdRol = @IdRol) AND (@Activo IS NULL OR u.Activo = @Activo) ORDER BY u.Nombre;");
                datos.SetearParametro("@Texto", texto);
                datos.SetearParametro("@IdRol", idrol);
                datos.SetearParametro("@Activo", activo);
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

        public void CambiarEstado(int id, bool activo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("UPDATE dbo.Usuarios SET Activo = @Activo WHERE Id = @Id;");
                datos.SetearParametro("@Activo", activo);
                datos.SetearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}
