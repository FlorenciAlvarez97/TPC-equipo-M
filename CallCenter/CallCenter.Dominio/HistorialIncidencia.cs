using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Dominio
{
    public class HistorialIncidencia
    {
        public int Id { get; set; }

        public Incidencia Incidencia { get; set; }

        public DateTime Fecha { get; set; }

        public Usuario Usuario { get; set; }

        public string Comentario { get; set; }

        public EstadoIncidencia EstadoResultante { get; set; }
    }
}
