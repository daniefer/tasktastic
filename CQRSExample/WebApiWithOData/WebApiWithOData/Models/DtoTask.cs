using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Contracts;

namespace WebApiWithOData.Models
{
    public class DtoTask
    {
        public string Description { get; set; }

        public DtoReminder Reminder { get; set; }

        [Key]
        public Guid Key { get; set; }
    }
}