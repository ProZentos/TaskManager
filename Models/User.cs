using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLengthAttribute(2,ErrorMessage = "Navn skal være på mindst 2 tegn.")]
        public string Name { get; set; }
        [Required]
        [MinLengthAttribute(1, ErrorMessage = "Title skal være udfyldt.")]

        public string Title { get; set; }
        [Required]
        public DateTime Age { get; set; }
        [Required]
        public bool Employed { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
