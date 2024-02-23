using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Brock.Models {
    public class Movie {
        // Some object are set to nullable (string?) but also have [Required]. This is so error messages display
        // properly. Including "?" does not affect the input of the data to the database since we still have [Required]
        [Key][Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } // Our foreign key CategoryId...
        public Category? Category { get; set; } // ...which links to a Category object

        [Required(ErrorMessage = "Please include the title of your movie")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please include a valid year for the movie")]
        [Range(minimum: 1888, maximum: Double.MaxValue, ErrorMessage = "Year must be at least 1888")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please include if the movie was edited or not")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Please indicate if the movie was copied to Plex servers")]
        public bool? CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Notes must be under 25 characters")] // Character count of 25 max
        public string? Notes { get; set; }
    }
}
