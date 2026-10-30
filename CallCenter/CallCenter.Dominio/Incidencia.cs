using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Dominio
{
    public class Incidencia
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; } //Esta fecha inicia vacia cuando es un alta       
        public string Descripcion {  get; set; }
        public string Resolucion { get; set; }
        public string ComentarioCierre { get; set; }
        public Cliente cliente { get; set; }
        public TipoIncidencia Tipo {  get; set; }
        public Usuario UsuarioCreador { get; set; }
        public Usuario UsuarioAsignado { get; set; }
        public Usuario UsuarioUltimaModificacion { get; set; }
        public EstadoIncidencia Estado {  get; set; }
        public Prioridad prioridad { get; set; }
        public bool Activo  { get; set; }

    }
}
