using Crud_Tarea_1_U1.Models;

namespace Crud_Tarea_1_U1.Interfaces;

public interface IRepositorioTareas
{
    public List<Tarea> Tareas { get; }
    public List<Tarea> ObtenerTareas();
    public void AgregarTarea(Tarea tarea);
    public void EliminarTarea(Guid id);
    public void ActualizarTarea(Tarea tarea);
    public Tarea ObtenerTarea(Guid id);
}