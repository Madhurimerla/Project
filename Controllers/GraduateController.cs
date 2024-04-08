using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CourseAdvisoryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CourseAdvisoryApplication.Controllers
{
    
    public class GraduateController : Controller
    {
    private readonly ILogger<GraduateController> _logger;
    private readonly MyDbContext _context;

    public GraduateController(ILogger<GraduateController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
        
     public IActionResult SelectCourses()
    {   
        //ViewBag.CourseList = _context.Course.ToList();
        string SelectedDegree = (string)TempData["Degree"];
        if (SelectedDegree == "Master of Science in Computer Science")
        {
        ViewBag.CourseList = _context.Set<Course>().FromSqlRaw(@"select distinct c.*
        from degree d 
        inner join dbo.degreepath dp on d.degree_id=dp.degree_id
        inner join dbo.degreepath_Course_Map dcm on dp.degreepath_id=dcm.degreepath_id
        inner join dbo.course c on c.course_id=dcm.course_id
        where d.degree_name='Master of Science in Computer Science';").ToList();
        return View("Graduate");
        }
        if (SelectedDegree == "Executive Master of Science in Criminal Justice")
        {
        ViewBag.CourseList = _context.Set<Course>().FromSqlRaw(@"select distinct c.*
        from degree d 
        inner join dbo.degreepath dp on d.degree_id=dp.degree_id
        inner join dbo.degreepath_Course_Map dcm on dp.degreepath_id=dcm.degreepath_id
        inner join dbo.course c on c.course_id=dcm.course_id
        where d.degree_name='Executive Master of Science in Criminal Justice';").ToList();
        return View("Graduate");
        }

        return View("Graduate");
    }  
    [HttpPost]
        
    public IActionResult SelectCourses(List<string> selectedItems)
    {  
        /*List<string> reqcourseslst = new List<string>();
        reqcourseslst.Add("CMPS500");
        reqcourseslst.Add("CMPS501");
        reqcourseslst.Add("CMPS502");
        reqcourseslst.Add("CMPS512");
        IEnumerable<string> LstCoursesReq = reqcourseslst.Except(selectedItems);*/
      //var username = HttpContext.Session.GetString("UserId");
      string username = (string)TempData["username"];
      var AdvisorName = _context.Users.Where(x => x.UserName == username).Select(x => x.AdvisorName.ToString()).FirstOrDefault();
      string AdvisorDetails =  "Advisor Name :";
      TempData["Advisor_name"] = AdvisorDetails + " " + AdvisorName;
       var TempTabledata = _context.Temp.ToList();
       
        _context.Temp.RemoveRange(TempTabledata);
        _context.SaveChanges();
       
        foreach (var item in selectedItems)
        {
          var selectedcourse = new Temp
          {
            CourseId = item
          };
        _context.Temp.Add(selectedcourse);
        _context.SaveChanges();
        }
        
         var queryResult = _context.Set<Status>().FromSqlRaw(
                @"With data as(
select
dp.path_name,max(dp.TotalCreditsRequired) as TotalCreditsRequired
,sum(case when t.course_id is null then -0 else course_credits end) as Total_Course_Credits_obtained
,sum(mandatorycourse_1_0) as Number_of_MandatoryCourses
,sum(case when t.course_id is null then -0 else mandatorycourse_1_0 end) as Number_of_MandatoryCourses_Completed
from 
degree d 
inner join dbo.degreepath dp on d.degree_id=dp.degree_id
inner join dbo.degreepath_Course_Map dcm on dp.degreepath_id=dcm.degreepath_id
inner join dbo.course c on c.course_id=dcm.course_id
left join Temp t on t.course_id=c.course_id
where d.degree_name='Master of Science in Computer Science' --and dp.path_name='Thesis Option'
group by dp.path_name
)

select concat(path_name,': The student has completed ',Number_of_MandatoryCourses_Completed, ' out of ', Number_of_MandatoryCourses ,' Mandatory Courses Required.' 
,'The student has completed ',Total_Course_Credits_obtained, ' out of ', TotalCreditsRequired ,' Credits Required'

     ) as message

from data;").AsEnumerable();

         ViewBag.messagelist = queryResult?.Select(x => x.message).ToList();
         var queryCourseResult = _context.Set<Result>().FromSqlRaw(
                @"With A as(
select distinct path_name as Path_Name,c.Course_id as Course_ID,Course_Name,Course_Credits,MandatoryCourse_1_0 as Mandatory_Course, dcm.Course_Category
from 
degree d 
inner join dbo.degreepath dp on d.degree_id=dp.degree_id
inner join dbo.degreepath_Course_Map dcm on dp.degreepath_id=dcm.degreepath_id
inner join dbo.course c on c.course_id=dcm.course_id
where d.degree_name='Master of Science in Computer Science'
),
pvt as(
select *
from A
pivot(max(Mandatory_Course) for path_name in ([Thesis Option],[Non-Thesis Option])) dd
)

select pvt.course_id as Course_ID,pvt.Course_Name,Course_Category
,CP.PREREQ_COURSE_ID as PreReq_Course_ID
,pvt.Course_Credits
,case when pvt.[Thesis Option] =1 then 'Y' else 'N' end as ThesisOption_MandatoryCourse_YN
,case when pvt.[Non-Thesis Option] =1 then 'Y' else 'N' end as NonThesisOption_MandatoryCourse_YN
,case when t.course_id is not null then  'Complete' 
when t.course_id is  null and (pvt.[Thesis Option] =1 or pvt.[Non-Thesis Option] =1 ) then 'Incomplete' else null
   end as Student_Course_Completion_Status

,case when t.course_id is null then -0 else course_credits end as Course_Credits_Obtained
from pvt 
left join temp t on t.course_id=pvt.Course_id
LEFT JOIN DBO.COURSE_PREREQ CP ON CP.COURSE_ID=pvt.COURSE_ID
order by ThesisOption_MandatoryCourse_YN desc,NonThesisOption_MandatoryCourse_YN desc
;").ToList();
    return View(queryCourseResult);
        //return View(LstCoursesReq.ToList());
        }

    /*public class Status
    {
      public string? message { get; set; }    
    }*/

  }
}