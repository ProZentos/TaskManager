namespace TaskManager.Models
{
    public class Shifts
    {
        public List<User> users { get; set; }
        public List<Task> tasks { get; set; }
        public List<Dutyschedule> dutyschedules { get; set; }
    }
}
