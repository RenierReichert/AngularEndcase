using CoursesDBProject.Entities;


namespace CoursesDBProject.DTOs
{
    public class ChangeListDTO
    {
        public string message;

        public List<CourseInstance> courseInstance;

        public List<Course> courses;
    }
}
