using CoursesDBProject.Tables;
using CoursesDBProject.Entities;

namespace CoursesDBProject.Shared
{
    public class CourseDBControl
    {
        private InfoSupportDbContext _db;
        public CourseDBControl(InfoSupportDbContext db)
        {
            _db = db;
        }


        public List<CourseInstance> CoursesUpload(List<CourseInstance> courses) 
        {
            var addedCourses = new List<CourseInstance>();


            foreach(CourseInstance courseinstance in courses)
            {
                int existingcourses = _db.CoursesTable.Where(c => c.code == courseinstance.course.code).Count();
                if (existingcourses > 0)
                {
                    Console.WriteLine(courseinstance.course.code + "Course Already exists in DB, skipping...");
                    courseinstance.course = _db.CoursesTable.First(c => c.code == courseinstance.course.code);
                }
                else
                {
                    Console.WriteLine("Adding course to DB...");
                    _db.CoursesTable.Add(courseinstance.course);
                }

                int existinginstances = _db.CourseInstancesTable.Where(c => courseinstance.startdatum == c.startdatum && c.course.code == courseinstance.course.code).Count();

                if (existingcourses > 0)
                {
                    Console.WriteLine("Instance Already exists in DB, skipping...");
                }
                else
                {
                    Console.WriteLine("Adding courseInstance to DB...");
                    _db.CourseInstancesTable.Add(courseinstance);

                    addedCourses.Add(courseinstance);
                }

                
            }
            _db.SaveChanges();

            return addedCourses;
        }


    }
}
