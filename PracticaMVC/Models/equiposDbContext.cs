using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Models
{
    public class equiposDbContext : DbContext
    {
        public equiposDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<marcas> marcas { get; set; }
        public DbSet<estados_equipo> Estados_equipo { get; set; }
        public DbSet<facultades> facultades { get; set;}
        public DbSet<tipo_equipo> tipo_equipo { get; set;}
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<carreras> carreras { get; set; }
        public DbSet<equipos> equipos { get; set; }

    }
}
