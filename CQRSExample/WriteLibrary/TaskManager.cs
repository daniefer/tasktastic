using System;
using Common;
using Contracts;
using WriteLibrary.Exceptions;

namespace WriteLibrary
{
    public class TaskManager
    {
        private readonly EventStore<Task, Guid> _eventStore;

        public TaskManager(EventStore<Task, Guid> eventStore)
        {
            this._eventStore = eventStore;
        }

        public virtual Task Create(Task task)
        {
            task.Key = Guid.NewGuid();
            Transform<Task> transform = new Transform<Task>(null, task);
            _eventStore.Add(transform);
            return task;
        }

        public virtual Task Update(Task task)
        {
            var oldTask = _eventStore.Get(task.Key);
            if (!oldTask.HasValue)
            {
                throw new RecordDeletedException();
            }
            Transform<Task> transform = new Transform<Task>(oldTask, task);
            _eventStore.Add(transform);
            return task;
        }

        public virtual void Delete(Guid key)
        {
            Task? task = this._eventStore.Get(key);
            if (!task.HasValue)
                return; 
            var transform = new Transform<Task>(task.Value, null);
            this._eventStore.Add(transform);
        }
    }
}
