using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registro_Visitas_Renso_Soriano.Data
{
    public class Changes
    {
        //Tabla de cambios y o Movimientos

        [Key]
        public int IdChanges { get; set; }
        [DisplayName("Cambios")]

        public string? ChangesNames { get; set; }
    }
}
