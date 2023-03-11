using System.ComponentModel.DataAnnotations;

namespace NoteManager.Models
{
    public class AddEditDeleteLog
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NoteText { get; set; }
        [Required]
        public string Flag { get; set; }
        [Required]
        public DateTime ActionDateTime { get; set; } = DateTime.Now;
    }
}
