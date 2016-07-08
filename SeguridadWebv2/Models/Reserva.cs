using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models
{
    public class Reserva
    {
        public Reserva()
        {
            this.IDReserva = Guid.NewGuid().ToString();
        }

        [Key]
        public string IDReserva { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Cliente")]
        public string IDCliente { get; set; }
        [ForeignKey("Auto")]
        public string IDAuto { get; set; }

        public Cliente Cliente { get; set; }
        public Auto Auto { get; set; }
    }

    public class ReservaViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
        [Required]
        [Display(Name = "Codigo Postal")]
        [StringLength(4)]
        public int CodigoPostal { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public string IDAuto { get; set; }
    }
}