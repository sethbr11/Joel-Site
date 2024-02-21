using Microsoft.EntityFrameworkCore;

namespace Mission06_Brock.Models {
    public class MovieApplicationContext : DbContext { // Liaison from the app to the database
        // Constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base (options) {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>().HasData(
                // Our default categories (seed the data). If no categories are in the table, we add these by default
                new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television" },
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 8, CategoryName = "VHS" }

            ); 
        }
    }
}
