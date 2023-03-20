using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesDBProject.Entities
{
    public class CourseInstance
    {
        [Key]
        public int id { get; set; }

        public Course course { get; set; }

        public DateTime startdatum { get; set; }


    }
}
