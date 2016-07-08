using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class ObraSocial
    {
        public ObraSocial()
        {
            this.IdObraSocial = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdObraSocial { get; set; }
        public string RazonSocial { get; set; }
        public string PaginaWeb { get; set; }
        public ICollection<Contacto_ObraSocial> ContactoObraSociales { get; set; }
        public ICollection<Direccion_ObraSocial> DireccionObraSociales { get; set; }
        public ICollection<Telefono_ObraSocial> TelefonoObraSociales { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}