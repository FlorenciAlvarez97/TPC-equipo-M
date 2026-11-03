using System;
using System.Collections.Generic;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    internal class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ValidarConsulta("SELECT Id, Nombre, Apellido, Email, Telefono, Direccion, Activo FROM dbo.Clientes ORDER BY Apellido, Nombre;");
                datos.Leer();

                while (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.Id = (int)datos.Lector["Id"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Telefono = datos.Lector["Telefono"] is DBNull ? null : (string)datos.Lector["Telefono"];
                    cliente.Direccion = datos.Lector["Direccion"] is DBNull ? null : (string)datos.Lector["Direccion"];
                    cliente.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(cliente);
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
