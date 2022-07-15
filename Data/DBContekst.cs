using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class DBContekst : DbContext
    {
        public DBContekst(DbContextOptions<DBContekst> options) : base(options)
        {
        }

        public DbSet<User>Users { get; set; }
        public DbSet<TaskManager.Models.Task> Tasks { get; set; }
        public DbSet<Dutyschedule> dutyschedules { get; set; }
        public DbSet<TaskManager.Models.CreateShift>? CreateShift { get; set; }
    }
}
