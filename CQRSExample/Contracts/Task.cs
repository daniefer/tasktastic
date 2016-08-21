using System;

namespace Contracts
{
    public struct Task : IKey<Guid>
    {
        private readonly Reminder? _reminderTime;
        private readonly string _description;

        public Task(string description) : this(description, null)
        {
        }

        public Task(string description, Reminder? reminderTime): this(Guid.Empty, description, reminderTime)
        {
        }

        public Task(Guid key, string description, Reminder? reminderTime)
        {
            this._reminderTime = reminderTime;
            this._description = description;
            this.Key = key;
        }

        public string Description
        {
            get { return this._description; }
        }

        public Reminder? Reminder
        {
            get { return this._reminderTime; }
        }

        public Guid Key { get; set; }
    }
}