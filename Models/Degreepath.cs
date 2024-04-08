using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class Degreepath
    {
        public Degreepath()
        {
            DegreePathCourseComboMap = new HashSet<DegreePathCourseComboMap>();
            DegreePathCourseMap = new HashSet<DegreePathCourseMap>();
            DegreepathRule = new HashSet<DegreepathRule>();
        }

        public int DegreePathId { get; set; }
        public int? DegreeId { get; set; }
        public int? PathNumber { get; set; }
        public string PathName { get; set; }
        public int? TotalCreditsRequired { get; set; }

        public virtual Degree Degree { get; set; }
        public virtual ICollection<DegreePathCourseComboMap> DegreePathCourseComboMap { get; set; }
        public virtual ICollection<DegreePathCourseMap> DegreePathCourseMap { get; set; }
        public virtual ICollection<DegreepathRule> DegreepathRule { get; set; }
    }
}
