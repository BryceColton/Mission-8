using System.ComponentModel.DataAnnotations;

namespace Mission_8.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Navigation property for one-to-many relationship
        public List<TaskModel> Tasks { get; set; }
    }
}
