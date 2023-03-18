using Crud_Agenda_Telefonica_Foro_U2.Models;

namespace Crud_Agenda_Telefonica_Foro_U2.Interface;

public interface IrepositorioContactos
{
    public List<Contacto> Contactos { get; }
    public List<Contacto> ObtenerContactos();
    public void AgregarContacto(Contacto contacto);
    public void ActualizarContacto(Contacto contacto);
    public void EliminarContacto(Guid id);
    public Contacto ObtenerContacto(Guid id);
}