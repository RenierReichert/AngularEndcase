using CoursesDBProject.Entities;
using System.Text;

namespace CoursesDBProject.Shared
{
    public class Parsers
    {

        public static List<CourseInstance> ParseCoursesFromFile(List<string> lines)
        {
            List<CourseInstance> instances = new List<CourseInstance>();

            //Self-explanatory
            for (int i = 0; i < lines.Count; i += 5)
            {

                string titel = lines[i].Split(": ")[1];
                string cursuscode = lines[i + 1].Split(':')[1].Trim();
                int duur = int.Parse(lines[i + 2].Split(' ')[1]);

                //Pretty date
                DateTime startdatum = DateTime.Parse
                    (
                    lines[i + 3].Split(':')[1]
                    );

                // Put values in a course object
                Course course = new Course
                {
                    titel = titel,
                    code = cursuscode,
                    duur = duur,
                };

                //Generate an instance of the Course as well since we were given a start date
                CourseInstance CI = new CourseInstance
                {
                    course = course,
                    startdatum = startdatum
                };


                // Add the object to the list of courses
                instances.Add( CI );
            }



            return instances;
        }


        public static List<string> ReadAsList(IFormFile file)
        {
            var result = new List<string>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.Add(reader.ReadLine());
                }
            }
            return result;
        }
    }
}
