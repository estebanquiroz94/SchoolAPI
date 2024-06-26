﻿using System;
using System.Collections.Generic;

namespace SchoolAPI.Models
{
    public partial class Class
    {
        public Class()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
