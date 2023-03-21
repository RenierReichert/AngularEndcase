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
                var existingcourse = _db.CoursesTable.First(c => c.code == courseinstance.course.code);
                if (existingcourse is not null)
                {
                    Console.WriteLine(courseinstance.course.code + " Already exists in DB, skipping...");
                    courseinstance.course = existingcourse;
                }
                else
                {
                    Console.WriteLine("Adding course to DB...");
                    _db.CoursesTable.Add(courseinstance.course);
                }

                var existinginstance = _db.CourseInstancesTable.First(c => courseinstance.startdatum == c.startdatum && c.course.code == courseinstance.course.code);

                if (existinginstance is not null)
                {
                    Console.WriteLine(existinginstance);
                    Console.WriteLine(" Already exists in DB, skipping...");
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
