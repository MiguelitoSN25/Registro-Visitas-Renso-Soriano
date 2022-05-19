using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Visitas_Renso_Soriano.Data
{
    public class EventsAssignation
    {
        //Modelo que utiliza la app para conectarse a la asignacion de eventos

        [Key]
        public int IdEventsAssignation { get; set; }

        [Required(ErrorMessage = "Visitante es Requerido")]
        [ForeignKey("Visitors")]
        [DisplayName("Nombre Visitante")]
        public int VisitorId { get; set; }
        [Required(ErrorMessage = "Evento es Requerido")]
        [ForeignKey("Events")]
        [DisplayName("Nombre Evento")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Fecha del Evento es Requerido")]
        [DisplayName("Fecha Evento")]
        public DateTime Date { get; set; }
        public Visitors? Visitors { get; set; }
        public Events? Events { get; set; }



    }
}
