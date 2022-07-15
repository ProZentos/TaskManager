using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Dutyschedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId{ get; set; }
        [Required]
        public int TaskIds { get; set; }
        [Required]
        public DateTime ShiftStart { get; set; } = DateTime.Now;
        [Required]
        public DateTime ShiftEnd { get; set; }  = DateTime.Now.AddHours(8);
    }
}
