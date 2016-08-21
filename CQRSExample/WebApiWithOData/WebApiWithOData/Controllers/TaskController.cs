using System;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using Contracts;
using WebApiWithOData.Models;
using WriteLibrary;

namespace WebApiWithOData.Controllers
{
    public class TaskController : ODataController
    {
        private readonly TaskManager _taskManager;

        public TaskController(TaskManager taskManager)
        {
            this._taskManager = taskManager;
        }

        public IHttpActionResult Post(DtoTask dtoTask)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            Reminder reminder = new Reminder(dtoTask.Reminder.ReminderTime);
            Task task = new Task(Guid.Empty, dtoTask.Description, reminder);
            task = this._taskManager.Create(task);
            dtoTask.Key = task.Key;
            dtoTask.Description = task.Description;
            dtoTask.Reminder = new DtoReminder { ReminderTime = task.Reminder.Value.ReminderTime};
            return this.Ok(dtoTask);
        }

        public IHttpActionResult Put(Guid key, DtoTask dtoTask)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            Reminder reminder = new Reminder(dtoTask.Reminder.ReminderTime);
            Task task = new Task(key, dtoTask.Description, reminder);
            task = this._taskManager.Update(task);
            dtoTask.Key = task.Key;
            dtoTask.Description = task.Description;
            dtoTask.Reminder = new DtoReminder { ReminderTime = task.Reminder.Value.ReminderTime };
            return this.Ok(task);
        }

        public IHttpActionResult Delete(Guid key)
        {
            this._taskManager.Delete(key);
            return this.Ok();
        }
    }
}
