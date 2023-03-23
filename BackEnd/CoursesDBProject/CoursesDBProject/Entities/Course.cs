using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace CoursesDBProject.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public int duur { get; set; }

        [MaxLength(200)]
        public string titel { get; set; }

        [MaxLength(10)]
        public string code { get; set; }
    }
}
