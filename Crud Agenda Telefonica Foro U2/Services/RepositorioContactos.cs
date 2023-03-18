using Crud_Agenda_Telefonica_Foro_U2.Interface;
using Crud_Agenda_Telefonica_Foro_U2.Models;

namespace Crud_Agenda_Telefonica_Foro_U2.Services;

public class RepositorioContacto : IrepositorioContactos
{
   public List<Contacto> Contactos { get; }

   public RepositorioContacto()
   {
      Contactos = new List<Contacto>();
   }

   public List<Contacto> ObtenerContactos()
   {
      return Contactos;
   }

   public void AgregarContacto(Contacto contacto)
   {
      contacto.Id = Guid.NewGuid();
      Contactos.Add(contacto);
   }

   public void EliminarContacto(Guid id)
   {
      var contactoAEliminar = Contactos.Find(contacto => contacto.Id == id);
      if (contactoAEliminar == null)
      {
         throw new Exception("No existe EL CONTACTO que desea eliminar");
      }

      Contactos.Remove(contactoAEliminar);
   }

   public void ActualizarContacto(Contacto contacto)
   {
      var contactoAActualizar = Contactos.Find(contacto => contacto.Id == contacto.Id);
      if (contactoAActualizar == null)
      {
         throw new Exception("No existe EL CONTACTO que desea actualizar");
      }

      contactoAActualizar.Nombre = contacto.Nombre;
      contactoAActualizar.NumCelular = contacto.NumCelular;
      contactoAActualizar.NumFijo = contacto.NumFijo;
      contactoAActualizar.NumResidencial = contacto.NumResidencial;
      contactoAActualizar.NumTrabajo = contacto.NumTrabajo;
   }
   

   public Contacto ObtenerContacto(Guid id)
   {
      var contactoAObtener = Contactos.Find(contacto => contacto.Id == contacto.Id);
      if (contactoAObtener == null)
      {
         throw new Exception("No existe EL CONTACTO que desea obtener");
      }

      return contactoAObtener;
   }
   
}