using SeguridadWebv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Data.Entity;
using SeguridadWebv2.Models.Aplicacion;
using SeguridadWebv2.Services;

namespace SeguridadWebv2.Models
{
    public class InicializarDatos
    {

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string nombre = "William Gustavo";
            const string apellido = "Santisteban";
            const bool estado = true;
            const string name = "administrador@mcga.com";
            const string password = "Mcga@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, Nombre = nombre, Apellido = apellido, Estado = estado, EmailConfirmed = true };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);

            }

            var groupManager = new GrupoManager();
            var newGroup = new ApplicationGroup("Administradores", "Acceso General al Sistema");

            groupManager.CreateGroup(newGroup);
            groupManager.SetUserGroups(user.Id, new string[] { newGroup.Id });
            groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });

            var PermisosUsuario = new List<ApplicationRole> {
                new ApplicationRole {
                    Name = "Agregar_Usuario"
                },
                new ApplicationRole {
                    Name = "Editar_Usuario"
                },
                new ApplicationRole {
                    Name = "Detalle_Usuario"
                },
                new ApplicationRole {
                    Name = "Eliminar_Usuario"
                },
                new ApplicationRole {
                    Name = "AllUsuarios"
                }
            };
            PermisosUsuario.ForEach(c => db.Roles.Add(c));


            var PermisosGrupo = new List<ApplicationRole> {
                new ApplicationRole {
                    Name = "Agregar_Grupo"
                },
                new ApplicationRole {
                    Name = "Editar_Grupo"
                },
                new ApplicationRole {
                    Name = "Detalle_Grupo"
                },
                new ApplicationRole {
                    Name = "Eliminar_Grupo"
                },
                new ApplicationRole {
                    Name = "AllGrupos"
                }
            };
            PermisosGrupo.ForEach(c => db.Roles.Add(c));


            var PermisosAcciones = new List<ApplicationRole> {
                new ApplicationRole {
                    Name = "Agregar_Permiso"
                },
                new ApplicationRole {
                    Name = "Editar_Permiso"
                },
                new ApplicationRole {
                    Name = "Detalle_Permiso"
                },
                new ApplicationRole {
                    Name = "Eliminar_Permiso"
                },
                new ApplicationRole {
                    Name = "AllPermisos"
                }
            };
            PermisosUsuario.ForEach(c => db.Roles.Add(c));

            var PermisosAutos = new List<ApplicationRole> {
                new ApplicationRole {
                    Name = "Agregar_Auto"
                },
                new ApplicationRole {
                    Name = "Editar_Auto"
                },
                new ApplicationRole {
                    Name = "Detalle_Auto"
                },
                new ApplicationRole {
                    Name = "Eliminar_Auto"
                },
                new ApplicationRole {
                    Name = "AllAutos"
                }
            };
            PermisosAutos.ForEach(c => db.Roles.Add(c));


            var grupos = new List<ApplicationGroup> {
                new ApplicationGroup {
                    Name = "Gestionar Usuarios",
                    Description = "Gestionar Usuarios"
                },
                new ApplicationGroup {
                    Name = "Gestionar Grupos",
                    Description = "Gestionar Grupos"
                },
                new ApplicationGroup {
                    Name = "Gestionar Acciones",
                    Description = "Gestionar Acciones"
                },
                new ApplicationGroup {
                    Name = "Gestionar Autos",
                    Description = "Gestionar Autos"
                },
             };
            grupos.ForEach(c => db.ApplicationGroups.Add(c));
            
            var especialidades = new List<Especialidad> {
                new Especialidad {
                    NombreEspecialidad = "Dietética / Nutricion",
                    Imagen = "~/Content/img/especialidad/nutricionista.png"
                },
                new Especialidad {
                    NombreEspecialidad = "Ginecología",
                    Imagen = "~/Content/img/especialidad/ginecologia.jpg"
                },
                new Especialidad {
                    NombreEspecialidad = "Psicología",
                    Imagen = "~/Content/img/especialidad/psicologia.jpg"
                },
                new Especialidad {
                    NombreEspecialidad = "Dermatología",
                    Imagen = "~/Content/img/especialidad/dermatologia.jpg"
                },
                new Especialidad {
                    NombreEspecialidad = "Pediatría",
                    Imagen = "~/Content/img/especialidad/pediatria.jpg"
                },
                new Especialidad {
                    NombreEspecialidad = "Neumología",
                    Imagen = "~/Content/img/especialidad/neumologia.jpg"
                },
                new Especialidad {
                    NombreEspecialidad = "Neurología",
                    Imagen = "~/Content/img/especialidad/neurologia.jpg"
                },
                new Especialidad {
                    NombreEspecialidad = "Psiquiatría",
                    Imagen = "~/Content/img/especialidad/psiquiatria.jpg"
                }
            };
            especialidades.ForEach(c => db.Especialidades.Add(c));

            var especialistas = new List<Especialista>
            {
                new Especialista {
                    Prefijo = Models.Aplicacion.Prefijo.Dr,
                    Nombre = "Agustin",
                    Apellido = "Stelzer",
                    Email = "stelzer.af@gmail.com",
                    Telefono = "3413354582",
                    ImagenMedico = "~/Content/img/medicos/agustin_stelzer.jpg",
                    Especialidad = especialidades[6],
                    NumeroMatricula = "MEDICO156"
                },
                new Especialista {
                    Prefijo = Models.Aplicacion.Prefijo.Dra,
                    Nombre = "Pamela",
                    Apellido = "Sosa",
                    Email = "pame312@gmail.com",
                    Telefono = "3415215487",
                    ImagenMedico = "~/Content/img/medicos/pamela_sosa.jpg",
                    Especialidad = especialidades[2],
                    NumeroMatricula = "PSICO652"
                },
                new Especialista {
                    Prefijo = Models.Aplicacion.Prefijo.Dr,
                    Nombre = "Hernan",
                    Apellido = "Carballo",
                    Email = "hernancitoquerido@gmail.com",
                    Telefono = "3416112542",
                    ImagenMedico = "~/Content/img/medicos/hernan_carballo.jpg",
                    Especialidad = especialidades[2],
                    NumeroMatricula = "PSICO524"
                },
                new Especialista {
                    Prefijo = Models.Aplicacion.Prefijo.Dr,
                    Nombre = "Lucas",
                    Apellido = "Ordoñez",
                    Email = "luquitascrack@gmail.com",
                    Telefono = "3413202020",
                    ImagenMedico = "~/Content/img/medicos/lucas_ordonez.jpg",
                    Especialidad = especialidades[4],
                    NumeroMatricula = "PEDIA156"
                },
                new Especialista {
                    Prefijo = Models.Aplicacion.Prefijo.Dr,
                    Nombre = "William",
                    Apellido = "Santisteban",
                    Email = "rootsantisteban@gmail.com",
                    Telefono = "3413555226",
                    ImagenMedico = "~/Content/img/medicos/will_santisteban.jpg",
                    Especialidad = especialidades[2],
                    NumeroMatricula = "PSICO333"
                }
            };
            especialistas.ForEach(c => db.Especialistas.Add(c));

            var horarios = new List<Horario>
            {
                //Inicio Primer Especialista
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 08:00"),
                    FechaFin = DateTime.Parse("2016-07-15 08:40"),
                    Especialista = especialistas[0],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 09:00"),
                    FechaFin = DateTime.Parse("2016-07-15 09:40"),
                    Especialista = especialistas[0],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 10:00"),
                    FechaFin = DateTime.Parse("2016-07-15 10:40"),
                    Especialista = especialistas[0],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 11:00"),
                    FechaFin = DateTime.Parse("2016-07-15 11:40"),
                    Especialista = especialistas[0],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 12:00"),
                    FechaFin = DateTime.Parse("2016-07-15 11:40"),
                    Especialista = especialistas[0],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 15:00"),
                    FechaFin = DateTime.Parse("2016-07-15 15:40"),
                    Especialista = especialistas[0],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 16:00"),
                    FechaFin = DateTime.Parse("2016-07-15 16:40"),
                    Especialista = especialistas[0],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 17:00"),
                    FechaFin = DateTime.Parse("2016-07-15 17:40"),
                    Especialista = especialistas[0],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                //Inicio Segundo Especialista
               new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 08:00"),
                    FechaFin = DateTime.Parse("2016-07-15 08:40"),
                    Especialista = especialistas[1],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 09:00"),
                    FechaFin = DateTime.Parse("2016-07-15 09:40"),
                    Especialista = especialistas[1],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 10:00"),
                    FechaFin = DateTime.Parse("2016-07-15 10:40"),
                    Especialista = especialistas[1],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 11:00"),
                    FechaFin = DateTime.Parse("2016-07-15 11:40"),
                    Especialista = especialistas[1],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                // Inicio Tercer Especialista
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 08:00"),
                    FechaFin = DateTime.Parse("2016-07-15 08:40"),
                    Especialista = especialistas[2],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 09:00"),
                    FechaFin = DateTime.Parse("2016-07-15 09:40"),
                    Especialista = especialistas[2],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 10:00"),
                    FechaFin = DateTime.Parse("2016-07-15 10:40"),
                    Especialista = especialistas[2],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 11:00"),
                    FechaFin = DateTime.Parse("2016-07-15 11:40"),
                    Especialista = especialistas[2],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                 new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 12:00"),
                    FechaFin = DateTime.Parse("2016-07-15 12:40"),
                    Especialista = especialistas[2],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                //Inicio del Cuarto Especialista
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 08:00"),
                    FechaFin = DateTime.Parse("2016-07-15 08:40"),
                    Especialista = especialistas[4],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 09:00"),
                    FechaFin = DateTime.Parse("2016-07-15 09:40"),
                    Especialista = especialistas[4],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 10:00"),
                    FechaFin = DateTime.Parse("2016-07-15 10:40"),
                    Especialista = especialistas[4],
                    Estado = EstadoHorario.Ocupado,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 11:00"),
                    FechaFin = DateTime.Parse("2016-07-15 11:40"),
                    Especialista = especialistas[4],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 12:00"),
                    FechaFin = DateTime.Parse("2016-07-15 12:40"),
                    Especialista = especialistas[4],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 15:00"),
                    FechaFin = DateTime.Parse("2016-07-15 15:40"),
                    Especialista = especialistas[4],
                    Estado = EstadoHorario.Ocupado,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 16:00"),
                    FechaFin = DateTime.Parse("2016-07-15 16:40"),
                    Especialista = especialistas[4],
                    Estado = EstadoHorario.Ocupado,
                    Precio = 300M
                },
                new Horario
                {
                    FechaInicio = DateTime.Parse("2016-07-15 17:00"),
                    FechaFin = DateTime.Parse("2016-07-15 17:40"),
                    Especialista = especialistas[4],
                    Estado = EstadoHorario.Disponible,
                    Precio = 300M
                },
            };
            horarios.ForEach(c => db.Horarios.Add(c));

            var clientetarjeta = new List<ClienteTarjeta>
            {
                new ClienteTarjeta
                {
                    NombreCliente = "ALEJANDRO SARTORIO",
                    DNI = 35252525
                },
                new ClienteTarjeta
                {
                    NombreCliente = "WILLIAM SANTISTEBAN",
                    DNI = 94566808,
                },
            };
            clientetarjeta.ForEach(c => db.ClienteTarjetas.Add(c));

            var tarjetas = new List<Tarjeta>
            {
                new Tarjeta
                {
                    TipoDeTarjeta = TipoTarjeta.Visa.ToString(),
                    NumeroTarjeta = "4907331874003523",
                    MesExpiracion = (int)Mes.Mayo,
                    AnoExpiracion = (int)AnoExpiracion.AnoActual,
                    CodigoSeguridad = ServicioGenerico.EncriptarCVV("123"),
                    Cliente = clientetarjeta[0],
                    Estado = EstadoTarjeta.Habilitada.ToString(),
                },
                new Tarjeta
                {
                    TipoDeTarjeta = TipoTarjeta.Mastercard.ToString(),
                    NumeroTarjeta = "4626077485249225",
                    MesExpiracion = (int)Mes.Octubre,
                    AnoExpiracion = (int)AnoExpiracion.AnoProx2,
                    CodigoSeguridad = ServicioGenerico.EncriptarCVV("235"),
                    Cliente = clientetarjeta[1],
                    Estado = EstadoTarjeta.Rechazada.ToString(),
                },
            };
            tarjetas.ForEach(c => db.Tarjetas.Add(c));

            db.SaveChanges();
        }
    }
}