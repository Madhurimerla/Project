using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            SpecialtyCourseMap = new HashSet<SpecialtyCourseMap>();
        }

        public int SpecId { get; set; }
        public int? DegreeId { get; set; }
        public string SpecialtyName { get; set; }

        public virtual Degree Degree { get; set; }
        public virtual ICollection<SpecialtyCourseMap> SpecialtyCourseMap { get; set; }
    }
}
