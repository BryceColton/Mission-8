using System.ComponentModel.DataAnnotations;

namespace Mission_8.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public string Quadrant { get; set; } // Quadrant I, II, III, IV

        [Required]
        public int CategoryId { get; set; } // Foreign Key
        public CategoryModel Category { get; set; }

        public bool Completed { get; set; } = false;
    }
}
