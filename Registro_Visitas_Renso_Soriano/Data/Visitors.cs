using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registro_Visitas_Renso_Soriano.Data
{
    public class Visitors
    {
        //Creacion de Modelos de Visitante
        [Key]
        public int VisitorId { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        [DisplayName("Nombre")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Apellido es Requerido")]
        [DisplayName("Apellido")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Fecha es Requerida")]
        [DataType(DataType.DateTime)]
        [DisplayName("Fecha_Ultimo_Registro")]
        public DateTime? Last_Date_Register { get; set; }


    }
}
