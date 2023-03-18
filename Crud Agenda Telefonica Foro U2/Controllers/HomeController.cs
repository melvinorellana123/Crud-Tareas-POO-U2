using Crud_Agenda_Telefonica_Foro_U2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Crud_Agenda_Telefonica_Foro_U2.Interface;

namespace Crud_Agenda_Telefonica_Foro_U2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IrepositorioContactos _repositorioContactos;

        public HomeController(ILogger<HomeController> logger, IrepositorioContactos repositorioContactos)
        {
            _logger = logger;
            _repositorioContactos = repositorioContactos;
        }


        public IActionResult Index()
        {
            var todosLosContactos = _repositorioContactos.ObtenerContactos();
            var contactosViewModel = new ContactosViewModel
            {
                contactos = todosLosContactos
            };
            return View(contactosViewModel);
        }
        
        public IActionResult Crear()
        {
            return View("FormularioCrear");
        }

        [HttpPost]
        public IActionResult Crear(Contacto contacto)
        {
            _repositorioContactos.AgregarContacto(contacto);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(Guid Id)
        {
            var contacto = _repositorioContactos.ObtenerContacto(Id);
            return View("FormularioEditar", contacto);
        }

        [HttpPost]
        public IActionResult Editar(Contacto contacto)
        {
            _repositorioContactos.ActualizarContacto(contacto);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Eliminar(Guid Id)
        {
            _repositorioContactos.EliminarContacto(Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}