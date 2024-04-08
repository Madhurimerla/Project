using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class Courses
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public int? CourseCredits { get; set; }
    }
}
