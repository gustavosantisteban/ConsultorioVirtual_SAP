using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Aplicacion
{
    public class GeneralViewModels
    {
       public Especialista Especialista { get; set; }
       public IEnumerable<Horario> Horarios { get; set; }
    }
    
}