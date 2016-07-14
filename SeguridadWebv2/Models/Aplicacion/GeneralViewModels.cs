using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class GeneralViewModels
    {
       public Especialista Especialista { get; set; }
       public IEnumerable<Horario> Horarios { get; set; }
    }

    public class TarjetaViewModel
    {
        [Required]
        [Display(Name = "Tipo de Tarjeta")]
        public int IdTipoTarjeta { get; set; }
        [Required]
        [MaxLength(16, ErrorMessage = "El numero de tarjeta debe tener 16 Digitos"), MinLength(16)]
        [Display(Name = "Numero de Tarjeta")]
        public string NumeroTarjeta { get; set; }
        [Required]
        [Display(Name = "Mes Expiracion")]
        public int IdMesTarjeta { get; set; }
        [Required]
        [Display(Name = "Año Expiracion")]
        public int IdAnoExp { get; set; }
        [Required]
        [Display(Name = "Codigo Seguridad CVV")]
        [MaxLength(3, ErrorMessage = "Codigo de Seguridad debe tener 3 Digitos"), MinLength(3)]
        [DataType(DataType.Password)]
        public string CodigoSeguridad { get; set; }
        [Required]
        public string NombreClienteTarjeta { get; set; }
        [Required]
        public int DNIClienteTarjeta { get; set; }
        public Especialista idespecialista { get; set; }
        public Horario idhorario { get; set; }
        public ApplicationUser UsuarioPaciente { get; set; }
    }

    public class HorarioViewModel
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
        public Especialista Especialista { get; set; }
    }
    

}