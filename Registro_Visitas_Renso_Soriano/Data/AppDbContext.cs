using Microsoft.EntityFrameworkCore;

namespace Registro_Visitas_Renso_Soriano.Data
{
    public class AppDbContext : DbContext
    {
        //Contexto que utiliza la app para conectarse a la bd
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public  DbSet<VisitsHistory> VisitsHistories { get; set; }
        public  DbSet<Visitors> Visitors { get; set; }
        public  DbSet<Events> Events { get; set; }
        public  DbSet<EventsAssignation> EventsAssignations { get; set; }

        public virtual DbSet<Changes> Changes { get; set; }


    }
}
