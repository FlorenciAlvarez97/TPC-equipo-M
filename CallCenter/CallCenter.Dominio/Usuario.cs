using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Dominio
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get;set; }
        public string NombreUsuario { get; set; }
        public string Contraseña    { get; set; }
        public RolUsuario Rol {  get; set; }
        public bool Activo { get; set; }

    }
}
