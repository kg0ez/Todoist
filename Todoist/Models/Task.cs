using System.ComponentModel.DataAnnotations;

namespace Todoist.Models
{
	public class Task
	{
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Subtitle { get; set; }

        public DateTime FinalData { get; set; }
    }
}

