using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models
{
    public class Cliente
    {
        public Cliente()
        {
            this.IDCliente = Guid.NewGuid().ToString();
        }
        [Key]
        public string IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public int CodigoPostal { get; set; }
        public string Direccion { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}