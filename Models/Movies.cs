using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Brock.Models {
    public class Movies {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Categories Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, Double.MaxValue)] // Range from 1888 to the current year
        public int Year { get; set; }
        [Required]
        public string? Director { get; set; }
        [Required]
        public string? Rating { get; set; }
        [Required]
        public bool Edited { get; set; } = false;
        public string? LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; } = false;
        [StringLength(25)] // Character count of 25 max
        public string? Notes { get; set; }
    }
}
