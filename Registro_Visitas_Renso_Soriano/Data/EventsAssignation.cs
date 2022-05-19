﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Visitas_Renso_Soriano.Data
{
    public class EventsAssignation
    {
        [Key]
        public int IdEventsAssignation { get; set; }

        [Required(ErrorMessage = "Visitante es Requerido")]
        [ForeignKey("Visitors")]
        [DisplayName("Visitante")]
        public int VisitorId { get; set; }
        [Required(ErrorMessage = "Evento es Requerido")]
        [ForeignKey("Events")]
        [DisplayName("Eventos")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Fecha del Evento es Requerido")]
        [DisplayName("Eventos")]
        public DateTime Date { get; set; }
        public Visitors? Visitors { get; set; }
        public Events? Events { get; set; }



    }
}