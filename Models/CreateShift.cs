using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    [Keyless]
    public class CreateShift
    {
        
        public int userId { get; set; }
        //public List<TaskManager.Models.Task> tasks { get; set; }
        public List<SelectListItem> tasks { get; set; }
        [Required]
        public List<int>? selectedTaskIds { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }

    }
}
