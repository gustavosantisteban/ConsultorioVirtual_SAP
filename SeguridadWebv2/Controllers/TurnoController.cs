using SeguridadWebv2.Models;
using SeguridadWebv2.Models.Aplicacion;
using SeguridadWebv2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SeguridadWebv2.Controllers
{
    public class TurnoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Turno
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ReservarTurno(string id, string espec)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var showhorario = db.Horarios.Where(x => x.IDHorario == id).FirstOrDefault();
            var especialista = db.Especialistas.Where(x => x.EspecialistaId == id).FirstOrDefault();

            if (showhorario == null)
            {
                return HttpNotFound();
            }
            
            var tipotarjeta = from TipoTarjeta d in Enum.GetValues(typeof(TipoTarjeta))
                              select new { IdTipoTarjeta = (int)d, Name = d.ToString() };

            var mestarjeta = from Mes d in Enum.GetValues(typeof(Mes))
                              select new { IdMesTarjeta = (int)d, Name = (int)Enum.Parse(typeof(Mes), d.ToString()) };

            var anotarjeta = from AnoExpiracion d in Enum.GetValues(typeof(AnoExpiracion))
                             select new { IdAnoExp = (int)d, Name = (int)Enum.Parse(typeof(AnoExpiracion), d.ToString()) };



            ViewBag.IdTipoTarjeta = new SelectList(tipotarjeta, "IdTipoTarjeta", "Name");
            ViewBag.IdMesTarjeta = new SelectList(mestarjeta, "IdMesTarjeta", "Name");
            ViewBag.IdAnoExp = new SelectList(anotarjeta, "IdAnoExp", "Name");

            ViewBag.IdHorarioShowView = showhorario;
            ViewBag.IdEspecislistaShowView = especialista;
            var model = new Models.Aplicacion.TarjetaViewModel
            {
                idespecialista = especialista,
                idhorario = showhorario,
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ConfirmarPagoReserva(Models.Aplicacion.TarjetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                string cvv = ServicioGenerico.EncriptarCVV(model.CodigoSeguridad);
                var tarjeta = db.Tarjetas.Where(x => x.NumeroTarjeta == model.NumeroTarjeta &&
                                                x.MesExpiracion == model.IdMesTarjeta &&
                                                x.AnoExpiracion == model.IdAnoExp &&
                                                x.CodigoSeguridad == cvv &&
                                                x.Cliente.NombreCliente == model.NombreClienteTarjeta &&
                                                x.Cliente.DNI == model.DNIClienteTarjeta).FirstOrDefault();

                if (tarjeta == null)
                {
                    return View("Error");
                }

                var especialistareserva = db.Especialistas.Find(model.idespecialista);
                var horarioreserva = db.Horarios.Find(model.idhorario);

                if (tarjeta != null && tarjeta.Estado == "Habilitada")
                {

                    var turno = new Turno
                    {
                        Especialista = especialistareserva,
                        Horario = horarioreserva,
                        Estado = Estado.Reservado,
                        EsElDiaDelTurno = false
                    };
                    db.Turnos.Add(turno);
                    db.SaveChanges();

                    //var pago = new Pago { ReservaHotel = reservahotel, FechaPago = DateTime.Now, IdTarjeta = tarjeta.IdTarjeta };
                    //db.Pagos.Add(pago);
                    //db.SaveChanges();
                    return View("PagoGeneradoCorrectamente");
                }

                if (tarjeta != null && tarjeta.Estado == "Inhabilitada")
                {
                    return View("ErrorBanco");
                }
            }
            return View(model);
        }
    }
}