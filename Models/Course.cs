using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class Course
    {
        public Course()
        {
            CoursePrereqCourse = new HashSet<CoursePrereq>();
            CoursePrereqPrereqCourse = new HashSet<CoursePrereq>();
            DegreePathCourseComboMap = new HashSet<DegreePathCourseComboMap>();
            DegreePathCourseMap = new HashSet<DegreePathCourseMap>();
            SpecialtyCourseMap = new HashSet<SpecialtyCourseMap>();
        }

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public int? CourseCredits { get; set; }

        public virtual ICollection<CoursePrereq> CoursePrereqCourse { get; set; }
        public virtual ICollection<CoursePrereq> CoursePrereqPrereqCourse { get; set; }
        public virtual ICollection<DegreePathCourseComboMap> DegreePathCourseComboMap { get; set; }
        public virtual ICollection<DegreePathCourseMap> DegreePathCourseMap { get; set; }
        public virtual ICollection<SpecialtyCourseMap> SpecialtyCourseMap { get; set; }
    }
}
