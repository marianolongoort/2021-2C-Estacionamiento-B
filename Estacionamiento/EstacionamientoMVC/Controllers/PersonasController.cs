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
        private readonly EstacionamientoContext _db;

        public PersonasController(EstacionamientoContext contexto)
        {
            this._db = contexto;
        }

        public IActionResult Index()
        {           
           
            //Consulto al contexto por las personas.
            List<Persona> personas = _db.Personas.ToList();

            return View(personas);
        }

        public IActionResult Detalles(int? id)
        {
            //si no me pasa id, no puedo ir a buscar la nada misma
            if(id == null)
            {
                return NotFound();
            }

            var resultadoEnDb = _db.Personas.Find(id);
            //resultadoEnDb = _db.Personas.First( p  => p.Id == id);
            //resultadoEnDb = _db.Personas.FirstOrDefault(p => p.Id == id);
            
            //var TodosLosPedros = _db.Personas.Where(p => p.Nombre == "Pedro");

            //verifico si hay persona en DB
            if(resultadoEnDb == null)
            {
                return NotFound();
            }


            return View(resultadoEnDb);
        }

        //entregamos el formulario
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //recibimos el form y procesamos
        [HttpPost]
        public IActionResult Create(string nombre,string apellido,int otracosa)
        {
            //tartamiento de los datos.
            //validar
            Persona personaNueva = new Persona() {
                Nombre = nombre,
                Apellido = apellido,
                DNI = otracosa,
                Email = "pablo@marmol.com"
            };
            //crear
            //guardar
            //retornar o redireccionar.

            _db.Personas.Add(personaNueva);
            _db.SaveChanges();

            return View();
        }

        public IActionResult Seed()
        {
            Persona persona1 = new Persona() {
                Nombre = "Pedro",
                Apellido = "Picapiedra",
                DNI = 22333444,
                Email = "pedro@roca.com"
            };
            _db.Personas.Add(persona1);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}
