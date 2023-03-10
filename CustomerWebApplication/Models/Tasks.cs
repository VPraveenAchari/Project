using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApplication.Models
{
    public class Tasks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        public Guid TaskId { get; set; }

        public Guid WorkerId { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Task Name can only be 200 characters long")]
        public string TaskName { get; set; }

        [MaxLength(200, ErrorMessage = "Description can only be 200 characters long")]
        public string Description { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}