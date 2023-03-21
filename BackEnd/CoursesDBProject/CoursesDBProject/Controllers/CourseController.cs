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

        DateTime startdatum = new DateTime(year, 1, 1);
        DateTime enddatum = new DateTime(2025, 3, 31);


        var coursesInRange = from c in _db.CoursesTable
                             join i in _db.CourseInstancesTable on c.Id equals i.course.Id
                             where i.startdatum.Year >= year && i.startdatum.Year <= (year+5)
                             select new { Course = c, instancestartdatum = i.startdatum };

        Console.WriteLine(coursesInRange);
        return coursesInRange;
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

