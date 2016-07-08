using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class Analisis
    {
        public Analisis()
        {
            this.IdAnalisis = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdAnalisis { get; set; }
        public string IdPaciente { get; set; }
        public DateTime FechaAnalisis { get; set; }
        public string IdMedico { get; set; }
    }
}