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
        
        public ActionResult ReservarTurno()
        {
            //if (r == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var reservaid = db.ReservaHoteles.Find(r);
            //if (reservaid == null)
            //{
            //    return HttpNotFound();
            //}

            var tipotarjeta = from TipoTarjeta d in Enum.GetValues(typeof(TipoTarjeta))
                              select new { IdTipoTarjeta = (int)d, Name = d.ToString() };

            var mestarjeta = from Mes d in Enum.GetValues(typeof(Mes))
                              select new { IdMesTarjeta = (int)d, Name = (int)Enum.Parse(typeof(Mes), d.ToString()) };

            var anotarjeta = from AnoExpiracion d in Enum.GetValues(typeof(AnoExpiracion))
                             select new { IdAnoExp = (int)d, Name = (int)Enum.Parse(typeof(AnoExpiracion), d.ToString()) };



            ViewBag.IdTipoTarjeta = new SelectList(tipotarjeta, "IdTipoTarjeta", "Name");
            ViewBag.IdMesTarjeta = new SelectList(mestarjeta, "IdMesTarjeta", "Name");
            ViewBag.IdAnoExp = new SelectList(anotarjeta, "IdAnoExp", "Name");
            //ViewBag.IdReserva = r;
            return View();
        }

        public ActionResult ConfirmarPagoReserva(TarjetaViewModel model)
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

                //var reservahotel = db.ReservaHoteles.Find(idreserva);
                if (tarjeta != null && tarjeta.Estado == "Habilitada")
                {
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