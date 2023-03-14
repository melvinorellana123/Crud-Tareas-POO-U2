using Crud_Tarea_1_U1.Interfaces;
using Crud_Tarea_1_U1.Models;

namespace Crud_Tarea_1_U1.Servicios;

public class RepositorioTarea : IRepositorioTareas
{
    
    public List<Tarea> Tareas { get; }

    public RepositorioTarea()
    {
        Tareas = new List<Tarea>();
    }
    
    
    public List<Tarea> ObtenerTareas()
    {
        return Tareas;
    }

    public void AgregarTarea(Tarea tarea)
    {
        tarea.Id = Guid.NewGuid();
        Tareas.Add(tarea);
    }

    public void EliminarTarea(Guid id)
    {
        var tareaAEliminar = Tareas.Find(tarea => tarea.Id == id );
        if (tareaAEliminar == null)
        {
            throw new Exception("No existe la tarea");
        }

        Tareas.Remove(tareaAEliminar);
    }

    public void ActualizarTarea(Tarea tarea)
    {
        var tareaAActualizar = Tareas.Find(tarea => tarea.Id == tarea.Id );

        if (tareaAActualizar == null)
        {
            throw new Exception("No existe la tarea");
        }

        tareaAActualizar.Nombre = tarea.Nombre;
        tareaAActualizar.Descripcion = tarea.Descripcion;
        tareaAActualizar.FechaVencimiento = tarea.FechaVencimiento;

    }

    public Tarea ObtenerTarea(Guid id)
    {
        var tareaAObtener = Tareas.Find(tarea => tarea.Id == tarea.Id );
        if (tareaAObtener == null)
        {
            throw new Exception("No existe la tarea");
        }

        return tareaAObtener;
    }
}