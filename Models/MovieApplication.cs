using System.ComponentModel.DataAnnotations;

namespace Mission06_Brock.Models {
    public class MovieApplication {
        [Key]
        [Required]
        public int ApplicationID { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [StringLength(25)] // Character count of 25 max
        public string? Notes { get; set; }
    }
}
