using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAdvisoryApplication.Models
{
    public class Result
    {
    public string? Course_ID { get; set; }
    public string? Course_Name { get; set; }
    public string? ThesisOption_MandatoryCourse_YN { get; set; }
    public string? NonThesisOption_MandatoryCourse_YN { get; set; }
    public string? Course_Category { get; set; }
    public int? Course_Credits { get; set; }
    public string? Student_Course_Completion_Status { get; set; }
    public int? Course_Credits_Obtained { get; set; }
    public string? PreReq_Course_ID { get; set; }
    }
}