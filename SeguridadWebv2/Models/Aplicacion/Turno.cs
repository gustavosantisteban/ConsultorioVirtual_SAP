using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class Turno
    {

        public Turno()
        {
            this.IdTurno = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdTurno { get; set; }
        [Required]
        public DateTime FechaTurno { get; set; }
        [Required]
        public TimeSpan HoraInicio { get; set; }
        [Required]
        public TimeSpan HoraFin { get; set; }
        [Required]
        public virtual Estado Estado { get; set; }
        public string Nota { get; set; }
        public double Precio { get; set; }
        [Required]
        public Especialista Especialista { get; set; }
        
    }

    public enum Estado
    {
        Reservado,
        Cancelado,
        Pendiente
    }
}