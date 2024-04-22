using System;
using System.Collections.Generic;

namespace SchoolAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int IdGrade { get; set; }
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Adress { get; set; } = null!;

        public virtual Grade IdGradeNavigation { get; set; } = null!;
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
