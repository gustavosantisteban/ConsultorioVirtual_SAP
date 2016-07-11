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
        public Especialista Especialista { get; set; }
        public bool EsElDiaDelTurno { get; set; }
        public Estado Estado { get; set; }
    }

    public enum Estado
    {
        Reservado,
        Cancelado,
        Pendiente
    }
}