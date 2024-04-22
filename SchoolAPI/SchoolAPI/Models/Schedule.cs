using System;
using System.Collections.Generic;

namespace SchoolAPI.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int IdStudent { get; set; }
        public int IdClass { get; set; }
        public string Credits { get; set; } = null!;
        public string Observations { get; set; } = null!;

        public virtual Class IdClassNavigation { get; set; } = null!;
        public virtual Student IdStudentNavigation { get; set; } = null!;
    }
}
