using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class Especialista
    {
        public Especialista()
        {
            this.EspecialistaId = Guid.NewGuid().ToString();
        }

        [Key]
        public string EspecialistaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Prefijo Prefijo { get; set; }
        public string ImagenMedico { get; set; }
        public string Telefono { get; set; }
        public Especialidad Especialidad { get; set; }
        public string NumeroMatricula { get; set; }
    }

    public enum Prefijo
    {
        Dr,
        Dra,
        Sr,
        Sra
    }
}