using EstacionamientoMVC.Data;
using EstacionamientoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Controllers
{
    public class PersonasController : Controller
    {
        private readonly EstacionamientoContext contexto;

        public PersonasController(EstacionamientoContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {           
            //Creo Persona
            Persona pers1 = new Persona()
            {
                Nombre = "Pedro",
                Apellido = "Picapiedra",
                Email = "pedro@picapiedra.com"
            };

            //La agrego al contexto 
            contexto.Personas.Add(pers1);

            //Disparo la acción para guardar en la base de datos.
            contexto.SaveChanges();

            //Consulto al contexto por las personas.
            var personas = contexto.Personas.ToList();

            return View(personas);
        }
    }
}
