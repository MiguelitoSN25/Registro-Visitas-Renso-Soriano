using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Visitas_Renso_Soriano.Data
{
    public class VisitsHistory
    {
        //Modelo que utiliza la app para conectarse a el historia de eventos


        [Key]
        public int VisitsId { get; set; }

        [Required(ErrorMessage = "Visitante es Requerido")]
        [DisplayName("Visitante")]
        [ForeignKey("Visitors")]
        public int VisitorId { get; set; }
        [Required(ErrorMessage = "Motivo es Requerido")]
        [DisplayName("Motivo")]
        public string Subject  { get; set; }
        [Required(ErrorMessage = "Fecha es Requerida")]
        [DataType(DataType.Date)]
        [DisplayName("Fecha Registro")]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Fecha de Entrada es Requerida")]
        [DataType(DataType.DateTime)]
        [DisplayName("Fecha Entrada")]
        public DateTime DateIncome { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        [DisplayName("Fecha Salida")]
        public DateTime DateDeparture { get; set; } = DateTime.Now;


        public Visitors? Visitors { get; set; }


    }
}
