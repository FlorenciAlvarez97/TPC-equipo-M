using System;
using System.Collections.Generic;
using CallCenter.Datos;
using CallCenter.Dominio;

namespace CallCenter.Negocio
{
    public class PrioridadNegocio
    {
        public List<Prioridad> Listar()
        {
            List<Prioridad> lista = new List<Prioridad>();
            AccesoDatos datos = new AccesoDatos();

            // Valida y ejecuta la consulta

            try
            {
                datos.ValidarConsulta("SELECT Id, Nombre, Nivel FROM dbo.Prioridades ORDER BY Nivel, Id; ");
                datos.Leer();

                // Crear un objeto por cada registro recibido

                while (datos.Lector.Read())
                {
                    Prioridad prioridad = new Prioridad();

                    prioridad.Id = (int)datos.Lector["Id"];
                    prioridad.Nombre = (string)datos.Lector["Nombre"];
                    prioridad.Nivel = (int)datos.Lector["Nivel"];

                    lista.Add(prioridad);
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
