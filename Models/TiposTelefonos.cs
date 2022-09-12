using System.ComponentModel.DataAnnotations;

namespace RegistroPersona.Models
{
    public class TiposTelefonos
    {
        [Key]
        public int TiposTelefonoId { get; set; } 
        public string Descripcion { get; set; }
    }
}
