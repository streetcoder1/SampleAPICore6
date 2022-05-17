using Microsoft.EntityFrameworkCore;
using SampleAPICore6.Model;

namespace SampleAPICore6.Data
{
    public class DbContextCinema : DbContext
    {
        public DbContextCinema(DbContextOptions<DbContextCinema> option):base(option)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movies> Movie { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
