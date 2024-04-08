using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class SpecialtyCourseMap
    {
        public int SpecId { get; set; }
        public string CourseId { get; set; }
        public int? MandatoryCourse10 { get; set; }

        public virtual Course Course { get; set; }
        public virtual Specialty Spec { get; set; }
    }
}
