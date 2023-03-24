using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursesDBProject.Entities;
using CoursesDBProject.Tables;
using System.Collections;

namespace CoursesDBProject.Controllers;

[Route("api/courses")]
[ApiController]
public class CourseController : Controller
    {

    private InfoSupportDbContext _db;

    public CourseController(InfoSupportDbContext db)
    {
        _db = db;
    }


    [HttpGet]
    public IEnumerable<Course> GetAll()
    {
        
        Console.WriteLine("Courses GETALL called");
        var courses = _db.CoursesTable.ToList() ;
        return courses;
    }


    [HttpGet("filtered/{year}/{week}")]
    public IEnumerable Get(int year, int week)
    {
        var route = Request.Path.Value;
        Console.WriteLine(route);

        DateTime startdate = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
        while (startdate.DayOfWeek != DayOfWeek.Monday)
        {
            // Is this the best way? I guess it works
            startdate = startdate.AddDays(-1);
        }
        DateTime enddate = startdate.AddDays(7);


        var coursesInRange = from c in _db.CoursesTable
                             join i in _db.CourseInstancesTable on c.Id equals i.course.Id
                             where i.startdatum >= startdate && i.startdatum <= enddate
                             select new { Course = c, instancestartdatum = i.startdatum };

        Console.WriteLine(coursesInRange);
        var resultlist = coursesInRange.ToList();

        //Create a fake course in case we didn't find any results at all.
        //This lets the user know why there are 0 results.
        //Giving a fake entity back with a message
        //avoids triggering the HTTPErrorInterceptor in the frontend.
        if (resultlist.Count() == 0)
        {
            
            var crs = new Course();
            crs.Id = 0;
            crs.duur = 0;
            crs.titel = $"Geen resultaten gevonden voor jaar {year} in week {week}";
            crs.code = "Foutcode";

            var d = new DateTime();

            var tcrs = new {
                Course = crs,
                instancestartdatum = d                
            };
            
            resultlist.Add(tcrs);
        }

        return resultlist;
    }

    /*

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    */
}

