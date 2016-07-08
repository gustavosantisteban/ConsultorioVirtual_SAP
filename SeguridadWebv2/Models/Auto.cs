using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models
{
    public class Auto
    {
        public Auto()
        {
            this.IDAuto = Guid.NewGuid().ToString(); 
        }

        [Key]
        public string IDAuto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Precio { get; set; }
        public int Kilometros { get; set; }
        public string Imagen { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}