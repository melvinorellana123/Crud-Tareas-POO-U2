using Crud_Tarea_1_U1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Crud_Tarea_1_U1.Interfaces;

namespace Crud_Tarea_1_U1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioTareas _repositorioTareas;

        public HomeController(ILogger<HomeController> logger, IRepositorioTareas repositorioTareas)
        {
            _logger = logger;
            _repositorioTareas = repositorioTareas;
        }

        public IActionResult Index()
        {
            
            var todasLasTareas = _repositorioTareas.ObtenerTareas();
            var tareasViewModel = new TareasViewModel
            {
                tareas = todasLasTareas
            };
            return View(tareasViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Crear()
        {
            return View("FormularioCrear");
            
        }
        [HttpPost]
        public IActionResult Crear(Tarea tarea)
        {
            _repositorioTareas.AgregarTarea(tarea);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(Guid Id)
        {
            var tarea = _repositorioTareas.ObtenerTarea(Id);
            return View("FormularioEditar",tarea);
        }
        [HttpPost]
        public IActionResult Editar(Tarea tarea)
        {
            _repositorioTareas.ActualizarTarea(tarea);
            return RedirectToAction("Index");
        }
      
        
        [HttpGet]
        public IActionResult Eliminar(Guid Id)
        {
            _repositorioTareas.EliminarTarea(Id);
            return RedirectToAction("Index");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}