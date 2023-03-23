using CoursesDBProject.Entities;
using System.Text;
using System.Text.RegularExpressions;

namespace CoursesDBProject.Shared
{
    public class Parsers
    {

        public static List<CourseInstance> ParseCoursesFromFile(List<string> lines)
        {
            List<CourseInstance> instances = new List<CourseInstance>();
            CourseInstance CI;
            string dateString;

            // This says: start, one or more digits, a /, one or more digis, a /, 4 digits, end.
            Regex regex = new Regex(@"^\d+\/\d+\/\d{4}$");
            DateTime startdatum;

            //Self-explanatory
            for (int i = 0; i < lines.Count; i += 5)
            {
                try
                {
                    string titel = lines[i].Split(": ")[1];
                    if(titel.Length > 300)
                    {
                        throw new Exception();
                    }

                    string cursuscode = lines[i + 1].Split(':')[1].Trim();
                    if (cursuscode.Length > 10)
                    {
                        i++;
                        throw new Exception();
                    }

                    int duur = int.Parse(lines[i + 2].Split(' ')[1]);

                    //I could check if this value is EXACTLY '# dagen', not followeed by more words, but who cares.
                    if (duur > 5 || lines[i + 2].Split(' ')[2] != "dagen")
                    {
                        i += 2;
                        throw new Exception();
                    }

                    dateString = lines[i + 3].Split(':')[1].Trim();
                    if (regex.IsMatch(dateString))
                    {

                        //Pretty date
                        startdatum = DateTime.Parse
                            (
                            lines[i + 3].Split(':')[1]
                            );
                    }
                    else
                    {
                        i += 3;
                        throw new Exception();
                    }

                    // Put values in a course object
                    Course course = new Course
                    {
                        titel = titel,
                        code = cursuscode,
                        duur = duur,
                    };

                    //Generate an instance of the Course as well since we were given a start date
                    CI = new CourseInstance
                    {
                        course = course,
                        startdatum = startdatum
                    };
                }
                catch(Exception e)
                { 
                    Console.WriteLine(e.ToString());
                    throw new MyException($"Something went wrong on. Exception on line: {i} of the inputfile.\n");
                }


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

        // VS generated this for me
        [Serializable]
        public class MyException : Exception
        {
            public MyException() { }
            public MyException(string message) : base(message) { }
            public MyException(string message, Exception inner) : base(message, inner) { }
            protected MyException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
