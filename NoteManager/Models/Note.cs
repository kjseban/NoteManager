using System.ComponentModel.DataAnnotations;

namespace NoteManager.Models
{
    public class Note
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NoteText { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
