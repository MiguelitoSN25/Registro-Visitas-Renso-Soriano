using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registro_Visitas_Renso_Soriano.Data
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }

        [DisplayName("Eventos")]
        public string EventName { get; set; }


        public virtual ICollection<EventsAssignation>? EventsAssignations { get; set; }
    }
}
