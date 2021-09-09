using EstacionamientoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Persona pers1 = new Persona() {
                Nombre = "Pedro",
                Apellido = "Picapiedra",
                Email = "pedro@picapiedra.com"
            };

            List<Persona> lista        = new List<Persona>();
            IEnumerable<Persona> ie = new List<Persona>();
            ICollection<Persona> ic = new List<Persona>();
            IList<Persona> il       = new List<Persona>();
            
            il.Add(pers1);
            //ie.add
            //ic.Add(pers1);
            
            //il.Add(pers1);
            il.Add(new Persona() { 
                Nombre="Pablo",
                Apellido="Marmol",
                Email ="pablo@marmol.com"
            } );

            Persona pers3 = new Persona()
            {
                Nombre = "Vilma",
                Apellido = "Picapiedra",
                Email = "vilma@picapiedra.com"
            };
            il.Add(pers3);

            Persona supervisor = new Persona()
            {
                Nombre = "Betty",
                Apellido = "Marmol",
                Email = "betty@marmol.com"
            };


            lista.AddRange(il);

            ViewBag.Supervisor = supervisor;
           // ViewBag.Supervisor = "Hola";

            var resultado = ViewBag.Supervisor;



            return View(lista);     
        }

        public IActionResult Privacy()
        {
            ViewBag.OtraCosa = "asdasdasd"; 

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
