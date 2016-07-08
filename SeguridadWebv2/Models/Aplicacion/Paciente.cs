using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class Paciente 
    {
        public Paciente()
        {
            this.IdPaciente = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdPaciente { get; set; }
    }
}