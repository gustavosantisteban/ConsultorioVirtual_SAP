using SeguridadWebv2.Models;
using SeguridadWebv2.Models.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeguridadWebv2.Controllers
{
    public class EspecialistaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Especialista
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Turnos(string id)
        {
            
            Especialista espec = db.Especialistas.FirstOrDefault(x => x.EspecialistaId == id);

            IQueryable<Horario> horario = db.Horarios.Where(x => x.Especialista.EspecialistaId == id)
                                            .OrderBy(x => x.FechaInicio)
                                            .Include(x => x.Especialista);

            var model = new GeneralViewModels
            {
                Especialista = espec,
                Horarios = horario.ToList()
            };
            
            return View(model);
        }
    }
}