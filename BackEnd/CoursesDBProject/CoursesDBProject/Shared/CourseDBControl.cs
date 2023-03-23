using CoursesDBProject.Tables;
using CoursesDBProject.Entities;
using CoursesDBProject.DTOs;

namespace CoursesDBProject.Shared
{
    public class CourseDBControl
    {
        private InfoSupportDbContext _db;
        public CourseDBControl(InfoSupportDbContext db)
        {
            _db = db;
        }


        public ChangeListDTO CoursesUpload(List<CourseInstance> courses)
        {
            var addedCourseInstances = new List<CourseInstance>();
            var addedCourses = new List<Course>();
            int coursesaddedcount = 0, coursesskipped = 0;
            int courseinstancesaddedcount = 0, courseinstancesskipped = 0;
            string msg;


            foreach (CourseInstance courseinstance in courses)
            {

                #region uploadcourse
                int existingcourses = _db.CoursesTable.Where(c => c.code == courseinstance.course.code).Count();

                // Check the DB if this entity already exists.
                // Also check the current transaction.
                // This way the entities can be added in 1 transaction without duplicates.
                if (existingcourses == 0 && !addedCourses.Any(s => s.code.Equals(courseinstance.course.code)))
                {
                    Console.WriteLine("Adding course to DB...");
                    _db.CoursesTable.Add(courseinstance.course);
                    coursesaddedcount++;
                    addedCourses.Add(courseinstance.course);
                }
                else
                {
                    Console.WriteLine(courseinstance.course.code + "Course Already exists in DB, skipping...");
                    coursesskipped++;
                }
                #endregion

                #region uploadcourseinstance
                int existinginstances = _db.CourseInstancesTable.Where(c => courseinstance.startdatum == c.startdatum && c.course.code == courseinstance.course.code).Count();

                if (existingcourses == 0 && !addedCourseInstances.Any(c => c.Equals(courseinstance)))
                {
                    Console.WriteLine("Adding courseInstance to DB...");
                    _db.CourseInstancesTable.Add(courseinstance);
                    courseinstancesaddedcount++;
                    addedCourseInstances.Add(courseinstance);
                }
                else
                {
                    Console.WriteLine("Instance Already exists in DB, skipping...");
                    courseinstancesskipped++;
                }
                #endregion

            }

            _db.SaveChanges();

            msg = $"{coursesaddedcount} courses were added to the database. " +
                $"\n{coursesskipped} duplicate courses were not added." +
                $"\n{courseinstancesaddedcount} course instances were added to the database. " +
                $"\n{courseinstancesskipped} were duplicates and skipped. See changelist below of entities that were added.";
            
            var DTO = new ChangeListDTO { 
                message = msg,
                courseInstance = addedCourseInstances,
                courses = addedCourses
            };
            

            return DTO;
        }


    }
}
