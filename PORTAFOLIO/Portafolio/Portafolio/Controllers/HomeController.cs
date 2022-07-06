using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        //private readonly ServicioDelimitado delimintado;
        //private readonly ServicioUnico unico;
        //private readonly ServicioTransitorio transitorio;

        public HomeController(ILogger<HomeController> logger,IRepositorioProyectos repositorioProyectos
            /*ServicioDelimitado delimintado,ServicioUnico unico,ServicioTransitorio transitorio*/)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            //this.delimintado = delimintado;
            //this.unico = unico;
            //this.transitorio = transitorio;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Este es un log");
            var proyectos = repositorioProyectos.ObtenerProyecto().Take(3).ToList();
            //var guid = new EjemploGUIDViewModel()
            //{
            //    Delimitado = delimintado.ObtenerGuid,
            //    Unico = unico.ObtenerGuid,
            //    Transtitorio = transitorio.ObtenerGuid,
            //};
            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos,
                //EjemploGUID1 = guid
            };

            return View(modelo);
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyecto().ToList();

            return View(proyectos);
        }

        public IActionResult Contacto() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contacto)
        {
            EnvioCorreo correo = new EnvioCorreo();
            string msj = "";
            correo.EnviarCorreo(contacto.mensaje,contacto.email,"Respuesta de contacto",ref msj);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}