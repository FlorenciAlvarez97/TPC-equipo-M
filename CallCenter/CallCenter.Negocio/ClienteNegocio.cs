using System;
using System.Collections.Generic;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    public class ClienteNegocio
    {
        private const string Columnas = "Id, Nombre, Apellido, Email, Telefono, Direccion, Activo";

        private Cliente ArmarCliente(AccesoDatos datos)
        {

            Cliente cliente = new Cliente();

            cliente.Id = (int)datos.Lector["Id"];
            cliente.Nombre = (string)datos.Lector["Nombre"];
            cliente.Apellido = (string)datos.Lector["Apellido"];
            cliente.Email = (string)datos.Lector["Email"];
            cliente.Telefono = datos.Lector["Telefono"] is DBNull ? null : (string)datos.Lector["Telefono"];
            cliente.Direccion = datos.Lector["Direccion"] is DBNull ? null : (string)datos.Lector["Direccion"];
            cliente.Activo = (bool)datos.Lector["Activo"];

            return cliente;
        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta("SELECT " + Columnas + " FROM dbo.Clientes ORDER BY Apellido, Nombre;");
                datos.Leer();
                while (datos.Lector.Read())
                {
                    lista.Add(ArmarCliente(datos));
                }
                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Cliente> Buscar(string texto, bool? activo)
        {

            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("SELECT " + Columnas + " FROM dbo.Clientes WHERE (Nombre LIKE @Texto OR Apellido LIKE @Texto OR Email LIKE @Texto) AND (@Activo IS NULL OR Activo = @Activo) ORDER BY Apellido, Nombre;");
                datos.SetearParametro("@Texto", "%" + texto?? "");
                datos.SetearParametro("@Activo", activo);
                datos.Leer();
                while (datos.Lector.Read())
                {
                    lista.Add(ArmarCliente(datos));
                }
                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
            
        }

        public Cliente obtenerporId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.ValidarConsulta("SELECT " + Columnas + " FROM dbo.Clientes WHERE Id = @Id;");
                datos.SetearParametro("@Id", id);
                datos.Leer();
                if (datos.Lector.Read())
                {
                    return ArmarCliente(datos);
                }
                return null;

            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        private void cargarparametros(AccesoDatos datos, Cliente cliente)
        {
            datos.SetearParametro("@Nombre", cliente.Nombre);
            datos.SetearParametro("@Apellido", cliente.Apellido);
            datos.SetearParametro("@Email", cliente.Email);
            datos.SetearParametro("@Telefono", string.IsNullOrWhiteSpace(cliente.Telefono) ? null : cliente.Telefono);
            datos.SetearParametro("@Direccion", string.IsNullOrWhiteSpace(cliente.Direccion) ? null : cliente.Direccion);
            datos.SetearParametro("@Activo", cliente.Activo);
        }

        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("INSERT INTO dbo.Clientes (Nombre, Apellido, Email, Telefono, Direccion, Activo) VALUES (@Nombre, @Apellido, @Email, @Telefono, @Direccion, @Activo);");
                cargarparametros(datos, nuevo);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void cambiarestado(int id, bool activo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("UPDATE dbo.Clientes SET Activo = @Activo WHERE Id = @Id;");
                datos.SetearParametro("@Activo", activo);
                datos.SetearParametro("@Id", id);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ValidarConsulta("UPDATE dbo.Clientes SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, Direccion = @Direccion, Activo = @Activo WHERE Id = @Id;");
                cargarparametros(datos, cliente);
                datos.SetearParametro("@Id", cliente.Id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }





    }
}
