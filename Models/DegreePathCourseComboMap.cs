using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class DegreePathCourseComboMap
    {
        public int DegreePathId { get; set; }
        public string ComboId { get; set; }
        public string CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Degreepath DegreePath { get; set; }
    }
}
