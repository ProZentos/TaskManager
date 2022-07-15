using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLengthAttribute(1, ErrorMessage = "Title skal være udfyldt.")]
        public string Title { get; set; }
        [Required]
        [Range(13,100,ErrorMessage ="Minimums alder skal være imellem 13 og 100.")]
        public int RequiredAge { get; set; }
    }
}
