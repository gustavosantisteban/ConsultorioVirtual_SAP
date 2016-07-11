using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class Horario
    {
        public Horario()
        {
            this.IDHorario = Guid.NewGuid().ToString();
        }

        [Key]
        public string IDHorario { get; set; }
        public EstadoHorario Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
        public Especialista Especialista { get; set; }
    }
    
    public enum EstadoHorario
    {
        Disponible,
        Ocupado,
        Pendiente
    } 
}