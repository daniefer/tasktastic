using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public struct Reminder
    {
        private readonly DateTime _reminderTime;

        public Reminder(DateTime reminderTime)
        {
            this._reminderTime = reminderTime;
        }

        public DateTime ReminderTime
        {
            get { return this._reminderTime; }
        }
    }
}
