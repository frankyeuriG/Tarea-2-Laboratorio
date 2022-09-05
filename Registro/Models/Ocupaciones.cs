using System.ComponentModel.DataAnnotations;

public class Ocupaciones 
{
    [Key]

    public int OcupacionId {get; set;}

    [Required(ErrorMessage ="La descripion es requerida")]

    public string? Descripion {get; set;}
}