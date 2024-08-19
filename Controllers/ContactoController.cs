using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace progra.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;

        public ContactoController(ILogger<ContactoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(Contacto contacto)
        {
            double igv;
            if(contacto.Membresia=="Básico"){
                igv=500*0.18;
            }else{
                igv=1000*0.18;
            }
            ViewData["MsgRpta"] = $"Gracias por su inscripción en {contacto.Membresia} el IGV sería {igv}";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

    public class Contacto
    {
         public string? Nombre { get; set; }
        public int? Edad { get; set; }
        public string? Genero { get; set; }
        public string? Fecha { get; set; }
        public string? Dir { get; set; }
        public string? Dist { get; set; }
        public string? Membresia { get; set; }
    }
}