using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class ShiftScheduleController : Controller
    {
        private readonly DBContekst _db;
        private User User { get; set; }
        public ShiftScheduleController(DBContekst db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<User> users = _db.Users.ToList();
            List<TaskManager.Models.Task> tasks = _db.Tasks.ToList();
            List<Dutyschedule> duty = _db.dutyschedules.ToList();
            foreach (Dutyschedule itemDuty in duty)
            {
                var obj = tasks.Where(x => x.Id == itemDuty.TaskIds);

                if (obj.Count() == 0)
                {
                    Models.Task task = new Models.Task();
                    task.Id = itemDuty.TaskIds;
                    task.Title = "Ingen opgave(r)";
                    task.RequiredAge = 0;
                    tasks.Add(task);
                }
            }
            Shifts schedule = new Shifts();
            schedule.users = users;
            schedule.tasks = tasks;
            schedule.dutyschedules = duty;
            return View(schedule);
        }

        private List<SelectListItem> BindList(int id)
        {
            List<SelectListItem> tasks = new List<SelectListItem>();
            List<TaskManager.Models.Task> allTasks = _db.Tasks.ToList();
            User = _db.Users.Find(id);
            int usersAge = DateTime.Now.Year - User.Age.Year;

            List<TaskManager.Models.Task> avalibleTask = new List<Models.Task>();

            foreach (TaskManager.Models.Task task in allTasks)
            {
                if (usersAge >= task.RequiredAge)
                {
                    tasks.Add(new SelectListItem { Text = task.Title, Value = task.Id.ToString() });
                }
            }
            return tasks;
        }


        public IActionResult AssignTask(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
             
            //List<Dutyschedule> duty = _db.dutyschedules.Find(id);
            CreateShift shift = new CreateShift();
            
            shift.tasks = BindList(id);
            shift.userId = User.Id;
            //shift. = duty;

            return View(shift);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignTask(CreateShift createShift)
        {
            List<Dutyschedule> dutys = new List<Dutyschedule>();

            if (createShift.selectedTaskIds.Count >= 1)
            {
                foreach (var taskID in createShift.selectedTaskIds)
                {
                    Dutyschedule dutyschedule = new Dutyschedule();
                    dutyschedule.ShiftStart = createShift.ShiftStart;
                    dutyschedule.ShiftEnd = createShift.ShiftEnd;
                    dutyschedule.UserId = createShift.userId;
                    dutyschedule.TaskIds = taskID;

                    _db.dutyschedules.Add(dutyschedule);
                }
                
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = _db.dutyschedules.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.dutyschedules.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
