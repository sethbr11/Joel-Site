using Microsoft.EntityFrameworkCore;

namespace Mission06_Brock.Models {
    public class MovieApplicationContext : DbContext { // Liaison from the app to the database
        // Constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base (options) {

        }
        public DbSet<MovieApplication> Applications { get; set; }
    }
}
