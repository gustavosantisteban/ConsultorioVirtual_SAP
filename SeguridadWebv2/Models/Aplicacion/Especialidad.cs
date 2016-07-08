using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class Especialidad
    {
        public Especialidad()
        {
            this.EspecialidadId = Guid.NewGuid().ToString();
        }

        [Key]
        public string EspecialidadId { get; set; }
        public string NombreEspecialidad { get; set; }
        public string Imagen { get; set; }
        public ICollection<Especialista> Especialistas { get; set; }
    }
}