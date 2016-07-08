using SeguridadWebv2.Models;
using SeguridadWebv2.Models.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeguridadWebv2.Models.Aplicacion;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;

namespace SeguridadWebv2.Models
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Especialidad> especialidades = db.Especialidades.ToList();
            return View(especialidades.Take(6));
        }

        [HttpGet]
        public ActionResult BuscarEspecialidades(string busqueda)
       {
            busqueda = busqueda.ToUpper();
            List<Especialidad> especialidades = ObtenerEspecialidades().Where(x => x.NombreEspecialidad.ToUpper().Contains(busqueda)).ToList();

            return Json(especialidades, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<Especialidad> ObtenerEspecialidades()
        {
            List<Especialidad> especialidades = db.Especialidades.ToList();
            return especialidades;
        }

        public IEnumerable<Especialista> ObtenerEspecialistas()
        {
            List<Especialista> especialistas = db.Especialistas.ToList();
            return especialistas;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> MostrarProfesionales(string especialidad)
        {
            if (especialidad == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad id = db.Especialidades.FirstOrDefault(x => x.NombreEspecialidad.Contains(especialidad.ToUpper()));

            IQueryable<Especialista> esp = db.Especialistas.Where(x => x.Especialidad.EspecialidadId == id.EspecialidadId);
            //IQueryable<Especialista> esp = db.Especialistas.Where(x => x.Especialidad.NombreEspecialidad.Contains(id));

            return View(await esp.ToListAsync()); 
        }
	}
}