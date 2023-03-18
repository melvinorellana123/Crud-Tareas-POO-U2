namespace Crud_Agenda_Telefonica_Foro_U2.Models;

public class Contacto
{
   
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string NumCelular { get; set; }
    public string NumFijo { get; set; }
    public string NumResidencial { get; set; }
    public string NumTrabajo { get; set; }
}