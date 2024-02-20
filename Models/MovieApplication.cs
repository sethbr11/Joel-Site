using System.ComponentModel.DataAnnotations;

namespace Mission06_Brock.Models {
    public class MovieApplication {
        [Key]
        [Required]
        public int ApplicationID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, 2024)] // Range from 1888 to the current year
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [StringLength(25)] // Character count of 25 max
        public string? Notes { get; set; }
    }
}
