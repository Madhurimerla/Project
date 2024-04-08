using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class DegreepathRule
    {
        public int RuleId { get; set; }
        public int? DegreePathId { get; set; }
        public string RuleCategory { get; set; }
        public string RuleValue { get; set; }

        public virtual Degreepath DegreePath { get; set; }
    }
}
