using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class Degree
    {
        public Degree()
        {
            Degreepath = new HashSet<Degreepath>();
            Specialty = new HashSet<Specialty>();
        }

        public int DegreeId { get; set; }
        public int? DepId { get; set; }
        public string DegreeName { get; set; }

        public virtual Department Dep { get; set; }
        public virtual ICollection<Degreepath> Degreepath { get; set; }
        public virtual ICollection<Specialty> Specialty { get; set; }
    }
}
